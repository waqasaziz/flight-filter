using Xunit;
using System;
using Domain;
using Domain.Filters;
using Domain.Entities;
using System.Collections.Generic;

namespace Tests
{
    public class TestArrivalDateBeforeDepartureDateFilter
    {
        [Fact]
        public void Shloud_Filter_Flights_Which_Departs_Before_Current_Datetime()
        {
            var threeDaysFromNow = DateTime.Now.AddDays(3);

            Flight flight = TestHelper.CreateFlight("A flight that departs before it arrives",
                                         departure: threeDaysFromNow,
                                         arrival: threeDaysFromNow.AddHours(-6));

            var filter = new ArrivalDateBeforeDepartureDateFilter();

            var result = filter.IsValid(flight);

            Assert.True(result);
        }

        [Fact]
        public void Should_Not_Filter_Flights_Which_Departs_Before_Current_Datetime()
        {
            var threeDaysFromNow = DateTime.Now.AddDays(3);

            Flight flight = TestHelper.CreateFlight("A flight that departs after it arrives",
                                         departure: threeDaysFromNow.AddDays(-6),
                                        arrival: threeDaysFromNow);

            var filter = new ArrivalDateBeforeDepartureDateFilter();

            var result = filter.IsValid(flight);

            Assert.False(result);
        }


    }
}
