using RestSharp;
using System.Text.Json;
using WebDevPortRn.Models;
using WebDevDAL.APOD;

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

            try
            {

                request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");

                var response = client.ExecuteGet(request);

                if(response.StatusCode == System.Net.HttpStatusCode.OK) 
                {
                    return JsonSerializer.Deserialize<GetPhotoModel>(response.Content);                 
                }
                else
                {
                    throw new Exception($"Status: {response.StatusCode} | Error: {response.ErrorMessage} | Exception: {response.ErrorException?.Message}");
                }        

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GetPhotoModel> GetPhotoByPeriod(DateTime initialDate, DateTime finalDate)
        {

            var client = new RestClient();
            var request = new RestRequest($"https://api.nasa.gov/planetary/apod?api_key={_NASA_API_KEY}&start_date={initialDate.ToString("yyyy-MM-dd")}&end_date={finalDate.ToString("yyyy-MM-dd")}", Method.Get);
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");

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

        public string CreatePhoto(GetPhotoModel record)
        {
            ApodDal ApodDal_Service = new ApodDal();

            ApodDal_Service.Create(
                record.copyright, record.date, 
                record.explanation, record.hdurl, 
                record.media_type, record.service_version, 
                record.title, record.url
            );

            return string.Empty;

        }   

    }
}
