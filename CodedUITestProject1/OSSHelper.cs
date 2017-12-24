using Aliyun.OSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1
{
    public class OSSHelper
    {
        public static OssClient client;

        static OSSHelper()
        {
            if (client == null)
            {

                client = new OssClient("oss-cn-hangzhou.aliyuncs.com", "LTAAI3zgDu1SwYazUA", "y1ALW2nMgtEoz6hZIpbgOZvHdJdy7r7A");
            }
        }
        /// <summary>
        /// 删除指定存储空间中的所有文件
        /// </summary>
        /// <param name="bucketName">存储空间的名称</param>
        public void DeleteObjects(string bucketName)
        {
            try
            {
                var keys = new List<string>();
                var listResult = client.ListObjects(bucketName);
                foreach (var summary in listResult.ObjectSummaries)
                {
                    keys.Add(summary.Key);
                }
                var request = new DeleteObjectsRequest(bucketName, keys, false);
                client.DeleteObjects(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete objects failed. {0}", ex.Message);
            }
        }
    }
}
