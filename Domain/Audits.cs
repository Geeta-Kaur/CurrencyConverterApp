using System;

namespace ConverterAPI.Domain
{
    public class Audit {
        public Audit(string message, DateTime logDate)
        {
            LogMessage = message;
            LogDate = logDate;
        }
      public string LogMessage{ get; private set;}
      public DateTime LogDate {get; private set;}
    }
}