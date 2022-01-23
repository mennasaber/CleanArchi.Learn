using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.GetCartItems
{
    public class GetCartItemsQuery:IRequest<List<Item>>
    {
    }
}
