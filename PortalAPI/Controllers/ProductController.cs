﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortalAPI.ViewModels;
using PortalAPI.Midleware.Contracts;
using PortalAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("read")]
        public IActionResult Read()
        {
            var _list = new List<ProductView>();
            var list = _service.Get().ToList();
            foreach (var item in list)
            {
                _list.Add(new ProductView
                {
                    Id = item.Id,
                    ProductName = item.Name,
                    ProductCategory = item.ProductCategory.Name,
                    Description = item.Description,
                    StartFrom = item.StartFrom
                });
            }
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
        public IActionResult Create([FromBody] Products model)
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
        public IActionResult Edit([FromBody]Products model)
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