using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Original.OpenBank.Application.Models;
using Newtonsoft.Json;

namespace Original.OpenBank.Application.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            Response.Redirect("https://sb-autenticacao-api.original.com.br/OriginalConnect?scopes=account&callback_url=http://localhost:17973/home/callback?callback_id=1&developer_key=28f955c90b3a2940134ff1a970050f569a87facf");
        }

        public IActionResult callback()
        {
            var uid = HttpContext.Request.Query["uid"].ToString();
            var authCode = HttpContext.Request.Query["auth_code"].ToString();

            var jsonBody = JsonConvert.SerializeObject(new
            {
                uid = uid,
                auth_code = authCode,
                developer_key = LiveData.DeveloperKey,
                secret_key = LiveData.SecreteKey
            });

            var client = new System.Net.WebClient();
            var response = client.UploadString("https://sb-autenticacao-api.original.com.br/OriginalConnect/AccessTokenController", "POST", jsonBody);

            LiveData.Token = JsonConvert.DeserializeObject<AcessTokenResponse>(response).access_token;

            client = new System.Net.WebClient();
            client.DownloadString("");

            bool alerta = true;

            if (alerta)
                return View("Alerta");
            else
                return RedirectToAction("index", "Saldo");
        }
    }
}
