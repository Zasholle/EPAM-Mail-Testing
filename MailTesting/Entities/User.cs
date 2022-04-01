namespace MailTesting.Entities
{
    public class User
    {
        private readonly string _email;
        private readonly string _password;
        public string[] UserData { get; set; }

        public User(string email, string password)
        {
            _email = email;
            _password = password;
            UserData = new[] {_email, _password};
        }
    }
}
