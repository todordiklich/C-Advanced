namespace _07._Tuple
{
    public class Tuple<T1, T2>
    {
        private T1 firstItem;
        private T2 secondItem;

        public Tuple(T1 firstItem, T2 secondItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
        }

        public override string ToString()
        {
            return $"{firstItem} -> {secondItem}";
        }
    }
}
