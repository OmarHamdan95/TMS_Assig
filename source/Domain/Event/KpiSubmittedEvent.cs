namespace AjKpi.Domain.Event;

public class KpiSubmittedEvent : BaseEvent
{
    public KpiSubmittedEvent(Kpi item)
    {
        Item = item;
    }

    public Kpi Item;

}
