namespace SingletonDemo.Models
{
    public static class StaticDemo
    {
        private static int number;
        public static string Property => "Static Property";
        public static int Number 
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
    }
}
