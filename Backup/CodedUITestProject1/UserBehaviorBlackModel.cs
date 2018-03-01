using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1
{
    public class UserBehaviorBlackModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 行为类型：1.注册，2.登录，3.实名，4.绑卡，5.解绑卡，6.投资活期，7.投资定期，8.赎回活期，9.提前赎回，10.赎回收益，11.充值，12.提现，13.更换手机号，14.预约定期，15.充值成功，16.提现成功，17.定期赎回成功，18.首次投资
        /// </summary>
        public int? TypeBlack { get; set; }
        /// <summary>
        /// 行为类型名称
        /// </summary>
        public int? EventBlack { get; set; }
        /// <summary>
        /// 渠道码黑名单
        /// </summary>
        public string ChannelCodeBlack { get; set; }
        /// <summary>
        /// 渠道类型黑名单
        /// </summary>
        public int? ChannelTypeBlack { get; set; }
        /// <summary>
        /// 是否是黑名单
        /// </summary>
        public int IsBlack { get; set; }
        /// <summary>
        /// 是否删除 0:未删除 1:已删除
        /// </summary>
        public int IsDel { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 加息券和红包type
        /// </summary>
        public int InterestType { get; set; }
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
