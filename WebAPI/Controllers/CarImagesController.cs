using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Data.Count > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetByCarId/{id}")]
        public IActionResult GtByCarId(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("AddCarImage")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage, formFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _carImageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }


        [HttpPut("UpdateCarImage")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(carImage, formFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }





    }
}
