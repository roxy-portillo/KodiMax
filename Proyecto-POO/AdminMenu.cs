using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Proyecto_POO
{
    class AdminMenu : IMenu
    {
        private string Option;
        MovieListings movieListings = new MovieListings();
        CandyShop candyShop = new CandyShop();
        TicketOffice ticketOffice = new TicketOffice();
        Login login = new Login();

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("KODIMAX - ADMINISTRADOR\n*****************************");
            Console.WriteLine("1. Crear o eliminar empleados\n2. Eliminar usuarios\n3. Modificar Cartelera\n4. Modificar Tienda de Golosinas\n5. Reportes\n6. Salir\n");
            Console.WriteLine("Ingresa una opción:");
            Option = Console.ReadLine();
            NavigateMenu();
        }

        public void NavigateMenu()
        {
            switch (Option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("\n1. Crear empleado\n2. Eliminar empleado\n");
                    int optionc1 = int.Parse(Console.ReadLine());
                    if (login.users.Count == 0)
                    {
                        login.EmployeesDatabase();
                    }
                    switch (optionc1)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Ingresar ID:");
                            string id = Console.ReadLine();
                            Console.WriteLine("Ingresar Nombres:");
                            string names = Console.ReadLine();
                            Console.WriteLine("Ingresar Apellidos:");
                            string lastNames = Console.ReadLine();
                            Console.WriteLine("Ingresar Email:");
                            string email = Console.ReadLine();
                            Console.WriteLine("Ingresar Telefono:");
                            string phoneNumber = Console.ReadLine();
                            Console.WriteLine("Ingresar Sexo:");
                            string sex = Console.ReadLine();
                            Console.WriteLine("Ingresar Fecha de Nacimiento:");
                            string birthDate = Console.ReadLine();
                            Console.WriteLine("Ingresar Usuario:");
                            string userName = Console.ReadLine();
                            Console.WriteLine("Ingresa Contraseña:");
                            string password = Console.ReadLine();
                            Employee newEmployee = new Employee(id, names, lastNames, email, phoneNumber, sex, birthDate, userName, password);
                            Console.WriteLine("\nAñadiendo empleado...\n");
                            login.users.Add(newEmployee);
                            Console.WriteLine("\nEmpleado añadido.\n");
                            foreach (User u in login.users)
                            {
                                Console.WriteLine(u);
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ingresar ID:");
                            string IDem = Console.ReadLine();
                            foreach (Employee u in login.users)
                            {
                                if (u.ID == IDem)
                                {
                                    Console.WriteLine("\nEliminando empleado...\n");
                                    login.users.Remove(u);
                                    Console.WriteLine("Empleado eliminado...\n");
                                    break;
                                }

                            }
                            foreach (User u in login.users)
                            {
                                Console.WriteLine(u);
                            }
                            break;

                        default: break;

                    }
                    Console.WriteLine("\nPresione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    if (login.users.Count == 0)
                    {
                        login.EmployeesDatabase();
                    }
                    Console.WriteLine("Ingresar ID:");
                    string Id = Console.ReadLine();
                    foreach (User u in login.users)
                    {
                        if (u.ID == Id)
                        {
                            Console.WriteLine("\nEliminando usuario...\n");
                            login.users.Remove(u);
                            Console.WriteLine("Usuario eliminado...\n");
                            break;
                        }

                    }
                    foreach (User u in login.users)
                    {
                        Console.WriteLine(u);
                    }
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("\n1. Agregar pelicula\n2. Eliminar Pelicula\n3. Modificar sala de exhibición\n");
                    int optionc3 = int.Parse(Console.ReadLine());
                    if (movieListings.NowShowing.Count == 0)
                    { movieListings.MovieList(); }
                    switch (optionc3)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Ingresa ID:");
                            string ID = Console.ReadLine();
                            Console.WriteLine("Ingresa Titulo:");
                            string Title = Console.ReadLine();
                            Console.WriteLine("Ingresa la duracion:");
                            int Duration = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingresa tipo:");
                            string MovieGenre = Console.ReadLine();
                            Movie newMovie = new Movie(ID, Title, Duration, MovieGenre);
                            Console.WriteLine("\nAñadiendo pelicula...\n");
                            movieListings.NowShowing.Add(newMovie);
                            Console.WriteLine("\nPelicula añadida...\n");
                            foreach (Movie m in movieListings.NowShowing)
                            {
                                Console.WriteLine(m);
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ingresa ID:");
                            string Idm = Console.ReadLine();
                            foreach (Movie m in movieListings.NowShowing)
                            {
                                if (m.ID == Idm)
                                {
                                    Console.WriteLine("\nEliminando pelicula...\n");
                                    movieListings.NowShowing.Remove(m);
                                    Console.WriteLine("Pelicula eliminada...\n");
                                    break;
                                }

                            }
                            foreach (Movie m in movieListings.NowShowing)
                            {
                                Console.WriteLine(m);
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Modificar sala:\n1. Estandar\n2. Premium\n3. VIP");
                            string room = Console.ReadLine();
                            Console.WriteLine("\nIngresa el nuevo nombre");
                            string newName = Console.ReadLine();
                            Console.WriteLine("\nIngresa el numero de filas");
                            int rows = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nIngresa el numero de asientos");
                            int seats = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nSala modificada.\n");
                            if (room == "1")
                            {
                                ticketOffice.screeningRoom1 = newName;
                                ticketOffice.StandardSeats = new bool[rows, seats];
                                Console.WriteLine("\nSala 1: {0} Asientos: {1}\n", ticketOffice.screeningRoom1, ticketOffice.StandardSeats.Length);
                            }
                            else if (room == "2")
                            {
                                ticketOffice.screeningRoom2 = newName;
                                Console.WriteLine("\nSala 2: {0} Asientos: {1}\n", ticketOffice.screeningRoom2, ticketOffice.PremiumSeats.Length);
                                ticketOffice.PremiumSeats = new bool[rows, seats];
                            }
                            else if (room == "3")
                            {
                                ticketOffice.screeningRoom3 = newName;
                                ticketOffice.PremiumSeats = new bool[rows, seats];
                                Console.WriteLine("\nSala 3: {0} Asientos: {1}\n", ticketOffice.screeningRoom3, ticketOffice.VIPSeats.Length);
                            }
                            break;
                        default: break;

                    }
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;


                case "4":
                    Console.Clear();
                    if (candyShop.CandyList.Count == 0)
                    {
                        candyShop.Menu();
                    }
                    Console.WriteLine("\n1. Agregar golosina\n2. Eliminar golosina\n3. Modificar golosina\n");
                    int optionc4 = int.Parse(Console.ReadLine());
                    switch (optionc4)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Ingresa ID:");
                            string id = Console.ReadLine();
                            Console.WriteLine("Ingresa el nombre:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Ingresa el tipo:");
                            string type = Console.ReadLine();
                            Console.WriteLine("Ingresa el precio:");
                            double price = double.Parse(Console.ReadLine());
                            Candy newCandy = new Candy(id, name, type, price);
                            Console.WriteLine("\nAñadiendo golosina...\n");
                            candyShop.CandyList.Add(newCandy);
                            Console.WriteLine("\nGolosina añadida...\n");
                            foreach (Candy c in candyShop.CandyList)
                            {
                                Console.WriteLine(c);
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ingresa ID:");
                            string ID = Console.ReadLine();
                            foreach (Candy c in candyShop.CandyList)
                            {
                                if (c.ID == ID)
                                {
                                    Console.WriteLine("\nEliminando golosina...\n");
                                    candyShop.CandyList.Remove(c);
                                    Console.WriteLine("Golosina eliminada...\n");
                                    break;
                                }
                            }
                            foreach (Candy c in candyShop.CandyList)
                            {
                                Console.WriteLine(c);
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Ingresa ID:");
                            string idc = Console.ReadLine();
                            foreach (Candy c in candyShop.CandyList)
                            {
                                if (c.ID == idc)
                                {
                                    Console.WriteLine("\nModificar tipo\n1. Si\n2. No");
                                    string mod = Console.ReadLine();
                                    if (mod == "1")
                                    {
                                        Console.WriteLine("\nIngresa el tipo:");
                                        c.Type = Console.ReadLine();
                                    }

                                    Console.WriteLine("\nModificar precio\n1. Si\n2. No");
                                    string modp = Console.ReadLine();
                                    if (modp == "1")
                                    {
                                        Console.WriteLine("\nIngresa el precio:");
                                        c.Price = double.Parse(Console.ReadLine());
                                    }

                                    Console.WriteLine("\nGolosina modificada.\n");
                                    break;
                                }
                            }
                            foreach (Candy c in candyShop.CandyList)
                            {
                                Console.WriteLine(c);
                            }
                            break;

                        default: break;
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("\n1. Reporte usuarios\tIngrese U\n2. Reporte peliculas\tIngrese C\n3. Reporte golosinas\tIngrese G\n");
                    string letter = Console.ReadLine();
                    switch (letter)
                    {
                        case "U":
                            if (login.users.Count == 0)
                            {
                                login.EmployeesDatabase();
                            }
                            List<User> allUsers = new List<User>();
                            for (int i = 0; i < login.users.Count; i++)
                            {
                                allUsers.Add(new User()
                                {
                                    Names = login.users[i].Names,
                                    LastNames = login.users[i].LastNames,
                                    Email = login.users[i].Email,
                                    PhoneNumber = login.users[i].PhoneNumber,
                                    Sex = login.users[i].Sex,
                                    BirthDate = login.users[i].BirthDate,
                                    Username = login.users[i].Username,
                                    Password = login.users[i].Password,
                                    ID = login.users[i].ID,
                                    Type = login.users[i].Type
                                });
                            }
                            Console.Clear();
                            Console.WriteLine("\nCreando archivo AllUsers.json...\n");
                            string jsonU = JsonConvert.SerializeObject(allUsers.ToArray());

                            System.IO.File.WriteAllText(@"C:\json\AllUsers.json", jsonU);
                            Console.WriteLine("\nArchivo AllUsers.json creado\n");
                            Console.ReadKey();
                            break;

                        case "C":
                            if (movieListings.NowShowing.Count == 0)
                            {
                                movieListings.MovieList();
                            }
                            List<Movie> allMovies = new List<Movie>();
                            for (int i = 0; i < movieListings.NowShowing.Count; i++)
                            {
                                allMovies.Add(new Movie()
                                {
                                    ID = movieListings.NowShowing[i].ID,
                                    Name = movieListings.NowShowing[i].Name,
                                    Duration = movieListings.NowShowing[i].Duration,
                                    MovieGenre = movieListings.NowShowing[i].MovieGenre,
                                });
                            }
                            Console.Clear();
                            Console.WriteLine("\nCreando archivo AllMovies.json...");
                            string jsonC = JsonConvert.SerializeObject(allMovies.ToArray());

                            System.IO.File.WriteAllText(@"C:\json\AllMovies.json", jsonC);
                            Console.WriteLine("\nArchivo AllMovies.json creado\n");
                            Console.ReadKey();
                            break;

                        case "G":
                            if (candyShop.CandyList.Count == 0)
                            {
                                candyShop.Menu();
                            }
                            List<Candy> allCandies = new List<Candy>();
                            for (int i = 0; i < candyShop.CandyList.Count; i++)
                            {
                                allCandies.Add(new Candy()
                                {
                                    ID = candyShop.CandyList[i].ID,
                                    Name = candyShop.CandyList[i].Name,
                                    Type = candyShop.CandyList[i].Type,
                                    Price = candyShop.CandyList[i].Price,
                                });
                            }
                            Console.Clear();
                            Console.WriteLine("Creando archivo AllCandies.json...");
                            string jsonG = JsonConvert.SerializeObject(allCandies.ToArray());

                            System.IO.File.WriteAllText(@"C:\json\AllCandies.json", jsonG);
                            Console.WriteLine("\nArchivo AllCandies.json creado\n");
                            Console.ReadKey();
                            break;

                    }

                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;

                case "6":
                    Console.Clear();
                    login.userLogin();
                    break;

                default: break;
            }

            Print();
        }
    }
}
