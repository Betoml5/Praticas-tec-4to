using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculadoraFracciones
{
    public class Calculadora:INotifyPropertyChanged
    {

        public Calculadora()
        {
            SumarCommand = new RelayCommand(Sumar);
            RestarCommand = new RelayCommand(Restar);
            LimpiarCommand = new RelayCommand(Limpiar);
        }

        public ICommand SumarCommand { get; set; }
        public ICommand RestarCommand { get; set; }
        public ICommand LimpiarCommand { get; set; }
        
        public int? Numerador1 { get; set; }
        public int? Denominador1 { get; set; }
        public int? Numerador2 { get; set; }
        public int? Denominador2 { get; set; }
        public int? ResultadoNumerador {  get; set; }
        public int? ResultadoDenominador { get; set; }
        public string ErrorMsg { get; set; } = "";




        public void Sumar()
        {
            if (Numerador1 != null && Numerador2 != null && Denominador1 != null &&  Denominador2 !=null)
            {
                ResultadoNumerador = (Numerador1 * Denominador2) + (Numerador2 * Denominador2);
                ResultadoDenominador = Denominador1 * Denominador2;
            } else
            {
                ErrorMsg = "Ingresa valores validos";
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

        }

        public void Restar()
        {
            if (Numerador1 != null && Numerador2 != null && Denominador1 != null && Denominador2 != null)
            {
                ResultadoNumerador = (Numerador1 * Denominador2) - (Numerador2 * Denominador2);
                ResultadoDenominador = (Denominador1 * Denominador2);
            }
            else
            {
                ErrorMsg = "Ingresa valores validos";
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

        }

        public void Limpiar()
        {
            Numerador1 = null;
            Numerador2 = null;
            Denominador1 = null;
            Denominador2 = null;
            ResultadoDenominador = null;
            ResultadoNumerador = null;
            ErrorMsg = "";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
