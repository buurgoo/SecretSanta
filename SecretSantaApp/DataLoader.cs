using SecretSantaApp.Entities;

namespace SecretSantaApp
{
    public static class DataLoader
    {
        private static class TsvIndex
        {
            public const int Id = 1;
            public const int Username = 2;
            public const int SpeciesOptional = 4;
            public const int SpeciesMain = 5;
            public const int Size = 6;
            public const int Background = 7;
            public const int Characters = 10;
        }
        
        public static List<Contestant> LoadFromFile(string filePath)
        {
            var contestants = new List<Contestant>();
            
            try
            {
                var lines = File.ReadLines(filePath).Skip(1);
                
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var data = line.Split('\t');
                    
                    if (data.Length <= Math.Max(TsvIndex.Id, TsvIndex.Username))
                    {
                        Console.WriteLine($"Error: Skipping line due to insufficient columns: {line}");
                        continue;
                    }

                    Contestant temp = CreateContestantFromTsvData(data);
                    contestants.Add(temp);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file path was not found: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred during file loading: {ex.Message}");
            }
            
            return contestants;
        }
        
        private static Contestant CreateContestantFromTsvData(string[] data)
        {
            string[] SplitCommaString(string? input) => 
                input?.Split(',', StringSplitOptions.RemoveEmptyEntries)
                     .Select(s => s.Trim())
                     .ToArray() ?? [];

            return new Contestant(
                
                id: data[TsvIndex.Id],
                username: data[TsvIndex.Username],
                
                speciesMain: data[TsvIndex.SpeciesMain],
                speciesOptional: SplitCommaString(data[TsvIndex.SpeciesOptional]),
                
                size: data[TsvIndex.Size],
                background: data[TsvIndex.Background],
                
                characters: SplitCommaString(data[TsvIndex.Characters])
            );
        }
    }
}
