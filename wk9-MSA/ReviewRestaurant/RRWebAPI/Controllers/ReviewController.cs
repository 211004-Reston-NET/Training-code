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
    public class ReviewController : ControllerBase
    {
        //Dependency injection
        private readonly IReviewBL _RevBL;

        public ReviewController(IReviewBL p_revBL)
        {
            _RevBL = p_revBL;
        }

        [HttpGet("{p_id}")]
        public IActionResult GetRestaurantById(int p_id)
        {
            return Ok(_RevBL.GetAllReviewByRestId(p_id));
        }

    }
}
