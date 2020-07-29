using System;
using System.Collections;
using System.IO;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's generate a static site!");

            foreach (DictionaryEntry envVar in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"{envVar.Key} {envVar.Value}");
            }

            var targetDirectory = Environment.GetEnvironmentVariable("app_artifact_location") ?? "dist";
            var completeTarget = Path.Combine(Environment.CurrentDirectory, "..", targetDirectory);

            if (!Directory.Exists(completeTarget))
            {
                Directory.CreateDirectory(completeTarget);
            }

            Console.WriteLine($"Writing to {completeTarget}");

            var indexPath = Path.Combine(completeTarget, "index.html");

            File.WriteAllText(indexPath, "Hello World");
        }
    }
}