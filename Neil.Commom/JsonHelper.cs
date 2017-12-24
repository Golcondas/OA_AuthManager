using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace Neil.Commom
{
    public class JsonHelper
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("JsonHelper");
        // 从一个对象信息生成Json串
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            //MemoryStream stream = new MemoryStream();
            //serializer.WriteObject(stream, obj);
            //byte[] dataBytes = new byte[stream.Length];
            //stream.Position = 0;
            //stream.Read(dataBytes, 0, (int)stream.Length);
            //return Encoding.UTF8.GetString(dataBytes);
        }
        // 从一个Json串生成对象信息
        public static T JsonToObject<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {

                log.Error("JsonToObject 报错：Ex:" + ex);
                return default(T);
            }
            
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            //MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            //return serializer.ReadObject(mStream);
        }
    }
}
