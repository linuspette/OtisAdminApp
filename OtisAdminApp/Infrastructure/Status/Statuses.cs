namespace OtisAdminApp.Infrastructure.Status;

public class Statuses
{
    public List<string> Status { get; private set; } = new List<string>();

    public Statuses()
    {
        LoadStatuses();
    }

    private void LoadStatuses()
    {
        Status.AddRange(new List<string>
        {
            "Created", "Awaiting response from Tech", "Escalated to 2nd Line Support","Escalated to 3rd Line Support", "Completed", "Awaiting spare parts"
        });
    }
}