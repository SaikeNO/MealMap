﻿using MealMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMap.Application.RecipeCreator
{
	public abstract class RecipeCreator
	{
		public abstract Recipe CreateRecipe(string name);
	}
}