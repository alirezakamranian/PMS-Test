using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Domain.Entities.project;

public class Project
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string? Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    [Required]
    public DateOnly EndDate { get; set; }

    [Required]
    public DateOnly DeadLine { get; set; }

    public string? Status { get; set; }


    public List<ProjectTask> ProjectTasks { get; set; }

    public ProjectManagement ProjectManagement { get; set; }
}