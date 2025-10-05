namespace WebApplication1.Domain.Entities.UserDepartament;

public class Departament
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public int TotalMembers { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public Departament() { }

    public Departament(string name, int totalMembers, bool isActive)
    {
        Id = Guid.NewGuid();
        Name = name;
        TotalMembers = totalMembers;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
    }
}
