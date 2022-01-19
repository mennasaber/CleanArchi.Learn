using CleanArchi.Learn.Application.Features.Products;
using CleanArchi.Learn.Application.Features.Products.Commands;
using CleanArchi.Learn.Application.Features.Products.Commands.DeleteProduct;
using CleanArchi.Learn.Application.Features.Products.Commands.UpdateProduct;
using CleanArchi.Learn.Application.Features.Products.Queries.GetProduct;
using CleanArchi.Learn.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CleanArchi.Learn.MVC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View(products);
        }

        [Authorize(Roles = AppConstants.ADMIN_ROLE)]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductQuery addProductQuery)
        {
            try
            {
                await _mediator.Send(addProductQuery);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public async Task<IActionResult> Details(GetProductQuery getProductQuery)
        {
            try
            {
                var product = await _mediator.Send(getProductQuery);
                return View(product);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = AppConstants.ADMIN_ROLE)]
        public async Task<IActionResult> Update(GetProductQuery getProductQuery)
        {
            try
            {
                var product = await _mediator.Send(getProductQuery);
                return View(product);
            }

            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductCommand updateProductCommand)
        {
            try
            {
                await _mediator.Send(updateProductCommand);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = AppConstants.ADMIN_ROLE)]
        public async Task<IActionResult> Delete(GetProductQuery getProductQuery)
        {
            try
            {
                var product = await _mediator.Send(getProductQuery);
                return View(product);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProductCommand deleteProductCommand)
        {
            try
            {
                await _mediator.Send(deleteProductCommand);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
