using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1
{
    public class UserBehaviorSetting
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 行为类型：1.注册，2.登录，3.实名，4.绑卡，5.解绑卡，6.投资活期，7.投资定期，8.赎回活期，9.提前赎回，10.赎回收益，11.充值，12.提现，13.更换手机号，14.预约定期，15.充值成功，16.提现成功，17.定期赎回成功，18.首次投资
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 行为类型名称
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 渠道类型：1.自注册，2.好友推荐，3.渠道推荐 
        /// </summary>
        public int ChannelType { get; set; }
        /// <summary>
        /// 渠道类型码（特殊渠道用，如玖一渠道）
        /// </summary>
        public string ChannelCode { get; set; }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 事件类型：1.现金奖励，2.加息券，3.理财红包，4.理财金，5.营销短信
        /// </summary>
        public int EventType { get; set; }
        /// <summary>
        /// 事件标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 红包金额，加息利率
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 红包限额，加息限额
        /// </summary>
        public decimal AmountLimit { get; set; }
        /// <summary>
        /// 过期天数
        /// </summary>
        public int ExpireDay { get; set; }
        /// <summary>
        /// 有效天数
        /// </summary>
        public int ValidDay { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 加息券和红包type
        /// </summary>
        public int InterestType { get; set; }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string Ext1 { get; set; }
        /// <summary>
        /// 备用字段2
        /// </summary>
        public string Ext2 { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime Modified { get; set; }
        public long ModifiedBy { get; set; }
    }


}
