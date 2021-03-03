using System;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        //private byte[] profilePicture;

        //WHY PUBLIU?
        //public Lazy<byte[]> ProfilePictureValueHolder { get; set; }
        public Guid CustomerId { get; set; }

        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string ShippingAddress { get; set; }

        [Required]
        public virtual string City { get; set; }
        [Required]
        public virtual string PostalCode { get; set; }
#nullable enable
        public virtual string Country { get; set; }
#nullable disable
        public virtual byte[] ProfilePicture { get; set; }
        //{ 
            //get
            //{
                // *****************  LAZY INITIALISATION ****************************
                // CODE SMELL! Now our model needs to know about the ProfilePictureService
                // We also need to ensure that when the Customer Model is created, the Profile PIcture property
                // is not tracked. We do this by overriding the OnModelCreation method of the DBContext and ignore this prop.
                //if (profilePicture == null)
                //{
                //    profilePicture = ProfilePictureService.GetFor(Name);
                //}
                //return profilePicture;
                //return profilePicture.Value.GetFor(Name);

                //***** Now the Repo will inject the correct ValueLoader into the ctror.
                // ***** Separaion of concerns, now the model does not know about the service.
                //return ProfilePictureValueHolder.Value;
           // }
            //set 
            //{
            //    profilePicture = value;
            //} 
        //}

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
