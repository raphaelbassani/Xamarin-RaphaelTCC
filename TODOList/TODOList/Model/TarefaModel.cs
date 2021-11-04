using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TODOList.Model
{
    [Table("TASK")]
    public class TarefaModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }

        public bool Done { get; set; }


    }
}
    