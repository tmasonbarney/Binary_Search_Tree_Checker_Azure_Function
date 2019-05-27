using System;
using System.IO;
using System.Threading.Tasks;
using BinarySearchTreeChecker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BinarySearchTreeChecker
{
    public static class BinarySearchTreeChecker
    {
        [FunctionName("BinarySearchTreeChecker")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var branchTree = JsonConvert.DeserializeObject<BinaryTree>(requestBody);
           

            return new OkObjectResult(branchTree.Info);
        }
    }
}
