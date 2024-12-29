using AjKpi.Domain.Common;

namespace AjKpi.Domain.Event;

public class LookupValueCreatedEvent : BaseEvent
{
    public LookupValueCreatedEvent(LookupValue item)
    {
        Item = item;
    }
    public LookupValue Item;
}
