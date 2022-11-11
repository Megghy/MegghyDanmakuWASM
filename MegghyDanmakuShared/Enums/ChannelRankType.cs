using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegghyDanmakuShared.Enums
{
    public enum ChannelRankType
    {
        /// <summary>
        /// 最后直播日期
        /// </summary>
        LastLive,

        /// <summary>
        /// 观看人数
        /// </summary>
        WatchCount,

        /// <summary>
        /// 互动人数
        /// </summary>
        Interaction,

        /// <summary>
        /// 收录日期
        /// </summary>
        AddDate,

        /// <summary>
        /// 在API中未使用
        /// </summary>
        Favorite
    }
}
