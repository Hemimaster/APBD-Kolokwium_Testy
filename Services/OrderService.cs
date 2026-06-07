using APBD_Kolokwium.Exceptions;
using Microsoft.EntityFrameworkCore;
using APBD_Kolokwium.Data;
using APBD_Kolokwium.DTOs;

namespace APBD_Kolokwium.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<OrderDto?> GetOrderAsync(int id)
    {
        var order = await _context.Orders
            .Include(e => e.Client)
            .Include(e => e.Status)
            .Include(e => e.ProductOrders)
            .ThenInclude(e => e.Product)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (order is null)
        {
            return null;
        }

        return new OrderDto
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            FulfilledAt = order.FulfilledAt,
            Status = order.Status.Name,
            Client = new ClientInfoDto
            {
                FirstName = order.Client.FirstName,
                LastName = order.Client.LastName
            },
            Products = order.ProductOrders.Select(e => new OrderLineItemDto
            {
                Name = e.Product.Name,
                Price = e.Product.Price,
                Amount = e.Amount
            }).ToList()
        };
    }

    public async Task FulfillOrderAsync(int id, FulfillOrderDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.StatusName))
        {
            throw new BadRequestException("Status name is required.");
        }

        await using var transaction = await _context.Database.BeginTransactionAsync();

        var order = await _context.Orders
            .Include(e => e.ProductOrders)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (order is null)
        {
            throw new NotFoundException($"Order with id {id} was not found.");
        }

        if (order.FulfilledAt is not null)
        {
            throw new ConflictException("Order is already fulfilled.");
        }

        var status = await _context.Statuses
            .FirstOrDefaultAsync(e => e.Name == dto.StatusName);

        if (status is null)
        {
            throw new NotFoundException($"Status {dto.StatusName} was not found.");
        }

        order.StatusId = status.Id;
        order.FulfilledAt = DateTime.Now;

        _context.ProductOrders.RemoveRange(order.ProductOrders);

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
    }
}