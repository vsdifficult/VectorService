using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vectors
{
    public class BertClient
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<float[]> GetBertVectorAsync(string text)
        {
            var json = JsonConvert.SerializeObject(new { text });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5000/embed", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(responseString);

            return result.vector.ToObject<float[]>();
        }
    } 
}