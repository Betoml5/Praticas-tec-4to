using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ejercicio_Binding_1
{
    public class Votacion:INotifyPropertyChanged
                                      
    {

        public ICommand VotarCommand { get; set; }

        public double Si { get; set; }
        public double No { get; set; }



        public double PorcentajeSi
        {
            get
            {
                if (Si+No == 0)
                {
                    return 0;
                }
                {
                    return (Si * 100) / (Si + No);
                } }
        }

        public double PorcentajeNo
        {
            get {
                if (Si+No == 0)
                {
                    return 0;

                }

                return (No * 100) / (Si + No);
            }
        }




        public Votacion()
        {
            VotarCommand = new RelayCommand<bool>(Votar);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Votar(bool voto)
        {
            if (voto)
            {
                Si++;
             }
            else
            {
                No++;
            }
            //Actualiza ambas propiedades en la UI
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Like()
        {
            this.Si++;
        }

        public void Dislike()
        {
            this.No++;
        }
       
    }
}
