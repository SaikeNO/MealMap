using MealMap.Domain.Interface;

namespace MealMap.Application.Decorator;

public class VeganRecipe : BaseRecipeDecorator
{
    public VeganRecipe(IRecipe recipe) : base(recipe) { } 
    public override string Emoji => $"{base.Emoji}🌱";
}
