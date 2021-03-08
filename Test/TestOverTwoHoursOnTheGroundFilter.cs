using Xunit;
using System;
using Domain.Filters;
using Domain.Entities;
using System.Collections.Generic;

namespace Tests
{
    public class TestOverTwoHoursOnTheGroundFilter
    {
        [Fact]
        public void Should_Filter_Flights_Which_Have_Ground_Time_Over_Two_Hours()
        {
            var threeDaysFromNow = DateTime.Now.AddDays(3);

            var flight = TestHelper.CreateFlight("A flight that departs before it arrives",
                                         new List<Segment>
                                         {
                                             new Segment { DepartureDate = threeDaysFromNow,
                                                 ArrivalDate = threeDaysFromNow.AddHours(2) },

                                             new Segment { DepartureDate = threeDaysFromNow.AddHours(5),
                                                 ArrivalDate =threeDaysFromNow.AddHours(6) }
                                         });

            var filter = new OverTwoHoursOnTheGroundFilter();
            var result = filter.IsValid(flight);

            Assert.True(result);
        }

        [Fact]
        public void Should_Not_Filter_Flights_Which_Have_Ground_Time_Equal_Two_Hours()
        {
            var threeDaysFromNow = DateTime.Now.AddDays(3);

            var flight = TestHelper.CreateFlight("A flight that departs before it arrives",
                                         new List<Segment>
                                         {
                                             new Segment { DepartureDate = threeDaysFromNow,
                                                 ArrivalDate = threeDaysFromNow.AddHours(2) },

                                             new Segment { DepartureDate = threeDaysFromNow.AddHours(4),
                                                 ArrivalDate =threeDaysFromNow.AddHours(6) }
                                         });

            var filter = new OverTwoHoursOnTheGroundFilter();
            var result = filter.IsValid(flight);

            Assert.False(result);
        }

        [Fact]
        public void Should_Not_Filter_Flights_Which_Have_Ground_Time_Less_Than_Two_Hours()
        {
            var threeDaysFromNow = DateTime.Now.AddDays(3);

            var flight = TestHelper.CreateFlight("A flight that departs before it arrives",
                                         new List<Segment>
                                         {
                                             new Segment { DepartureDate = threeDaysFromNow,
                                                 ArrivalDate = threeDaysFromNow.AddHours(2) },

                                             new Segment { DepartureDate = threeDaysFromNow.AddHours(3),
                                                 ArrivalDate =threeDaysFromNow.AddHours(6) }
                                         });

            var filter = new OverTwoHoursOnTheGroundFilter();
            var result = filter.IsValid(flight);

            Assert.False(result);
        }


    }
}
