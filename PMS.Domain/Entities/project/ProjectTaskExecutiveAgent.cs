using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Domain.Entities.project;

public class ProjectTaskExecutiveAgent
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string? Role { get; set; }


    public int ProjectTaskId { get; set; }
    [ForeignKey("ProjectTaskId")]
    public ProjectTask ProjectTask { get; set; }
}