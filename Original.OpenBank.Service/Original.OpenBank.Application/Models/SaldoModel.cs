using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Original.OpenBank.Application.Models
{
    public class SaldoModel
    {
        public string current_balance { get; set; }
        public string available_limit { get; set; }
        public string current_limit { get; set; }
    }
}
