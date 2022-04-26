using GalaSoft.MvvmLight.Command;
using HerosApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HerosApp.ViewModels
{
    public class HeroesViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Hero> Heroes { get; set; } = new ObservableCollection<Hero>();

        public Hero? Hero { get; set; }
        public string View { get; set; } = "home";



        public ICommand ChangeViewCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ICommand CreateCommand { get; set; }


        public HeroesViewModel()
        {
            Open();
            ChangeViewCommand = new RelayCommand<string>(ChangeView);
            CancelCommand = new RelayCommand(Cancel);
            CreateCommand = new RelayCommand(Create);
        }


        void ChangeView(string View)
        {
            this.View = View;

            if (View == "create")
            {
                Hero = new Hero();
            }

            PropertyChange();
        }

        private void Cancel()
        {
            Hero = null;
            ChangeView("home");
        }
        void Save()
        {

            var json = JsonConvert.SerializeObject(Heroes);
            File.WriteAllText("heroes.json", json);
        }

        void Create()
        {
            if (Hero != null)
            {
                Heroes.Add(Hero);
                ChangeView("home");
                Save();
            }
        }
        void Open()
        {
            if (File.Exists("heroes.json"))
            {
                var json = File.ReadAllText("heroes.json");
                var data = JsonConvert.DeserializeObject<ObservableCollection<Hero>>(json);

                if (data == null)
                {
                    Heroes = new ObservableCollection<Hero>();
                }
                else
                {
                    Heroes = data;
                }
            }
        }

        void PropertyChange(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
