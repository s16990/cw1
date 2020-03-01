using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            //string str = "Ala ma kota";
            //string str2 = "I psa";
            //bool boolean = true;
            //Console.WriteLine($"{str} {str2}");
            //var tmpVar = 4;
            //var newPerson = new Person { FirstName = "Kamil" };
            //HTTP GET/POST/"PUT/Patch"/DELETE
            //Console.WriteLine("Hello World!");

            var url = args.Length> 0 ? args[0] : "https://www.pja.edu.pl";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }

        }
    }
}
