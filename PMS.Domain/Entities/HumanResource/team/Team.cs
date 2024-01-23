﻿using System.ComponentModel.DataAnnotations;
using PMS.Domain.Entities.project;

namespace PMS.Domain.Entities.HumanResource.team;

public class Team
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string? Name { get; set; }


    public List<TeamMember> TeamMembers { get; set; }


}