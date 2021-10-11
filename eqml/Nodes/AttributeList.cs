using System;
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

        public void Reset()
        {
            _iterator = 0;
        }

        public Attribute Next()
        {
            return _iterator < Count ? this[_iterator++] : null;
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
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(val) && name.ToUpper() == "CLASS")
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
    }
}