using System;
using System.Linq;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain
{
    public class FlightBuilder : IFlightBuilder
    {
        public IList<Flight> GetFlights()
        {
            var threeDaysFromNow = DateTime.Now.AddDays(3);

            return new List<Flight>
            {
                // A normal flight with two hour duration
                CreateFlight("A normal flight with two hour duration",threeDaysFromNow, threeDaysFromNow.AddHours(2)),

                // A normal multi-segment flight
                CreateFlight("A normal multi-segment flight",threeDaysFromNow, threeDaysFromNow.AddHours(2), threeDaysFromNow.AddHours(3), threeDaysFromNow.AddHours(5)),
                
                // A flight departing in the past
                CreateFlight("A flight departing in the past",threeDaysFromNow.AddDays(-6), threeDaysFromNow),

                // A flight that departs before it arrives
                CreateFlight("A flight that departs before it arrives",threeDaysFromNow, threeDaysFromNow.AddHours(-6)),

                // A flight with more than two hours ground time
                CreateFlight("A flight with more than two hours ground time",threeDaysFromNow, threeDaysFromNow.AddHours(2), threeDaysFromNow.AddHours(5), threeDaysFromNow.AddHours(6)),

                // Another flight with more than two hours ground time
                CreateFlight("Another flight with more than two hours ground time",threeDaysFromNow, threeDaysFromNow.AddHours(2), threeDaysFromNow.AddHours(3), threeDaysFromNow.AddHours(4), threeDaysFromNow.AddHours(6), threeDaysFromNow.AddHours(7))
            };
        }

        private static Flight CreateFlight(string description, params DateTime[] dates)
        {
            if (dates.Length % 2 != 0)
                throw new ArgumentException("You must pass an even number of dates,", "dates");

            var departureDates = dates.Where((date, index) => index % 2 == 0);
            var arrivalDates = dates.Where((date, index) => index % 2 == 1);

            var segments = departureDates
                .Zip(arrivalDates, (departureDate, arrivalDate) => new Segment { DepartureDate = departureDate, ArrivalDate = arrivalDate })
                .ToList();

            return new Flight { Description = description, Segments = segments };
        }
    }
}

