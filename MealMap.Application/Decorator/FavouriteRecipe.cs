using MealMap.Domain.Interface;

namespace MealMap.Application.Decorator;

public class FavouriteRecipe : BaseRecipeDecorator
{
    public FavouriteRecipe(IRecipe recipe) : base(recipe) { }
    public override string Emoji => $"{base.Emoji}❤️ ";
}
