using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Passages.Enums;
using JornadaMilhas.Core.Entities.Planes;

namespace JornadaMilhas.Core.Entities.Classes
{
    public abstract class Class : BaseEntity
    {
        public int TotalSeats { get; protected set; }

        public decimal PriceSeat { get; protected set; }

        public int ReservedSeats { get; protected set; }

        public Plane Plane { get; private set; }

        public long PlaneId { get; private set; }

        public bool SeatAvailable(int quantity) => TotalSeats - ReservedSeats >= quantity;

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

        public void OccupedSeat(int quantity)
        {
            ReservedSeats += quantity;
        }
    }
}
