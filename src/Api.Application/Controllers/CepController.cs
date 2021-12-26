using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.Cep;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    public class CepController : BaseApiController
    {
        private readonly ICepService _service;

        public CepController(ICepService service)
        {
            _service = service;
        }

        [HttpGet("{id}", Name = "GetCepWithId")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(Guid id)
        {
            if(id == Guid.Empty)
                return BadRequest();

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("byCep/{cep}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(string cep)
        {
            if(string.IsNullOrEmpty(cep))
                return BadRequest();

            try
            {
                return Ok(await _service.Get(cep));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCepDto model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var result = await _service.Post(model);
                if(result != null)
                    return Created(new Uri(Url.Link("GetCepWithId", new { id = result.Id })), result);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCepDto model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var result = await _service.Put(model);
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
                return Ok(await _service.Delete(id));
            }
            catch (System.Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }

    }
}