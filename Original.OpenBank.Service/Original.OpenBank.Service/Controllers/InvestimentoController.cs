using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Original.OpenBank.Service.Model;

namespace Original.OpenBank.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Investimento")]
    public class InvestimentoController : BaseController
    {

        public InvestimentoController()
        {

        }

        public InvestimentoController(string token):base(token)
        {

        }

        [HttpGet("teminvestimento")]
        public async Task<bool> TemInvestimento()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", base.GetToken());
            client.DefaultRequestHeaders.Add("developer-key", LiveData.DeveloperKey);

            var saida = JsonConvert.DeserializeObject<List<InvestimentoModel>>((await (await client.GetAsync($"https://sandbox.original.com.br/investments/v1/portfolio-summary")).Content.ReadAsStringAsync()));

            return saida.Count > 0;
        }

        [HttpGet("evolucaoinvestimento/{dateFrom}/{dateTo}")]
        public async Task<int> EvolucaoInvestimento([FromRoute]string dateFrom, [FromRoute]string dateTo)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", LiveData.Token);
            client.DefaultRequestHeaders.Add("developer-key", LiveData.DeveloperKey);

            var saidaFundos = JsonConvert.DeserializeObject<List<FundosModel>>((await (await client.GetAsync($"https://sandbox.original.com.br/investments/v1/funds/transaction-history?date_from={dateFrom}&date_to={dateTo}")).Content.ReadAsStringAsync()));
            var saidaRenda = JsonConvert.DeserializeObject<List<RendaFixaModel>>((await (await client.GetAsync($"https://sandbox.original.com.br/investments/v1/fixed-income/transaction-history?date_from={dateFrom}&date_to={dateTo}")).Content.ReadAsStringAsync()));

            int totalRegasteF = saidaFundos.FindAll(x => x.transaction_type.Contains("Resgate")).Count;
            int totalAplicacaoF = saidaFundos.FindAll(x => x.transaction_type.Contains("Aplicacao")).Count;

            int totalRegasteR = saidaRenda.FindAll(x => x.transaction_type.Contains("Resgate")).Count;
            int totalAplicacaoR = saidaRenda.FindAll(x => x.transaction_type.Contains("Aplicacao")).Count;

            int total = (totalAplicacaoF + totalAplicacaoR) - (totalRegasteF + totalRegasteR);

            return total > 0 ? 1 : total == 0 ? 0 : -1;
        }
    }
}