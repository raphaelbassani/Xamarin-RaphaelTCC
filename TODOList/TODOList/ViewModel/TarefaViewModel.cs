using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TODOList.Commands;
using TODOList.Model;
using TODOList.Service;
using Xamarin.Forms;

namespace TODOList.ViewModel
{
    public class TarefaViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<TarefaModel> ListaTarefa { get; set; }
        public Name _currentName;


        public Name CurrentName
        {
            get => _currentName;
            set
            {
                _currentName = value;
                OnPropertyChanged();
            } }


        private TarefaModel _tarefaAtual;

        public TarefaModel TarefaAtual { 
            get =>_tarefaAtual;
            set 
            {
                _tarefaAtual = value;
                OnPropertyChanged();

            }
        }

        public Command  SalvarCommand { get; private set; }
        public Command EditarCommand { get; private set; }
        public Command ExcluirCommand { get; private set; }
        public ICommand EditarSituacaoCommand { get; private set; }
       
        public Command AtualizarNameCommand { get; private set; } 


        public TarefaViewModel()
        {
            TarefaAtual = new TarefaModel();
            CurrentName = new Name("Raphael");

            ListaTarefa = new ObservableCollection<TarefaModel>(TarefaService.Instance.GetListTarefa());

            SalvarCommand = new Command(Salvar);
            EditarCommand = new Command<TarefaModel>(Editar);

            ExcluirCommand = new Command<TarefaModel>(Excluir);

            EditarSituacaoCommand = new EditarSituacaoCommand(this);

            AtualizarNameCommand = new Command(Atualizar);


            GetName();
            
        }

        private void Atualizar()
        {
            GetName();
        }

        private void Salvar()
        {
            bool exists = false;
            foreach (var item in ListaTarefa)
            {
                if(TarefaAtual.Description == item.Description)
                {
                    exists = true;
                }
            }
            if (exists)
            {
                App.Current.MainPage.DisplayAlert("Item já cadastrado ", "",
                    "Ok");
            }
            else
            {
                if (TarefaAtual.Id == 0)
                {
                    TarefaAtual.Done = false;
                    TarefaService.Instance.Save(TarefaAtual);
                    ListaTarefa.Add(TarefaAtual);
                }
                else
                {
                    TarefaService.Instance.Update(TarefaAtual);
                    var tarefa = ListaTarefa.Where(t => t.Id == TarefaAtual.Id).FirstOrDefault();
                    var index = ListaTarefa.IndexOf(tarefa);

                    if (tarefa != null)
                    {
                        ListaTarefa.RemoveAt(index);
                        ListaTarefa.Insert(index, TarefaAtual);
                    }

                }
            }

            
            TarefaAtual = new TarefaModel();
        }

        private void Editar(TarefaModel tarefa) => TarefaAtual = tarefa;

        private async void Excluir(TarefaModel tarefa)
        {
            var result = await App.Current.MainPage.DisplayAlert("Deseja " +
                "deletar este item?", "","Deletar", "Cancelar");
            if (result)
            {
                TarefaService.Instance.Delete(tarefa);
                ListaTarefa.Remove(tarefa);
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        INameService _rest = DependencyService.Get<INameService>();
        
        public async void GetName()
        {
            var result = await _rest.getName();

            if (result != null)
            {
                Console.WriteLine(result.FirstName);
                CurrentName = new Name(result.FirstName);
            }
        }

        private string nameOf(string displayName)
        {
            throw new NotImplementedException();
        }

        private NameStat nameStats;

        public NameStat NameStats
        {
            get { return nameStats; }
            set
            {
                nameStats = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameStats"));
            }
        }


    }
}
