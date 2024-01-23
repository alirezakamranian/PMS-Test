using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Domain.Entities.project;

public class ProjectManagement
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string? ManagementRole { get; set; }




    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public Project Project { get; set; }
}