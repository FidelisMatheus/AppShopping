using AppShopping.Models;
using AppShopping.Services;
using AppShopping.Libraries.Enuns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using AppShopping.Libraries.Helpers.MVVM;

namespace AppShopping.ViewModels
{
    public class StoresViewModel : BaseViewModel
    {
        /* 
         * MVVM - View <-> ViewModel <-> Model
         * - Commands: Ações (Events) > Métodos.
         * - Bindings: Vinculos -> Propriedades.
         * - Notifications:
         * 
         * 
         * View(Lojas-Stores): Entry(Text=Binding SearchWord, Mode=TwoWay)
         * ViewModel: string SearchWord (é nome da propriedade que será vinculada na View).
         * Entry-Text=Renner (ViewModel-SearchWord:: (recebendo) Renner).
         * 
         * Notificação: INotifyPropertyChanged: Houve uma mudança em uma propriedade. MessageCenter(Code Behind)
         * 
         */

        public String SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }

        private List<Establishment> _establishments;

        public List<Establishment> Establishments
        {
            get { return _establishments; }
            set { SetProperty(ref _establishments, value); } //faz uma referencia para qual lugar ele vai ser recebido
        }

        public List<Establishment> _allEstablishments; //prop criada para evitar consultas frequentes

        public StoresViewModel()
        {
            SearchCommand = new Command(Search);

            var allEstablishment = new EstablishmentService().GetEstablishments(); //E30 = L20 + R10
            var allStores = allEstablishment.Where(a => a.Type == EstablishmentType.Store).ToList();

            Establishments = allStores;
            _allEstablishments = allStores;
        }

        private void Search()
        {
            //filtro para pesquisar os registros das lojas -> Salvo no Establishments
            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();

            /*
             * aqui ele não funcionaria corretamente, pois a tela necessita ser notificada de trocar
             * os seus dados apresentados
             */
        }

    }
}
