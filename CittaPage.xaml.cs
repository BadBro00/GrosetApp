using System;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using Grosseto.Models;
namespace Grosseto;

public partial class CittaPage : ContentPage
{
    readonly HttpClient ht = new HttpClient();
    readonly string baseurl = "https://api.jsonbin.io/v3/b/6620334ce41b4d34e4e60a2c";
    public ObservableCollection<Citta> cresults { get; set; } = new ObservableCollection<Citta>();

    public CittaPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var cresponse = await ht.GetFromJsonAsync<CittaResults>(baseurl);
        foreach (var c in cresponse.results)
        {
            cresponse.results.Add(c);
        }
    }
}