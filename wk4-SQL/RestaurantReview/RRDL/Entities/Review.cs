using System;
using System.Collections.Generic;

#nullable disable

namespace RRDL.Entities
{
    public partial class Review
    {
        public int RevId { get; set; }
        public int RevRating { get; set; }
        public int RestId { get; set; }

        public virtual Restaurant Rest { get; set; }
    }
}
