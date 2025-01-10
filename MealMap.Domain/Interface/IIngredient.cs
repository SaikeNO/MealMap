using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMap.Domain.Interface
{
    public interface IIngredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }

        void Display();
    }

}
