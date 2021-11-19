using System.ComponentModel.DataAnnotations;

namespace RRModels
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public int RestId { get; set; }
        public Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            return $"Rating: {Rating}";
        }
    }
}