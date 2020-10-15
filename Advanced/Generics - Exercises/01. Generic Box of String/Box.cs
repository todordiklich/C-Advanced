namespace _01._Generic_Box_of_String
{
    public class Box<T>
    {
        private T element;

        public Box(T element)
        {
            this.element = element;
        }

        public override string ToString()
        {
            return $"{element.GetType().FullName}: {element}";
        }
    }
}
