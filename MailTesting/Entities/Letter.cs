namespace MailTesting.Entities
{
    public class Letter
    {
        private readonly string _receiver;
        private readonly string _subject;
        private readonly string _text;

        public string[] LetterData;

        public Letter(string receiver, string subject, string text)
        {
            _receiver = receiver;
            _subject = subject;
            _text = text;

            LetterData = new[] {_receiver, _subject, _text};
        }
    }
}
