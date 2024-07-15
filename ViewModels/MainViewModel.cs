using CovidAnalysis.Services;
using CovidAnalysis.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.ViewModels
{
    public class MainViewModel
    {

        public ChartViewModel CountryChartVM { get; set; }


        public MainViewModel()
        {
            ICovidCasesService covidCasesSercice = new APICovidCountryinfoService();

            CountryChartVM = ChartViewModel.LoadVM(covidCasesSercice);
        }

    }
}
