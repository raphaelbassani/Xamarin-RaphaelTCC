using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using TODOList.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODOList.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TarefaPageView : ContentPage
    {
        //private TarefaModel _tarefaInEdition;
        public TarefaPageView()
        {
            
            InitializeComponent();
            BindingContext = new TarefaViewModel();

        }
    }
}