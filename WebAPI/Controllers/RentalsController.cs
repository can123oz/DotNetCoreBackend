using Business.Abstract;
using Entity.Concrete;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalsService _rentalsService;

        public RentalsController(IRentalsService rentalsService)
        {
            _rentalsService = rentalsService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _rentalsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _rentalsService.DeleteRental(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _rentalsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(RentalDto rentalDto)
        {
            var result = _rentalsService.AddRental(rentalDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update(Rentals rentals)
        {
            var result = _rentalsService.UpdateRental(rentals);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("ReturnCar")]
        public IActionResult ReturnCar(RentalDto rentalDto)
        {
            var returedCar = _rentalsService.ReturnCar(rentalDto.carId);
            return Ok(returedCar);
        }

        [HttpGet("GetRentalDetail")]
        public IActionResult GetRentalDetails()
        {
            var result = _rentalsService.GetRentalDetails();
            return Ok(result);
        }
    }
}
