using System;
using System.IO;
using Newtonsoft.Json;

namespace ConverterAPI.Domain
{
    public class Audit {
        public Audit(string message, DateTime logDate)
        {
            LogMessage = message;
            LogDate = logDate;
        }
      
      public string LogMessage{ get; set;}
      public DateTime LogDate {get;  set;}

      public void Save(){

          //Commit changes to repo.
          string deserialiseData = System.IO.File.ReadAllText(@"log/audit.txt");
          string jsonData = JsonConvert.SerializeObject(this, Formatting.None);
          System.IO.File.WriteAllText(@"log/audit.txt", deserialiseData + "\n" +jsonData);
      }
    }
}
