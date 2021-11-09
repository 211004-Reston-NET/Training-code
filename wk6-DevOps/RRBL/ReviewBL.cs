using RRDL;
using RRModels;
using System;
using System.Collections.Generic;

namespace RRBL
{
    public class ReviewBL : IReviewBL
    {
        private IRepository _repo;
        public ReviewBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public Review GetReviewById(int p_id)
        {
           return _repo.GetReviewById(p_id);
        }

        public Tuple<List<Review>, double> GetAllReviewByRestId(int p_id)
        {
            List<Review> listOfReview = _repo.GetAllReviewByRestId(p_id);
            double overallRating = 0.0;

            foreach (Review item in listOfReview)
            {
                overallRating += item.Rating;
            }
            overallRating = overallRating / listOfReview.Count;

            return new Tuple<List<Review>, double>(listOfReview, overallRating);
        }

        public Review UpdateReview(Review p_rev, int p_howMuchAdded)
        {
            //Changes the rating property of my review 
            //and add it based on p_howMuchAdded parameter
            p_rev.Rating += p_howMuchAdded; 

            return _repo.UpdateReview(p_rev);
        }
    }
}