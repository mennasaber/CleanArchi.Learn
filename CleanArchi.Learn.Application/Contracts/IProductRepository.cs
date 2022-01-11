using CleanArchi.Learn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Contracts
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
