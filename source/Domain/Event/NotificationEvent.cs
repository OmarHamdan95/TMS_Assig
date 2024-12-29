namespace AjKpi.Domain.Event;

public class NotificationEvent<T> : INotification
{
    public NotificationEvent()
    {

    }
    public NotificationEvent(T item)
    {
        Item = item;
    }

    public T? Item { get; }
    public string? Email { get; set; }
    public string? EmailCc { get; set; }
    public string? TemplateTypeCode { get; set; }
    public string? LanguageCode { get; set; }
    public string? NotificationTypeCode { get; set; }
}
