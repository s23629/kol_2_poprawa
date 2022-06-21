using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TeamService : ITeamService
    {

        private readonly TeamContext _context;

        public TeamService(TeamContext context)
        {
            _context = context;
        }

        public IQueryable<Team> GetTeam(int id)
        {
            return _context.Team.Where(e => e.IdTeam == id).Include(e => e.Membership).ThenInclude(e => e.Member);
        }

        public IQueryable<Team> GetTeamById(int id)
        {
            return _context.Team.Where(e => e.IdTeam == id).Include(e => e.Organization);
        }

    }
}
