using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _discountService.GetAll();
            var valuesDto = _mapper.Map<List<ResultDiscountDto>>(values);
            return Ok(valuesDto);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var values = _mapper.Map<Discount>(createDiscountDto);
            _discountService.Add(values);
            return Ok("Discount successfully added.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.GetById(id);
            _discountService.Delete(values);
            return Ok("Discount successfully deleted.");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var values = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.Update(values);
            return Ok("Discount successfully updated.");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.GetById(id);
            var valuesDto = _mapper.Map<GetDiscountDto>(values);
            return Ok(valuesDto);
        }
    }
}
