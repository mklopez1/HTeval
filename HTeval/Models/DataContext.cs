using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HTeval.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }

    }
}