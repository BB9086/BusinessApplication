using BusinessMobile.ViewModel;
using MetroLog.Maui;

namespace BusinessMobile.View;

public partial class StorePage : ContentPage
{
	public StorePage(StoresViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		//View log info when shake phone 
		var logController = new LogController();
		logController.IsShakeEnabled = true;
	}
}