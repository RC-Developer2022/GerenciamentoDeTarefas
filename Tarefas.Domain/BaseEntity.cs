using Flunt.Notifications;

namespace Tarefas.Domain;

public abstract class BaseEntity : Notifiable<Notification>
{
    public BaseEntity()
    {
        
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

}
