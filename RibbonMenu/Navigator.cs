using GalaSoft.MvvmLight.Command;
using RibbonMenu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RibbonMenu
{
    public class Navigator
    {

        
       


        public ICommand ShowTableroCommand { get; set; }
        public ICommand ShowConvertidorCommand { get; set; }
        public ICommand ShowCalculadoraCommand { get; set; }
        public ICommand ShowContadorCommand { get; set; }


        public void ShowTablero()
        {
            TableroWindow tableroWindow = new();
            tableroWindow.Show();
            

        }

        public void ShowConvertidor()
        {
            ConvertidorWindow convertidorWindow = new();
            convertidorWindow.Show();
        }

        public void ShowCalculadora()
        {
            CalculadoraWindow calculadoraWindow = new();

            calculadoraWindow.Show();
        }
        public void ShowContador()
        {
            ContadorWindow contadorWindow = new();

            contadorWindow.Show();
        }

        public Navigator()
        {
            ShowTableroCommand = new RelayCommand(ShowTablero);
            ShowConvertidorCommand = new RelayCommand(ShowConvertidor);
            ShowCalculadoraCommand = new RelayCommand(ShowCalculadora);
            ShowContadorCommand = new RelayCommand(ShowContador);
        }



    }
}
