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
        public int? Niddle { 
            get => tattoo.Niddle;
            set {
                tattoo.Niddle = value;
                OnPropertyChanged(nameof(Niddle));
            } 
        }

        public int? Height {
            get => tattoo.Height;
            set {
                tattoo.Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }
        public int? Width {
            get => tattoo.Width;
            set {
                tattoo.Width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public int? ColorPrice {
            get => tattoo.ColorPrice;
            set {
                tattoo.ColorPrice = value;
                OnPropertyChanged(nameof(ColorPrice));
            }
        }
        public int? TimePrice {
            get => tattoo.TimePrice;
            set {
                tattoo.TimePrice = value;
                OnPropertyChanged(nameof(TimePrice));
            }
        }
        public int? DesignPrice {
            get => tattoo.DesignPrice;
            set {
                tattoo.DesignPrice = value;
                OnPropertyChanged(nameof(DesignPrice));
            }
        }
        public int? DetailPrice {
            get => tattoo.DetailPrice;
            set {
                tattoo.DetailPrice = value;
                OnPropertyChanged(nameof(DesignPrice));
            }
        }
        #endregion

        #region tattoo result props
        public int? NiddleResultPrice {
            get => tattooResult.NiddleResultPrice;
            set {
                tattooResult.NiddleResultPrice = value;
                OnPropertyChanged(nameof(NiddleResultPrice));
            }
        }

        public int? HeightResultPrice {
            get => tattooResult.HeightResultPrice;
            set {
                tattooResult.HeightResultPrice = value;
                OnPropertyChanged(nameof(HeightResultPrice));
            }
        }
        public int? WidthResultPrice {
            get => tattooResult.WidthResultPrice;
            set {
                tattooResult.WidthResultPrice = value;
                OnPropertyChanged(nameof(WidthResultPrice));
            }
        }

        public int? ColorResultPrice {
            get => tattooResult.ColorResultPrice;
            set {
                tattooResult.ColorResultPrice = value;
                OnPropertyChanged(nameof(ColorResultPrice));
            }
        }
        public int? TimeResultPrice {
            get => tattooResult.TimeResultPrice;
            set {
                tattooResult.TimeResultPrice = value;
                OnPropertyChanged(nameof(TimeResultPrice));
            }
        }
        public int? DesignResultPrice {
            get => tattooResult.DesignResultPrice;
            set {
                tattooResult.DesignResultPrice = value;
                OnPropertyChanged(nameof(DesignResultPrice));
            }
        }
        public int? DetailResultPrice {
            get => tattooResult.DetailResultPrice;
            set {
                tattooResult.DetailResultPrice = value;
                OnPropertyChanged(nameof(DetailResultPrice));
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
                return;
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
        public int? NiddleResultPrice { get; set; }
        public int? HeightResultPrice { get; set; }
        public int? WidthResultPrice { get; set; }
        public int? ColorResultPrice { get; set; }
        public int? TimeResultPrice { get; set; }
        public int? DesignResultPrice { get; set; }
        public int? DetailResultPrice { get; set; }
    }

    public class TattooModel {
        public int? Niddle { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? ColorPrice { get; set; }
        public int? TimePrice { get; set; }
        public int? DesignPrice { get; set; }
        public int? DetailPrice { get; set; }

    }

    public static class Helper {

        public static bool ValidateFields(TattooModel tattoo) {
            bool valid = true;
            PropertyInfo[] properties = tattoo.GetType().GetProperties();

            foreach (PropertyInfo property in properties) {
                var obj = property.GetValue(tattoo);
                //if (obj != null && ValidateTypes(obj as string)) {
                //    valid = false;
                //    break;
                //}
            }
            return valid;
        }

        //private static bool ValidateTypes(string? prop) {
        //    int parsedVal;

        //    if (!int.TryParse(prop, out parsedVal)) {

        //    }
        //}
    }

}
