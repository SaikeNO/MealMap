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
		public override Recipe CreateRecipe(string name)
		{
			return new Recipe(name, "Dessert");
		}
	}
}
