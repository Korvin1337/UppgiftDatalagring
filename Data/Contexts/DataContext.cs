using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers { get; set; } = default!; /* = default! generated / suggested by chatgpt 4o ensures properties are set */

    public DbSet<ProjectEntity> Projects { get; set; } = default!; /* = default! generated / suggested by chatgpt 4o  ensures properties are set */

    /* Lazy Loading Config Override */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    /* Lazy Loading Future Syntax ? */
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectEntity>()
            .HasKey(x => new { x.ProjectId, x.CustomerId });

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(row => row.Customer)
            .WithMany(customer => customer.Name)
            .HasForeignKey(row => row.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }*/

}
