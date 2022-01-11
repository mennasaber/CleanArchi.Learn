using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Products.Commands
{
    public class AddProductQuery :IRequest<int>
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
