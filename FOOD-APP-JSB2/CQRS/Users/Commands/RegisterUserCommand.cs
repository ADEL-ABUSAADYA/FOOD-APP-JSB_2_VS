using System.Windows.Input;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Users.Commands;

public record RegisterUserCommand(string name) : IRequest<bool>;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    IRepository<Recipe> _repository;
    public RegisterUserCommandHandler(IRepository<Recipe> repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new Recipe { Name = request.name});
        _repository.SaveChanges();

        return Task.FromResult(true);
    }
}