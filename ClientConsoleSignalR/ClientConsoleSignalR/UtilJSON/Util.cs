using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Data;
using System.IO;

namespace ClientConsoleSignalR.UtilJSON
{
    public static class Util
    {
        public static string ToBson(string strJson)
        {
            var jsonObj = JsonConvert.DeserializeObject(strJson);

            MemoryStream ms = new MemoryStream();
            using (BsonDataWriter writer = new BsonDataWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, jsonObj);
            }

            string data = Convert.ToBase64String(ms.ToArray());


            Console.WriteLine(data);

            return data;
        }

        public static string ToJson(string strBson)
        {
            byte[] dados = Convert.FromBase64String(strBson);

            MemoryStream ms = new MemoryStream(dados);
            using (BsonDataReader reader = new BsonDataReader(ms))
            {
                JsonSerializer serializer = new JsonSerializer();

                DataTable dt = new DataTable();

                dt = serializer.Deserialize<DataTable>(reader);

                //string strJson = reader.ToBsonDocument().ToJson().ToString();
                string strJson = JsonConvert.SerializeObject(dt, Formatting.Indented);

                Console.WriteLine(strJson);

                return strJson;
            }
        }
    }
}
