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
    public class JsonFileUserHandler : JsonFileHandler<User>
    {
        public JsonFileUserHandler(string filePath) : base(filePath)
        {
        }

        public void UpdateUser(User user)
        {
            string jsonUserString = JsonConvert.SerializeObject(user);
            string tempFile = Path.GetTempFileName();
            string line;
            User tempUser;

            using (var fileReader = OpenReader())
            using (var tempFileWriter = new StreamWriter(tempFile))
            {
                while ((line = fileReader.ReadLine()) != null)
                {
                    tempUser = JsonConvert.DeserializeObject<User>(line);
                    tempFileWriter.WriteLine(tempUser.Id == user.Id ? jsonUserString : line);
                }
            }
            File.Delete(FilePath);
            File.Move(tempFile, FilePath);
        }
    }
}
