namespace CovidAnalysis.Services.API.Models
{
    public class APICovidCountry
    {
        public string Country { get; set; }

        public int Cases { get; set; }

        public APICountryInfo CountryInfo { get; set; }
    }
}