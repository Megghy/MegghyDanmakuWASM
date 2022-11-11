using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegghyDanmakuShared
{
    public struct SimpleCascaderNode
    {
        public string Label { get; set; }

        public string Value { get; set; }

        public IEnumerable<SimpleCascaderNode> Children { get; set; }
    }
}
