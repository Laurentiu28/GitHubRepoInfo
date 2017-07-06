using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHubRepoInfo.DTO;
using GitHubRepoInfo.Repositories;
using AutoMapper;

namespace GitHubRepoInfo.Controllers
{
    [Route("api/[controller]")]
    public class UserRepositoriesController : Controller
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserRepositoriesController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        // GET api/userrepositories/test
        [HttpGet("{searchQuery}")]
        public IActionResult Get(string searchQuery)
        {
            var userRepositories = _userInfoRepository.GetRepositories(searchQuery);

            var results = Mapper.Map<IEnumerable<UserRepositoryDto>>(userRepositories);

            return Ok(results);
        }
    }
}
