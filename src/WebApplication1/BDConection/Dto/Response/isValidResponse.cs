using BDConection.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDConection.Dto.Response
{
    public class isValidResponse : BasicResponse
    {
        public User UserInfo { get; set; }
    }
}
