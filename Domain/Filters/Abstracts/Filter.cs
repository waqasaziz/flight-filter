using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Filters
{
    using Entities;

    public abstract class Filter
    {
        public virtual bool IsValid(Flight flight) => flight.Segments?.Count > 0;
    }
}
