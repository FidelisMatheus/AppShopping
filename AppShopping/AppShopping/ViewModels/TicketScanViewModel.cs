using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class TicketScanViewModel : BaseViewModel
    {
        public string TicketNumber { get; set; }
        public ICommand TicketScanCommand { get; set; }
        
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        public ICommand TicketPaidHistoryCommand { get; set; }

        public TicketScanViewModel()
        {
            TicketScanCommand = new Command(TicketScan);
            TicketPaidHistoryCommand = new Command(TicketPaidHistory);
        }

        private void TicketScan()
        {
            //TODO - Camera - Scannear o código de Barras.
            


            //TicketNumber > Método para fazer o processamento
            /*
             * GetTicketInfo( NumeroTicket)
             * > Message (caso exception)
             * > Ticket > GoToAsync
             */
            TicketProcess("");
        }

        private void TicketProcess(string ticketNumber)
        {
            try
            {
                var ticket = new TicketService().GetTicketInfo(ticketNumber);

                //TODO - Navegar para página de pagamento do Ticket
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }

        private void TicketPaidHistory()
        {

        }

    }
}
