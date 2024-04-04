namespace Domain
{
    /// <summary>
    /// Deeplink Log
    /// </summary>
    public class DeeplinkLog : ISeqNo
    {
        /// <summary>
        /// 流水號 索引
        /// </summary>
        public int SeqNo { get; set; }
        /// <summary>
        /// 主題
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// 作業系統
        /// </summary>
        public string OsType { get; set; }
        /// <summary>
        /// 來源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 媒體
        /// </summary>
        public string Medium { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
