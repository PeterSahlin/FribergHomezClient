using System.ComponentModel.DataAnnotations;

namespace FribergHomezClient.Models
{
    public class RealEstateAgent
    {
        public string Id { get; set; }
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
        //public string Username { get; set; } 
        public string Password { get; set; }
     
        [Required]
        public bool IsActive { get; set; } = true;

        //Navigation Properties
        public Firm Firm { get; set; }

        public RealEstateAgent(string firstName, string lastName, string email, Firm firm, string phoneNumber, string imageUrl, bool isActive, int firmId, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Firm = firm;
            PhoneNumber = phoneNumber;
            ImageUrl = imageUrl;
            IsActive = isActive;
            FirmId = firmId;
            //Username = email;
            Password = password;
        }
        public RealEstateAgent() { }
    }
}
