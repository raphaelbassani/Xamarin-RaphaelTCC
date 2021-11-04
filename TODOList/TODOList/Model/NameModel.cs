using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TODOList.Model
{
    public class Name
    {
        public Name(string firstName)
        {
            FirstName = firstName;
        }

        public string FirstName { get; set; }
    }


    public class NameStat
    {
        public static implicit operator ObservableCollection<object>(NameStat v)
        {
            throw new NotImplementedException();
        }

        public class Name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string last { get; set; }
        }

        public class Result
        {
            public Name name { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
        }
    }
}
