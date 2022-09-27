using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppClimaAPIRest.Model;

namespace AppClimaAPIRest.Services
{
    class DataServices
    {
        public static async Task<Clima> GetPrevisaodoTempo(string cidade)
        {
            string appID = "493e1a591f5ce79846327bd3b694e068";

            string queryString = "http://api.weathermap.org/data/2.5/weather?q=" + cidade + "&units=metric" + "&appid=" + appID;
            dynamic resultado = await getDataFromService(queryString).ConfigureAwait(false);

            if (resultado["weather"] != null)
            {
                Clima previsao = new Clima();
                previsao.Title = (string)resultado["name"];
                previsao.Temperature = (string)resultado["main"]["temp"] + " C";
                previsao.Wind = (string)resultado["wind"]["speed"] + " mph";
                previsao.Humidity = (string)resultado["main"]["humidity"] + " %";
                previsao.Visibility = (string)resultado["weather"][0]["main"];
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)resultado["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)resultado["sys"]["sunset"]);
                previsao.Sunrise = String.Format("{0:d/MM/yyyy HH:mm:ss}", sunrise);
                previsao.Sunset = String.Format("{0:d/MM/yyyy HH:mm:ss}", sunset);
                return previsao;
            }
            else
            {
                return null;
            }
        }
    }
}
