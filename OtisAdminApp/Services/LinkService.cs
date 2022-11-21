namespace OtisAdminApp.Services;

public interface ILinkService
{
    public string ShowElevatorInformationPage(string deviceId);
}
public class LinkService : ILinkService
{
    public string ShowElevatorInformationPage(string deviceId)
    {
        return $"/Elevators/View/{deviceId}";
    }
}