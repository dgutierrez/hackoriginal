using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Original.OpenBank.Service.Model
{
    public class FundosModel
    {
        public string transaction_type { get; set; }
        public string asset_name { get; set; }
        public string transaction_date { get; set; }
        public string quota_conversion_date { get; set; }
        public string gross_value { get; set; }
        public string net_value { get; set; }
        public string quota_quantity { get; set; }
        public string quota_value { get; set; }
        public string income_tax_value { get; set; }
        public string iof_tax_value { get; set; }
    }
}
