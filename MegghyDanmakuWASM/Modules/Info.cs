using MegghyDanmakuShared;

namespace MegghyDanmakuWASM.Modules
{
    public static class Info
    {
        /// <summary>
        /// 网站设置项
        /// </summary>
        public static MConfig Config { get; internal set; } = new();
        public static RuntimeInfo SiteRuntimeInfo { get; internal set; } = new();
    }
}
