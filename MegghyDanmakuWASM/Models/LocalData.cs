namespace MegghyDanmakuWASM.Models
{
    public class LocalData
    {
        public const string LOCAL_NAME = "MegghyDanmaku.LocalData";
        public Dictionary<long, string> SearchHistory { get; set; } = new();
        public List<long> FavoriteChannels { get; set; } = new();
    }
}
