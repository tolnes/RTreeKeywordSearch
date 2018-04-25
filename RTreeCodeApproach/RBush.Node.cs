using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTreeCodeApproach
{
    public partial class RBush<T>
    {
        internal class Node : ISpatialData
        {
            public List<ISpatialData> Children { get; }
            public int Height { get; }
            public bool IsLeaf => Height == 1;
            public ref readonly Envelope Envelope => ref _envelope;
            public double Distance { get; set; }
            public List<string> Keywords { get; set; }

            private Envelope _envelope;
            

            public Node(List<ISpatialData> items, int height)
            {
                this.Height = height;
                this.Children = items;
                ResetEnvelope();
                
            }

            public void Add(ISpatialData node)
            {
                Children.Add(node);
                _envelope = Envelope.Extend(node.Envelope);
            }

            public void ResetEnvelope()
            {
                _envelope = GetEnclosingEnvelope(Children);
            }

            
        }
    }
}
