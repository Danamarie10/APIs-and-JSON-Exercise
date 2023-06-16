using Newtonsoft.Json.Linq;
using System.Globalization;

namespace APIsAndJSON
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var client = new HttpClient();

            Console.WriteLine("Ron Swanson and Kanye West Conversation");
            
           
            
           

            for (int i = 0; i < 5; i++)
            {
                string ronSwansonQuote = GetRonSwansonQuote();
                string kanyeWestQuote = GetKanyeWestQuote();
                Console.WriteLine($"Ron says: {ronSwansonQuote}\n");
                Console.WriteLine($"Kanye says: {kanyeWestQuote}\n");

            }

            Console.ReadLine();
        }
        static string GetRonSwansonQuote()
        {
            var ronClient = new HttpClient();

            var ronSwansonAPI = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            string ronResponse = ronClient.GetStringAsync(ronSwansonAPI).Result;
            string ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
            return ronQuote;
        }
        static string GetKanyeWestQuote()
        {
            var kanyeClient = new HttpClient();
            var kanyeAPI = "https://api.kanye.rest";
            string kanyeResponse = kanyeClient.GetStringAsync(kanyeAPI).Result;
            string kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;

        }
    }
}
