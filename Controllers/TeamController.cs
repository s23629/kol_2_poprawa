using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WebApplication1.DTOs;
using WebApplication1.Models;
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

        [HttpPost]
        public async Task<IActionResult> AddMember(MemberPut body) {
            if (!ModelState.IsValid)
                return BadRequest("Niepoprawne ciało żądania!");

            var result = await _service.GetTeamById(body.IdTeam).FirstOrDefaultAsync();
            var result1 = await _service.GetMemberById(body.Id).FirstOrDefaultAsync();

            if (result == null) return NotFound("nie ma takiego teamu");
            if (result1 == null) return NotFound("nie ma takiego członka");

            if (result1.Organization.Id != result.Organization.Id) return Conflict();
            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var member = new Membership
                    {
                        IdMember = body.Id,
                        IdTeam = body.IdTeam
                    };

                    await _service.CreateAsync(member);
                    await _service.SaveChangesAsync();

                }
            }
            catch (Exception) {
                return Problem();
            }
            return NoContent();

        }
    }
}
