using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    public class TicketPaymentViewModel : BaseViewModel
    {
        private string _number;

        public String Number
        {
            set
            {
                _number = value; //aqui é o ticket scaneado
                OnPropertyChanged(nameof(Number));

                //TODO - Pesquisar Ticket e Jogar na tela.
            }
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get { return _ticket; }
            set 
            { 
                SetProperty(ref _ticket, value);
            }
        }


        public TicketPaymentViewModel()
        {

        }
    }
}
