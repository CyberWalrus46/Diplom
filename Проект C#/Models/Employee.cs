namespace Core
{
    public class Employee
    {
        private Employee(Guid id, Guid merchantId, string name, string surname, string patronymic,
            string contact, string email, string password, string cardNumber)
        {
            Id = id;
            MerchantId = merchantId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Contact = contact;
            Email = email;
            Password = password;
            CardNumber = cardNumber;
        }

        public Guid Id { get; set; }
        public Guid MerchantId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CardNumber { get; set; }

        public static (Employee employee, string error) Create(Guid id, Guid merchantId, string name, string surname, string patronymic,
            string contact, string email, string password, string cardNumber)
        {
            var error = string.Empty;
            //if (string.IsNullOrEmpty(title) || title.Length > 255)
            //{
            //    error = "Title is too small or too long";
            //}

            var employee = new Employee(id, merchantId, name, surname, patronymic,
            contact, email, password, cardNumber);

            return (employee, error);
        }
    }
}
