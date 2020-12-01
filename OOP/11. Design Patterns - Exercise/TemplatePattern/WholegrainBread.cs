using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class WholegrainBread : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking Wholegrain bread");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing infredients for Wholegrain bread");
        }
    }
}
