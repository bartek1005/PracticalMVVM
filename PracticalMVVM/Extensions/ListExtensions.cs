using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalMVVM.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in col)
            {
                c.Add(e);
            }
            return c;
        }
    }
}
