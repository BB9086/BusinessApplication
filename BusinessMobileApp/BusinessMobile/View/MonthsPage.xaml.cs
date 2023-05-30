using BusinessMobile.ViewModel;

namespace BusinessMobile.View;

public partial class MonthsPage : ContentPage
{
	public MonthsPage(MonthsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}