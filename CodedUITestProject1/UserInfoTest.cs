using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neil.DAL;
using Neil.DalAbstratFactory;
using Neil.IDAL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1
{
    [TestClass]
    public class UserInfoTest
    {
        [TestMethod]
        public void TestUserInfoLoadEntities()
        {
            ////查找
            //var result = new Neil.DAL.UserDal().LoadEntities(c=>true).ToList();
            ////分页查找
            //int totalCount;
            //var result2 = new Neil.DAL.UserDal().LoadEntitiesWhere(c => true, d => d.ID, false, out totalCount, 1, 3).ToList();
            ////添加
            //UserInfo model=new UserInfo();//ID=21
            //model.UName="Web1_Test1";
            //model.UPwd="123456";
            //model.SubTime = DateTime.Now;
            //model.DelFlag = 0;
            //model.ModifiedOn = DateTime.Now;
            //var reuslt3 = new Neil.DAL.UserDal().AddEntities(model);

            ////修改
            //UserInfo userInfoModel = new UserInfo();
            //userInfoModel.ID = 23;
            //userInfoModel.UPwd = "sasd";
            //var reuslt4 = new Neil.DAL.UserDal().UpdateEntities(userInfoModel, "UPwd");
            ////删除
            //UserInfo userInoModel2 = new UserInfo();
            //userInoModel2.ID = 22;
            //IBaseDal<UserInfo> userDal = new UserDal();
            //var result5 = userDal.DeleteByModel(userInoModel2);
            //var userInfo =DALAbstractFactory.CreatNewDal();

            //string a = "a,b,d,723084977739710464 ,723084977739710464,";
            //string[] b=a.Split(new[] {','});

            List<UserBehaviorSetting> list1 = new List<UserBehaviorSetting>();
            UserBehaviorSetting d1 = new UserBehaviorSetting() { ID = 745515461606162432, Type = 1, EventKey = "Register", ChannelType = 1, ChannelCode = null, StartDate = Convert.ToDateTime("2016-06-21 00:00:00"), EndDate = Convert.ToDateTime("2016-06-30T00:00:00"), EventType = 1, Title = "测试黑名单", Amount = 11.1000M, AmountLimit = 1000.0000M, ExpireDay = 5, ValidDay = 10, Remark = "测试黑名单-注册", InterestType = 11, Ext1 = null, Ext2 = null, Created = Convert.ToDateTime(" 2016-06-22T15:15:01"), CreatedBy = 1, Modified = Convert.ToDateTime("2016-06-22T15:15:01"), ModifiedBy = 1 };
            UserBehaviorSetting d2 = new UserBehaviorSetting() { ID = 737887106151616512, Type = 1, EventKey = "Register", ChannelType = 1, ChannelCode = null, StartDate = Convert.ToDateTime("2016-06-01T00:00:00"), EndDate = Convert.ToDateTime("2016-06-30T00:00:00"), EventType = 3, Title = "注册送红包", Amount = 20.0000M, AmountLimit = 1000.0000M, ExpireDay = 3, ValidDay = 7, Remark = null, InterestType = 1, Ext1 = null, Ext2 = null, Created = Convert.ToDateTime("2016-06-01T14:02:50"), CreatedBy = 1, Modified = Convert.ToDateTime("2016-06-22T15:04:44"), ModifiedBy = 1 };

            list1.AddRange(new UserBehaviorSetting[] { d1, d2 });

            List<UserBehaviorBlackModel> list2=new List<UserBehaviorBlackModel>();
            UserBehaviorBlackModel t1=new UserBehaviorBlackModel(){ ID=746274312618033152,TypeBlack=1,EventBlack=3,ChannelCodeBlack="",ChannelTypeBlack=1,IsBlack=1,IsDel=0,Remark=null,InterestType=0,Created=Convert.ToDateTime("2016-06-24T17:30:22"),CreatedBy=1,Modified=Convert.ToDateTime("2016-06-26T00:35:09"),ModifiedBy=1 };
            list2.AddRange(new UserBehaviorBlackModel[] {t1 });

            List<UserBehaviorSetting> listBlack = new List<UserBehaviorSetting>();
            //比较事件黑名单信息
            foreach (var item in list2)
            {

                var listTest = list1.Where(t => (t.ChannelType != item.ChannelTypeBlack && t.EventType != item.EventBlack && t.Type != item.TypeBlack)).ToList();

                listBlack = list1.Where(t => t.ChannelType == item.ChannelTypeBlack && t.EventType == item.EventBlack && t.Type == item.TypeBlack).ToList();
            }
            //过滤事件黑名单信息
            if (listBlack.Count() > 0)
            {
                foreach (var item in listBlack)
                {
                    list1 = list1.Where(t => t.ID != item.ID).ToList();
                }
            }


            foreach (var item in list2)
            {
                list1 = list1.Where(t => t.ChannelType == item.ChannelTypeBlack && t.EventType == item.EventBlack && t.Type == item.TypeBlack).ToList();


                list1 = (from t in list1
                         where t.ChannelType != Convert.ToInt32(item.ChannelTypeBlack) && t.EventType != Convert.ToInt32(item.EventBlack) && t.Type != Convert.ToInt32(item.TypeBlack)
                        select t).ToList();
            }

            foreach (var item in list2)
            {

                list1 = list1.Where(t => t.ChannelType == item.ChannelTypeBlack && t.EventType == item.EventBlack && t.Type == item.TypeBlack).ToList();

                list1 = list1.Where(t => t.ChannelType != Convert.ToInt32(item.ChannelTypeBlack) && t.EventType != Convert.ToInt32(item.EventBlack) && t.Type != Convert.ToInt32(item.TypeBlack)).ToList();


            }
            list1 = (from l in list1
                     join a in list2 on
                    new
                    {
                        c1 = l.ChannelType,
                        c2 = l.EventType,
                        c3 = l.Type
                    }
                    equals
                    new
                    {
                        c1 = Convert.ToInt32(a.ChannelTypeBlack),
                        c2 = Convert.ToInt32(a.EventBlack),
                        c3 = Convert.ToInt32(a.TypeBlack)
                    }
                    select l).ToList();


            

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test2()
        {
            int b = 0;
            int d = b.ExtensionMethod();
            Console.ReadLine();
        }
    }
}
