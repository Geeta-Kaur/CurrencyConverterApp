using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConverterAPI.Domain.Read{

    public interface IAuditReader{
        public Task<List<Audit>> GetAllAsync();
        public Task<List<Audit>> GetAuditsAsync(DateTime fromDate, DateTime ToDate);
    }
}