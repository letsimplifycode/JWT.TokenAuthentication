using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.TokenAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthController : ControllerBase
    {
        public class Month
        {
            public string ShortName { get; set; }
            public string FullName { get; set; }
        }

        [HttpGet,Authorize]
        public IEnumerable<Month> Get()
        {
            var months = new Month[]
            {
                new Month(){ShortName ="Jan", FullName ="January"},
                new Month() {ShortName="Feb", FullName= "February"}
            };
            return months;
        }
    }
}
