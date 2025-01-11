using MealMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealMap.Application.Builder;

namespace MealMap.Application.Builder
{
    public class MealPlanBuilder : IMealPlanBuilder
    {
        private MealPlan _mealPlan = new MealPlan();

        public IMealPlanBuilder SetMealTime(string time)
        {
            _mealPlan.MealTime = time;
            return this;
        }

        public IMealPlanBuilder SetDateTime(string date)
        {
            if (DateTime.TryParse(date, out var parsedDate))
            {
                _mealPlan.DateTime = parsedDate;
            }
            else
            {
                throw new ArgumentException("Nieprawidłowy format daty.");
            }
            return this;
        }

        public IMealPlanBuilder AddMeal(Recipe recipe)
        {
            _mealPlan.AddMeal(recipe);
            return this;
        }

        public MealPlan Build()
        {
            var result = _mealPlan;
            _mealPlan = new MealPlan(); // Resetowanie stanu
            return result;
        }
    }
}
