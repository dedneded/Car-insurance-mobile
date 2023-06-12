using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace car_insurance_mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDetailsPage : ContentPage
    {
        private Guid clientId;
        public ClientDetailsPage(Guid clientId)
        {
            InitializeComponent();
            this.clientId = clientId;
        }
    }
}