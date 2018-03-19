using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ClientConsoleSignalR.ADO
{
    public static class DataColumnCollectionExtensions
    {
        public static IEnumerable<DataColumn> AsEnumerable(this DataColumnCollection source)
        {
            return source.Cast<DataColumn>();
        }

        public static IEnumerable<DataColumn> GetColumns(this DataTable source)
        {
            return source.Columns.AsEnumerable();
        }
    }
}
