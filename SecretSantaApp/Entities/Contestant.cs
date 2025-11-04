using SecretSantaApp.Interfaces;

namespace SecretSantaApp.Entities
{
    public class Contestant(
        string id,
        string username,
        string speciesMain,
        string[] speciesOptional,
        string size,
        string background,
        string[] characters,
        Contestant? pair = null)
        : IContestant
    {
    

        public string Id { get; set; } = id;

        public string Username { get; set; } = username;

        public string SpeciesMain { get; set; } = speciesMain;
        public string[] SpeciesOptional { get; set; } = speciesOptional;

        public string Size { get; set; } = size;
        public string Background { get; set; } = background;
        public string[] Characters { get; set; } = characters;

        public Contestant? Pair {get; set;} = pair;

        public static string? UsedSpeciesCategory { get; set; }
        public static string? UsedSizeCategory { get; set; }
        public static string? UsedBackgroundCategory { get; set; }
    }
}