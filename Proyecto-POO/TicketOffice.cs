using System;
using System.Collections.Generic;

namespace Proyecto_POO
{
    class TicketOffice : MovieListings
    {
        Random RNG = new Random();
        public double Price { get; set; }
        public double DriveInPrice;
        public string screeningRoom1 { get; set; }
        public string screeningRoom2 { get; set; }
        public string screeningRoom3 { get; set; }
        public string thisScreeningRoom { get; set; }      
        public string branchName;
        public int branchType;     
        public List<Sale> Sales = new List<Sale>();
        public bool[,] StandardSeats = new bool[8, 8];
        public bool[,] PremiumSeats = new bool[5, 8];
        public bool[,] VIPSeats = new bool[5, 6];

        public void BuyTickets()
        {
            Console.WriteLine("Ingrese ID de la pelicula");
            string movieID = Console.ReadLine();
            string movieName = "";
            Console.WriteLine("");
            MovieList();
            foreach (Movie m in NowShowing)
            {
                if (movieID == m.ID)
                {
                    Console.WriteLine(m);
                    movieName = m.Name;
                    break;
                }
            }
            Console.WriteLine("Ingresar la cantidad:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("\nElegir la sucursal\n1. Centro\n2. Sur\n");
            int branch = int.Parse(Console.ReadLine());
            switch (branch)
            {
                case 1:
                    branchName = "Centro";
                    break;

                case 2:
                    branchName = "Sur";
                    break;

            }
            Console.WriteLine("\nElegir la modalidad\n1. Sala de Cine\n2. Autocine\n");
            branchType = int.Parse(Console.ReadLine());
            switch (branchType)
            {
                case 1:
                    Console.WriteLine("\nPrecios\nSala Estandar $3.55\nSala Premium $4.75\nSala VIP $6.50\n");
                    Console.WriteLine("\nElegir una sala de exhibición\n1. Estándar\n2. Premium\n3. VIP");
                    int screeningRoom = int.Parse(Console.ReadLine());
                    switch (screeningRoom)
                    {
                        case 1:
                            for (int i = 0; i < quantity; i++)
                            {
                                screeningRoom1 = "Estandar";
                                thisScreeningRoom = screeningRoom1;
                                Console.WriteLine("\nIngresar la fila");
                                int row = int.Parse(Console.ReadLine());
                                Console.WriteLine("\nIngresar el asiento A-H");
                                char seat = char.Parse(Console.ReadLine());
                                Standard(row, lettertonumber(seat));
                            }
                            break;

                        case 2:
                            screeningRoom2 = "Premium";
                            thisScreeningRoom = screeningRoom2;
                            for (int i = 0; i < quantity; i++)
                            {
                                Console.WriteLine("\nIngresar la fila");
                                int row = int.Parse(Console.ReadLine());
                                Console.WriteLine("\nIngresar el asiento A-H");
                                char seat = char.Parse(Console.ReadLine());
                                Premium(row, lettertonumber(seat));
                            }
                            break;

                        case 3:
                            screeningRoom3 = "VIP";
                            thisScreeningRoom = screeningRoom3;
                            for (int i = 0; i < quantity; i++)
                            {
                                Console.WriteLine("\nIngresar la fila");
                                int row = int.Parse(Console.ReadLine());
                                Console.WriteLine("\nIngresar el asiento A-F");
                                char seat = char.Parse(Console.ReadLine());
                                VIP(row, lettertonumber(seat));
                            }
                            break;

                        default: break;
                    }
                    break;

                case 2:
                    DriveInPrice = 5.00;
                    Console.WriteLine("\nPrecio Autocine ${0:0.00}", DriveInPrice);
                    thisScreeningRoom = "Autocine";
                    Price = DriveInPrice;
                    break;

            }


            Console.WriteLine("\nProcesando...\n");
            Console.WriteLine("Imprimiendo recibo...\n");

            PrintTicket(movieName, thisScreeningRoom, quantity, Price);
            double total;
            if (branchType == 2)
            {
                total = quantity * (Price + (Price * 0.3533)) + 1.75;
            }
            else total = quantity * (Price + (Price * 0.3533));
            Pay(Math.Round(total, 2));
        }

        private void PrintTicket(string id, string sr, int quantity, double price)
        {
            Console.WriteLine("\tKODIMAX\n\t{0}\n", branchName);
            Login login = new Login();
            login.EmployeesDatabase();
            Employee emp = (Employee)login.users[RNG.Next(0, 2)];
            Console.WriteLine("Empleado: {0} {1}\tID: {2}\n", emp.Names, emp.LastNames, emp.ID);
            Console.WriteLine("Fecha: {0}\n", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            Console.WriteLine("\n{0}\n{1}\tx " +
                "{2}\n\nSubtotal: ${3:0.00}", sr, id, quantity, price * quantity);
            if (branchType == 2)
            {
                Console.WriteLine("Parqueo: $1.75");
                Console.WriteLine("Impuesto: ${0:0.00}\nTotal: ${1:0.00}", quantity * (price * 0.3533), quantity * (price + (price * 0.3533)) + 1.75);
            }
            else
                Console.WriteLine("Impuesto: ${0:0.00}\nTotal: ${1:0.00}", quantity * (price * 0.3533), quantity * (price + (price * 0.3533)));

            Sale newSale = new Sale(branchName, sr, id, quantity, price);
            Sales.Add(newSale);
        }

        public void Standard(int row, int seat)
        {
            Price = 3.55;
            if (StandardSeats[row - 1, seat - 1] == false)
            {
                StandardSeats[row - 1, seat - 1] = true;
            }
            else
            {
                Console.WriteLine("Asiento ya esta reservado, por favor elige otro");
                Console.Clear();
                BuyTickets();
            }
        }

        public void Premium(int row, int seat)
        {
            Price = 4.75;
            if (PremiumSeats[row - 1, seat - 1] == false)
            {
                PremiumSeats[row - 1, seat - 1] = true;
            }
            else
            {
                Console.WriteLine("Asiento ya esta reservado, por favor elige otro");
                Console.Clear();
                BuyTickets();
            }

        }

        public void VIP(int row, int seat)
        {
            Price = 6.50;
            if (VIPSeats[row - 1, seat - 1] == false)
            {
                VIPSeats[row - 1, seat - 1] = true;
            }
            else
            {
                Console.WriteLine("Asiento ya esta reservado, por favor elige otro");
                Console.Clear();
                BuyTickets();
            }
        }

        internal static int lettertonumber(char letter)
        {
            int index = char.ToUpper(letter) - 64;
            return index;
        }

        private void Pay(double total)
        {
            Console.Write("\nIngresa cantidad a pagar: ");
            double payment = double.Parse(Console.ReadLine());
            Console.WriteLine("\nProcesando pago...");
            if (payment == total)
            {
                Console.WriteLine("\nCobro exacto, gracias por comprar en KODIMAX");
            }
            else if (payment > total)
            {
                Console.WriteLine("\nSu cambio es ${0:00.00}, gracias por comprar en KODIMAX", payment - total);
            }
            else
            {
                Console.WriteLine("\nPago insuficiente");
                Pay(total);
            }
            Console.ReadKey();
        }
    }
}
