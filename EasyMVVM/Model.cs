using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EasyMVVM
{
    public class Model
    {
        ObservableCollection<string> _data = new ObservableCollection<string>();
        public ObservableCollection<string> GetData()
        {
            _data.Add("First entry!");
            _data.Add("Second entry!");
            _data.Add("Third entry!");
            return _data;
        }
    }
}
