
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using BinarySearchTreeChecker.Models;

namespace BinarySearchTreeCheckerTests
{
    public class TestFactory
    {
        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[] { "name", "Bill" },
                new object[] { "name", "Paul" },
                new object[] { "name", "Steve" }

            };
        }

        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };
            return qs;
        }

        //convert this to JSON body with branch tree.
        internal static DefaultHttpRequest CreateHttpRequest(BinaryTree binaryTree)
        {
            var json = JsonConvert.SerializeObject(binaryTree);

            byte[] byteArray = Encoding.ASCII.GetBytes(json);
            MemoryStream stream = new MemoryStream(byteArray);

            var request = new DefaultHttpRequest(new DefaultHttpContext()) {

                Method = "post",
                ContentType = "application/json",
                Body = stream
            };

            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}
