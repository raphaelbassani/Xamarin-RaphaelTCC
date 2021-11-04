using SQLite;
using System.Collections.Generic;
using TODOList.Interface;
using TODOList.Model;
using Xamarin.Forms;

namespace TODOList.Service
{
    public class TarefaService
    {
        private static TarefaService _instance;
        private SQLiteConnection _conn;


        public static TarefaService Instance => _instance ?? (_instance = new TarefaService());

        public TarefaService()
        {
            _conn = DependencyService.Get<IDatabase>().GetConnection();
            _conn.CreateTable<TarefaModel>();
        }

        public IList<TarefaModel> GetListTarefa() => _conn.Table<TarefaModel>().ToList();

        public int Save(TarefaModel tarefa) => _conn.Insert(tarefa);

        public int Update(TarefaModel tarefa) => _conn.Update(tarefa);

        public void Delete(TarefaModel tarefa) => _conn.Delete(tarefa);

    }
}
