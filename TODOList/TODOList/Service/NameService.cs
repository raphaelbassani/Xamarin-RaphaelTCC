using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TODOList.Model;

namespace TODOList.Service
{
    public class NameService : INameService
    {
        string BaseURL = "https://randomuser.me/api/?inc=name&noinfo";
        public async Task<Name> getName()
        {
            string url = BaseURL;
            HttpClient client = new HttpClient();
            //HttpResponseMessage responseMessage = await client.GetAsync(url);
            string result = await client.GetStringAsync(url);

            Console.WriteLine(result);

            var resultObject = JObject.Parse(result);
            string firstName = resultObject["results"][0]["name"]["first"].ToString();

            //if(responseMessage.IsSuccessStatusCode)
            //{
            //    var result = await responseMessage.Content.ReadAsStringAsync();
            //    var json = JsonConvert.DeserializeObject<NameStat>(result);

            //    return json;
            //}

            Name name = new Name(firstName);

            return name;
        }
    }
}
