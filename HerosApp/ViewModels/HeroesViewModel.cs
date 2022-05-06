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


        public string Error { get; set; } = "";
        public Hero? Hero { get; set; }
        public string View { get; set; } = "home";

        int initialPosition;



        public ICommand ChangeViewCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        //TODO 
        //Change command name to "CreateHeroCommand"
        public ICommand CreateHeroCommand { get; set; }
        public ICommand ViewHeroDetailsCommand { get; set; }
        public ICommand ViewHeroEditCommand { get; set; }
        public ICommand DeleteHeroCommand { get; set; }
        public ICommand EditHeroCommand { get; set; }


        public HeroesViewModel()
        {
            Open();
            ChangeViewCommand = new RelayCommand<string>(ChangeView);
            CancelCommand = new RelayCommand(Cancel);
            CreateHeroCommand = new RelayCommand(Create);
            ViewHeroDetailsCommand = new RelayCommand<Hero>(ViewHeroDetails);
            ViewHeroEditCommand = new RelayCommand<Hero>(ViewHeroEdit);
            DeleteHeroCommand = new RelayCommand(Delete);
            EditHeroCommand = new RelayCommand(Edit);


        }


        void ChangeView(string View)
        {
            this.View = View;
            if (View == "create")
            {
                Hero = new Hero();
            }

            if (View == "edit")
            {
                if (Hero != null)
                {
                    //Save initial positon of Hero
                    initialPosition = Heroes.IndexOf(Hero);

                    var clon = new Hero()
                    {
                        Name = Hero.Name,
                        Skill = Hero.Skill,
                        Age = Hero.Age,
                        Image = Hero.Image,
                    };

                    Hero = clon;
                   
                }
            }

            PropertyChange();
        }

        void ViewHeroDetails(Hero Hero)
        {

            
            this.Hero = Hero;
            ChangeView("details");

        }

        void ViewHeroEdit(Hero Hero)
        {
            this.Hero = Hero;
            ChangeView("edit");
        }


        //TODO
        void GoBackToHeroDetails()
        {
            ChangeView("details");
        }

        

        private void Cancel()
        {
            Hero = null;
            Error = "";
            ChangeView("home");
        }

       
        void Save()
        {

            var json = JsonConvert.SerializeObject(Heroes);
            File.WriteAllText("heroes.json", json);
        }

       void ShowErrorMessage(string ErrorMsg)
        {
            this.Error += ErrorMsg + "\n";
            PropertyChange();
        }

        void Create()
        {
            Error = "";
            if (Hero != null)
            {

                if (string.IsNullOrWhiteSpace(Hero.Name))
                {
                    ShowErrorMessage("Ingresa un nombre valido");
                }

                if (string.IsNullOrWhiteSpace(Hero.Skill))
                {
                    ShowErrorMessage("Ingresa un Don valido");
                }

                if (string.IsNullOrWhiteSpace(Hero.Age))
                {
                    ShowErrorMessage("Ingresa una edad valida");
                }

                if (!Uri.TryCreate(Hero.Image, UriKind.Absolute, out var uri))
                {
                    ShowErrorMessage("Ingresa una url valida");
                }


                if (Error == "")
                {
                    Heroes.Add(Hero);
                    ChangeView("home");
                    Save();
                }
            }
        }

        void Delete ()
        {
            if (Hero != null)
            {
                Heroes.Remove(Hero);
                Save();
                ChangeView("home");
            }
        }

        void Edit()
        {

            Error = "";
            if (Hero != null)
            {

                if (string.IsNullOrWhiteSpace(Hero.Name))
                {
                    ShowErrorMessage("Ingresa un nombre valido");
                }

                if (string.IsNullOrWhiteSpace(Hero.Skill))
                {
                    ShowErrorMessage("Ingresa un Don valido");
                }

                if (string.IsNullOrWhiteSpace(Hero.Age))
                {
                    ShowErrorMessage("Ingresa una edad valida");
                }

                if (!Uri.TryCreate(Hero.Image, UriKind.Absolute, out var uri))
                {
                    ShowErrorMessage("Ingresa una url valida");
                }

                if (Error == "")
                {
                    Heroes[initialPosition] = Hero;
                    Save();
                    ChangeView("home");
                }

                   
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
