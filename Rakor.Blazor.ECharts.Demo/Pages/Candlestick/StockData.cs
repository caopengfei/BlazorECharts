namespace Demo.Pages.Candlestick
{
    /// <summary>
    /// 股票数据
    /// </summary>
    public class StockData
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { set; get; }

        /// <summary>
        /// 开盘价
        /// </summary>
        public double Open { set; get; }

        /// <summary>
        /// 最高价
        /// </summary>
        public double High { set; get; }

        /// <summary>
        /// 最低价
        /// </summary>
        public double Low { set; get; }

        /// <summary>
        /// 收盘价
        /// </summary>
        public double Close { set; get; }

        /// <summary>
        /// 成交额
        /// </summary>
        public double Amount { set; get; }

        ///// <summary>
        ///// 换手率
        ///// </summary>
        //public double? Turn { set; get; }

        ///// <summary>
        ///// 涨跌幅
        ///// </summary>
        //public double PctChg { set; get; }

        /// <summary>
        /// 滚动市盈率
        /// </summary>
        public double PeTTM { set; get; }
    }

    public class StockInfo
    {
        [Newtonsoft.Json.JsonProperty("code_name")]
        public string Name { set; get; }

        /// <summary>
        /// 证券类型
        /// <para>1：股票，2：指数,3：其它</para>
        /// </summary>
        public int Type { set; get; }
    }
}