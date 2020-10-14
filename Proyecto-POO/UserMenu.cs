using System;

namespace Proyecto_POO
{
    class UserMenu : IMenu
    {
        private string Option;
        MovieListings movieListings = new MovieListings();
        CandyShop candyShop = new CandyShop();
        TicketOffice ticketOffice = new TicketOffice();
        Login login = new Login();

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("KODIMAX - CLIENTE\n********************");
            Console.WriteLine("1. Ver Cartelera\n2. Ver Tienda de Golosinas\n3. Comprar Boletos\n4. Comprar Golosinas\n5. Salir\n");
            Console.WriteLine("Ingresa una opción:");
            Option = Console.ReadLine();
            NavigateMenu();
        }

        public void NavigateMenu()
        {
            switch (Option)
            {
                case "1":
                    Console.WriteLine("\tEn cartelera\n");
                    movieListings.Print();
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;

                case "2":
                    candyShop.Print();
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("\tTaquilla\n");
                    ticketOffice.BuyTickets();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("\tDulceria\n");
                    candyShop.Buy();
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
