using System.Text.Json.Serialization;

namespace MegghyDanmakuShared
{
    /// <summary>
    /// 主播信息
    /// </summary>
    public struct APIChannelInfo
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UName { get; set; }
        /// <summary>
        /// 直播间Id
        /// </summary>
        public long RoomId { get; set; }
        /// <summary>
        /// 头像链接
        /// </summary>
        public string FaceUrl { get; set; }
        /// <summary>
        /// 是否正在直播
        /// </summary>
        public bool IsLiving { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// 直播间tag
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        /// 上次直播的开始时间
        /// </summary>
        public DateTime LastLiveDate { get; set; }
        /// <summary>
        /// 上次直播的弹幕
        /// </summary>
        public int LastLiveDanmakuCount { get; set; }
        /// <summary>
        /// 收到的弹幕数，只包括普通弹幕, 不含礼物, 入场, 上舰之类的
        /// </summary>
        public long TotalDanmakuCount { get; set; }
        /// <summary>
        /// 总收益
        /// </summary>
        public decimal TotalIncome { get; set; }
        /// <summary>
        /// 记录的直播场数量
        /// </summary>
        public long TotalLiveCount { get; set; }
        /// <summary>
        /// 总直播时长，单位秒
        /// </summary>
        public long TotalLiveSecond { get; set; }
        /// <summary>
        /// 收录日期
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 如果正在直播, 则是正在直播的场次信息
        /// </summary>
        public APILiveInfo? LivingInfo { get; set; }

        [JsonIgnore]
        public string SpaceUrl
            => $"https://space.bilibili.com/{UId}/";
        [JsonIgnore]
        public string LiveRoomUrl
            => $"https://live.bilibili.com/{RoomId}/";
    }
}
