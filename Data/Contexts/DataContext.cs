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

}
