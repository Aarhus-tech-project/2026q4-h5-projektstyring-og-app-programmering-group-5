using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5MauiApp.Pages.TripDetails;

public partial class TripDetailsView : ContentPage
{
    public TripDetailsView(TripDetailsViewModel tripDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = tripDetailsViewModel;
    }
}