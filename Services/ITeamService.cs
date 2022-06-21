using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ITeamService
    {
        IQueryable<Team> GetTeam(int id);
        IQueryable<Team> GetTeamById(int id);
        Task CreateAsync<T>(T entity) where T : class;
        IQueryable<Member> GetMemberById(int id);
        Task SaveChangesAsync();

    }
}
