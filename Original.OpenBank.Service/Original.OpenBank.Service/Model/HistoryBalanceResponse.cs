using System;
namespace Original.OpenBank.Service.Model
{
    public class HistoryBalanceResponse
    {
        public HistoryBalanceResponse()
        {
        }

        public string transaction_amount
        {
            get;
            set;
        }

        public decimal TransacionAmountDecimal
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public string date
        {
            get;
            set;
        }

        public DateTime DateDateTime
        {
            get;
            set;
        }

        public string transaction_type
        {
            get;
            set;
        }

        public string comments
        {
            get;
            set;
        }
    }
}
