using System;
using System.Net.ServerSentEvents;
using Library.CMS.Models;

namespace CMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Content Management System");

            Console.WriteLine("Choose a site to manage:");

            Site site1 = new Site{Name = "Site 1"};
            List<Site> sites = new List<Site>
            {
                site1
            };

            int count = 0;
            sites.ForEach(s => Console.WriteLine($"{++count}. {s}"));

            var selection = Console.ReadLine();



            if (!string.IsNullOrEmpty(selection))
            {
                Console.WriteLine(selection);

                var match = sites
                    .FirstOrDefault(s => s?.Name?.Equals(selection, StringComparison.InvariantCultureIgnoreCase)
                    ?? false);

                if(match != null)
                {
                     Console.WriteLine($"MATCHED: {match}");
                }
                else
                {
                    Console.WriteLine("No match found");
                }
                
            }
        }
    }
}
