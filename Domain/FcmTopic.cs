using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

/// <summary>
/// Firebase 推播主題
/// </summary>
public class FcmTopic : ISeqNo
{
    /// <summary>
    /// 流水號 索引
    /// </summary>
    public int SeqNo { get; set; }

    /// <summary>
    /// 主題名稱
    /// </summary>
    public string TopicName { get; set; }

    /// <summary>
    /// 全部數量
    /// </summary>
    public int Count { get; set; }

}