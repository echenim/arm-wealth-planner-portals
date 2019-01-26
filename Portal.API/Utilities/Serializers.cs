using System.IO;
using System.Runtime.Serialization.Json;

namespace Portal.API.Utilities
{
    public static class Serializers
    {
        public static string Serialize<T>(T bsObj)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, bsObj);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
            string json = sr.ReadToEnd();

            sr.Close();
            msObj.Close();
            return json;
        }
    }
}