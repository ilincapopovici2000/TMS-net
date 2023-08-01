namespace TMS_API.Models.Dto
{
    public class OrderPostDto
    {

        public int NumberOfTickets { get; set; }

        public long TicketCategoryId { get; set; }

        public long UserId { get; set; }
    }
}
