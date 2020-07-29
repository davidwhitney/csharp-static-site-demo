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

            var baseDirectory = (Environment.GetEnvironmentVariable("GITHUB_WORKSPACE") ?? "").Replace("/app", "");
            var targetDirectory = Environment.GetEnvironmentVariable("INPUT_APP_ARTIFACT_LOCATION") ?? "";
            var outputLocation = Path.Combine(baseDirectory, targetDirectory);
            
            if (!Directory.Exists(outputLocation))
            {
                Console.WriteLine($"Creating output location: {outputLocation}");
                Directory.CreateDirectory(outputLocation);
            }

            Console.WriteLine($"Writing to: {outputLocation}");

            var indexPath = Path.Combine(outputLocation, "index.html");

            File.WriteAllText(indexPath, "Hello World");
        }
    }
}