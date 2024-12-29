using AjKpi.Domain.Common;

namespace AjKpi.Domain.Event;

public class LookupDeletedEvent : BaseEvent
{
    public LookupDeletedEvent(Lookup item)
    {
        Item = item;
    }

    public Lookup Item { get; }
}
