using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Entities.Classes
{
    public class BusinessClass : Class
    {
        public BusinessClass(int totalSeats, decimal priceSeat, int reservedSeats) : base(totalSeats, priceSeat, reservedSeats)
        {
        }
    }
}
