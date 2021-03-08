using System.Collections.Generic;

namespace Domain
{
    using Entities;
    public interface IFlightBuilder
    {
        IList<Flight> GetFlights();
    }
}
