using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.CQRS.Users.Commands;
using FOOD_APP_JSB_2.CQRS.Users.Queries;
using FOOD_APP_JSB_2.Data.Enums;
using FOOD_APP_JSB_2.Filters;
using FOOD_APP_JSB_2.Helpers;
using FOOD_APP_JSB_2.ViewModels.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;


namespace FOOD_APP_JSB_2.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    IMediator _mediator;
    private readonly TokenHelper _tokenHelper;

    public UserController(IMediator mediator, TokenHelper tokenHelper)
    {
        _mediator = mediator;
        _tokenHelper = tokenHelper;
    }

    [HttpPost]
    [Authorize]
    [TypeFilter(typeof(CustomRequestCultureProvider), Arguments = new object[] { Feature.Create })]
    public async Task<bool>  Create(UserViewModel viewModel)
    {
        var user = viewModel.Map<RegisterUserCommand>();
        var isAdded = await _mediator.Send(user);
        return isAdded;
    }
    
    [HttpGet]
    [Authorize]
    [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments =new object[] {Feature.GetByID})]
    public async Task<UserViewModel> GetByID(int id)
    {
        var istructor = await _mediator.Send(new GetUserByIDQuery(id));

        return istructor;
    }

    [HttpPost]
    public string Login(int userID, string password)
    {
        // check valid username and password
        // return temp Token

        return _tokenHelper.GenerateToken(2);
    }
}