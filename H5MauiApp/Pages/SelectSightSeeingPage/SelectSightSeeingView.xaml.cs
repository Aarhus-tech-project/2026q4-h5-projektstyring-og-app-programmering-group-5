using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5MauiApp.Pages.SelectSightSeeingPage;

public partial class SelectSightSeeingView : ContentPage
{
    public SelectSightSeeingView(SelectSightSeeingViewModel selectSightSeeingViewModel)
    {
        InitializeComponent();
        BindingContext = selectSightSeeingViewModel;
    }
}