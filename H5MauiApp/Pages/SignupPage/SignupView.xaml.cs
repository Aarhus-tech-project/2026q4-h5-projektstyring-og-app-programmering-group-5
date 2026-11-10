using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5MauiApp.Pages.SignupPage;

public partial class SignupView : ContentPage
{
    public SignupView(SignupViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}