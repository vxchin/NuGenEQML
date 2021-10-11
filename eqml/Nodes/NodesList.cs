using System.Collections.Generic;

namespace Nodes
{
    public class NodesList : List<Node>
    {
        private int _iterator;

        public NodesList()
        {
            _iterator = 0;
        }

        public void Reset()
        {
            _iterator = 0;
        }

        public Node Next()
        {
            return Get(_iterator++);
        }

        public Node Get(int n)
        {
            return n < Count ? this[n] : null;
        }
    }
}