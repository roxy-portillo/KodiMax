using System;
using System.Collections.Generic;

namespace Proyecto_POO
{
    class Login : User
    {
        public string UserName { get; set; }
        public new string Password { get; set; }
        public List<User> users = new List<User>();
        private string KodimaxID = "KGD5JD6-MAX";
        private bool Verified;

        public Login()
        {

        }

        public void EmployeesDatabase()
        {
            Employee employee1 = new Employee("0dl1", "Diana", "Lopez", "dianalopez@kodimax.com", "79854213", "F", "22/08/1987", "dl01-max", "01max");
            users.Add(employee1);
            Employee employee2 = new Employee("0jh2", "Jonathan", "Henriquez", "jonathanhenriquez@kodimax.com", "76423789", "M", "11/04/1992", "jh02-max", "02max");
            users.Add(employee2);
            Admin admin = new Admin("Raquel", "Benitez", "raquelbenitez@kodimax.com", "71843293", "F", "05/02/1975", "admin-max", "@dminM@x");
            users.Add(admin);
            //For testing
            User myUser = new User("Roxy", "Salguero", "roxys@gmail.com", "74102489", "F", "20/11/1998", "roxy221", "roxy");
            users.Add(myUser);
        }

        public void userLogin()
        {
            EmployeesDatabase();
            Console.Clear();
            Console.WriteLine("\nLogin\n");
            Console.Write("Usuario: ");
            UserName = Console.ReadLine();
            Console.Write("Contraseña: ");
            Password = Console.ReadLine();

            foreach (User u in users)
            {
                //check if it is in list
                if (UserName == u.Username && Password == u.Password)
                {
                    Verified = true;
                    break;
                }
                else
                {
                    Verified = false;
                }
            }
            Console.WriteLine("\nVerificando usuario...");
            if (Verified == true)
            {
                Console.WriteLine("\nUsuario verificado");
                Console.ReadKey();
                if (UserName.Equals("admin-max"))
                {
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.Print();
                }
                else if (UserName.Contains("-max"))
                {
                    EmployeeMenu employeeMenu = new EmployeeMenu();
                    employeeMenu.Print();
                }
                else
                {
                    UserMenu userMenu = new UserMenu();
                    userMenu.Print();
                }
            }
            else
            {
                Console.WriteLine("\nUsuario o contraseña no validos.\n 1. Intentelo de nuevo\n 2. Registrese");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    userLogin();
                }
                else if (option == "2")
                {
                    Register();
                }
            }
        }

        public void Register()
        {
            Console.Clear();
            Console.WriteLine("Registrarse\n");
            Console.Write("Nombres: ");
            string names = Console.ReadLine();
            Console.Write("Apellidos: ");
            string lastNames = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Numero de Telefono: ");
            string phone = Console.ReadLine();
            Console.Write("Sexo: ");
            string sex = Console.ReadLine();
            Console.Write("Fecha de Nacimiento: ");
            string birth = Console.ReadLine();
            Console.Write("Usuario: ");
            string username = Console.ReadLine();
            //check for user
            foreach (User u in users)
            {
                if (username == u.Username)
                {
                    Console.WriteLine("Ese nombre de usuario ya existe, por favor elige otro");
                    Console.Write("\n Usuario: ");
                    username = Console.ReadLine();
                }
            }

            Console.Write("Contraseña: ");
            string password = Console.ReadLine();
            User newUser = new User(names, lastNames, email, phone, sex, birth, username, password);
            users.Add(newUser);
            Console.Write("\n(Solo para emplados) KODIMAX ID: \n 1. Ingresar\n 2. Saltar\n");
            string IdOption = Console.ReadLine();
            if (IdOption == "1")
            {
                Console.Write("\nKODIMAX ID: ");
                string id = Console.ReadLine();
                Console.WriteLine("\nVerificando ID...\n");
                if (id == KodimaxID)
                {
                    Console.WriteLine("ID valido! Registrado como empleado\n");
                    users.Add(newUser);
                    Console.ReadKey();
                    userLogin();
                }
                else
                {
                    Console.WriteLine("ID No valido\n");
                    Console.WriteLine("\nRegistrando como usuario...\n");
                    users.Add(newUser);
                    Console.WriteLine("Registro exitoso!\n\n Su usuario es: {0}\n Su contraseña es: {1}", username, password);
                    Console.ReadKey();
                    userLogin();
                }
            }
            else
            {
                Console.WriteLine("\nRegistrando usuario...\n");
                users.Add(newUser);
                Console.WriteLine("Registro exitoso!\n\n Su usuario es: {0}\n Su contraseña es: {1}", username, password);
                Console.ReadKey();
                userLogin();
            }
        }
    }
}
