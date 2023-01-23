using Microsoft.Extensions.Configuration;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;
using System;
using System.Net.Http;

namespace PairingTest.Web.Implementations
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly IConfiguration _config;
        public QuestionnaireRepository(IConfiguration config)
        {
            _config = config;
        }

        public QuestionnaireViewModel GetQuestionnaire()
        {
            var questionnaireViewModel = new QuestionnaireViewModel();
            string apiUrl = _config["WebApiUrl"] + "/api/Questions";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    questionnaireViewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<QuestionnaireViewModel>(data);
                }
            }
            return questionnaireViewModel;
        }
    }
}
