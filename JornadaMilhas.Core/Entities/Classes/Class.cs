using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Entities.Classes
{
    public abstract class Class

    {
        
        public int TotalSeats { get; protected set; }

        public decimal PriceSeat { get; protected set; }

        public int ReservedSeats { get; protected set; }

        public bool SeatAvailable(int quantity)
        {
            return TotalSeats - ReservedSeats >= quantity;
        }

        public virtual decimal CalculatePrice(int quantity)
        {
            return quantity * PriceSeat;
        }

        protected Class(int totalSeats, decimal priceSeat, int reservedSeats)
        {
            TotalSeats = totalSeats;
            PriceSeat = priceSeat;
            ReservedSeats = reservedSeats;
        }
    }
}
