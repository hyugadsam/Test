using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDConection.Dto.Common
{
    public class PaySheet
    {
        public int Paysheetid { get; set; }
        public int Userid { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public decimal Salary { get; set; }
        public decimal BreakFast { get; set; }
        public decimal Savings { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Deposit { get; set; }
    }
}
