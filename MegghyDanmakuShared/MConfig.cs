namespace MegghyDanmakuShared
{
    public class MConfig
    {
        #region bool值
        public bool IsMaintenance { get; set; } = false;
        #endregion

        #region 是否启用功能
        public bool EnableDataAnalyze { get; set; } = true;
        public bool EnableAddChannel { get; set; } = true;
        #endregion

        #region 文本设置项
        public string SiteName { get; set; } = "某弹幕站";
        public string SiteName_Short { get; set; } = "MDMKS";
        public string SiteAPIDocAddress { get; set; } = "";
        #endregion
    }
}