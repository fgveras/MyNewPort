using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
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


        public async Task<GetPhotoModel> GetPhoto()
        {

            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            };

            var response = await _httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={_NASA_API_KEY}");
            
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<GetPhotoModel>(options);

            return data;
        }

        public async Task<List<GetPhotoModel>> GetPhotoByPeriod(DateTime initialDate, DateTime finalDate)
        {

            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            };

            var start_date = initialDate.ToString("yyyy-MM-dd");
            var end_date = finalDate.ToString("yyyy-MM-dd");

            var response = await _httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={_NASA_API_KEY}&start_date={start_date}&end_date={end_date}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<List<GetPhotoModel>>(options);

            return data;
        }

    }
}
