using System;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        //private byte[] profilePicture;
        private Lazy<ProfilePictureService> profilePicture = new Lazy<ProfilePictureService>(() => new ProfilePictureService(), true);
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public byte[] ProfilePicture 
        { 
            get
            {
                // *****************  LAZY INITIALISATION ****************************
                // CODE SMELL! Now our model needs to know about the ProfilePictureService
                // We also need to ensure that when the Customer Model is created, the Profile PIcture property
                // is not tracked. We do this by overriding the OnModelCreation method of the DBContext and ignore this prop.
                //if (profilePicture == null)
                //{
                //    profilePicture = ProfilePictureService.GetFor(Name);
                //}
                //return profilePicture;
                return profilePicture.Value.GetFor(Name);
            }
            //set 
            //{
            //    profilePicture = value;
            //} 
        }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
