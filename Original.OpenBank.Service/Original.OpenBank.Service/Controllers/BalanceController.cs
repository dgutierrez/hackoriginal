using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Original.OpenBank.Service.Model;

namespace Original.OpenBank.Service.Controllers
{
    [Route("api/balance")]
    public class BalanceController
    {
        public BalanceController()
        {
        }

        [HttpGet("history/{dateFrom}/{dateTo}")]
        public async Task<List<HistoryBalanceResponse>> GetHistory([FromRoute]string dateFrom, [FromRoute]string dateTo)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", LiveData.Token);
            client.DefaultRequestHeaders.Add("developer-key", LiveData.DeveloperKey);

            return JsonConvert.DeserializeObject<List<HistoryBalanceResponse>>((await (await client.GetAsync($"https://sandbox.original.com.br/accounts/v1/transaction-history?dateFrom={dateTo}&dateTo={dateFrom}")).Content.ReadAsStringAsync()));
        }


    }
}
