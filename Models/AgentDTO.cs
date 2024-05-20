namespace FribergHomezClient.Models
{
    public class AgentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string ImageUrl { get; set; } = "https://www.pngfind.com/pngs/m/610-6104451_image-placeholder-png-user-profile-placeholder-image-png.png";
        public int? FirmId { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }


        //Navigation Properties
        public Firm Firm { get; set; }
    }
}
