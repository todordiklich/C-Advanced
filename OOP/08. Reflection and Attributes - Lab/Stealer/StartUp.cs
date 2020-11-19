using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            //spy.StealFieldInfo("Stealer.Hacker", "username", "password");

            //spy.AnalyzeAcessModifiers("Stealer.Hacker");

            //spy.RevealPrivateMethods("Stealer.Hacker");

            spy.CollectGettersAndSetters("Stealer.Hacker");
        }
    }
}
