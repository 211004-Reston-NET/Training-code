using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Models
{
    public class ReviewVM
    {
        public ReviewVM()
        {

        }

        public ReviewVM(Review p_rev)
        {
            this.Id = p_rev.Id;
            this.Rating = p_rev.Rating;
            this.Description = p_rev.Description;
            this.RestId = p_rev.RestId;
        }

        public int Id { get; set; }
        public int Rating { get; set; }

        public string Description { get; set; }
        public int RestId { get; set; }
    }
}
