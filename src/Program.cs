using System;
using System.IO;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var isCi =  bool.Parse((Environment.GetEnvironmentVariable("CI") ?? "false"));
            if (!isCi) 
            {
                Console.WriteLine("Skipping generation, not running in CI.");
                return;
            }

            Console.WriteLine("Let's generate a static site!");

            var baseDirectory = Environment.GetEnvironmentVariable("DESTINATION_DIR") ?? "";
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