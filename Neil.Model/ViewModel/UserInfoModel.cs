using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.Model.ViewModel
{
    public class UserInfoModel:BaseModel
    {
        public int ID { get; set; }
        public string UName { get; set; }
        public string UPwd { get; set; }
        public String SubTime { get; set; }
        public int DelFlag { get; set; }
        public String ModifiedOn { get; set; }
        public string Remark { get; set; }
        public string Sort { get; set; }

        public static UserInfoModel GetUserInfo(UserInfo model) 
        {
            if (model == null)
            {
                return null;
            }
            UserInfoModel userInfoModel = new UserInfoModel();
            userInfoModel.ID = model.ID;
            userInfoModel.UName = model.UName;
            userInfoModel.UPwd = model.UPwd;
            userInfoModel.SubTime = model.SubTime.ToString("yyyy-MM-dd hh:mm:ss");
            userInfoModel.DelFlag = model.DelFlag;
            userInfoModel.ModifiedOn = model.ModifiedOn.ToString("yyyy-MM-dd hh:mm:ss");
            userInfoModel.Remark = model.Remark;
            userInfoModel.Sort = model.Sort;
            return userInfoModel;
        }

        public static List<UserInfoModel> GetUserInfoList(List<UserInfo> list) 
        {
            if(list==null||list.Count==0)
            {
                return new List<UserInfoModel>();
            }

            List<UserInfoModel> userInfoList=new List<UserInfoModel>();
            foreach (UserInfo item in list)
            {
                userInfoList.Add(GetUserInfo(item));
            }
            return userInfoList;
        }
    }
}
