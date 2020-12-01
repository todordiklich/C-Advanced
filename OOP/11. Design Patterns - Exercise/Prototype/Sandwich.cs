namespace Prototype
{
    public class Sandwich : SandwichPrototype
    {
        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            Bread = bread;
            Meat = meat;
            Cheese = cheese;
            Veggies = veggies;
        }

        public string Bread { get; set; }
        public string Meat { get; set; }
        public string Cheese { get; set; }
        public string Veggies { get; set; }


        public override SandwichPrototype Clone()
        {
            // that makes shallow copy
            return this.MemberwiseClone() as SandwichPrototype;
        }
    }
}
