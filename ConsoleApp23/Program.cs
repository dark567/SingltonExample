using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingltonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Launch("Admin");
            Console.WriteLine(user.Login.Name);

            // у нас не получится изменить Login, так как объект уже создан    
            user.Login = Singleton.getInstance("Manager");
            Console.WriteLine(user.Login.Name);

            Console.ReadLine();
        }
    }
    class User
    {
        public Singleton Login { get; set; }
        public void Launch(string osName)
        {
            Login = Singleton.getInstance(osName);
        }
    }

    class Singleton
    {
        private static Singleton instance;
        private static object syncRoot = new Object();

        public string Name { get; private set; }

        protected Singleton(string name)
        {
            this.Name = name;
        }

        public static Singleton getInstance(string name)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Singleton(name);
                }
            }
            return instance;
        }
    }
}
