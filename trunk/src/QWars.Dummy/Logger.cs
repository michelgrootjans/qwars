using System;

namespace QWars.Dummy
{
    public class Logger
    {
        private readonly object master;

        public Logger(object master)
        {
            this.master = master.GetType().Name;
        }

        protected internal void Log(string message)
        {
            Console.WriteLine(string.Format("{0}: {1}", master, message));
        }
    }
}