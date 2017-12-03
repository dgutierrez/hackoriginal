using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Original.OpenBank.Service.Model;

namespace Original.OpenBank.Service.Controllers
{
    [Route("api/data")]
    public class DataController
    {
        public DataController()
        {
        }

        [HttpGet]
        public async Task<DataResponse> GetData()
        {
            var balanceController = new BalanceController();
            var balanceHistory = await balanceController.GetHistory(DateTime.Today.AddYears(-6).ToString("yyyyMMdd"), DateTime.Today.ToString("yyyyMMdd"));

            if (balanceHistory == null)
                return null;

            foreach (var item in balanceHistory)
            {
                item.TransacionAmountDecimal = decimal.Parse(item.transaction_amount);
                item.DateDateTime = DateTime.ParseExact(item.date, "yyyyMMdd", CultureInfo.CurrentCulture);
            }

            var firstDate = balanceHistory.OrderBy(x => x.DateDateTime).First().DateDateTime;
            var lastMonthTransactions = balanceHistory.Where(x => x.DateDateTime > DateTime.Now.AddMonths(-1)).Count();

            var lastMonthBalance = balanceHistory.Where(x => x.DateDateTime > DateTime.Now.AddDays(-30)).Sum(x => x.TransacionAmountDecimal);
            var lastLastMonthBalance = balanceHistory.Where(x => x.DateDateTime > DateTime.Now.AddDays(-60) && x.DateDateTime <= DateTime.Now.AddDays(-30)).Sum(x => x.TransacionAmountDecimal);

            var balanceTrend = 0;
            if (lastMonthBalance > lastLastMonthBalance)
                balanceTrend = 1;
            else if (lastMonthBalance < lastLastMonthBalance)
                balanceTrend = -1;

            return new DataResponse { 
                total_transactions_last_month = lastMonthTransactions,
                months_since_account_opened = (int)DateTime.Now.Subtract(firstDate.Date).Days / 30,
                balance_trend = balanceTrend
            };
        }
    }
}
