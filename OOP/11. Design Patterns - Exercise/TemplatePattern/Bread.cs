namespace TemplatePattern
{
    public abstract class Bread
    {
        public abstract void MixIngredients();
        public abstract void Bake();
        public virtual void Slice()
        {
            System.Console.WriteLine($"Slicing: {GetType().Name}");
        }

        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}
