using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Core.Services.Data;
using Core.Services.Rest;
using ElasticSearch.DTO;
using ElasticSearch.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ElasticSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICloudinaryService _cloudinary;
        private IProductServices _product;
        private IMapper _mapper;
        public ProductController(IProductServices product, ICloudinaryService cloudinary,IMapper mapper)
        {
            _product = product;
            _cloudinary = cloudinary;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        
            {
            var model = await _product.GetProducts();
            var produts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductGetDto>>(model);
            return Ok(produts);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm]ProductSetDto productSetDto)
        {
            if (!string.IsNullOrEmpty(productSetDto.ProductName) && productSetDto.Photo!=null && productSetDto.Quantity > 0) 
            {
                string path = FileManager.IFormSave(productSetDto.Photo, "temp");
                string id = _cloudinary.Store(path);

                var pro= _mapper.Map<ProductSetDto, Product>(productSetDto);
                pro.Photo = id;
                var model = await _product.Create(pro);
                var produts= _mapper.Map<Product, ProductGetDto>(model);
                return Ok(produts);
            }

            return BadRequest("error");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var model= await _product.GetById(id);
            if (model!=null)
            {
                var produts = _mapper.Map<Product,ProductGetDto>(model?.FirstOrDefault());
                return Ok(produts);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductEditDto productEditDto)
        {
            if (!string.IsNullOrEmpty(productEditDto.ProductName) && productEditDto.Quantity > 0)
            {
                var pro = _mapper.Map<ProductEditDto, Product>(productEditDto);
                var result = await _product.Edit(pro);

                var products = _mapper.Map<Product, ProductGetDto>(result);
                return Ok(products);
            }
            return BadRequest(400);
        }

        [HttpDelete]
        public async Task<IActionResult>Delete(ProductEditDto productEditDto)
        {
            if (productEditDto.Id > 0)
            {
              bool result= await _product.Delete(productEditDto.Id);
                if (result)
                    return StatusCode(204);
            }
            return BadRequest(400);
        }
    }
}