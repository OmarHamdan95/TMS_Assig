using AjKpi.Domain.Common;

namespace AjKpi.Domain.Event;

public class LookupValueDeletedEvent : BaseEvent
{
    public LookupValueDeletedEvent(LookupValue item)
    {
        Item = item;
    }

    public LookupValue Item { get; }
}
