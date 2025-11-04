namespace SecretSantaApp.Interfaces
{
    public interface IContestant 
    {
        string Id { get; set; }
        string Username { get; set; }
        string SpeciesMain { get; set; }
        string[] SpeciesOptional { get; set; }
        string Size { get; set; }
        string Background { get; set; }
        string[] Characters { get; set; }
    }
}