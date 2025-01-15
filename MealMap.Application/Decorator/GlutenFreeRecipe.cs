using MealMap.Domain.Interface;

namespace MealMap.Application.Decorator;

public class GlutenFreeRecipe : BaseRecipeDecorator
{
    public GlutenFreeRecipe(IRecipe recipe) : base(recipe) { }
    public override string Emoji => $"{base.Emoji}🚫🍞 ";
}
