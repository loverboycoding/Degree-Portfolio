namespace _1._2P
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Message myMessage = new("Hello,World...");

        myMessage.Print();
            
            List<Message> messages = new List<Message>();
            messages.Add(new Message("Hello,Wilma!"));
            messages.Add(new Message("Hello,Fred!"));
            messages.Add(new Message("Hello,Steve!"));
            messages.Add(new Message("Hello,Damien!"));
            messages.Add(new Message("Hello!"));

            Console.Write("Enter your name: ");

            string name = Console.ReadLine();
            if (name.ToLower() == "wilma")
            {
                
                messages[0].Print();
            }
            else if (name.ToLower() == "fred")
            {
                
                messages[1].Print();
            }
            else if (name.ToLower() == "steve")
            {
                
                messages[2].Print();
            }
            else if (name.ToLower() == "damien")
            {
                
                messages[3].Print();
            }
            else
            {
                
                messages[4].Print();
            }




        }
    }
}