using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HTeval.Models
{
    public class ContactSearchModel
    {
        [DisplayName("First name starts with")]
        public string FirstNameParameter { get; set; }

        [DisplayName("Last name starts with")]
        public string LastNameParameter { get; set; }

        public IEnumerable<HTeval.Models.ContactModel> SearchResults { get; set; }
    }
}