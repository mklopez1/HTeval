using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

namespace HTeval.Models
{
    public class ContactModel
    {
        [Required]
        public int ID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        [StringLength(150)]
        public string EmailAddress { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [DisplayName("Number of computers")]
        public int NumberOfComputers { get; set; }

        public virtual ICollection<AddressModel> Addresses { get; set; }
    }
}