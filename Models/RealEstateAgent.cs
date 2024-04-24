namespace FribergHomezClient.Models
{
    public class RealEstateAgent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName +" "+ LastName;
            }
            set { }
        }
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public int? FirmId { get; set; }
    }
}
