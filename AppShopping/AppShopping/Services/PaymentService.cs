using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class PaymentService
    {
        //Falta enviar para o Provedor de Pagamento: Ticker(Number), Valor e Dados do Cliente(Endereço) - Visa, Master. 

        public int SendPayment(CreditCard creditCard) //realiza o pagamento
        {
            if(creditCard.SecurityCode == "111")
            {
                throw new Exception("Código de segurança inválido!");
            }

            return 1; //geralmente enviaria um codigo de transação
        }
    }
}
