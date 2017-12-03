using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Original.OpenBank.Service.Model
{
    public class RendaFixaModel
    {
        public string transaction_type { get; set; }
		public string asset_name { get; set; }
        public string certificate_number { get; set; }
        public string transaction_date { get; set; }
        public string investment_date { get; set; }
        public string gross_value { get; set; }
        public string net_value { get; set; }
        public string iof_tax_value { get; set; }
        public string income_tax_value { get; set; }
        public string lock_up_period { get; set; }
        public string liquidity { get; set; }
        public string maturity_date { get; set; }
        public string contracts_quantity { get; set; }
        public string fixed_income_index { get; set; }
    }
}
