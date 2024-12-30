using TMS.Domain.Common;

namespace TMS.Domain.Event;

public class LookupValueCreatedEvent : BaseEvent
{
    public LookupValueCreatedEvent(LookupValue item)
    {
        Item = item;
    }
    public LookupValue Item;
}
