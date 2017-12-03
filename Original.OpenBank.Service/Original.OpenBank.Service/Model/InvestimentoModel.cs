using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Original.OpenBank.Service.Model
{
    public class InvestimentoModel
    {
        public string asset_name { get; set; }
        public string benchmark_class { get; set; }
        public string gross_value { get; set; }
        public string net_value { get; set; }
        public string income_tax_value { get; set; }
        public string iof_tax_value { get; set; }
    }
}
