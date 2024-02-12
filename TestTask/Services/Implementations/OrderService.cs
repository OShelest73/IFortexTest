﻿using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> GetOrder()
    {
        var order = await _dbContext.Orders
            .OrderByDescending(o => o.Price)
            .FirstOrDefaultAsync();

        return order;
    }

    public async Task<List<Order>> GetOrders()
    {
        var orders = await _dbContext.Orders.Where(o => o.Quantity > 10).ToListAsync();

        return orders;
    }
}
