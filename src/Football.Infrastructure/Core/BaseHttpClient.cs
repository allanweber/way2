using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Football.Infrastructure.Core
{
    public class BaseHttpClient
    {
        private readonly HttpClient client;

        public BaseHttpClient(
            string baseAdrress,
            string path,
            List<KeyValuePair<string, string>> headers = null,
            string accept = "application/json")
        {
            this.BaseAdrress = baseAdrress;
            this.Path = path;
            this.Accept = accept;
            this.client = new HttpClient();

            this.client.BaseAddress = new Uri(this.BaseAdrress);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this.Accept));

            if (headers != null && headers.Count > 0)
                headers.ForEach(header =>
                {
                    this.client.DefaultRequestHeaders.Add(header.Key, header.Value);
                });
        }

        public string BaseAdrress { get; }
        public string Path { get; }
        public string Accept { get; }

        public async Task<HttpResponseMessage> Get()
        {
            return await this.client.GetAsync(this.Path);
        }
    }
}
