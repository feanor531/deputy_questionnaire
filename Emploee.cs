using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5
{
   
    internal class Emploee : INotifyPropertyChanged, IEditableObject
    {
        private ItemData _copyData;
        private ItemData _currentData;


        //private string first_name;
        //private string second_name;
        //private string surname;
        //private int birth_year;
        //private string education; // образование
        //private string languages;
        //private string level_language;
        //private string computer_skills;
        //private int experients; //стаж работы
        //private string recomendation;

        public Emploee() { }
        public Emploee(string _first_name, string _second_name,
                string _surname, int _birth_year,
                string _education, string _languages, string _level_language,
                string _computer_skills, int _experients, string _recomendation)
        {
            FirstName = _first_name;
            SecondName = _second_name;
            Surnaname = _surname;
            BirthYear = _birth_year;
            Education = _education;
            Languages = _languages;
            LevelLanguage = _level_language;
            ComputerSkills = _computer_skills;
            Experients = _experients;
            Recomendation = _recomendation;
        }

        public string FirstName
        {
            get { return _currentData.FirstName; }
            set
            {
                _currentData.FirstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        public string SecondName
        {
            get { return _currentData.SecondName; }
            set
            {
                _currentData.SecondName = value;
                NotifyPropertyChanged("SecondName");
            }
        }
        public string Surnaname
        {
            get { return _currentData.Surnaname; }
            set
            {
                _currentData.Surnaname = value;
                NotifyPropertyChanged("Surnaname");
            }
        }
        public int BirthYear
        {
            get { return _currentData.BirthYear; }
            set
            {
                _currentData.BirthYear = value;
                NotifyPropertyChanged("BirthYear");
            }
        }
        public string Education
        {
            get { return _currentData.Education; }
            set
            {
                _currentData.Education = value;
                NotifyPropertyChanged("Education");
            }
        }
        public string Languages
        {
            get { return _currentData.Languages; }
            set
            {
                _currentData.Languages = value;
                NotifyPropertyChanged("Languages");
            }
        }
        public string LevelLanguage
        {
            get { return _currentData.LevelLanguage; }
            set
            {
                _currentData.LevelLanguage = value;
                NotifyPropertyChanged("LevelLanguage");
            }
        }
        public string ComputerSkills
        {
            get { return _currentData.ComputerSkills; }
            set
            {
                _currentData.ComputerSkills = value;
                NotifyPropertyChanged("ComputerSkills");
            }
        }
        public int Experients
        {
            get { return _currentData.Experients; }
            set
            {
                _currentData.Experients = value;
                NotifyPropertyChanged("Experients");
            }
        }
        public string Recomendation
        {
            get { return _currentData.Recomendation; }
            set
            {
                _currentData.Recomendation = value;
                NotifyPropertyChanged("Recomendation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string arg)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(arg));
        }

        public override string ToString() => $"{Surnaname} {FirstName} {SecondName}";
        private struct ItemData
        {
            internal string FirstName;
            internal string SecondName;
            internal string Surnaname;
            internal int BirthYear;
            internal string Education;
            internal string Languages;
            internal string LevelLanguage;
            internal string ComputerSkills;
            internal int Experients;
            internal string Recomendation;
        }

        public void BeginEdit()
        {
            _copyData = _currentData;
        }

        public void CancelEdit()
        {
            _currentData = _copyData;
            NotifyPropertyChanged("");
        }

        public void EndEdit()
        {
            _copyData = new ItemData();
        }
    }
}
