﻿using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Model.Entities;

namespace AuthImplementation.Services.Interfaces;

public interface IInventoryServices
{
    Task<string> Create(CreateFruitRequest request);
    Task<Fruit> GetInventoryAsync(int id);
    Task<IEnumerable<Fruit>> GetAllInventoryAsync();
}
