﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Authentication.ExtendedProtection;

namespace PMS.Domain.Entities.HumanResource.team;

public class TeamMember
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string? Role { get; set; }

    public int TeamId { get; set; }
    [ForeignKey("TeamId")]
    public Team Team { get; set; }

    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }

    public List<TeamMemberTask> TeamMemberTasks { get; set; }

}