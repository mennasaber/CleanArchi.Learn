using CleanArchi.Learn.Application.Features.Orders.Commands.AddOrder;
using CleanArchi.Learn.Application.Features.Orders.Queries.AddItemToCart;
using CleanArchi.Learn.Application.Features.Orders.Queries.DecreaseItemFromCart;
using CleanArchi.Learn.Application.Features.Orders.Queries.DeleteItemFromCart;
using CleanArchi.Learn.Application.Features.Orders.Queries.GetCartItems;
using CleanArchi.Learn.Application.Features.Orders.Queries.GetOrder;
using CleanArchi.Learn.Application.Features.Users.Queries.GetUser;
using CleanArchi.Learn.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchi.Learn.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _mediator.Send(new GetCartItemsQuery());
            if (items == null)
                items = new List<Item>();
            return View(items);
        }
        public async Task<IActionResult> IncreaseItemQuantity(int id)
        {
            await _mediator.Send(new AddItemToCartQuery() { ProductId = id });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DecreaseItemQuantity(int id)
        {
            await _mediator.Send(new DecreaseItemFromCartQuery() { ProductId = id });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _mediator.Send(new DeleteItemFromCartQuery() { ProductId = id });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Confirm()
        {
            var items = await _mediator.Send(new GetCartItemsQuery());
            var user = await _mediator.Send(new GetCurrentUserQuery());
            if (user != null && items.Count != 0)
            {
                await _mediator.Send(new AddOrderCommand { Items = items, User = user, OrderedTime = System.DateTime.Now });
            }
            return Content("Confirmed");
        }
    }
}
