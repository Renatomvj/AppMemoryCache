using AppMemoryCache.Core.Entities;
using AppMemoryCache.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMemoryCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            this._service = service;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Product product)
        {
            this._service.Create(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult FindBy(int id)
        {
            return Ok(this._service.FindById(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._service.GetAll());
        }
    }
}
