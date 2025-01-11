using MealMap.Application.Decorator;

namespace MealMap.Domain.Models
{
    public class FavouriteRecipe : BaseRecipeDecorator
    {
        public FavouriteRecipe(IRecipe recipe) : base(recipe) { }
        public override string Emoji => $"{base.Emoji}❤️";
    }
}
