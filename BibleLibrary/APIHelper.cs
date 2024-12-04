using BibleLibrary.Models;
using System.Text.Json;

namespace BibleLibrary
{
    public class APIHelper
    {
        private static readonly string apiUrl = "https://api.esv.org/v3/passage/text/";
        private static readonly string apiKey = "Token 49f93ef8e952337f2eecd82e18749fe72d5605ca"; // Replace with your actual API key

        public async Task<ApiResponse> GetVerses(string book, string chapter, string verse)
        {
            var endpoint = $"{apiUrl}?q={book}+{chapter}:{verse}";

            return await SendGetRequest(endpoint);
        }
        public async Task<ApiResponse> GetVerses(string book, string chapterWithVerse)
        {
            if (String.IsNullOrEmpty(book) || string.IsNullOrEmpty(chapterWithVerse))
            {
                return new ApiResponse();
            }

            var endpoint = $"{apiUrl}?q={book}+{chapterWithVerse}";

            return await SendGetRequest(endpoint);
        }

        public async Task<ApiResponse> GetVerses(string[] bookChapterWithVerses)
        {
            var endpoint = $"{apiUrl}?q={string.Join(";", bookChapterWithVerses)}";

            return await SendGetRequest(endpoint);
        }



        public async Task<ApiResponse> SendGetRequest(string endpoint)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Add the API key to the request header
                    client.DefaultRequestHeaders.Add("Authorization", apiKey);

                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync(endpoint);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string reponse = await response.Content.ReadAsStringAsync();
                        ApiResponse responseJson = JsonSerializer.Deserialize<ApiResponse>(reponse);
                        Console.WriteLine($"Response:\n {responseJson.Display()}");
                        return responseJson;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        return new();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return new();
            }
        }
    }
}

