using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDConection.Dto.Common
{
    public class User
    {
        public int Userid { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime InsertDate { get; set; }
        public Decimal Salary { get; set; }
        public Decimal BreakFast { get; set; }
        public Decimal Savings { get; set; }
        public bool isActive { get; set; }
        public int Roleid { get; set; }
        public string Password { get; set; }
        public string UserLogin { get; set; }
    }
}
