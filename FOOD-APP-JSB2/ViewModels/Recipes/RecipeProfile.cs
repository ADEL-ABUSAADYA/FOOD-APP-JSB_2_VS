using AutoMapper;
using FOOD_APP_JSB_2.CQRS.Recipes.Commands;
using FOOD_APP_JSB_2.Models;

namespace FOOD_APP_JSB_2.ViewModels.Recipes;

public class RecipeProfile: Profile
{
    public RecipeProfile()
    {
        CreateMap<Recipe, RecipeViewModel>().ReverseMap();
        CreateMap<AddRecipeCommand, RecipeViewModel>().ReverseMap();
    }
}