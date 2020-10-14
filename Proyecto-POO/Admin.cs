namespace Proyecto_POO
{
    class Admin : User
    {
        public Admin(string names, string lastNames, string email, string phoneNumber, string sex, string birthDate, string username, string password) : base(names, lastNames, email, phoneNumber, sex, birthDate, username, password)
        {
            ID = "01RBAdK";
            Type = "Admin";
        }
    }
}
