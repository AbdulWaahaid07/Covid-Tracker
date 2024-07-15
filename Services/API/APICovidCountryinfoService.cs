using CovidAnalysis.Models;
using CovidAnalysis.Services.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CovidAnalysis.Services.API
{
    public class APICovidCountryinfoService : ICovidCasesService
    {
        public async Task<IEnumerable<CovidCases>> GetCases(int NofCountries)
        {
            using(HttpClient client = new HttpClient()) 
            {

                string requestURI = "https://disease.sh/v3/covid-19/countries?sort=cases";

                HttpResponseMessage apiResponse = await client.GetAsync(requestURI);

                string jsonresponse = await apiResponse.Content.ReadAsStringAsync();

                List<APICovidCountry> apiCountry = JsonSerializer.Deserialize<List<APICovidCountry>>(jsonresponse, new JsonSerializerOptions() 
                { 
                    PropertyNameCaseInsensitive = true 
                });

                return apiCountry.Take(NofCountries).Select(apiCountry => new CovidCases()
                {
                    Country = apiCountry.Country,
                    Casecount = apiCountry.Cases,
                    Flag = apiCountry.CountryInfo.Flag
                }) ;

            }
        }
    }
}
