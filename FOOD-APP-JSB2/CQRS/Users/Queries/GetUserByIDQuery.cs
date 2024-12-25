using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using FOOD_APP_JSB_2.ViewModels.Users;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Users.Queries;

public record GetUserByUserIDQuery (int ID) : IRequest<UserViewModel>;

public class GetUserByIDQueryHandler : IRequestHandler<GetUserByUserIDQuery, UserViewModel>
{
    IRepository<Recipe> _repository;
    IMediator _mediator;
    public GetUserByIDQueryHandler(IMediator mediator, IRepository<Recipe> repository)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<UserViewModel> Handle(GetUserByUserIDQuery request, CancellationToken cancellationToken)
    {
        // var exams = _mediator.Send(new GetExamsByInstructorIDQuery(request.ID));

        return (await _repository.GetByIDAsync(request.ID))
            .Map<UserViewModel>();
    }
}