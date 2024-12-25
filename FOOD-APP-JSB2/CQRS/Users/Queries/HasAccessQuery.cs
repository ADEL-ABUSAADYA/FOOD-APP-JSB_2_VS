using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.Data.Enums;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using FOOD_APP_JSB_2.ViewModels.Recipes;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Users.Queries;

public record HasAccessQuery (int ID, Feature Feater) : IRequest<bool>;

public class HasAccessQueryHandler : IRequestHandler<HasAccessQuery, bool>
{
    IRepository<UserFeature> _repository;
    IMediator _mediator;
    public HasAccessQueryHandler(IMediator mediator, IRepository<UserFeature> repository)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<bool> Handle(HasAccessQuery request, CancellationToken cancellationToken)
    {
        var hasFeature = await _repository.AnyAsync(
             uf => uf.UserID == request.ID && uf.Feature.);

        return hasFeature;
    }

 
}