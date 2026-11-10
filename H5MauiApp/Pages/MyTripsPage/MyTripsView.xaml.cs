using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5MauiApp.Pages.MyTripsPage;

public partial class MyTripsView : ContentPage
{
    private readonly MyTripsViewModel _myTripsViewModel;

    public MyTripsView(MyTripsViewModel myTripsViewModel)
    {
        InitializeComponent();
        _myTripsViewModel = myTripsViewModel;
        BindingContext = _myTripsViewModel;
    }

    // todo async void is dangerous ? 
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        // do you need try catch for global ex hadnling in thr app? 
        try
        {
            await _myTripsViewModel.GetTripsAsync();
        }
        catch (Exception ex)
        {
            // Log the error and show an appropriate message.
        }
    }
}