using System;
using System.Net.ServerSentEvents;
using Library.CMS.Models;
using Library.CMS.Services;

namespace CMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Content Management System");
            Console.WriteLine("C. Create a Site");

            var choice = Console.ReadLine();
            if(choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Name:");
                var name = Console.ReadLine();
                var site = new Site{Name = name};
                SiteServiceProxy.Current.Add(site);
            }

            Console.WriteLine("Choose a site to manage:");



            int count = 0;
            SiteServiceProxy.Current.Sites.ForEach(s => Console.WriteLine($"{++count}. {s}"));

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
