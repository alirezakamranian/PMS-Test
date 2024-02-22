using Microsoft.EntityFrameworkCore;
using System;
using PMS.Domain.Entities.HumanResource.team;
using PMS.Domain.Entities.HumanResource;
using PMS.Domain.Entities.project;

namespace DataAccess.Context;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }

    //Project entities
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectManagement> ProjectManagements { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<ProjectTaskExecutiveAgent> ProjectTaskExecutiveAgents { get; set; }

    //HumanResources entities
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
   




    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<TeamMemberTask>()
    //        .HasOne(e => e.TeamMember)
    //        .WithMany(e => e.TeamMemberTasks)
    //        .HasForeignKey(e => e.TeamMemberId)
    //        ;
    //}
}