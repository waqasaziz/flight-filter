using Xunit;
using System;
using Domain.Filters;
using Domain.Entities;
using System.Collections.Generic;

namespace Tests
{
    public class TestDepartsBeforeCurrentTimeFilter
    {
        [Fact]
        public void Shloud_Filter_Flights_Which_Departs_Before_Arrival()
        {
            Flight flight = TestHelper.CreateFlight("A flight departing in the past",
                                           departure: DateTime.Now.Date,
                                           arrival: DateTime.Now.AddDays(3));

            var filter = new DepartsBeforeCurrentTimeFilter();
            var result = filter.IsValid(flight);

            Assert.True(result);
        }

        [Fact]
        public void Should_Not_Filter_Flights_Which_Departs_Before_Arrival()
        {
            Flight flight = TestHelper.CreateFlight("A flight departing in the Future",
                                               departure: DateTime.Now.AddDays(1),
                                                arrival: DateTime.Now.AddDays(3));

            var filter = new DepartsBeforeCurrentTimeFilter();
            var result = filter.IsValid(flight);

            Assert.False(result);
        }

    }
}
