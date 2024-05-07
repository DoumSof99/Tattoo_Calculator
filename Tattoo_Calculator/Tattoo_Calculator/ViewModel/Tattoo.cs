using System.ComponentModel;
using System.Windows.Input;

namespace Tattoo_Calculator.Models {

    public class TattooViewModel : INotifyPropertyChanged { 
        private TattooModel tattoo = new TattooModel();

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
        public List<string>? DesignChoice {
            get => tattoo.DesignChoice;
            set {
                tattoo.DesignChoice = value;
                OnPropertyChanged(nameof(DesignChoice));
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
            get => tattoo.DesignPrice;
            set {
                tattoo.DesignPrice = value;
                OnPropertyChanged(nameof(DesignPrice));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TattooModel {
        public int? Niddle { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? ColorPrice { get; set; }
        public int? TimePrice { get; set; }
        public List<string>? DesignChoice { get; set; }
        public int? DesignPrice { get; set; }
        public int? DetailPrice { get; set; }

        public TattooModel()
        {
            DesignChoice = new List<string>() {
                "Yes",
                "No"
            };
        }
    }

}
