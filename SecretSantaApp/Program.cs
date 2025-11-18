using SecretSantaApp.Entities;
using System.Text;

namespace SecretSantaApp;

static class Program
{
    public static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        
        Console.Write("Enter the full path to the contestants file (.tsv): ");
        var filePath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            Console.WriteLine("Invalid file path. Please make sure the file exists.");
            return;
        }

        var contestants = DataLoader.LoadFromFile(filePath);

        //Console.WriteLine($"Successfully loaded {contestants.Count} contestants.");
            
        //var pairsWithoutTolerance = PairFinder.FindPairs(contestants, tolerance: false);
        //OutputHelper.PrintPairs(pairsWithoutTolerance, false);

        var pairsWithTolerance = PairFinder.FindPairs(contestants, tolerance: true);
        //Presenter.PrintPairs(pairsWithTolerance, true);
        Presenter.PrintPairsRaw(pairsWithTolerance, false);
    }
}