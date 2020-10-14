namespace Proyecto_POO
{
    class Candy
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public Candy(string id, string name, string type, double price)
        {
            ID = id;
            Name = name;
            Type = type;
            Price = price;
        }

        public Candy()
        {

        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}..........${2:0.00}\n{3}\n", ID, Name, Price, Type);
        }
    }
}
