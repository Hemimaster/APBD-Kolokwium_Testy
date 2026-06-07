using APBD_Kolokwium.DTOs;
using APBD_Kolokwium.Exceptions;
using APBD_Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Kolokwium.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _orderService.GetOrderAsync(id);

        if (order is null)
        {
            return NotFound($"Order with id {id} was not found.");
        }

        return Ok(order);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> FulfillOrder(int id, FulfillOrderDto dto)
    {
        try
        {
            await _orderService.FulfillOrderAsync(id, dto);
            return Ok("Order fulfilled successfully.");
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
}