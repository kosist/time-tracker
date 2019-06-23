using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FileLayer.JsonFileRepositories.JsonFileHelpers
{
    public class JsonFileHandler<TObj> where TObj : class
    {
        protected string FilePath;
        public JsonFileHandler(string filePath)
        {
            FilePath = filePath;
            //TODO - add handling of not valid path, etc.
        }

        #region PublicHelperMethods
        public TObj GetObjectById(int id)
        {
            IEnumerable<TObj> records = GetAllObjects();
            return records.ElementAt(id);
        }

        public IEnumerable<TObj> GetAllObjects()
        {
            string line;
            var records = new List<TObj>();
            var fileReader = OpenReader();

            using (fileReader)
            {
                while ((line = fileReader.ReadLine()) != null)
                {
                    records.Add(JsonConvert.DeserializeObject<TObj>(line));
                }
            }
            return records;
        }

        public void AddObject(TObj obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            var fileWriter = OpenWriter();

            using (fileWriter)
            {
                fileWriter.WriteLine(json);
                fileWriter.Flush();
            }
        }

        public void RemoveObject(TObj obj)
        {
            string tempFile = Path.GetTempFileName();
            string line;
            string json = JsonConvert.SerializeObject(obj);

            using (var fileReader = OpenReader())
            using (var tempFileWriter = new StreamWriter(tempFile))
            {
                while ((line = fileReader.ReadLine()) != null)
                {
                    if (line != json)
                        tempFileWriter.WriteLine(line);
                }
            }
            File.Delete(FilePath);
            File.Move(tempFile, FilePath);
        }

        public void DisposeFile()
        {
            File.Delete(FilePath);
        }

        #endregion

        #region ProtectedMethods
        protected StreamReader OpenReader()
        {
            var file = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            StreamReader fileReader = new StreamReader(file);
            return fileReader;
        }
        protected StreamWriter OpenWriter()
        {
            var file = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.None);
            StreamWriter fileWriter = new StreamWriter(file);
            return fileWriter;
        } 
        #endregion

    }
}
