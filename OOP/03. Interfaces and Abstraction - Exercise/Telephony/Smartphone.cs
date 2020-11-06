namespace Telephony
{
    class Smartphone : ICallable, ISearchable
    {
        public string Call(string number)
        {
            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }
    }
}
