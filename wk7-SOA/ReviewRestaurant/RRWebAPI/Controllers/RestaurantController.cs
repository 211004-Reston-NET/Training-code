using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        //Dependency injection
        private readonly IRestaurantBL _RestBL;

        public RestaurantController(IRestaurantBL p_restBL)
        {
            _RestBL = p_restBL;
        }

        // GET: api/<RestaurantController>\
        [HttpGet("All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAllRestaurant()
        {
            return Ok(_RestBL.GetAllRestaurant());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{p_id}")]
        public IActionResult GetRestaurantById(int p_id)
        {
            return Ok(_RestBL.GetRestaurantById(p_id));
        }

        // POST api/<RestaurantController>
        [HttpPost("Add")]
        public IActionResult AddRestaurant([FromBody] Restaurant p_rest)
        {
            return Created("api/Restaurant/Add", _RestBL.AddRestaurant(p_rest));
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
