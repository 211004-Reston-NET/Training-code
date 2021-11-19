using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModels;
using RRWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewBL _rev;

        public ReviewController(IReviewBL p_rev)
        {
            this._rev = p_rev;
        }

        public IActionResult Index(int p_id)
        {
            Tuple<List<Review>, double> revWithOverall = _rev.GetAllReviewByRestId(p_id);

            if (revWithOverall.Item1.Count == 0)
            {
                ViewData.Add("OverRating", "No Reviews Yet");
            }
            else
            {
                ViewData.Add("OverRating", revWithOverall.Item2);
            }
            
            return View(revWithOverall.Item1
                            .Select(rev => new ReviewVM(rev))
                            .ToList()
            );
        }
    }
}
