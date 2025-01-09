using MealMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMap.Application.Decorator
{
    public class SpicyRecipe : BaseRecipeDecorator
    {
        public SpicyRecipe(IRecipe recipe) : base(recipe) { }
        public override string Emoji => $"{base.Emoji}🌶 ";
    }
}
