using Grosseto.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace Grosseto;
public partial class MainPage : ContentPage
{
    public HttpClient ht = new HttpClient();
    public string url = "https://api.jsonbin.io/v3/b/662034fead19ca34f85bbe8b";
    public ObservableCollection<MeteoGiorno> mresults { get; set; } = new ObservableCollection<MeteoGiorno>();
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        var mresponse = await ht.GetFromJsonAsync<MeteoResults>(url);
        foreach (var m in mresponse.mresults)
        {
            mresults.Add(m);
        }
    }
}