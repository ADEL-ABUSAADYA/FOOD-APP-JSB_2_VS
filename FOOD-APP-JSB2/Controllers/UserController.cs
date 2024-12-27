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
    [TypeFilter(typeof(CustomRequestCultureProvider), Arguments = new object[] { Feature.Register })]
    public async Task<bool> Register(UserViewModel viewModel)
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
    public async Task<string> Login(LoginViewModel viewModel)
    {

        var user = viewModel.Map<UserLogInQuery>();
        var userData = await _mediator.Send(user);

        if (userData.ID != 0 && !userData.TwoFactorAuth)
        {
            return _tokenHelper.GenerateToken(userData.ID);
        }
        if (userData.ID != 0 && userData.TwoFactorAuth)
        {
            return _tokenHelper.GenerateToken(userData.ID);
        }
        return _tokenHelper.GenerateToken(userData.ID);
    }

}