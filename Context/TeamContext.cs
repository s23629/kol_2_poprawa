using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class TeamContext : DbContext
    {
        public DbSet<File> File { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Team> Team { get; set; }




        public TeamContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<File>(e =>
            {
                e.ToTable("File");
                e.HasKey(e => e.IdFile);

                e.Property(e => e.IdTeam).IsRequired();
                e.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                e.Property(e => e.FileExtension).HasMaxLength(4).IsRequired();
                e.Property(e => e.FileSize).IsRequired();

                e.HasOne(e => e.Team).WithMany(e => e.File).HasForeignKey(e => e.IdTeam).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new File
                    {
                        IdFile = 1,
                        IdTeam = 1,
                        FileName = "xxx",
                        FileExtension = "jpg",
                        FileSize = 2
                    }
                    );
            });
            modelBuilder.Entity<Team>(e =>
            {
                e.ToTable("Team");
                e.HasKey(e => e.IdTeam);
                e.Property(e => e.IdOrganization).IsRequired();
                e.Property(e => e.TeamName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Description).HasMaxLength(500).IsRequired(false);

                e.HasOne(e => e.Organization).WithMany(e => e.Team).HasForeignKey(e => e.IdOrganization).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasMany(e => e.Membership).WithOne(e => e.Team).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(new Team
                {
                    IdTeam = 1,
                    IdOrganization = 1,
                    TeamName = "zzzzz",
                    Description = "asadasdaf"
                });

            });
            modelBuilder.Entity<Member>(e =>
            {
                e.ToTable("Member");
                e.HasKey(e => e.IdMember);
                e.Property(e => e.IdOrganization).IsRequired();
                e.Property(e => e.Name).HasMaxLength(20).IsRequired();
                e.Property(e => e.Surname).HasMaxLength(50).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(20).IsRequired(false);

                e.HasOne(e => e.Organization).WithMany(e => e.Member).HasForeignKey(e => e.IdOrganization).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasMany(e => e.Membership).WithOne(e => e.Member).HasForeignKey(e => e.IdMember).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(new Member
                {
                    IdMember = 1,
                    IdOrganization = 1,
                    Name = "aaaaa",
                    Surname = "fffff",
                    NickName = "ssss"
                });

            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.ToTable("MemberShip");
                e.HasKey(e => new { e.IdMember, e.IdTeam });
                e.Property(e => e.MembershipDate).IsRequired();

                e.HasData(new Membership
                {
                    IdMember = 1,
                    IdTeam = 1,
                    MembershipDate = DateTime.Today
                });

            });

            modelBuilder.Entity<Organization>(e =>
            {
                e.ToTable("Organization");
                e.HasKey(e => e.Id);
                e.Property(e => e.Name);
                e.Property(e => e.Domain);

                e.HasData(new Organization
                {
                    Id = 1,
                    Name = "dddd",
                    Domain = "sssss"
                });
            });

        }
    }
}

