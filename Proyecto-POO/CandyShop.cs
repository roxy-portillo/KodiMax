using System;
using System.Collections.Generic;

namespace Proyecto_POO
{
    class CandyShop : Candy
    {
        public List<Candy> CandyList = new List<Candy>();
        private Random RNG = new Random();

        public CandyShop()
        {

        }

        public void Menu()
        {
            Candy candy1 = new Candy("02R", "Palomitas de maiz", "Aperitivo Salado", 3.75);
            CandyList.Add(candy1);
            Candy candy2 = new Candy("42G", "Pretzel", "Aperitivo Dulce", 2.50);
            CandyList.Add(candy2);
            Candy candy3 = new Candy("1KV", "Chocolate", "Barra de Dulce", 2.00);
            CandyList.Add(candy3);
            Candy candy4 = new Candy("9ZG", "Skittles", "Caramelos de Fruta", 2.25);
            CandyList.Add(candy4);
            Candy candy5 = new Candy("7GW", "Soda", "Bebida Fria", 2.75);
            CandyList.Add(candy5);
        }
        public void Print()
        {
            Console.Clear();
            if(CandyList.Count == 0)
            {
                Menu();
            }
            
            Console.WriteLine("\tMenu\n----------------------------------\n");
            foreach (Candy c in CandyList)
            {
                if (c != null)
                {
                    Console.WriteLine(c);
                }
            }
        }

        public void Buy()
        {
            Console.WriteLine("Ingrese ID de la golosina");
            string candyID = Console.ReadLine();
            string candyName = "";
            double candyPrice = 0.00;
            bool inStore = false;
            Menu();
            foreach (Candy c in CandyList)
            {
                if (c.ID == candyID)
                {
                    inStore = true;
                    candyName = c.Name;
                    candyPrice = c.Price;
                    break;
                }
            }
            if (inStore == true)
            {
                Console.WriteLine("Ingrese la cantidad");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("\nProcesando...\n");
                Console.WriteLine("Imprimiendo recibo...\n");
                PrintReceipt(candyName, quantity, candyPrice);
            }
            else { Console.WriteLine("\nNo esta en existencia");
                Console.ReadKey();
            }
        }

        private void PrintReceipt(string item, int quantity, double price)
        {
            Console.WriteLine("\tKODIMAX\n");
            Login login = new Login();
            login.EmployeesDatabase();
            Employee emp = (Employee)login.users[RNG.Next(0, 2)];
            Console.WriteLine("Empleado: {0} {1}\tID: {2}\n", emp.Names, emp.LastNames, emp.ID);
            Console.WriteLine("Fecha: {0}\n", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            Console.WriteLine("\n{0}\tx {1}\n", item, quantity);
            double total = quantity * (price + (price * 0.453));
            Console.WriteLine("\nSubtotal: {0:0.00}\nImpuesto: {1:0.00}\nTotal: {2:0.00}", quantity * price, quantity * (price * 0.453), total);
            Pay(Math.Round(total, 2));
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
