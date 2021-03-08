using System.Collections.Generic;

namespace Domain
{
    using Entities;
    using Filters;

    public interface IFilterService
    {
        IEnumerable<Flight> Filter(IEnumerable<Flight> flights, params Filter[] filters);
    }
}
