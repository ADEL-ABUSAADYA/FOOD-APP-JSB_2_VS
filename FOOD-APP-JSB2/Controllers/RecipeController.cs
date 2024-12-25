using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.CQRS.Recipes.Commands;
using FOOD_APP_JSB_2.CQRS.Recipes.Queries;
using FOOD_APP_JSB_2.Data.Enums;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Helpers;
using FOOD_APP_JSB_2.Models;
using FOOD_APP_JSB_2.ViewModels.Recipes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;


namespace FOOD_APP_JSB_2.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class RecipeController : ControllerBase
{
    IMediator _mediator;
    private readonly TokenHelper _tokenHelper;

    public RecipeController(IMediator mediator, TokenHelper tokenHelper)
    {
        _mediator = mediator;
        _tokenHelper = tokenHelper;
    }

    [HttpPost]
    [Authorize]
    [TypeFilter(typeof(CustomRequestCultureProvider), Arguments = new object[] { Feature.Create })]
    public async Task<bool>  Create(UsserViewModel viewModel)
    {
        var recipe = viewModel.Map<RegisterUserCommand>();
        var isAdded = await _mediator.Send(recipe);
        return isAdded;
    }
    
    [HttpGet]
    [Authorize]
    [TypeFilter(typeof(CustomRequestCultureProvider), Arguments =new object[] {Feature.GetByID})]
    public async Task<UsserViewModel> GetByID(int id)
    {
        var istructor = await _mediator.Send(new GetUserByIDQuery(id));

        return istructor;
    }

    [HttpPost]
    public string Login(int userID, string password, Role role)
    {
        // check valid username and password
        // return temp Token

        return _tokenHelper.GenerateToken(1, password, role);
    }
}