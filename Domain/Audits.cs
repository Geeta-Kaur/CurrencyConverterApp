using System;

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
      }
    }
}
