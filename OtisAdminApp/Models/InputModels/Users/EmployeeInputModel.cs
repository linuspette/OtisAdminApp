using System.ComponentModel.DataAnnotations;

namespace OtisAdminApp.Models.InputModels.Users;

public class EmployeeInputModel
{
    [Range(0, 99999)]
    public int EmployeeNumber { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string FullName { get; private set; } = null!;

    public void SetFullName()
    {
        FullName = $"{FirstName} {LastName}";
    }
}