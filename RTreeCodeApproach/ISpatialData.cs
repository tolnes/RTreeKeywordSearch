using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTreeCodeApproach
{
    public interface ISpatialData
    {
        ref readonly Envelope Envelope { get; }
        List<ISpatialData> Children { get; }
        int Height { get; }
        bool IsLeaf { get; }
        double Distance { get; set; }
        List<string> Keywords { get; set; }
    }
}
