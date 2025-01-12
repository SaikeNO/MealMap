using MealMap.Application.Decorator;
using MealMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMap.Application.RecipeCreator.Creators
{
	public class DessertRecipeCreator : RecipeCreator
	{
		public override IRecipe CreateRecipe(string name)
		{
			return new Recipe(name, "Deser");
		}
	}
}
