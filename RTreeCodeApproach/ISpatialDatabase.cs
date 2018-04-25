using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTreeCodeApproach
{
    public interface ISpatialDatabase<T> : ISpatialIndex<T>
    {
        void Insert(T item);
        void Delete(T item);
        void Clear();

        void BulkLoad(IEnumerable<T> items);
    }
}
