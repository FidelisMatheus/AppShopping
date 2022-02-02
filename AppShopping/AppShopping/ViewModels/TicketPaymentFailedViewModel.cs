using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    public class TicketPaymentFailedViewModel : BaseViewModel
    {
        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);

                //Pesquisar Ticket e Jogar na tela.
                Ticket = _ticketService.GetTicket(value);
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

        public ICommand OKCommand { get; set; }

        private TicketService _ticketService;
        public TicketPaymentFailedViewModel()
        {
            OKCommand = new Command(OK);

            _ticketService = new TicketService();
        }

        private void OK()
        {
            Shell.Current.Navigation.PopToRootAsync();
        }

    }
}
