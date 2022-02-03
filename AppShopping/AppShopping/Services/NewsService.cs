using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class NewsService
    {
        private static List<News> fakeNews = new List<News>()
        {
            new News(){ Title = "Dia das Mães", Description = "A cada R$ 100,00 em compras ganhe um cupom para concorrer a um carro"},
            new News(){ Title = "Natal", Description = "A cada R$ 100,00 em compras ganhe um cupom para concorrer a um carro"}
        };

        public List<News> GetNews()
        {
            return fakeNews;
        }
    }
}
