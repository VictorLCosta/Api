using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTO.Account;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<object> Login(LoginDto model)
        {
            if(model == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);


            try
            {
                var result = await _accountService.FindByLogin(model);
                if(result != null)
                    return result;

                return NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                throw;
            }

        }
    }
}