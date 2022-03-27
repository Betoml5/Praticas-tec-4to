using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Actividad3
{
    public class Convertidor : INotifyPropertyChanged
    {
        public ICommand GenerarBinarioCommand { get; set; }
        public ICommand VerificarCommand { get; set; }

        public string NumeroBinario { get; set; }
        public int NumeroDecimal { get; set; }
        public int? NumeroDecimalUsuario { get; set; }



        public bool? Ganado { get; set; }
        public bool? JuegoIniciado { get; set; } = false;
        
        public Convertidor()
        {
            GenerarBinarioCommand = new RelayCommand(GenerarBinario);
            VerificarCommand = new RelayCommand(Verificar);
        }



        public void GenerarBinario()
        {
            Random r = new();
            NumeroDecimal = r.Next(1, 255);
            NumeroBinario = Convert.ToString(NumeroDecimal, 2);
            JuegoIniciado = true;
            Ganado = null;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Verificar()
        {
            if (NumeroDecimalUsuario == NumeroDecimal)
            {
                Ganado = true;
                NumeroDecimalUsuario = null;
            }
            else
            {
                Ganado = false;
                NumeroDecimalUsuario = null;
                
            }

            JuegoIniciado = false;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public event PropertyChangedEventHandler? PropertyChanged;


    }
}
