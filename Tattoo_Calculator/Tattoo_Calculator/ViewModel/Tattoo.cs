using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;

namespace Tattoo_Calculator.Models {

    public class TattooViewModel : INotifyPropertyChanged { 
        private TattooModel tattoo = new TattooModel();
        private bool isLabelVisible;
        //private TattooResultModel tattooResult = new TattooResultModel();

        public TattooViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate);
            ClearCommand = new RelayCommand(Clear); 
        }

        #region define props

        public TattooModel Model {
            get => tattoo;
            set {
                tattoo = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public bool IsLabelVisible {
            get => isLabelVisible;
            set {
                isLabelVisible = value;
                OnPropertyChanged(nameof(IsLabelVisible));
            }
        }

        //#region tattoo props
        //public string? Niddle { 
        //    get => tattoo.Niddle;
        //    set {
        //        tattoo.Niddle = value;
        //        OnPropertyChanged(nameof(Niddle));
        //    } 
        //}

        //public string? Height {
        //    get => tattoo.Height;
        //    set {
        //        tattoo.Height = value;
        //        OnPropertyChanged(nameof(Height));
        //    }
        //}
        //public string? Width {
        //    get => tattoo.Width;
        //    set {
        //        tattoo.Width = value;
        //        OnPropertyChanged(nameof(Width));
        //    }
        //}

        //public string? ColorPrice {
        //    get => tattoo.ColorPrice;
        //    set {
        //        tattoo.ColorPrice = value;
        //        OnPropertyChanged(nameof(ColorPrice));
        //    }
        //}
        //public string? TimePrice {
        //    get => tattoo.TimePrice;
        //    set {
        //        tattoo.TimePrice = value;
        //        OnPropertyChanged(nameof(TimePrice));
        //    }
        //}
        //public string? DesignPrice {
        //    get => tattoo.DesignPrice;
        //    set {
        //        tattoo.DesignPrice = value;
        //        OnPropertyChanged(nameof(DesignPrice));
        //    }
        //}
        //public string? DetailPrice {
        //    get => tattoo.DetailPrice;
        //    set {
        //        tattoo.DetailPrice = value;
        //        OnPropertyChanged(nameof(DesignPrice));
        //    }
        //}
        //#endregion

        //#region tattoo result props
        //public string? NiddleResultPrice {
        //    get => tattooResult.NiddleResultPrice;
        //    set {
        //        tattooResult.NiddleResultPrice = value;
        //        OnPropertyChanged(nameof(NiddleResultPrice));
        //    }
        //}

        //public string? HeightResultPrice {
        //    get => tattooResult.HeightResultPrice;
        //    set {
        //        tattooResult.HeightResultPrice = value;
        //        OnPropertyChanged(nameof(HeightResultPrice));
        //    }
        //}
        //public string? WidthResultPrice {
        //    get => tattooResult.WidthResultPrice;
        //    set {
        //        tattooResult.WidthResultPrice = value;
        //        OnPropertyChanged(nameof(WidthResultPrice));
        //    }
        //}

        //public string? ColorResultPrice {
        //    get => tattooResult.ColorResultPrice;
        //    set {
        //        tattooResult.ColorResultPrice = value;
        //        OnPropertyChanged(nameof(ColorResultPrice));
        //    }
        //}
        //public string? TimeResultPrice {
        //    get => tattooResult.TimeResultPrice;
        //    set {
        //        tattooResult.TimeResultPrice = value;
        //        OnPropertyChanged(nameof(TimeResultPrice));
        //    }
        //}
        //public string? DesignResultPrice {
        //    get => tattooResult.DesignResultPrice;
        //    set {
        //        tattooResult.DesignResultPrice = value;
        //        OnPropertyChanged(nameof(DesignResultPrice));
        //    }
        //}
        //public string? DetailResultPrice {
        //    get => tattooResult.DetailResultPrice;
        //    set {
        //        tattooResult.DetailResultPrice = value;
        //        OnPropertyChanged(nameof(DetailResultPrice));
        //    }
        //}
        //public string? TotalPrice {
        //    get => tattooResult.TotalPrice;
        //    set {
        //        tattooResult.TotalPrice = value;
        //        OnPropertyChanged(nameof(TotalPrice));
        //    }
        //}
        //public bool IsLabelVisible {
        //    get => tattooResult.IsLabelVisible;
        //    set {
        //        tattooResult.IsLabelVisible = value;
        //        OnPropertyChanged(nameof(IsLabelVisible));
        //    }
        //}
        //#endregion
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
                Model = Helper.CalculateResults(tattoo);
                IsLabelVisible = true;
            }
        }

        private void Clear() {
            Model = Helper.ClearFields(tattoo);
            //Helper.ClearFields(tattooResult);
            IsLabelVisible = false;
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

    //public class TattooResultModel {
        
    //    //public string? ColorResultPrice { get; set; }
    //    //public string? TimeResultPrice { get; set; }
    //    //public string? DesignResultPrice { get; set; }
    //    //public string? DetailResultPrice { get; set; }
       
    //}

    public class TattooModel {
        public string? Niddle { get; set; }
        public string? Height { get; set; }
        public string? Width { get; set; }
        public string? ColorPrice { get; set; }
        public string? TimePrice { get; set; }
        public string? DesignPrice { get; set; }
        public string? DetailPrice { get; set; }
        public string? NiddleResultPrice { get; set; }
        public string? HeightResultPrice { get; set; }
        public string? WidthResultPrice { get; set; }
        public string? TotalPrice { get; set; }
        //public bool IsLabelVisible { get; set; } = false;
    }

    public static class Helper {

        public static bool ValidateFields(TattooModel tattoo) {

            PropertyInfo[] properties = tattoo.GetType().GetProperties();

            foreach (PropertyInfo property in properties) {
                var obj = property.GetValue(tattoo);

                if (!string.IsNullOrEmpty(obj as string) && !ValidateTypes(obj as string)) {
                    ShowValidationError(string.Format("The {0} field should be numeric and not zero", property.Name));
                    return false;
                }
            }
            return ValidateNullableFields(tattoo);
        }

        private static bool ValidateTypes(string? prop) {
            
            return int.TryParse(prop, out int parsedVal) && parsedVal != 0;
        }

        private static bool ValidateNullableFields(TattooModel tattoo) {
          
            if (string.IsNullOrEmpty(tattoo.Niddle)) {
                ShowValidationError("The niddle field cannot be null");
                return false;
            }
            if (string.IsNullOrEmpty(tattoo.Width)) {
                ShowValidationError("The width field cannot be null"); 
                return false;
            }
            if (string.IsNullOrEmpty(tattoo.Height)) {
                ShowValidationError("The height field cannot be null");
                return false;
            }

            return true;
        }

        private static void ShowValidationError(string message) {
            Application.Current.MainPage.DisplayAlert("Error", message, "OK");
        }

        public static TattooModel CalculateResults(TattooModel tattoo) {

            Dictionary<string, int?> dcPrices = GetPricesDict(tattoo);

            return new TattooModel {
                Niddle = tattoo.Niddle,
                Width = tattoo.Width,
                Height = tattoo.Height,
                NiddleResultPrice = dcPrices.TryGetValue("niddle", out int? niddle) ? niddle.ToString() : string.Empty,
                HeightResultPrice = dcPrices.TryGetValue("height", out int? height) ? height.ToString() : string.Empty,
                WidthResultPrice = dcPrices.TryGetValue("width", out int? width) ? width.ToString() : string.Empty,
                ColorPrice = dcPrices.TryGetValue("color", out int? color) ? color.ToString() : string.Empty,
                TimePrice = dcPrices.TryGetValue("time", out int? time) ? time.ToString() : string.Empty,
                DesignPrice = dcPrices.TryGetValue("design", out int? design) ? design.ToString() : string.Empty,
                DetailPrice = dcPrices.TryGetValue("detail", out int? detail) ? detail.ToString() : string.Empty,
                TotalPrice = dcPrices.Values.Sum().ToString()
            };
        }

        private static Dictionary<string, int?> GetPricesDict(TattooModel tattoo) {

            return new Dictionary<string, int?> {
                { "niddle", int.Parse(tattoo.Niddle) * 20 },
                { "height", int.Parse(tattoo.Height) * 5 },
                { "width", int.Parse(tattoo.Width) * 5 },
                { "color", !string.IsNullOrEmpty(tattoo.ColorPrice) ? int.Parse(tattoo.ColorPrice) : null },
                { "time", !string.IsNullOrEmpty(tattoo.TimePrice) ? int.Parse(tattoo.TimePrice) : null },
                { "design", !string.IsNullOrEmpty(tattoo.DesignPrice) ? int.Parse(tattoo.DesignPrice) : null },
                { "detail", !string.IsNullOrEmpty(tattoo.DetailPrice) ? int.Parse(tattoo.DetailPrice) : null }
            };
        }

        public static T ClearFields<T>(T model) {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties) {
                property.SetValue(model, null);
            }
            return model;
        }
    }

}
