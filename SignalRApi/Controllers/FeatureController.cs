using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.GetAll();
            var valuesDto = _mapper.Map<List<ResultFeatureDto>>(values);
            return Ok(valuesDto);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);
            _featureService.Add(values);
            return Ok("Feature successfully added.");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.GetById(id);
            _featureService.Delete(values);
            return Ok("Feature successfully deleted.");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.Update(values);
            return Ok("Feature successfully updated.");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values = _featureService.GetById(id);
            var valuesDto = _mapper.Map<GetFeatureDto>(values);
            return Ok(valuesDto);
        }
    }
}
