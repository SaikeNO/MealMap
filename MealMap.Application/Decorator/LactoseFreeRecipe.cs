using MealMap.Domain.Models;

namespace MealMap.Application.Decorator
{
    public class LactoseFreeRecipe : BaseRecipeDecorator
    {
        public LactoseFreeRecipe(IRecipe recipe) : base(recipe) { }
        public override string Emoji => $"{base.Emoji}🚫\U0001f95b ";
    }
}
