using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using AppClimaAPIRest.Model;
using AppClimaAPIRest.Services;

namespace AppClimaAPIRest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Previsão do Tempo";
            this.BindingContext = new Clima();
        }

        private async void btnPrevisao_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cidadeEntry.Text))
                {
                    Clima previsaoDoTempo = await DataServices.GetPrevisaodoTempo(cidadeEntry.Text);
                    this.BindingContext = previsaoDoTempo;
                    btnPrevisao.Text = "Nova Previsão";

                }
                   
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro", ex.Message , "OK");
            }

        }
    }
}
