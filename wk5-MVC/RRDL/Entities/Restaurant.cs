using System;
using System.Collections.Generic;

#nullable disable

namespace RRDL.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Reviews = new HashSet<Review>();
        }

        public int RestId { get; set; }
        public string RestName { get; set; }
        public string RestCity { get; set; }
        public string RestState { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
