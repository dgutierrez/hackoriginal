using System;
namespace Original.OpenBank.Service.Model
{
    public class DataResponse
    {
        public DataResponse()
        {
        }

        public int total_transactions_last_month
        {
            get;
            set;
        }

        public int months_since_account_opened
        {
            get;
            set;
        }

        public int balance_trend
        {
            get;
            set;
        }
    }
}
