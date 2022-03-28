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

        TableroWindow tableroWindow = new ();
        ConvertidorWindow convertidorWindow = new ();  
        CalculadoraWindow calculadoraWindow = new();  
        ContadorWindow contadorWindow = new();


        public ICommand ShowTableroCommand { get; set; }
        public ICommand ShowConvertidorCommand { get; set; }
        public ICommand ShowCalculadoraCommand { get; set; }
        public ICommand ShowContadorCommand { get; set; }


        public void ShowTablero()
        {
            tableroWindow.Show();
        }

        public void ShowConvertidor()
        {
            convertidorWindow.Show();
        }

        public void ShowCalculadora()
        {
            calculadoraWindow.Show();
        }
        public void ShowContador()
        {
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
