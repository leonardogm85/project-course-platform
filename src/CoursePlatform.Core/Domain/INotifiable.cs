using CoursePlatform.Core.Messages;

namespace CoursePlatform.Core.Domain;

public interface INotifiable
{
    IReadOnlyCollection<Event> GetEvents();
    bool HasEvents();
    void AddEvent(Event @event);
    void RemoveEvent(Event @event);
    void ClearEvents();
}
