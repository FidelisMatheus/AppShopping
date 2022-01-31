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
    public class TicketPaymentViewModel : BaseViewModel
    {
        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);

                //Pesquisar Ticket e Jogar na tela.
                Ticket = _ticketService.GetTicketInfo(value);

                //GetTicketInfo já realiza o calculo necessario.
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

        private CreditCard _creditCard;

        public CreditCard CreditCard
        {
            get { return _creditCard; }
            set 
            { 
                SetProperty(ref _creditCard, value);
            }
        }

        public ICommand PaymentCommand { get; set; } //Botao de pagamento
        private PaymentService _paymentService;


        private TicketService _ticketService;
        public TicketPaymentViewModel()
        {
            _ticketService = new TicketService();
            _paymentService = new PaymentService();

            CreditCard = new CreditCard();

            PaymentCommand = new Command(Payment);
        }

        private void Payment()
        {
            //TODO - Validações - Manual, Data Annotations e Fluent Validation (pesquisar)

            try //Integração com um Serviço API.
            {
                int paymentId = _paymentService.SendPayment(CreditCard);

                //TODO - Redirecionar para tela de sucesso.

            }
            catch (Exception)
            {

                //TODO - Colocar mensagem de erro. redirecionar erro
                throw;
            }


        }
    }
}
