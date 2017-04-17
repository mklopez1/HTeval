using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTeval.Models
{
    public class AddressModel
    {
        [Required]
        public int ID { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        [StringLength(150)]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        [StringLength(150)]
        public string AddressLine2 { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        [StringLength(2)]
        public string StateCode { get; set; }

        public int Zip { get; set; }

        [DisplayName("Address Type")]
        [Required]
        [StringLength(20)]
        public string AddressType { get; set; }

        [ForeignKey("ContactModel")]
        public virtual int ContactModel_ID { get; set; }

        public virtual ContactModel ContactModel { get; set; }

    }
}