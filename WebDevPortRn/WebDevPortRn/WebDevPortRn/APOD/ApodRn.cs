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

    }
}
