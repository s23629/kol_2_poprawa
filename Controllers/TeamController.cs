using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetTeam(int id)
        {
            try
            {
                var exist = await _service.GetTeamById(id).FirstOrDefaultAsync();

                if (exist == null) return NotFound("Nie znaleziono Teamu");




                return Ok(await _service.GetTeam(id)
                    .Select(e =>
                    new TeamGet
                    {
                        Name = e.TeamName,
                        Description = e.Description,
                        Organization = exist.Organization.Name,
                        Members = e.Membership.Select(e => new Members
                        {
                            Name = e.Member.Name,
                            Surname = e.Member.Surname,
                            membershipDate = e.MembershipDate


                        }).OrderBy(e => e.membershipDate).ToList()
                    }).ToListAsync()
                    );

            }
            catch (Exception) {
                return Problem();
            }
        }
    }
}
