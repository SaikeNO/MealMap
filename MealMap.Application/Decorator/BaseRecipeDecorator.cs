using MealMap.Application.Decorator;

namespace MealMap.Domain.Models
{
    public abstract class BaseRecipeDecorator : IRecipe
    {
        protected IRecipe wrappee;

        public BaseRecipeDecorator(IRecipe recipe)
        {
            wrappee = recipe;
        }

        public override string ToString()
        {
            return $"{Name} {Emoji}".Trim();
        }

        public virtual string Name { get => wrappee.Name; set => wrappee.Name = value; }
        public virtual string Description { get => wrappee.Description; set => wrappee.Description = value; }
        public virtual string Category { get => wrappee.Category; set => wrappee.Category = value; }
        public virtual List<Ingredient> Ingredients { get => wrappee.Ingredients; set => wrappee.Ingredients = value; }
        public virtual string Instructions { get => wrappee.Instructions; set => wrappee.Instructions = value; }
        public virtual int Calories { get => wrappee.Calories; set => wrappee.Calories = value; }
        public virtual double Protein { get => wrappee.Protein; set => wrappee.Protein = value; }
        public virtual double Fat { get => wrappee.Fat; set => wrappee.Fat = value; }
        public virtual double Carbs { get => wrappee.Carbs; set => wrappee.Carbs = value; }

        public virtual string Emoji => wrappee is BaseRecipeDecorator decorator ? decorator.Emoji : string.Empty;

        public virtual void AddIngredient(Ingredient ingredient) => wrappee.AddIngredient(ingredient);
        public virtual void RemoveIngredient(Ingredient ingredient) => wrappee.RemoveIngredient(ingredient);
        public virtual void EditIngredient(Ingredient ingredient) => wrappee.EditIngredient(ingredient);
        public virtual List<Ingredient> GetIngredients() => wrappee.GetIngredients();
    }
}
