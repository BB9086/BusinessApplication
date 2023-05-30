using BusinessMobile.ViewModel;

namespace BusinessMobile.View;

public partial class YearsPage : ContentPage
{
	public YearsPage(YearsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}