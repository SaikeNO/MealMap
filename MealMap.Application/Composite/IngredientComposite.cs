using MealMap.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMap.Application.Composite
{
    public class IngredientComposite : IIngredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }

        private List<IIngredient> _children = new List<IIngredient>();

        public void Add(IIngredient component)
        {
            _children.Add(component);
        }

        public void Remove(IIngredient component)
        {
            _children.Remove(component);
        }

        public IIngredient[] GetChildren()
        {
            return _children.ToArray();
        }

        public void Display()
        {
            Console.WriteLine($"Grupa: {Name}, Ilość: {Quantity}");
            foreach (var child in _children)
            {
                child.Display();
            }
        }
    }
}
