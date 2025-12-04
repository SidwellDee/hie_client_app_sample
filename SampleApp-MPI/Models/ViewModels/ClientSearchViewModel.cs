namespace SampleApp_MPI.Models.ViewModels;

public class ClientSearchViewModel
{
    public string SearchTerm { get; set; } = string.Empty;
    public ICollection<Patient> SearchResults { get; set; }
}
