using CleanArchi.Learn.Application.Features.Orders.Queries.GetOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        
        //public async Task<IActionResult> Index()
        //{
        //    //var order = await _mediator.Send(new GetOrderQuery() { Id=1});
        //    //return View(order);
        //}
    }
}
