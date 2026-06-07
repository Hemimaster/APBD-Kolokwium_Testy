using APBD_Kolokwium.DTOs;

namespace APBD_Kolokwium.Services;

public interface IOrderService
{
    Task<OrderDto?> GetOrderAsync(int id);

    Task FulfillOrderAsync(int id, FulfillOrderDto dto);
}