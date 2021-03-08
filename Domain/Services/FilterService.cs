using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    using Entities;
    using Filters;
    public class FilterService : IFilterService
    {
        public IEnumerable<Flight> Filter(IEnumerable<Flight> flights, params Filter[] filters)
        {
            if (flights == null) throw new ArgumentNullException(nameof(flights));
            if (filters == null) throw new ArgumentNullException(nameof(filters));

            return filters.SelectMany(filter => flights.Where(filter.IsValid));
        }

    }
}
