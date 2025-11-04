namespace SecretSantaApp.Entities;

public class Contestant : IContestant
{
    public string Id { get; set; }
    
    public string Username { get; set; }
    
    public string SpeciesMain { get; set; }
    public string[] SpeciesOptional { get; set; }
    
    public string Size { get; set; }
    public string Background { get; set; }
    public string[] Characters { get; set; }
    
    public Contestant? Pair {get; set;}
    
    public static string UsedSpeciesCategory { get; set; }
    public static string UsedSizeCategory { get; set; }
    public static string UsedBackgroundCategory { get; set; }
}