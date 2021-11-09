using RRModels;
using System;
using System.Collections.Generic;

namespace RRBL
{
    public interface IReviewBL
    {
        /// <summary>
        /// Will give a specific review from database using ID
        /// </summary>
        /// <param name="p_id">This is the id we are trying to find</param>
        /// <returns>Returns the review that it found</returns>
        Review GetReviewById(int p_id);

        /// <summary>
        /// This will add the rating property in review
        /// </summary>
        /// <param name="p_rev">This is the review you are adding to</param>
        /// <param name="p_howMuchAdded">This is how much you are adding it</param>
        /// <returns>It returns the added review</returns>
        Review UpdateReview(Review p_rev, int p_howMuchAdded);

        /// <summary>
        /// Will give reviews based on Rest Id and calculated overallRating
        /// </summary>
        /// <param name="p_id">This is the restaurant Id it will used to find the reviews</param>
        /// <returns>Tuple that has the list of reviews and the overall rating</returns>
        Tuple<List<Review>, double> GetAllReviewByRestId(int p_id);
    }
}