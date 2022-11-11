namespace MegghyDanmakuWASM.Models
{
    public static class API
    {
#if DEBUG
        public const string BASE_URL = "https://localhost:7169/api/v2/";
#else
        public const string BASE_URL = "https://danmaku.suki.club/api/v2/";
#endif

        public const string DATA_INDEX = BASE_URL + "info/channel/get";
        public const string DATA_INDEX_GET_BY_ID = BASE_URL + "info/channel/get";
    }
}
