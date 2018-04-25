using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTreeCodeApproach
{
    public interface ISpatialIndex<out T>
    {
        IReadOnlyList<T> Search();
        IReadOnlyList<T> Search(in Envelope boundingBox);
    }
}
