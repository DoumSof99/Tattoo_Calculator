using Tattoo_Calculator.Models;

namespace Tattoo_Calculator.Controls;

public partial class TattooPage : ContentPage
{
	public TattooPage()
	{
		InitializeComponent();
		this.BindingContext = new TattooViewModel();
	}

}