using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.City;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    public class CityController : BaseApiController
    {
        private ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id}", Name = "GetCityWithId")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(Guid id)
        {
            if(id == Guid.Empty)
                return BadRequest("ID inválido");

            try
            {
                var result = await _cityService.Get(id);
                if(result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("byIbge/{code}", Name = "GetCityWithIbge")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetByIbge(int code)
        {
            if(code < 0 || code > int.MaxValue)
                return BadRequest();

            try
            {
                var result = await _cityService.GetByIbge(code);
                if(result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _cityService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCityDto model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var result = await _cityService.Post(model);
                if(result != null)
                    return Created(new Uri(Url.Link("GetCityWithId", new { id = result.Id })), result);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCityDto model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var result = await _cityService.Put(model);
                if(result != null)
                    return Ok(result);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("ID inválido");
            }

            try
            {
                return Ok(await _cityService.Delete(id));
            }
            catch (System.Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }
    }
}