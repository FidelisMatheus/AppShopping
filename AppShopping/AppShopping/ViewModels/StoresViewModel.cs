using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.ViewModels
{
    public class StoresViewModel
    {
        /* 
         * MVVM - View <-> ViewModel <-> Model
         * - Commands: Ações (Events) > Métodos.
         * - Bindings: Vinculos -> Propriedades.
         * - Notifications:
         * 
         * 
         * View(Lojas-Stores): Entry(Text=Binding SearchWord, Mode=TwoWay)
         * ViewMOdel: string SearchWord (é nome da propriedade que será vinculada na View).
         * Entry-Text=Renner (ViewModel-SearchWord:: (recebendo) Renner).
         * 
         * Notificação: INotifyPropertyChanged: Houve uma mudança em uma propriedade. MessageCenter(Code Behind)
         * 
         */
    }
}
