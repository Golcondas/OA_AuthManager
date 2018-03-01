using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CodedUITestProject1
{
    [TestClass]
    public class SharePointDebug
    {
        [TestMethod]
        public void TestConnetion()
        {
            //ClientContext clientContext = new ClientContext();
            //Web web = clientContext.Web;
            //ListCollection collList = web.Lists;

            //clientContext.Load(collList);
            //clientContext.ExecuteQuery();   //Sharepoint的远程交互只有在ExecuteQuery之后才被执行的。

            //foreach (Microsoft.SharePoint.Client.List list in collList)
            //{
            //    Console.WriteLine("Title:{0}", list.Title);
            //}

            ////CamlQuery
            //CamlQuery camlQuery = new CamlQuery();
            //camlQuery.ViewXml = "<View></View>";

            //Microsoft.SharePoint.Client.List planlist = collList.GetByTitle(listName);
            //ListItemCollection collListItem = planlist.GetItems(camlQuery);
            //clientContext.Load(collListItem,
            //    items => items.Include(
            //        item => item.Id,
            //        item => item.DisplayName,
            //        item => item.HasUniqueRoleAssignments)
            //    );
            //clientContext.ExecuteQuery();

            //foreach (ListItem olistItem in collListItem)
            //{
            //    Console.WriteLine("ID: {0} \nDisplay name: {1} \nUnique role assignments: {2}",
            //        olistItem.Id, olistItem.DisplayName, olistItem.HasUniqueRoleAssignments);
            //}


            //clientContext.Load(planlist);
            //clientContext.ExecuteQuery();
            //Console.WriteLine(planlist.Title.ToString());
            //Console.WriteLine(planlist.ItemCount.ToString());
            //Console.ReadKey();
        }
    }
}
