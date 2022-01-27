using System.Net;
using System.Net.Http.Headers;

namespace Star_Wars_Api.Repository
{
    public class MainRepository
    {
        readonly string BaseAddress = "https://swapi.dev/api/";
        readonly string AcceptHeader = "application/json";

        protected HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeader));

            return client;
        }

        public async Task<T> GetEntity<T>(string url)
        {

            T result = default(T);

            using (HttpClient client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new System.Exception("We couldn't find what you were looking for");

                }
                else
                    response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsAsync<T>();
            }

            return result;
        }
    }
}
