﻿using CleanArchi.Learn.Application.Features.Orders.Commands.AddOrder;
using CleanArchi.Learn.Application.Features.Orders.Queries.AddItemToCart;
using CleanArchi.Learn.Application.Features.Orders.Queries.DecreaseItemFromCart;
using CleanArchi.Learn.Application.Features.Orders.Queries.DeleteItemFromCart;
using CleanArchi.Learn.Application.Features.Orders.Queries.GetCartItems;
using CleanArchi.Learn.Application.Features.Orders.Queries.GetOrderDetails;
using CleanArchi.Learn.Application.Features.Orders.Queries.GetUserOrders;
using CleanArchi.Learn.Application.Features.Users.Queries.GetUser;
using CleanArchi.Learn.Domain;
using CleanArchi.Learn.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
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
            return RedirectToAction(AppConstants.INDEX_ACTION);
        }
        public async Task<IActionResult> DecreaseItemQuantity(int id)
        {
            await _mediator.Send(new DecreaseItemFromCartQuery() { ProductId = id });
            return RedirectToAction(AppConstants.INDEX_ACTION);
        }
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _mediator.Send(new DeleteItemFromCartQuery() { ProductId = id });
            return RedirectToAction(AppConstants.INDEX_ACTION);
        }

        [Authorize]
        public async Task<IActionResult> Confirm()
        {
            var items = await _mediator.Send(new GetCartItemsQuery());
            var user = await _mediator.Send(new GetCurrentUserQuery());
            if (items == null)
                items = new List<Item>();
            if (user != null && items.Count != 0)
            {
                await _mediator.Send(new AddOrderCommand { Items = items, User = user, OrderedTime = System.DateTime.Now });
                return RedirectToAction(AppConstants.INDEX_ACTION, AppConstants.HOME_CONTROLLER);
            }
            return RedirectToAction(AppConstants.INDEX_ACTION);
        }
        [Authorize]
        public async Task<IActionResult> GetOrders()
        {
            var user = await _mediator.Send(new GetCurrentUserQuery());
            var orders = await _mediator.Send(new GetUserOrdersQuery() { UserId = user.Id });
            return View(orders);
        }
        public async Task<IActionResult> OrderDetails(int orderId)
        {
            var orderDetails = await _mediator.Send(new GetOrderDetailsQuery() { OrderId = orderId });
            return View(orderDetails);
        }
    }
}
