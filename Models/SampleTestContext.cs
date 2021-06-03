using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Models
{
    public class SampleTestContext:DbContext
    {
        public SampleTestContext(DbContextOptions<SampleTestContext> options) : base(options)
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Deposit> depositdata { get; set; }
        public DbSet<Withdraw> withdraws { get; set; }
    }
}
