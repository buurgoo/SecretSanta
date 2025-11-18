using SecretSantaApp.Entities;
using SecretSantaApp.Interfaces;

namespace SecretSantaApp
{
    public static class PairFinder
    {
        public static List<(Contestant, Contestant)> FindPairs(List<Contestant> contestants, bool tolerance)
        {
            var pairs = new List<(Contestant, Contestant)>();
            
            var shuffledContestants = contestants.OrderBy(x => Guid.NewGuid()).ToList();
            
            var availableContestants = new HashSet<Contestant>(contestants); 

            foreach (var contestant in shuffledContestants)
            {
                if (!availableContestants.Contains(contestant)) continue;

                var pair = FindCompatiblePair(contestant, availableContestants, tolerance);

                if (pair == null) continue;
                
                pairs.Add((contestant, pair));
                availableContestants.Remove(contestant);
                availableContestants.Remove(pair);
            }

            Presenter.PrintUnpairedContestants(availableContestants);

            return pairs;
        }

        private static Contestant? FindCompatiblePair(Contestant contestant, HashSet<Contestant> availableContestants, bool tolerance)
        {
            foreach (var pair in availableContestants)
            {
                if (pair != contestant && CanPartner(contestant, pair, tolerance))
                {
                    return pair;
                }
            }
            return null;
        }

        private static bool CanPartner(IContestant per1, IContestant per2, bool tolerance)
        {
            ArgumentNullException.ThrowIfNull(per1);
            ArgumentNullException.ThrowIfNull(per2);

            if (!tolerance)
            {
                return ContestantComparer.CheckReciprocalCompatibility(
                           per1.Characters, per1.SpeciesMain, 
                           per2.Characters, per2.SpeciesMain
                       ) &&
                       per1.Size == per2.Size && 
                       per1.Background == per2.Background; 
            }

            return ContestantComparer.CheckSpeciesOverlap(per1, per2) &&
                   ContestantComparer.CheckSpeciesOverlap(per2, per1) &&
                   !ContestantComparer.IsSizeException(per1.Size, per2.Size) && 
                   !ContestantComparer.IsBackgroundException(per1.Background, per2.Background);
        }
    }
}

