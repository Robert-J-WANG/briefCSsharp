namespace ConsoleApp_basic;


public delegate void NotifyDelegate(string message);

public class DeliveryMan
{
    private NotifyDelegate Notify;

    public void SetNotify(NotifyDelegate notify)
    {
        Notify = notify;
    }
    
    public void ReachDoor()
    {
        if (Notify != null)
        {
            Notify("我到门口了");
        }
    }
}