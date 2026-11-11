using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5MauiApp.Pages.CreateFlightPage;

public partial class CreateFlightView : ContentPage
{
    private readonly CreateFlightViewModel _createFlightViewModel;

    public CreateFlightView(CreateFlightViewModel createFlightViewModel)
    {
        InitializeComponent();
        _createFlightViewModel = createFlightViewModel;
        BindingContext = _createFlightViewModel;
    }
}