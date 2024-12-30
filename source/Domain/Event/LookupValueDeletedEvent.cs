using TMS.Domain.Common;

namespace TMS.Domain.Event;

public class LookupValueDeletedEvent : BaseEvent
{
    public LookupValueDeletedEvent(LookupValue item)
    {
        Item = item;
    }

    public LookupValue Item { get; }
}
