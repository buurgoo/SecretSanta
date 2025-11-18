using SecretSantaApp.Interfaces;

namespace SecretSantaApp
{
    public static class ContestantComparer
    {
        public static bool CheckReciprocalCompatibility(string[] list1, string value1, string[] list2, string value2)
        {
            var normalizedList1 = list1.Select(s => s.Trim().ToLowerInvariant()).ToArray();
            var normalizedList2 = list2.Select(s => s.Trim().ToLowerInvariant()).ToArray();
            
            var normalizedValue1 = value1.Trim().ToLowerInvariant();
            var normalizedValue2 = value2.Trim().ToLowerInvariant();

            return normalizedList1.Contains(normalizedValue2) &&
                   normalizedList2.Contains(normalizedValue1);
        }

        public static bool CheckSpeciesOverlap(IContestant per1, IContestant per2)
        {
            var requiredCharacters = new HashSet<string>(
                per2.Characters.Select(s => s.Trim().ToLowerInvariant())
            );
            
            return per1.SpeciesOptional.Any(s => 
                requiredCharacters.Contains(s.Trim().ToLowerInvariant())
            );
        }
        
        public static bool IsSizeException(string size1, string size2)
        {
            var sizes = new HashSet<string> { size1, size2 };
            return sizes.SetEquals(new HashSet<string> { "full", "head" });
        }
        
        public static bool IsBackgroundException(string bg1, string bg2)
        {
            return (bg1 == "d" && bg2 == "no") || (bg2 == "d" && bg1 == "no");
        }
    }
}
