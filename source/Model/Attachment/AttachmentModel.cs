namespace AjKpi.Model;

public class AttachmentModel
{
    public AttachemntGroupModel? AttachmentGroup { get; init; }
    public long? AttachmentGroupId { get; init; }
    public string? FileKey { get; init; }
    public long? FileSize { get; init; }
    public string? FileName { get; init; }
    public string? EntityCode { get; init; }
    public string? FilePath { get; init; }
}
