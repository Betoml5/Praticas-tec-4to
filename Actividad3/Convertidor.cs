using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Actividad3
{
    public class Convertidor : INotifyPropertyChanged
    {
        public ICommand? GenerarBinarioCommand { get; set; }

        public Convertidor()
        {
            GenerarBinarioCommand = new RelayCommand(GenerarBinario);
        }


        public int NumeroBinario { get; set; }

        public int NumeroDecimal { get; set; }


        public void GenerarBinario()
        {
            Random r = new();
            NumeroBinario = r.Next(1, 255);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

        }

        public event PropertyChangedEventHandler? PropertyChanged;

     
    }
    

    
   
}
