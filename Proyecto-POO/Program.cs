using System;
using System.Collections.Generic;

namespace Proyecto_POO
{
    class Program
    {     
        static void Main(string[] args)
        {
            Console.WriteLine("KODIMAX\n-------------------------");
            Console.WriteLine("1. Iniciar sesion\n2. Registrarse");
            string startScreen = Console.ReadLine();          
            Login login = new Login();
            switch (startScreen)
            {
                case "1":
                    login.userLogin();
                    break;

                case "2":
                    login.Register();
                    break;
            }
        }
    }
}
