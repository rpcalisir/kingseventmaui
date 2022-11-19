using CommunityToolkit.Mvvm.ComponentModel;
using KingsEventMAUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels.Startup
{
    public partial class PhoneSignInPageViewModel: BaseViewModel
    {
        #region Private Fields
        [ObservableProperty]
        private Countries _countries;

        [ObservableProperty]
        private List<string> _countriesWithCodes;
        #endregion

        #region Properties
        #endregion

        #region Commands
        #endregion

        #region Public Methods
        public PhoneSignInPageViewModel()
        {
            _countries = new Countries();
            _countries = JsonConvert.DeserializeObject<Countries>(_countries.countriesJson);

            foreach (var country in _countries)
            {
                _countriesWithCodes.Add($"{country.Name}: {country.Code}");
            }
        }
        #endregion

        #region Private Implementation
        #endregion
    }
}
