namespace Proyecto_POO
{
    class User
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ID { get; set; }
        public string Type { get; set; }

        public User(string names, string lastNames, string email, string phoneNumber, string sex, string birthDate, string username, string password)
        {
            Names = names;
            LastNames = lastNames;
            Email = email;
            PhoneNumber = phoneNumber;
            Sex = sex;
            BirthDate = birthDate;
            Username = username;
            Password = password;
            Type = "User";
            ID = string.Format(names.Substring(0, 1) + lastNames.Substring(0, 1) + birthDate.Substring(0,2));
        }

        public User()
        {
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1} {2}", ID, Username, Type);
        }
    }
}
