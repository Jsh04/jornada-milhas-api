using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Entities.Classes
{
    public class EconomicClass : Class
    {
        public EconomicClass(int totalSeats, decimal priceSeat, int reservedSeats) : base(totalSeats, priceSeat, reservedSeats)
        {
            
        }
    }
}
