using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class CinemaViewModel : BaseViewModel
    {
        public ICommand FilmDetailCommand { get; set; }
        public List<Film> Films { get; set; }

        public CinemaViewModel()
        {
            FilmDetailCommand = new Command<Film>(FilmDetail);

            Films = new CinemaService().GetFilms();
        }

        public void FilmDetail(Film film)
        {
            //Serializar o Filme > Enviar via URI
            var filmSerialized = JsonConvert.SerializeObject(film);

            //simbolo de dolar serve para adicionar paramentro sem concatenar
            Shell.Current.GoToAsync($"film/detail?filmSerialized={Uri.EscapeDataString(filmSerialized)}");
        }
    }
}
