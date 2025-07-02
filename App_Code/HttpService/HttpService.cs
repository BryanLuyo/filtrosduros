using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace infraestructura.servicio
{
    public static class HttpService
    {
        public static async Task<T> SendRequestAsync<T>(
         Uri url,
         HttpMethod httpMethod,
         IDictionary<string, string> headers = null,
         object requestData = null)
        {
            var result = default(T);

            // Default to GET
            var method = httpMethod ?? HttpMethod.Get;

            // Serialize request data
            var data = requestData == null
                ? null
                : JsonConvert.SerializeObject(requestData);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var request = new HttpRequestMessage(method, url))
            {
                // Add request data to request
                if (data != null)
                {
                    request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                }

                // Add headers to request
                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        request.Headers.Add(h.Key, h.Value);
                    }
                }

                // Get response
                var client = new HttpClient();
                var response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead).Result;
                var content = response.Content == null
                    ? null
                    : await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<T>(content);

                }
                else
                {
                    var _content = await response.Content.ReadAsStringAsync();
                    response.Dispose();
                    throw new HttpRequestException(response.StatusCode+": "+ _content+"");
                }
            }

            return result;
        }
    }
}
