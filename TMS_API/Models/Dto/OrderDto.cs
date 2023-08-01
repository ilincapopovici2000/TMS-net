namespace TMS_API.Models.Dto
{
    public class OrderDto
    {
        public long OrderId { get; set; }

        public int? NumberOfTickets { get; set; }

        public DateTime? OrderedAt { get; set; }

        public float? TotalPrice { get; set; }

        public long? TicketCategoryId { get; set; }

        public long? UserId { get; set; }

        public virtual TicketCategory? TicketCategory { get; set; }

        public virtual User? User { get; set; }
    }
}
