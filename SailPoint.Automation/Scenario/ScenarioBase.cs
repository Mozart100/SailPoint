﻿//using NetBet.Converters;
using System.Net.Http.Json;
using System.Text.Json;

namespace SailPoint.Automation.Scenario
{
    public class ScenarioConfig
    {
        public int NumberEmptyLines { get; set; } = 2;
    }
    public abstract class ScenarioBase
    {
        //private readonly DateOnlyJsonConverter _dateOnlyConverter;

        public ScenarioBase(string baseUrl)
        {
            BaseUrl = baseUrl;
            Config = new ScenarioConfig();

            //_dateOnlyConverter = new DateOnlyJsonConverter();
        }

        public string BaseUrl { get; }

        protected ScenarioConfig Config { get; }

        public abstract string ScenarioName { get; }
        public abstract string Description { get; }


        protected virtual Task Setup()
        {
            return Task.FromResult(true);
        }

        protected virtual Task PostRun()
        {
            return Task.FromResult(true);
        }


        protected abstract Task RunScenario();

        protected void DisplayEmptyLines()
        {
            var loop = Config.NumberEmptyLines;
            while(loop -- > 0)
            {
                Console.WriteLine();
            }
        }


        public async Task StartRunScenario()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine($" ------------------------{ScenarioName}----------------------------");
            Console.WriteLine($" ------------------------{ScenarioName}----------------------------");
            Console.WriteLine($" ------------------------{ScenarioName}----------------------------");
            Console.WriteLine($" ------------------------{ScenarioName}----------------------------");

            DisplayEmptyLines();

            Console.WriteLine($"This scenario main purpose: {Description}");

            DisplayEmptyLines();


            Console.WriteLine($"Setup of {ScenarioName} started.");
            await Setup();
            Console.WriteLine($"Setup of {ScenarioName} ended succeffully.");

            DisplayEmptyLines();


            Console.WriteLine($"Valid scenarios: {ScenarioName} base url = {BaseUrl} started.");
            await RunScenario();
            Console.WriteLine($"Valid scenarios: {ScenarioName} finished successfully.");


            Console.WriteLine($"Post run of {ScenarioName} started.");
            await PostRun();
            Console.WriteLine($"Post run of {ScenarioName} ended succeffully.");
        }

        protected async Task<TDto> Get<TDto>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadFromJsonAsync<TDto>();

                    return res;
                }

                throw new Exception("Server failed.");
            }
        }
        protected async Task<TResponse> DeleteCommand<TResponse>(string url) where TResponse : class
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var responseData = JsonSerializer.Deserialize<TResponse>(responseContent, options);
                    return responseData;
                }

                throw new Exception($"Failed to perform DELETE request to {url}");
            }

        }

        protected async Task<TResponse> RunPostCommand<TRequest, TResponse>(string url, TRequest request) where TRequest : class
        {
            return await RunPutOrPostCommand<TRequest, TResponse>(url, request, true);

        }

        protected async Task<TResponse> RunPutCommand<TRequest, TResponse>(string url, TRequest request) where TRequest : class
        {

            return await RunPutOrPostCommand<TRequest, TResponse>(url, request, false);
        }


        private async Task<TResponse> RunPutOrPostCommand<TRequest, TResponse>(string url, TRequest request, bool isPostRequest = true)
        {
            using (HttpClient client = new HttpClient())
            {
                var sendOptions = new JsonSerializerOptions();
                //sendOptions.Converters.Add(_dateOnlyConverter);

                var content = new StringContent(JsonSerializer.Serialize(request, sendOptions), System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                if (isPostRequest)
                {
                    response = await client.PostAsync(url, content);
                }
                else
                {
                    response = await client.PutAsync(url, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var recieveOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    //recieveOptions.Converters.Add(_dateOnlyConverter);

                    var responseData = JsonSerializer.Deserialize<TResponse>(responseContent, recieveOptions);
                    return responseData;
                }

                throw new Exception($"Failed Populate in {url}");
            }
        }

        //protected async Task<TResponse> RunPostCommand<TRequest, TResponse>(string url, TRequest request, bool isPostRequest = true) where TRequest : class
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var sendOptions = new JsonSerializerOptions();
        //        sendOptions.Converters.Add(_dateOnlyConverter);

        //        var content = new StringContent(JsonSerializer.Serialize(request, sendOptions), System.Text.Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = null;

        //        if (isPostRequest)
        //        {
        //            response = await client.PostAsync(url, content);
        //        }
        //        else
        //        {
        //            response = await client.PutAsync(url, content);
        //        }

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string responseContent = await response.Content.ReadAsStringAsync();
        //            var recieveOptions = new JsonSerializerOptions
        //            {
        //                PropertyNameCaseInsensitive = true
        //            };
        //            recieveOptions.Converters.Add(_dateOnlyConverter);

        //            var responseData = JsonSerializer.Deserialize<TResponse>(responseContent, recieveOptions);
        //            return responseData;
        //        }

        //        throw new Exception($"Failed Populate in {url}");
        //    }
        //}

    }
}
