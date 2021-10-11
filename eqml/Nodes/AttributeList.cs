using System.Collections.Generic;
using System.Linq;

namespace Nodes
{
    public class AttributeList : List<Attribute>
    {
        private int _iterator;

        public AttributeList()
        {
            _iterator = 0;
        }

        public void CopyTo(ref AttributeList list)
        {
            if (list is null) list = new AttributeList();
            list.AddRange(this.Select(attribute =>
                new Attribute(attribute.name, attribute.val, attribute.ns, attribute.system)));
            Reset();
            list.Reset();
        }

        public Attribute Next()
        {
            try
            {
                if (_iterator >= Count) return null;
                var attribute = this[_iterator];
                _iterator++;
                return attribute;
            }
            catch
            {
                return null;
            }
        }

        public void Reset()
        {
            _iterator = 0;
        }

        public Attribute Get(string name)
        {
            return this.FirstOrDefault(it => it.name == name);
        }

        public string GetValue(string name)
        {
            var attribute = Get(name);
            return attribute != null ? attribute.val : "";
        }

        public void Add(string name, string val)
        {
            try
            {
                if (name != null && val != null && name.Length > 0 && val.Length > 0 && name.ToUpper() == "CLASS")
                    val = val.Replace("_", "-");
                var attribute = Get(name);
                if (attribute != null)
                {
                    attribute.val = val;
                }
                else
                {
                    attribute = new Attribute(name, val, "");
                    Add(attribute);
                }
            }
            catch
            {
            }
        }
    }
}