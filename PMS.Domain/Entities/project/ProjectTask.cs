using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace PMS.Domain.Entities.project;

public class ProjectTask
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    [Required]
    public DateOnly EndDate { get; set; }

    [Required]
    public DateOnly DeadLine { get; set; }

    
    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public Project Project { get; set; }


    public int ProjectTaskExecutiveAgent { get; set; }
    [ForeignKey("ProjectTaskExecutiveAgent")]
    public List<ProjectTaskExecutiveAgent> ProjectTaskExecutiveAgents { get; set; }
}