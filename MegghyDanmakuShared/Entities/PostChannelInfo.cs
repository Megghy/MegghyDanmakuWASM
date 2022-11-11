using System.ComponentModel;
using MegghyDanmakuShared.Enums;

namespace MegghyDanmakuShared.Entities
{
    public struct PostChannelInfo
    {
        public PostChannelInfo() { }
        [DefaultValue(ChannelRankType.LastLive)]
        public ChannelRankType? Type { get; set; } = ChannelRankType.LastLive;
        [DefaultValue(ChannelInteractionType.All)]
        public ChannelInteractionType? InteractionType { get; set; } = ChannelInteractionType.All;
        [DefaultValue(null)]
        public string? Keyword { get; set; } = "";
        [DefaultValue(null)]
        public string? Area { get; set; } = "";
        [DefaultValue(0)]
        public int? PageNum { get; set; } = 0;
        [DefaultValue(100)]
        public int? PageSize { get; set; } = 100;
        [DefaultValue(null)]
        public long[]? Ids { get; set; } = null;
    }
}
