using Hl7.Fhir.Model;
using SampleApp_MPI.Translators;
using SampleApp_MPI.Utilities;

namespace SampleApp_MPI.Services;

public class PatientService
{

    private readonly IConfiguration _config;

    public PatientService(IConfiguration config)
    {
        _config = config;
    }

    public static async Task<string> AddPatientResource(Models.Patient patient)
    {
        var entries = new List<Resource>{ patient.ToFhir() };

        var response = await HttpClientHelper
            .PostAsync(_config.GetValue<string>("ApiBaseUrl"), BundleFactory.CreateBundle(entries));

        return await response.Content.ReadAsStringAsync(); 
    }

    // public static async Task<Models.Patient> GetPatientResource(string searchTerm) 
    // {
    //     var response = await HttpClientHelper.GetAsync("http://172.209.216.154:5001/fhir/Patient/", searchTerm);

    //     if (response.IsSuccessStatusCode)
    //     {
    //         var patientJson = await response.Content.ReadAsStringAsync();

    //         FhirJsonParser parser = new FhirJsonParser();
    //         var fhirPatient = parser.Parse<Hl7.Fhir.Model.Patient>(patientJson);

    //         return FromFHIR(fhirPatient);
    //     }

    //     return null;
    // }

    
}
