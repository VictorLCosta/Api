using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetWithId")]
        public async Task<IActionResult> Get(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("ID inválido");
            }

            try
            {
                return Ok(await _userService.Get(id));
            }
            catch (System.Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var result = await _userService.Post(model);
                if(result != null)
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(User model)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var result = await _userService.Put(model);
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
                return Ok(await _userService.Delete(id));
            }
            catch (System.Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }
    }
}