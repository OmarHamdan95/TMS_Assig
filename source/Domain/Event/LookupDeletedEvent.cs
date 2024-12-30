using TMS.Domain.Common;

namespace TMS.Domain.Event;

public class LookupDeletedEvent : BaseEvent
{
    public LookupDeletedEvent(Lookup item)
    {
        Item = item;
    }

    public Lookup Item { get; }
}
