using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLayer.DataModels;
using Newtonsoft.Json;

namespace FileLayer.JsonFileRepositories.JsonFileHelpers
{
    public class JsonFileTimeRecordHandler : JsonFileHandler<TimeRecord>
    {
        public JsonFileTimeRecordHandler(string filePath) : base(filePath)
        {
        }

        public void UpdateTimeRecord(TimeRecord timeRecord)
        {
            string jsonRecordString = JsonConvert.SerializeObject(timeRecord);
            string tempFile = Path.GetTempFileName();
            string line;
            TimeRecord tempTimeRecord;

            using (var fileReader = OpenReader())
            using (var tempFileWriter = new StreamWriter(tempFile))
            {
                while ((line = fileReader.ReadLine()) != null)
                {
                    tempTimeRecord = JsonConvert.DeserializeObject<TimeRecord>(line);
                    tempFileWriter.WriteLine(tempTimeRecord.Id == timeRecord.Id ? jsonRecordString : line);
                }
            }
            File.Delete(FilePath);
            File.Move(tempFile, FilePath);
        }
    }
}
