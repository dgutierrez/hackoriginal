using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Original.OpenBank.Service.Model;

namespace Original.OpenBank.Service.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {

        [HttpGet("authenticate")]
        public async Task<string> Authentication()
        {
            var client = new HttpClient();

            return await client.GetStringAsync($"https://sb-autenticacao-api.original.com.br/OriginalConnect/?scopes=account&callback_url=http://localhost:5000/api/authentication/callback&callback_id=1&developer_key=28f955c90b3a2940134ff1a970050f569a87facf");;
        }

        [HttpGet("callback")]
        public async Task Callback()
        {
            var uid = HttpContext.Request.Query["uid"].ToString();
            var authCode = HttpContext.Request.Query["auth_code"].ToString();

            var jsonBody = JsonConvert.SerializeObject ( new { 
                uid = uid,
                auth_code = authCode,
                developer_key = LiveData.DeveloperKey,
                secret_key = LiveData.SecreteKey
            });

            var client = new HttpClient();
            var response = await client.PostAsync("https://sb-autenticacao-api.original.com.br/OriginalConnect/AccessTokenController", new StringContent(jsonBody, Encoding.UTF8, "application/json") );

            LiveData.Token = JsonConvert.DeserializeObject<AcessTokenResponse>(await response.Content.ReadAsStringAsync()).access_token;
        }
    }
}


//https://sb-autenticacao-api.original.com.br/OriginalConnect/?scopes=account&callback_url=http://localhost:5000/api/authentication/callback&callback_id=1&developer_key=28f955c90b3a2940134ff1a970050f569a87facf