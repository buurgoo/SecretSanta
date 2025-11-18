using SecretSantaApp.Entities;

namespace SecretSantaApp
{

    public static class Presenter
    {
        public static void PrintPairs(List<(Contestant, Contestant)> pairs, bool tolerance)
        {
            const string green = "\u001b[32m"; 
            const string red = "\u001b[31m";   
            const string reset = "\u001b[0m";  

            Console.WriteLine($"--- Pairs Found (Tolerance: {tolerance}) ---");
            Console.WriteLine($"Number of pairs found: {pairs.Count}");
            
            foreach (var pair in pairs)
            {
                string backgroundColor, sizeColor;
                
                if (pair.Item1.Background == pair.Item2.Background)
                {
                    backgroundColor = $"{green}{pair.Item1.Background}{reset}";
                }
                else
                {
                    backgroundColor = $"{red}{pair.Item1.Background} / {pair.Item2.Background}{reset}";
                }
                
                if (pair.Item1.Size == pair.Item2.Size)
                {
                    sizeColor = $"{green}{pair.Item1.Size}{reset}";
                }
                else
                {
                    sizeColor = $"{red}{pair.Item1.Size} / {pair.Item2.Size}{reset}";
                }

                Console.WriteLine($">> {pair.Item1.Id} -- {pair.Item1.Username} - {sizeColor} | {backgroundColor} - {pair.Item2.Username} -- {pair.Item2.Id}");
            }
            Console.WriteLine();
        }
        
        public static void PrintUnpairedContestants(HashSet<Contestant> availableContestants)
        {
            Console.WriteLine("Unpaired contestants after this round:");
            foreach (var unpaired in availableContestants)
            {
                Console.WriteLine($"{unpaired.Id} -- {unpaired.Username}");
            }
            Console.WriteLine();
        }
        
        public static void PrintPairsRaw(List<(Contestant, Contestant)> pairs, bool tolerance)
        {
            
            
            foreach (var pair in pairs)
            {
                Console.WriteLine($">> {pair.Item1.Id} -- {pair.Item2.Id}");
            }
            Console.WriteLine();
        }
        
    }
}
