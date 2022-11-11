using System.ComponentModel;

namespace MegghyDanmakuShared.Enums
{
    public enum ChannelInteractionType
    {
        /// <summary>
        /// 过去10分钟内的互动人数
        /// </summary>
        [Description("过去10分钟内的互动人数")]
        TenMin,

        /// <summary>
        /// 过去30分钟内的互动人数
        /// </summary>
        ThirtyMin,

        /// <summary>
        /// 过去一小时内的互动人数
        /// </summary>
        AHour,

        /// <summary>
        /// 整场直播的互动人数
        /// </summary>
        All,
    }
}
