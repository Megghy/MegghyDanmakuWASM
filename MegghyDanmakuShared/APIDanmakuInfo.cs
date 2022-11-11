using MegghyDanmakuShared.Entities;
using MegghyDanmakuShared.Enums;
using MessagePack;

namespace MegghyDanmakuShared
{
    [MessagePackObject]
    public struct APIDanmakuInfo
    {
        [Key(0)]
        public long UId { get; set; }
        [Key(1)]
        public string UName { get; set; }
        [Key(2)]
        public DanmakuType Type { get; set; }
        [Key(3)]
        public long SendDate { get; set; }
        [Key(4)]
        public string Message { get; set; }
        [Key(5)]
        public decimal? Price { get; set; }
        [Key(6)]
        public string? CT { get; set; }
    }
}
