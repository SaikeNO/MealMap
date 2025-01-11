using MealMap.Domain.Models;

namespace MealMap.Application.Decorator
{
    public class VeganRecipe : BaseRecipeDecorator
    {
        public VeganRecipe(IRecipe recipe) : base(recipe) { } 
        public override string Emoji => $"{base.Emoji}🌱";
    }
}
