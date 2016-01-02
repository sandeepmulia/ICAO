using ICAO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICAO.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region "Private Properties"
        private List<Tuple<char, string>> _translatedContents = new List<Tuple<char, string>>();
        #endregion

        #region "Public Properties"
        public ICommand TranslateCommand { get; set;}
        public string UserText { get; set; }
        public List<Tuple<char, string>> TranslatedContents 
        {
            get
            {
                Debug.WriteLine(_translatedContents.Count);
                return _translatedContents;
            }

            set
            {
                _translatedContents = value;
                OnPropertyChanged("TranslatedContents");
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            TranslateCommand = new DelegateCommand(TranslateText, CanTranslateBeEnabled);
        }

        private void TranslateText(object parameter)
        {
            ICAOAlphabet alpha = new ICAOAlphabet();
            _translatedContents = alpha.Translate(UserText);
            TranslatedContents = _translatedContents;

            _translatedContents.ForEach((elem) =>
            {
                SpeechSynthesizerModel.Instance.Speak(elem.Item2);
            });
        }

        private bool CanTranslateBeEnabled(object parameter)
        {
            return String.IsNullOrEmpty(UserText) ? false : true;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
