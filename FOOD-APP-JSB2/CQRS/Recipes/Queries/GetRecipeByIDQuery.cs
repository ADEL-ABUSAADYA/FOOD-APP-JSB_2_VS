using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using FOOD_APP_JSB_2.ViewModels.Recipes;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Recipes.Queries;

public record GetRecipeByIDQuery (int ID) : IRequest<RecipeViewModel>;

public class GetRecipeByIDQueryHandler : IRequestHandler<GetRecipeByIDQuery, RecipeViewModel>
{
    IRepository<Recipe> _repository;
    IMediator _mediator;
    public GetRecipeByIDQueryHandler(IMediator mediator, IRepository<Recipe> repository)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<RecipeViewModel> Handle(GetRecipeByIDQuery request, CancellationToken cancellationToken)
    {
        // var exams = _mediator.Send(new GetExamsByInstructorIDQuery(request.ID));

        return (await _repository.GetByIDAsync(request.ID))
            .Map<RecipeViewModel>();
    }
}