using System.IO;
using BaseLayer.DataModels;
using Newtonsoft.Json;

namespace FileLayer.JsonFileRepositories.JsonFileHelpers
{
    public class JsonFileUserReportHandler : JsonFileHandler<UserReport>
    {
        public JsonFileUserReportHandler(string filePath) : base(filePath)
        {
        }

        public void UpdateUserReport(UserReport userReportRecord)
        {
            string jsonUserReportString = JsonConvert.SerializeObject(userReportRecord);
            string tempFile = Path.GetTempFileName();
            string line;
            UserReport tempUserReport;

            using (var fileReader = OpenReader())
            using (var tempFileWriter = new StreamWriter(tempFile))
            {
                while ((line = fileReader.ReadLine()) != null)
                {
                    tempUserReport = JsonConvert.DeserializeObject<UserReport>(line);
                    tempFileWriter.WriteLine(tempUserReport.Id == userReportRecord.Id ? jsonUserReportString : line);
                }
            }
            File.Delete(FilePath);
            File.Move(tempFile, FilePath);
        }
    }
}