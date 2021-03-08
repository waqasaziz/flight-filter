using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    internal static class TestHelper
    {
        internal static Flight CreateFlight(string description, DateTime departure, DateTime arrival)
        {
            return new Flight
            {
                Description = description,
                Segments = new List<Segment>
                {
                    new Segment{
                        DepartureDate = departure,
                        ArrivalDate = arrival
                    }
                }
            };
        }

        internal static Flight CreateFlight(string description, List<Segment> segments)
        {
            return new Flight
            {
                Description = description,
                Segments = segments
            };
        }
    }
}
