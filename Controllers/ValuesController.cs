using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get(string query)
        {
            string url = "https://api.wit.ai/message?q= "+ query; // sample url
            string a = "Bearer " + "Q4RKYGRYITQSLDZGPJ4B4VCRMOKTTHKE";
          /*  string[] name = {"Abhishekism9450", "Shubho666"};
            string[,] reposi = new string[2, 2]{ { "test-node-js", "Sentiment-Analysis" },{ "tmdb", "tmdb2" }}; */
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", a);
                var b = client.GetStringAsync(url).Result;
                dynamic json = JsonConvert.DeserializeObject(b);
                var str = JsonConvert.SerializeObject(json.entities);
                var p = str.Split(new string[] { "\"" }, StringSplitOptions.None);
                Console.WriteLine(p[1]);
                switch (p[1])
                {
                    case "create_repo":
                        
                        var client_ = new RestClient("https://api.github.com/user/repos");
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("cache-control", "no-cache");
                        request.AddHeader("Connection", "keep-alive");
                        request.AddHeader("Accept-Encoding", "gzip, deflate");
                        request.AddHeader("Host", "api.github.com");
                        request.AddHeader("Postman-Token", "d3056e59-d436-44b2-b04b-1bc8105d3cf2,8c6331ee-79d0-419d-a960-e69fcfe0814a");
                        request.AddHeader("Cache-Control", "no-cache");
                        request.AddHeader("Accept", "/application/vnd.github.shadow-cat-preview+json");
                        request.AddHeader("User-Agent", "PostmanRuntime/7.17.1");
                        request.AddHeader("Authorization", "Bearer 282de0d755e499919a08d835f45cb742b32fc10b");
                        request.AddJsonBody(new { name = "Alexa" });
                        IRestResponse response = client_.Execute(request);
                        return response.Content;
                        break;

                    case "issue":
                        var clientss = new RestClient("https://api.github.com/repos/Abhishekism9450/test-node-js/issue");
                        var requestss = new RestRequest(Method.POST);
                        requestss.AddHeader("cache-control", "no-cache");
                        requestss.AddHeader("Connection", "keep-alive");
                        requestss.AddHeader("Accept-Encoding", "gzip, deflate");
                        requestss.AddHeader("Host", "api.github.com");
                        requestss.AddHeader("Postman-Token", "d3056e59-d436-44b2-b04b-1bc8105d3cf2,8c6331ee-79d0-419d-a960-e69fcfe0814a");
                        requestss.AddHeader("Cache-Control", "no-cache");
                        requestss.AddHeader("Accept", "/application/vnd.github.shadow-cat-preview+json");
                        requestss.AddHeader("User-Agent", "PostmanRuntime/7.17.1");
                        requestss.AddHeader("Authorization", "Bearer 282de0d755e499919a08d835f45cb742b32fc10b");
                        requestss.AddJsonBody(new { name = "BotExample" });
                        requestss.AddJsonBody(new { title = "foo"}); //for issue it is required.

                        IRestResponse responsess = clientss.Execute(requestss);
                        return responsess.Content;
                        break;

                    case "fork":
                        var clients = new RestClient("https://api.github.com/repos/Abhishekism9450/test-node-js/issue");
                        var requests = new RestRequest(Method.POST);
                        requests.AddHeader("cache-control", "no-cache");
                        requests.AddHeader("Connection", "keep-alive");
                        requests.AddHeader("Accept-Encoding", "gzip, deflate");
                        requests.AddHeader("Host", "api.github.com");
                        requests.AddHeader("Postman-Token", "d3056e59-d436-44b2-b04b-1bc8105d3cf2,8c6331ee-79d0-419d-a960-e69fcfe0814a");
                        requests.AddHeader("Cache-Control", "no-cache");
                        requests.AddHeader("Accept", "/application/vnd.github.shadow-cat-preview+json");
                        requests.AddHeader("User-Agent", "PostmanRuntime/7.17.1");
                        requests.AddHeader("Authorization", "Bearer 282de0d755e499919a08d835f45cb742b32fc10b");
                        IRestResponse responses = clients.Execute(requests);
                        return responses.Content;
                        break;

                    default:
                        Console.WriteLine("No oooooooooooooooooooooooo");
                        break;

                }
 
            }
            return "Okay";

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
