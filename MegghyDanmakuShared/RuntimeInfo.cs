namespace MegghyDanmakuShared
{
    public struct RuntimeInfo
    {
        public int TotalChannelsCount { get; set; }
        public int LivingCount { get; set; }
        public long TotalDanmakusCount { get; set; }
        public int TotalSegamentsCount { get; set; }
        public int DanmakuSpeed { get; set; }
        public int OnlineCount { get; set; }
        public (string Name, long UId) LatestAddedChannel { get; set; }
    }
}
