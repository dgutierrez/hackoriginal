using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Original.OpenBank.Application.Models;
using System.Net;

namespace Original.OpenBank.Application.Controllers
{
    public class SaldoController : Controller
    {
        public IActionResult Index()
        {
            WebClient client = new System.Net.WebClient();
            client.Headers.Add("Authorization", LiveData.Token);
            var saldo = Newtonsoft.Json.JsonConvert.DeserializeObject<SaldoModel>(client.DownloadString("http://localhost:55556/api/balance/saldo"));

            return View(saldo);
        }
    }
}