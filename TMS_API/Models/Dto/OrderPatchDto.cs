namespace TMS_API.Models.Dto
{
    public class OrderPatchDto
    {
        public long OrderId { get; set; }

        public int? NumberOfTickets { get; set; }

        public DateTime? OrderedAt { get; set; }

        public long? TicketCategoryId { get; set; }
    }
}
