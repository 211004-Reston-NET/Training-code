using RRModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Models
{
    public class RestaurantVM
    {

        public RestaurantVM()
        {
                
        }
        public RestaurantVM(Restaurant p_rest)
        {
            this.Id = p_rest.Id;
            this.City = p_rest.City;
            this.State = p_rest.State;
            this.Name = p_rest.Name;
        }


        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
