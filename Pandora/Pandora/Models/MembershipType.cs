using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandora.Models
{
    public class MembershipType
    {

        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DuartionInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}