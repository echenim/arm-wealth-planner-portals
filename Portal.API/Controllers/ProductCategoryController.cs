using System.Linq;
using Portal.Business.Contracts;
using Portal.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryManager _service;

        public ProductCategoryController(IProductCategoryManager service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("read")]
        public IActionResult Read()
        {
            var _list = _service.Get().ToList();
            return Ok(_list);
        }

        [HttpGet]
        [Route("findbyId")]
        public IActionResult Findby(int id)
        {
            if (id > 0)
            {
                var _list = _service.Get(s => s.Id == id);
                return Ok(_list);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Create([FromBody] ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var _list = _service.Save(model: model);
                return Ok(_list);
            }

            return BadRequest(ModelState.ErrorCount);
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit([FromBody]ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var _list = _service.Edit(model);
                return Ok(_list);
            }
            return BadRequest(ModelState.ErrorCount);
        }

        [HttpPost]
        [Route("remove")]
        public IActionResult Delete([FromBody]int id)
        {
            if (ModelState.IsValid)
            {
                var model = _service.FindById(s => s.Id == id);
                model.Id = id;
                var _list = _service.Delete(model);
                return Ok(_list);
            }
            return BadRequest(ModelState.ErrorCount);
        }
    }
}