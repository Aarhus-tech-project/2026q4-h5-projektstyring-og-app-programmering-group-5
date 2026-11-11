using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5MauiApp.Pages.TripDetails;

public partial class TripDetailsView : ContentPage
{
    private readonly TripDetailsViewModel _tripDetailsViewModel;

    public TripDetailsView(TripDetailsViewModel tripDetailsViewModel)
    {
        InitializeComponent();
        _tripDetailsViewModel = tripDetailsViewModel;
        BindingContext = _tripDetailsViewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await _tripDetailsViewModel.GetTripDetailsAsync();
    }
}