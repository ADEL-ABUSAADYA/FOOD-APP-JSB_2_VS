using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using FOOD_APP_JSB_2.ViewModels.Users;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Users.Queries;

public record UserLogInQuery(string email, string password) : IRequest<(int ID, bool TwoFactorAuth)>;

public class UserLogInQueryHandler : IRequestHandler<UserLogInQuery, (int ID, bool TwoFactorAuth)>
{
    IUserRepository _repository;

    public UserLogInQueryHandler(IMediator mediator, IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<(int ID, bool TwoFactorAuth)> Handle(UserLogInQuery request, CancellationToken cancellationToken)
    {
        var userData = await _repository.LogInUser(request.email, request.password);
        
        return userData;
    }
}