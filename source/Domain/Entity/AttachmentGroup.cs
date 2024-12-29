using AjKpi.Domain.MarkarEntity;

namespace AjKpi.Domain;

public class AttachmentGroup : BaseAuditableEntity , IAggregateRoot
{
    public bool IsActive { get; set; }

    public List<Attachment> Attachments { get; set; }


    public AttachmentGroup(){}

    public AttachmentGroup(long id) => Id = id;

    public AttachmentGroup(List<Attachment> attachments)
    {
        IsActive = true;
        Attachments = attachments;
    }


    public void UpdateAttachment(List<Attachment> attachments)
    {
        Attachments = attachments;
    }
}
