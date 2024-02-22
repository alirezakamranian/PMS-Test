namespace ProjectManagementSystem.DtoObjects.Projects;

public class CreateProjectDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime DeadLine { get; set; }

    public string Status { get; set; }
}