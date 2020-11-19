using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    var attrs = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in attrs)
                    {
                        System.Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
