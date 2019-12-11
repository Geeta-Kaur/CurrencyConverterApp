using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConverterAPI.Domain.Read{

    public class AuditReader : IAuditReader
    {
               
        public async Task<List<Audit>> GetAllAsync()
        {                     
           List<Audit> audits = new List<Audit>{new Audit("Rates checked from GBP to USD", DateTime.Now.AddDays(1)),
                                                new Audit( "Rates checked from GBP to USD", DateTime.Now.AddDays(2))};
            
            return await Task.Run(() => audits);
        }

        public async Task<List<Audit>> GetAuditsAsync(DateTime fromDate, DateTime ToDate)
        {            
            List<Audit> audits = new List<Audit>{new Audit("Rates checked from GBP to USD", DateTime.Now.AddDays(1)),
                                                new Audit( "Rates checked from GBP to USD", DateTime.Now.AddDays(2))};
            audits  = audits.Where(x => x.LogDate >= fromDate && x.LogDate <= ToDate).ToList();
            return await Task.Run(() => audits);
        }
    }
}