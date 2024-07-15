using CovidAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.Services
{
    public interface ICovidCasesService
    {
        Task<IEnumerable<CovidCases>> GetCases(int NofCountries);
    }
}
