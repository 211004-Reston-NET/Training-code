using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Models
{
    public class RestaurantVM
    {
        public RestaurantVM(Restaurant p_rest)
        {
            this.Id = p_rest.Id;
            this.City = p_rest.City;
            this.State = p_rest.State;
            this.Name = p_rest.Name;
        }
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
    }
}
