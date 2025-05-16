using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.GetAll();
            var valuesDto = _mapper.Map<List<ResultProductDto>>(values);
            return Ok(valuesDto);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult GetProductsByCategories()
        {
            var values = _productService.GetProductsByCategories();
            var valuesDto = _mapper.Map<List<ResultProductWithCategoryDto>>(values);
            return Ok(valuesDto);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            _productService.Add(values);
            return Ok("Product successfully added.");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.GetById(id);
            _productService.Delete(values);
            return Ok("Product successfully deleted.");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            _productService.Update(values);
            return Ok("Product successfully updated.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var values = _productService.GetById(id);
            var valuesDto = _mapper.Map<GetProductDto>(values);
            return Ok(valuesDto);
        }
    }
}
