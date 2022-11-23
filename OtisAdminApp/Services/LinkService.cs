namespace OtisAdminApp.Services;

public interface ILinkService
{
    //Elevators
    public string ShowElevators();
    public string ShowElevatorInformationPage(string deviceId);

    //Errands
    public string ViewErrands();
    public string ViewErrand(string errandNumber);
    public string AddErrand();

    //Employees
    public string ViewEmployees();
    public string AddEmployee();
}
public class LinkService : ILinkService
{
    //Elevator links
    public string ShowElevators()
    {
        return "./elevators/view";
    }
    public string ShowElevatorInformationPage(string deviceId)
    {
        return $"./Elevators/Elevator/view/{deviceId}";
    }

    //Errand links
    public string ViewErrands()
    {
        return "./errands/view";
    }

    public string ViewErrand(string errandNumber)
    {
        return $"./errands/errand/view/{errandNumber}";
    }
    public string AddErrand()
    {
        return "./errands/add";
    }
    //Employee links
    public string ViewEmployees()
    {
        return "./employees/view";
    }
    public string AddEmployee()
    {
        return "./employees/add";
    }
}