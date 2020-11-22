using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventFunction.Entities
{
    public class CustomerEventContext : DbContext
    {
        public CustomerEventContext(DbContextOptions<CustomerEventContext> options)
            : base(options)
        { }

        public DbSet<CustomerEventEF> CustomerEvents { get; set; }
    }
}
