using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories;

public class CustomerRepository : BaseRepository<CustomerEntity>
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}
