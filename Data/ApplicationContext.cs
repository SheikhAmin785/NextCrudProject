using Microsoft.EntityFrameworkCore;
using NextCrudProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextCrudProject.Data
{
    public class ApplicationContext:DbContext
    {
       

     public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
      public DbSet<Employee> employees { get; set; }
     
    }
}
