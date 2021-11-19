using RRDL;
using RRModels;

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

        public Review UpdateReview(Review p_rev, int p_howMuchAdded)
        {
            //Changes the rating property of my review 
            //and add it based on p_howMuchAdded parameter
            p_rev.Rating += p_howMuchAdded; 

            return _repo.UpdateReview(p_rev);
        }
    }
}