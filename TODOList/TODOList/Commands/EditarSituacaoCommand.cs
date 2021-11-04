using System;
using System.Windows.Input;
using TODOList.Model;
using TODOList.Service;
using TODOList.ViewModel;

namespace TODOList.Commands
{
    public class EditarSituacaoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        private TarefaViewModel _tarefaViewModel;

        public EditarSituacaoCommand(TarefaViewModel tarefaViewModel)
        {
            _tarefaViewModel = tarefaViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var tarefa = (TarefaModel)parameter;


            var index = _tarefaViewModel.ListaTarefa.IndexOf(tarefa);

            tarefa.Done = !tarefa.Done;
            TarefaService.Instance.Update(tarefa);

            _tarefaViewModel.ListaTarefa.RemoveAt(index);
            _tarefaViewModel.ListaTarefa.Insert(index, tarefa);
        }
    }
}
