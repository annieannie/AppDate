using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using datingapp.api.Data;
using datingapp.api.Dtos;
using datingapp.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace datingapp.api.Controllers
{
     
    [Route("api/[controller]")]
   [ApiController] 
       public class UsersController:ControllerBase
    {
        private readonly IDatingRepository repo;
        private readonly IMapper mapper;

        public UsersController(IDatingRepository _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
                var users = await repo.GetUsers();
                var usersToReturn= mapper.Map<IEnumerable<UserForListDto>>(users);

                return Ok(usersToReturn);
        }

           [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
                var user = await repo.GetUser(id);
                var userToReturn= mapper.Map<UserForDetailsDto>(user);

                return Ok(userToReturn);
        }


       
    }

}