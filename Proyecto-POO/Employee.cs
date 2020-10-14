namespace Proyecto_POO
{
    class Employee : User
    {
        public Employee(string id, string names, string lastNames, string email, string phoneNumber, string sex, string birthDate, string username, string password) : base(names, lastNames, email, phoneNumber, sex, birthDate, username, password)
        {
            ID = id;
            Type = "Employee";
        }
    }
}
