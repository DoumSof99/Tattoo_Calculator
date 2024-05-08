using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;

namespace Tattoo_Calculator.Models {

    public class TattooViewModel : INotifyPropertyChanged { 
        private TattooModel tattoo = new TattooModel();
        private TattooResultModel tattooResult = new TattooResultModel();

        public TattooViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate);
            ClearCommand = new RelayCommand(Clear); 
            
            //DesignChoice = new List<string>() {
            //    "Yes",
            //    "No"
            //};
        }

        #region define props
        #region tattoo props
        public string? Niddle { 
            get => tattoo.Niddle;
            set {
                tattoo.Niddle = value;
                OnPropertyChanged(nameof(Niddle));
            } 
        }

        public string? Height {
            get => tattoo.Height;
            set {
                tattoo.Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }
        public string? Width {
            get => tattoo.Width;
            set {
                tattoo.Width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public string? ColorPrice {
            get => tattoo.ColorPrice;
            set {
                tattoo.ColorPrice = value;
                OnPropertyChanged(nameof(ColorPrice));
            }
        }
        public string? TimePrice {
            get => tattoo.TimePrice;
            set {
                tattoo.TimePrice = value;
                OnPropertyChanged(nameof(TimePrice));
            }
        }
        public string? DesignPrice {
            get => tattoo.DesignPrice;
            set {
                tattoo.DesignPrice = value;
                OnPropertyChanged(nameof(DesignPrice));
            }
        }
        public string? DetailPrice {
            get => tattoo.DetailPrice;
            set {
                tattoo.DetailPrice = value;
                OnPropertyChanged(nameof(DesignPrice));
            }
        }
        #endregion

        #region tattoo result props
        public string? NiddleResultPrice {
            get => tattooResult.NiddleResultPrice;
            set {
                tattooResult.NiddleResultPrice = value;
                OnPropertyChanged(nameof(NiddleResultPrice));
            }
        }

        public string? HeightResultPrice {
            get => tattooResult.HeightResultPrice;
            set {
                tattooResult.HeightResultPrice = value;
                OnPropertyChanged(nameof(HeightResultPrice));
            }
        }
        public string? WidthResultPrice {
            get => tattooResult.WidthResultPrice;
            set {
                tattooResult.WidthResultPrice = value;
                OnPropertyChanged(nameof(WidthResultPrice));
            }
        }

        public string? ColorResultPrice {
            get => tattooResult.ColorResultPrice;
            set {
                tattooResult.ColorResultPrice = value;
                OnPropertyChanged(nameof(ColorResultPrice));
            }
        }
        public string? TimeResultPrice {
            get => tattooResult.TimeResultPrice;
            set {
                tattooResult.TimeResultPrice = value;
                OnPropertyChanged(nameof(TimeResultPrice));
            }
        }
        public string? DesignResultPrice {
            get => tattooResult.DesignResultPrice;
            set {
                tattooResult.DesignResultPrice = value;
                OnPropertyChanged(nameof(DesignResultPrice));
            }
        }
        public string? DetailResultPrice {
            get => tattooResult.DetailResultPrice;
            set {
                tattooResult.DetailResultPrice = value;
                OnPropertyChanged(nameof(DetailResultPrice));
            }
        }
        public string? TotalPrice {
            get => tattooResult.TotalPrice;
            set {
                tattooResult.TotalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        public bool? IsLabelVisible {
            get => tattooResult.IsLabelVisible;
            set {
                tattooResult.IsLabelVisible = value;
                OnPropertyChanged(nameof(IsLabelVisible));
            }
        }
        #endregion
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Buttons commands impl
        public ICommand CalculateCommand { get; }
        public ICommand ClearCommand { get; }

        private void Calculate() {
            if (Helper.ValidateFields(tattoo)) {

                var niddleRes = Convert.ToInt32(Niddle) * 20;
                NiddleResultPrice = Convert.ToString(niddleRes);

                TotalPrice = "100";
            }
        }

        private void Clear() { 
            
        }
    }

    public class RelayCommand : ICommand {

        public event EventHandler? CanExecuteChanged;
        private readonly Action execute;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => execute.Invoke();
    }

    public class TattooResultModel {
        public string? NiddleResultPrice { get; set; }
        public string? HeightResultPrice { get; set; }
        public string? WidthResultPrice { get; set; }
        public string? ColorResultPrice { get; set; }
        public string? TimeResultPrice { get; set; }
        public string? DesignResultPrice { get; set; }
        public string? DetailResultPrice { get; set; }
        public string? TotalPrice { get; set; }
        public bool? IsLabelVisible { get; set; }
    }

    public class TattooModel {
        public string? Niddle { get; set; }
        public string? Height { get; set; }
        public string? Width { get; set; }
        public string? ColorPrice { get; set; }
        public string? TimePrice { get; set; }
        public string? DesignPrice { get; set; }
        public string? DetailPrice { get; set; }

    }

    public static class Helper {

        public static bool ValidateFields(TattooModel tattoo) {
            bool valid = true;
            PropertyInfo[] properties = tattoo.GetType().GetProperties();

            foreach (PropertyInfo property in properties) {
                var obj = property.GetValue(tattoo);

                if (obj != null && !ValidateTypes(obj as string)) {
                    Application.Current.MainPage.DisplayAlert("Error", string.Format("The {0} field should be numeric", property.Name), "OK");
                    valid = false;
                    break;
                }
            }
            if (valid) {
                valid = ValidateNullableFields(tattoo);
            }

            return valid;
        }

        private static bool ValidateTypes(string? prop) {
            
            if (!int.TryParse(prop, out int parsedVal)) {
                return false;
            }
            return true;
        }

        private static bool ValidateNullableFields(TattooModel tattoo) {
          
            if (string.IsNullOrEmpty(tattoo.Niddle)) {
                Application.Current.MainPage.DisplayAlert("Error", "The niddle field cannot be null", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(tattoo.Width)) {
                Application.Current.MainPage.DisplayAlert("Error", "The width field cannot be null", "OK"); 
                return false;
            }
            if (string.IsNullOrEmpty(tattoo.Height)) {
                Application.Current.MainPage.DisplayAlert("Error", "The height field cannot be null", "OK");
                return false;
            }

            return true;
        }
    }

}
