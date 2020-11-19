using System;
using System.Linq;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        public void StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(classToInvestigate);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            var classInstance = Activator.CreateInstance(classType);

            Console.WriteLine($"Class under investigation: {classType}");

            foreach (var field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                Console.WriteLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
        }

        public void AnalyzeAcessModifiers(string className)
        {
            Type type = Type.GetType(className);

            // inspect fields
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            foreach (var field in fields)
            {
                Console.WriteLine($"{field.Name} must be private!");
            }

            // inspect getters
            var getters = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var getter in getters.Where(m => m.Name.StartsWith("get")))
            {
                Console.WriteLine($"{getter.Name} have to be public!");
            }

            // inspect setters
            var setters = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (var setter in setters.Where(m => m.Name.StartsWith("set")))
            {
                Console.WriteLine($"{setter.Name} have to be private!");
            }
        }

        public void RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);

            Console.WriteLine($"All Private Methods of Class: {className}");
            Console.WriteLine($"Base Class: {type.BaseType}");

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                Console.WriteLine($"{method.Name}");
            }
        }

        public void CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var getter in methods.Where(m => m.Name.StartsWith("get")))
            {
                Console.WriteLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (var setter in methods.Where(m => m.Name.StartsWith("set")))
            {
                Console.WriteLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }
        }
    }
}
