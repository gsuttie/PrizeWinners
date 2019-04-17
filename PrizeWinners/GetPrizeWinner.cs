using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace PrizeWinners
{
    public static class GetPrizeWinner
    {
        [FunctionName("GetPrizeWinner")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var random = new Random();

            var list = new List<string> { "name1", "name2", "name3" };

            int index = random.Next(list.Count);
            var name = list[index];

            return name == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please try again.")
                : req.CreateResponse(HttpStatusCode.OK, "The magic 8 ball has chosen. Congratulations goes to " + name + " you have won a prize!");
        }
    }
}


