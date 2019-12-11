using System;
using System.Collections.Generic;
using ConverterAPI.Domain;
using ConverterAPI.Domain.Read;
using ConverterAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConverterAPI.Controllers{

    [ApiController]
    [Route("api/audit")]
    public class AuditController: ControllerBase
    {
        private readonly IAuditReader auditReader;
        public AuditController(IAuditReader _auditReader)
        {
            auditReader = _auditReader;
        }


        [HttpGet("searchinputmodel")]
        [Route("Report")]
        public ActionResult GetAuditsByDate([FromQuery] SearchInputModel searchInputModel)
        {
            List<Audit> result= new List<Audit>();
            if(!ValidInput(searchInputModel))
                return BadRequest("Invalid data");
            
            result = auditReader.GetAuditsAsync(searchInputModel.DateFrom,searchInputModel.DateTo).GetAwaiter().GetResult();
            
            if(result.Count==0)
                return NotFound("No results");

            return Ok(result);
        }
         private bool ValidInput(SearchInputModel input){
            if(input == null)
                return false;
            
            return true;
        }
    }
}