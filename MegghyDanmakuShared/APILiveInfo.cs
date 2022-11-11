namespace MegghyDanmakuShared
{
    /// <summary>
    /// 直播场数据
    /// </summary>
    public struct APILiveInfo
    {
        /// <summary>
        /// 直播Id
        /// </summary>
        public Guid LiveId { get; set; }
        /// <summary>
        /// 是否结束
        /// </summary>
        public bool IsFinish { get; set; }
        /// <summary>
        /// 父分区 (主分区)
        /// </summary>
        public string ParentArea { get; set; }
        /// <summary>
        /// 分区 (子分区)
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 直播封面
        /// </summary>
        public string CoverUrl { get; set; }
        /// <summary>
        /// 弹幕数
        /// </summary>
        public int DanmakusCount { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? StopDate { get; set; }
        /// <summary>
        /// 直播标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 收益
        /// </summary>
        public decimal TotalIncome { get; set; }
        /// <summary>
        /// 观看次数
        /// </summary>
        public int WatchCount { get; set; }
        /// <summary>
        /// 互动人数
        /// </summary>
        public int InteractionCount { get; set; }
    }
}
