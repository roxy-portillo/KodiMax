﻿using System;

namespace Proyecto_POO
{
    class EmployeeMenu : IMenu
    {
        private string Option;
        Login login = new Login();
        MovieListings movieListings = new MovieListings();
        CandyShop candyShop = new CandyShop();
        TicketOffice ticketOffice = new TicketOffice();
        ManageBranches manageBranches = new ManageBranches();

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("KODIMAX - EMPLEADO\n********************");
            Console.WriteLine("1. Modificar Cartelera\n2. Modificar Tienda de Golosinas\n3. Modificar Sucursales\n4. Modificar Precios Autocine\n5. Salir\n");
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
                    Console.WriteLine("\n1. Agregar pelicula\n2. Eliminar Pelicula\n3. Modificar sala de exhibición\n");
                    int optionc1 = int.Parse(Console.ReadLine());
                    if (movieListings.NowShowing.Count == 0)
                    { movieListings.MovieList(); }
                    switch (optionc1)
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
                                    Console.WriteLine("\nPelicula eliminada...\n");
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
                            if (room == "1")
                            {
                                ticketOffice.screeningRoom1 = newName;
                                ticketOffice.StandardSeats = new bool[rows, seats];
                                Console.WriteLine("\nNombre: {0} Asientos: {1}\n", ticketOffice.screeningRoom1, ticketOffice.StandardSeats.Length);
                            }
                            else if (room == "2")
                            {
                                ticketOffice.screeningRoom2 = newName;
                                Console.WriteLine("\nNombre: {0} Asientos: {1}\n", ticketOffice.screeningRoom2, ticketOffice.PremiumSeats.Length);
                                ticketOffice.PremiumSeats = new bool[rows, seats];
                            }
                            else if (room == "3")
                            {
                                ticketOffice.screeningRoom3 = newName;
                                ticketOffice.PremiumSeats = new bool[rows, seats];
                                Console.WriteLine("\nNombre: {0} Asientos: {1}\n", ticketOffice.screeningRoom3, ticketOffice.VIPSeats.Length);
                            }

                            break;
                        default: break;

                    }
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    if (candyShop.CandyList.Count == 0)
                    {
                        candyShop.Menu();
                    }
                    Console.WriteLine("\n1. Agregar golosina\n2. Eliminar golosina\n3. Modificar golosina\n");
                    int optionc2 = int.Parse(Console.ReadLine());
                    switch (optionc2)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Ingresa ID:");
                            string Id = Console.ReadLine();
                            Console.WriteLine("Ingresa el nombre:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Ingresa el tipo:");
                            string type = Console.ReadLine();
                            Console.WriteLine("Ingresa el precio:");
                            double price = double.Parse(Console.ReadLine());
                            Candy newCandy = new Candy(Id, name, type, price);
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
                            string id = Console.ReadLine();
                            foreach (Candy c in candyShop.CandyList)
                            {
                                if (c.ID == id)
                                {
                                    Console.WriteLine("\nModificar tipo\n1. Si\n2. No");
                                    string modT = Console.ReadLine();
                                    if (modT == "1")
                                    {
                                        Console.WriteLine("Ingresa el tipo:");
                                        c.Type = Console.ReadLine();
                                    }

                                    Console.WriteLine("Modificar precio\n1. Si\n2. No");
                                    string modP = Console.ReadLine();
                                    if (modP == "1")
                                    {
                                        Console.WriteLine("Ingresa el precio:");
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

                case "3":
                    Console.Clear();

                    Console.WriteLine("\n1. Agregar sucursal\n2. Modificar sucursal\n");
                    int optionc3 = int.Parse(Console.ReadLine());
                    if (manageBranches.Branches.Count == 0)
                    { manageBranches.BranchList(); }
                    switch (optionc3)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Ingresa ID:");
                            string ID = Console.ReadLine();
                            Console.WriteLine("Ingresa Nombre:");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Ingresa la modalidad:");
                            string Type = Console.ReadLine();
                            Branch newBranch = new Branch(ID, Name, Type);
                            Console.WriteLine("\nAñadiendo sucursal...\n");
                            manageBranches.Branches.Add(newBranch);
                            Console.WriteLine("\nSucursal añadida...\n");
                            foreach (Branch b in manageBranches.Branches)
                            {
                                Console.WriteLine(b);
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Modificar sucursal:\nIngresa ID\n");
                            string branchID = Console.ReadLine();
                            Console.WriteLine("\nIngresa el nuevo nombre");
                            string newName = Console.ReadLine();
                            Console.WriteLine("\nIngresa el nuevo ID");
                            string newID = Console.ReadLine();
                            Console.WriteLine("\nIngresa la nueva modalidad");
                            string newType = Console.ReadLine();

                            foreach (Branch b in manageBranches.Branches)
                            {
                                if (b.ID == branchID)
                                {
                                    b.Name = newName;
                                    b.ID = newID;
                                    b.Type = newType;
                                    Console.WriteLine("\nID: {0} Nombre: {1} Modalidad: {2}\n", b.ID, b.Name, b.Type);
                                    break;
                                }
                            }
                            break;

                        default: break;

                    }
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("\n1. Agregar precios autocine\n2. Modificar precios autocine\n");
                    int optionc4 = int.Parse(Console.ReadLine());
                    if (manageBranches.Branches.Count == 0)
                    { manageBranches.BranchList(); }
                    switch (optionc4)
                    {
                        case 1:
                            Console.Clear();                           
                            Console.WriteLine("Ingresa nuevo precio:");
                            double Price = double.Parse(Console.ReadLine());
                            
                            Console.WriteLine("\nAñadiendo precio...\n");
                            ticketOffice.Price = Price;
                            Console.WriteLine("\nPrecio añadido...\n");
                            Console.WriteLine("\nPrecio: ${0}\n", ticketOffice.Price);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Modificar precio autocine:\n");                         
                            Console.WriteLine("\nIngresa el nuevo precio");
                            double newPrice = double.Parse(Console.ReadLine());
                            
                            ticketOffice.DriveInPrice = newPrice;
                            Console.WriteLine("\nPrecio: ${0}\n", ticketOffice.DriveInPrice);
                            break;

                        default: break;

                    }
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Clear();
                    login.userLogin();
                    break;

                default: break;
            }
            Print();
        }
    }
}
