using AjKpi.Domain.Common;

namespace AjKpi.Domain.Event;

public class LookupCreatedEvent : BaseEvent
{
    public LookupCreatedEvent(Lookup item)
    {
        Item = item;
    }
    public Lookup Item;
}
