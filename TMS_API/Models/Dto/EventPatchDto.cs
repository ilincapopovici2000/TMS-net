namespace TMS_API.Models.Dto;

public class EventPatchDto
{
    public long EventId { get; set; }

    public DateTime? EndDate { get; set; }

    public string? EventDescription { get; set; }
}
