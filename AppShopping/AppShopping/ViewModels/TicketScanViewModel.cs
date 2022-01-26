using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

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
            TicketScanCommand = new MvvmHelpers.Commands.AsyncCommand(TicketScan); //necessita trocar já que o command nao aceita async
            TicketPaidHistoryCommand = new Command(TicketPaidHistory);
        }

        private async Task TicketScan() //Task é a mesma coisa que o Void - Porem Async
        {
            //Camera - Scannear o código de Barras. librarie -> (ZXing.Net.Mobile) acessar camera.
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += async (result) =>
            {
                scanPage.IsScanning = false;

                //Invocando a thread principal
                Device.BeginInvokeOnMainThread(async() =>
                {
                    await Shell.Current.Navigation.PopAsync(); //retire a tela da camera e dps mostre o resultado
                    Message = result.Text;
                    TicketProcess(result.Text);
                });

            };

            await Shell.Current.Navigation.PushAsync(scanPage);
            
            //TicketNumber > Método para fazer o processamento
            /*
             * GetTicketInfo( NumeroTicket)
             * > Message (caso exception)
             * > Ticket > GoToAsync
             */
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
