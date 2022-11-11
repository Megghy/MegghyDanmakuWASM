using MegghyDanmakuShared.Interfaces;

namespace MegghyDanmakuShared.PageData
{
    public struct PageData_Index : IMDMKSData
    {
        public PageData_Index() { }
        /// <summary>
        /// 主页获取的直播间信息
        /// </summary>
        public APIChannelInfo[] Channels { get; set; } = Array.Empty<APIChannelInfo>();
        public List<SimpleCascaderNode> Areas { get; set; } = new();
        public int TotalCount { get; set; } = 0;
    }
}
