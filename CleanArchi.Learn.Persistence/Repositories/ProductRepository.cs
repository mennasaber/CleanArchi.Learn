using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CleanArchiDbContext context) : base(context)
        {
        }
    }
}
