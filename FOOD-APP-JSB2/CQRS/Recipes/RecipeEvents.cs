using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Recipes;

public record RecipeRemoved(int ID) : INotification;
public record RecipeAdedd(int ID) : INotification;