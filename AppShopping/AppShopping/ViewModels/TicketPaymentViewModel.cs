using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Libraries.Validators;
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
        private string _messages;
        public string Messages //vinculado a uma label
        {
            get { return _messages; }
            set 
            {
                SetProperty(ref _messages, value);
            }
        }


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
            //Tipos de Validações - Manual, Data Annotations e Fluent Validation (pesquisar)

            try //Integração com um Serviço API.
            {
                Messages = string.Empty;
                string messages = Valid(CreditCard);

                if (string.IsNullOrEmpty(messages))
                {
                    int paymentId = _paymentService.SendPayment(CreditCard);
                    //TODO - Redirecionar para tela de sucesso.
                }
                else
                {
                    Messages = messages;
                }
            }
            catch (Exception)
            {

                //TODO - Colocar mensagem de erro. redirecionar erro
                throw;
            }
        }

        private string Valid(CreditCard creditCard) //realizar validações
        {
            StringBuilder messages = new StringBuilder();

            if (string.IsNullOrEmpty(creditCard.Name))
            {
                messages.Append("O nome não foi preenchido !" + Environment.NewLine);
            }


            if (string.IsNullOrEmpty(creditCard.Number))
            {
                messages.Append("O número do cartão não foi preenchido !" + Environment.NewLine);
            }
            else if (creditCard.Number.Length < 19)
            {
                messages.Append("O número do cartão está incompleto !" + Environment.NewLine);
            }


            try
            {
                var expiredString = creditCard.Expired.Split('/');
                var month = int.Parse(expiredString[0]);
                var year = int.Parse(expiredString[1]);

                new DateTime(month, year, 01);
            }
            catch (Exception e)
            {
                messages.Append("A validade do cartão não é válida!" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(creditCard.SecurityCode))
            {
                messages.Append("O código de segurança não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.SecurityCode.Length < 3)
            {
                messages.Append("O número do cartão está incompleto !" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(creditCard.Document))
            {
                messages.Append("O CPF não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.Document.Length < 14)
            {
                messages.Append("O CPF está incompleto !" + Environment.NewLine);
            }
            else if (CPFValidator.IsCpf(creditCard.Document))
            {
                messages.Append("O CPF é inválido!" + Environment.NewLine);
            }

            return messages.ToString();
        }
    }
}
