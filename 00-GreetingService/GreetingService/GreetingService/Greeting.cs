namespace GreetingService
{
    public class Greeting
    {
        public long Id { get; set; }
        public string Content { get; set; }

        public Greeting(int id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}