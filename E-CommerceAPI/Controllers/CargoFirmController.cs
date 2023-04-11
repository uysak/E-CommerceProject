using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.CargoFirmDTOs;
using Entity.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoFirmController : ControllerBase
    {
        ICargoFirmService _cargoFirmService;
        IMapper _mapper;

        public CargoFirmController(ICargoFirmService cargoFirmService, IMapper mapper)
        {
            _cargoFirmService = cargoFirmService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCargoFirms()
        {
            var cargoFirms = _cargoFirmService.GetAll();
            if (!cargoFirms.Success)
            {
                return NotFound();
            }
            return Ok(cargoFirms);
        }

        [HttpPost]
        public IActionResult CreateCargoFirms(CargoFirmForCreateDto cargoFirmDto)
        {
            var cargoFirm = _mapper.Map<CargoFirm>(cargoFirmDto);

            var result = _cargoFirmService.CreateCargoFirm(cargoFirm);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteCargoFirms(int id)
        {
            var result = _cargoFirmService.DeleteCargoFirm(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdatecargoFirms(int cargoFirmId, CargoFirmForUpdateDto cargoFirmDto)
        {

            var cargoFirm = _mapper.Map<CargoFirm>(cargoFirmDto);
            cargoFirm.Id = cargoFirmId;

            var result = _cargoFirmService.UpdateCargoFirm(cargoFirm);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}