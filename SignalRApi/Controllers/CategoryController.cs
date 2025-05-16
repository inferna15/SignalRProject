using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CategoryAdd(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.Add(value);
            return Ok("Category successfully added.");
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var values = _categoryService.GetById(id);
            _categoryService.Delete(values);
            return Ok("Category successfully deleted.");
        }

        [HttpPut]
        public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.Update(values);
            return Ok("Category successfully updated.");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _mapper.Map<GetCategoryDto>(_categoryService.GetById(id));
            return Ok(value);
        }
    }
}
