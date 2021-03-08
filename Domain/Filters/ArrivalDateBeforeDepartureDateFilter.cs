using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Filters
{
    using Entities;
    public sealed class ArrivalDateBeforeDepartureDateFilter : Filter
    {
        public override bool IsValid(Flight flight)
        {
            return base.IsValid(flight)
                 && flight.Segments.Any(x => x.ArrivalDate < x.DepartureDate);
        }
    }
}
