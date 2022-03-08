
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContadorDigital
{
    public class Contador : INotifyPropertyChanged
    {
        public ICommand SumarCommand { get; set; }
        public ICommand RestarCommand { get; set; }
        public ICommand ResetarCommand { get; set; }

        int CountN;

        public int Count
        {
            get { return CountN; }
            set { CountN = value; }
        }

        public Contador()
        {
            SumarCommand = new RelayCommand(Sumar);
        }

        public void Sumar()
        {
            CountN++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Restar()
        {
            CountN--;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

        }

        public void Resetar()
        {
            CountN = 0;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
