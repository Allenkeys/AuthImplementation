using AuthImplementation.Data.Repository;
using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Model.Entities;
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

    public async Task<IEnumerable<Fruit>> GetAllInventoryAsync()
    {
        var fruits = _fruitRepo.GetAll(trackChanges: false);
        return fruits;
    }

    public async Task<Fruit> GetInventoryAsync(string id)
    {
        var fruit = _fruitRepo.FindBy(x => x.Id.Equals(id), trackChanges: false).SingleOrDefault();
        return fruit;
    }
}
