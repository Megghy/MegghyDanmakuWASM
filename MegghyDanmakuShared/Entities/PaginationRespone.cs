using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegghyDanmakuShared.Entities
{
    public struct PaginationRespone<T>
    {
        public int Total { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public bool HasMore { get; set; }
        public T Datas { get; set; }
    }
}
