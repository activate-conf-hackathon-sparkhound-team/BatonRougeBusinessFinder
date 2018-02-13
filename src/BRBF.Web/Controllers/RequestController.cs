using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRBF.Core.Framework.RequestPipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BatonRougeBusinessFinder.Web.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class RequestController : Controller
    {
        public IRequestRunner RequestRunner { get; }

        public RequestController(IRequestRunner requestRunner)
        {
            RequestRunner = requestRunner;
        }

        [HttpGet("{queryName}")]
        public ActionResult ExecuteQuery(string queryName)
        {
            JObject requestJson = new JObject();
            foreach (var q in HttpContext.Request.Query)
            {
                requestJson.Add(q.Key, q.Value.FirstOrDefault());
            }
            var request = requestJson?.ToString();
            var response = RequestRunner.Execute(queryName, request);
            return Json(response);
        }

        [HttpPost("{commandName}")]
        public ActionResult ExecuteCommand(string commandName, [FromBody] JObject requestJson)
        {
            var request = requestJson?.ToString();
            var response = RequestRunner.Execute(commandName, request);
            return Json(response);
        }
    }
}