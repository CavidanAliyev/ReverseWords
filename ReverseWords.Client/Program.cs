using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReverseWords.Service;
using System;
using System.IO;
using System.Reflection;

namespace ReverseWords.Client
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            var config = GenerateConfiguration();

            var inPath = config.GetValue<string>("MySettings:In");
            var outPath = config.GetValue<string>("MySettings:Out");

            string[] allWords = File.ReadAllLines(inPath);
            var service = new ReadAndReverseWords(); 

            foreach (var item in allWords)
            {
                Console.WriteLine(item);
                var reversingItem = service.GetStringAndReverse(item);
                WriteToOutFile(outPath, reversingItem);
            }

            Console.WriteLine("Completed reverse operation");
        }

        private static void WriteToOutFile(string outPath, string reversingItem)
        {
            reversingItem = reversingItem + Environment.NewLine;
            File.AppendAllText(outPath, reversingItem);
            Console.WriteLine(reversingItem);
            Console.WriteLine(); 
        }

        private static IConfiguration GenerateConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
            return configuration;
        }
    }
}
