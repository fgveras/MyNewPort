using RestSharp;
using System.Text.Json;
using WebDevPortRn.Models;

namespace WebDevPortRn.APOD
{
    public class ApodRn
    {

        private string _NASA_API_KEY = "gJuYoanCYeEpVJOYYnhmfqQqap1cHd7ajYIoOgUZ";
        private readonly HttpClient _httpClient;

        public ApodRn(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public GetPhotoModel GetPhoto()
        {

            var client = new RestClient();
            var request = new RestRequest($"https://api.nasa.gov/planetary/apod?api_key={_NASA_API_KEY}", Method.Get);

            var response = client.ExecuteGet(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                return JsonSerializer.Deserialize<GetPhotoModel>(response.Content);
                 
            }else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }        
        }

        public List<GetPhotoModel> GetPhotoByPeriod(DateTime initialDate, DateTime finalDate)
        {

            var client = new RestClient();
            var request = new RestRequest($"https://api.nasa.gov/planetary/apod?api_key={_NASA_API_KEY}&start_date={initialDate.ToString("yyyy-MM-dd")}&end_date={finalDate.ToString("yyyy-MM-dd")}", Method.Get);

            var response = client.ExecuteGet(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<List<GetPhotoModel>>(response.Content);

            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

    }
}
