using MealMap.Domain.Interface;

namespace MealMap.Application.Decorator;

public class SpicyRecipe : BaseRecipeDecorator
{
    public SpicyRecipe(IRecipe recipe) : base(recipe) { }
    public override string Emoji => $"{base.Emoji}🌶 ";
}
