using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Flight
    {
        public string Description { get; set; }
        public IList<Segment> Segments { get; set; }

        public override string ToString() => Description;
    }
}
