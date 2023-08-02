using AuthImplementation.Data.Repository;
using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Model.Dtos.Response;
using AuthImplementation.Model.Entities;
using AuthImplementation.Model.Enums;
using AuthImplementation.Services.Interfaces;

namespace AuthImplementation.Services.Implementations;

public class InventoryServices : IInventoryServices
{
    private readonly IRepository<Fruit> _fruitRepo;
    private readonly IUnitOfWork _unitOfWork;

    public InventoryServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _fruitRepo = unitOfWork.GetRepository<Fruit>();
    }

    public async Task<string> Create(CreateFruitRequest request)
    {
        if(request == null) throw new ArgumentNullException(nameof(request));

        var fruit = new Fruit
        {
            Name = request.Name,
            Colour = request.Colour,
            SizeTypeId = request.SizeTypeId,
        };

        var result = _fruitRepo.Create(fruit);

        return $"{result.Name} has been created successfully";
    }

    public async Task<IEnumerable<FruitResponse>> GetAllInventoryAsync()
    {
        var fruits = _fruitRepo.GetAll(trackChanges: false)
            .Select(x => new FruitResponse
            {
                Name = x.Name,
                Colour = x.Colour,
                Size = x.SizeTypeId.ToStringValue()
            });

        if (fruits is null)
            return Enumerable.Empty<FruitResponse>();

        return fruits;
    }

    public async Task<FruitResponse> GetInventoryAsync(int id)
    {
        var fruit = _fruitRepo.FindBy(x => x.Id.Equals(id), trackChanges: false)
            .Select(x => new FruitResponse
            {
                Name = x.Name,
                Colour = x.Colour,
                Size = x.SizeTypeId.ToStringValue()
            })
             .SingleOrDefault();

        return fruit;
    }
}
