using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using FOOD_APP_JSB_2.ViewModels.Recipes;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.UserFeatures.Queries;

public record HasAccessQuery (int ID, ) : IRequest<bool>;

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
        // var exams = _mediator.Send(new GetExamsByInstructorIDQuery(request.ID));

        return (await _repository.GetByIDAsync(request.ID))
            .Map<UsserViewModel>();
    }

 
}