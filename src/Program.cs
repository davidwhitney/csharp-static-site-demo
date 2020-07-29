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

            var runnerWorkDir = Environment.GetEnvironmentVariable("RUNNER_WORKSPACE") ?? "/";
            var targetDirectory = Environment.GetEnvironmentVariable("app_artifact_location") ?? "dist";
            var completeTarget = Path.Combine("/", targetDirectory);

            Console.WriteLine($"Writing to {targetDirectory}");

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }


            var indexPath = Path.Combine(completeTarget, "index.html");

            File.WriteAllText(indexPath, "Hello World");
        }
    }
}