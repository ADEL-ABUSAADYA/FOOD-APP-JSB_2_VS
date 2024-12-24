using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.CQRS.Recipes.Commands;
using FOOD_APP_JSB_2.CQRS.Recipes.Queries;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using FOOD_APP_JSB_2.ViewModels.Recipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FOOD_APP_JSB_2.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class RecipeController : ControllerBase
{
    IMediator _mediator;

    public RecipeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<bool>  Create(RecipeViewModel viewModel)
    {
        var recipe = viewModel.Map<AddRecipeCommand>();
        var isAdded = await _mediator.Send(recipe);
        return isAdded;
    }
    
    [HttpGet]
    public async Task<RecipeViewModel> GetByID(int id)
    {
        var istructor = await _mediator.Send(new GetRecipeByIDQuery(id));

        return istructor;
    }
}