using AutoMapper;
using FOOD_APP_JSB_2.CQRS.Recipes.Commands;
using FOOD_APP_JSB_2.Models;

namespace FOOD_APP_JSB_2.ViewModels.Users;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<Recipe, UserViewModel>().ReverseMap();
        CreateMap<RegisterUserCommand, UserViewModel>().ReverseMap();
    }
}