namespace AjKpi.Domain;

public class Attachment : BaseAuditableEntity
{
    public AttachmentGroup AttachmentGroup { get; set; }
    public long? AttachmentGroupId { get; set; }
    public string? FileKey { get; set; }
    public long? FileSize { get; set; }
    public string? FileName { get; set; }
    public string? EntityCode { get; set; }
    public string? FilePath { get; set; }

}
