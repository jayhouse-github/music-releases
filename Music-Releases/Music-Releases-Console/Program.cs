using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Releases.BL;
using System.Net;
using Ninject;

namespace Music_Releases_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel(new BindModule());
            var amazonSearchRepo = kernal.Get<IAmazonSearchRepository>();
            var amazonItemRepo = kernal.Get<IAmazonItemRepository>();

            Console.WriteLine("1. Search from comma searated list.");
            Console.WriteLine("2. Search from ASIN.");
            Console.WriteLine("Please select.");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.WriteLine("Type a list of bands separated by commas");
                string list = Console.ReadLine();
                var amazonSearch = new AmazonSearch(amazonSearchRepo);

                IList<ExtendedItem> returnObj = null;

                try
                {
                    returnObj = amazonSearch.SearchFromCommaSeparatedList(list);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Found " + returnObj.Count.ToString() + " items");

                foreach (var item in returnObj)
                {
                    Console.WriteLine(item.Artist + " - " + item.Title + " " + item.ReleaseDate.ToLongDateString());
                }

                Console.ReadLine();
            }
            else if(answer == "2")
            {
                var amazonItemRetrieve = new AmazonItemSearch(amazonItemRepo);
                Console.WriteLine("Please enter ASIN.");
                string asin = Console.ReadLine();
                var returnedObj = amazonItemRetrieve.GetByASIN(asin);

                Console.WriteLine(returnedObj.Artist + " - " + returnedObj.Title);
                Console.ReadLine();            
            }

            string[] arg1 = { "" };
            Main(arg1);
        }
    }
}
