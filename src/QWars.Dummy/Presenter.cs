using System;

namespace QWars.Dummy
{
    public class Presenter
    {
        protected void Log(string message)
        {
            Console.WriteLine(string.Format("{0}: {1}", GetType().Name, message));
        }
    }
}