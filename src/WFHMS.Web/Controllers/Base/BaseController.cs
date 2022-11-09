using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WFHMS.Web.Controllers
{
    
    public class BaseController : Controller
    {

        private readonly IConfiguration _configure;
        private readonly string WFHMSBaseUrl;
        private readonly HttpClient _httpClient;
        public BaseController(IConfiguration configure, HttpClient httpClient)
        {
            _configure = configure;
            WFHMSBaseUrl = _configure.GetValue<string>("WFHMSBaseUrl");
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> DeleteAsync<T>(string requestURI)
        {
            _httpClient.BaseAddress = new Uri(WFHMSBaseUrl);
            var Response = await _httpClient.DeleteAsync(requestURI);
            return Response;
        }
        public async Task<HttpResponseMessage> PutAsync<T>(string requestURI, T entity)
        {
            _httpClient.BaseAddress = new Uri(WFHMSBaseUrl);
            var content = JsonConvert.SerializeObject(entity);
            return await _httpClient.PutAsync(requestURI, new StringContent(content, Encoding.UTF8, "application/json"));

        }
        public async Task<HttpResponseMessage> PostAsync<T>(T entity, string endpoint)
         {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            _httpClient.BaseAddress = new Uri(WFHMSBaseUrl);

            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
            return response;
        }
        public async Task<T> GetAsync<T>(string relativePath, string queryString = "")
        {
            var uriBuilder = new UriBuilder(WFHMSBaseUrl + relativePath);
            uriBuilder.Query = queryString;
            var response = await _httpClient.GetAsync(uriBuilder.Uri, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
          }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    
        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }
        //public IActionResult Index()
        //{
        //    return Redirect("~/Views/Department/AddDepartment.cshtml");
        //}
        //public IActionResult AddDepartment()
        //{
        //    return View();
        //}
    }
}
