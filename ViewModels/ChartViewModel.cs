using CovidAnalysis.Models;
using CovidAnalysis.Services;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.ViewModels
{
    public class ChartViewModel
    {
        private const int AMOUNT = 10;

        private readonly ICovidCasesService covidCasesService;


        public ChartValues<int> CountryCases { get; set; }

        public string[] CountryNames { get; set; }


        public ChartViewModel(ICovidCasesService covidCasesService)
        {
            this.covidCasesService = covidCasesService;
        }


        public static ChartViewModel LoadVM(ICovidCasesService covidCasesService, Action<Task> onLoaded = null)
        {

            ChartViewModel viewModel = new ChartViewModel(covidCasesService);

            viewModel.Load().ContinueWith(t => onLoaded?.Invoke(t)) ;
            
            return viewModel;
        }

        public async Task Load()
        {
            IEnumerable<CovidCases> countries = await covidCasesService.GetCases(AMOUNT);

            CountryCases = new ChartValues<int>(countries.Select(c => c.Casecount));
            CountryNames = countries.Select(c => c.Country).ToArray();
        }
    }
}
