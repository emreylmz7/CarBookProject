namespace CarBook.Domain.Entities
{
	public class Review
	{
		public int ReviewId { get; set; }
		public int Rating { get; set; } 
		public string? Comment { get; set; } 
		public DateTime DatePosted { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
    }
}
