using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Filters
{
    using Entities;
    public sealed class OverTwoHoursOnTheGroundFilter : Filter
    {
        private const int MaxGroundTime = 2;

        public override bool IsValid(Flight flight)
        {
            if (!base.IsValid(flight)) return false;

            foreach (var item in flight.Segments)
            {
                var currentIndex = flight.Segments.IndexOf(item);
                var nextSegment = flight.Segments.ElementAtOrDefault(currentIndex + 1);

                if (nextSegment == null) break;

                var totalGap = nextSegment.DepartureDate.Subtract(item.ArrivalDate).TotalHours;

                if (totalGap > MaxGroundTime) return true;
            }

            return false;
        }
    }
}
