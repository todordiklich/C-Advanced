using System;

namespace TemplatePattern
{
    public class WhiteBread : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking White bread");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing infredients for White bread");
        }
    }
}
