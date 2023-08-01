using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TMS_API.Models;
using TMS_API.Models.Dto;
using TMS_API.Repository;

namespace TMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategoryRepository, IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();
            var dtoOrders = _mapper.Map<List<OrderDto>>(orders);

            return Ok(dtoOrders);

        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var @o = await _orderRepository.GetById(id);

            if (@o == null)
            {
                return NotFound();
            }

            var dtoOrders = _mapper.Map<OrderDto>(@o);

            return Ok(dtoOrders);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(orderPatch, orderEntity);
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var eventEntity = await _orderRepository.GetById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            _orderRepository.Delete(eventEntity);
            return NoContent();
        }

    
        [HttpPost]
        public async Task<ActionResult> Add(OrderPostDto @orderPostDto)
        {
            TicketCategory ticketCategory = await _ticketCategoryRepository.GetById(@orderPostDto.TicketCategoryId);
            User user = await _userRepository.GetById(@orderPostDto.UserId);
            if (ticketCategory == null || user == null)
            {
                return NotFound();
            }
            float totalPrice = orderPostDto.NumberOfTickets * ticketCategory.Price;

            if (totalPrice == null)
            {
                return NotFound();
            }

            var addedOrder = _mapper.Map<Order>(@orderPostDto);
            _orderRepository.Add(addedOrder);
            return Ok(addedOrder);
        }
        
    }
}
