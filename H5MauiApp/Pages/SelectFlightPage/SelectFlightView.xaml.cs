using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5MauiApp.Pages.SelectFlightPage;

public partial class SelectFlightView : ContentPage
{
    public SelectFlightView(SelectFlightViewModel selectFlightViewModel)
    {
        InitializeComponent();
        BindingContext = selectFlightViewModel;
    }
}