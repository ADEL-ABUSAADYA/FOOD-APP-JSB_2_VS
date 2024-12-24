using System.Windows.Input;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Recipes.Commands;

public record AddRecipeCommand(string name) : IRequest<bool>;

public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, bool>
{
    IRepository<Recipe> _repository;
    public AddRecipeCommandHandler(IRepository<Recipe> repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new Recipe { Name = request.name});
        _repository.SaveChanges();

        return Task.FromResult(true);
    }
}