using System.Collections.Generic;
using LitJson;
namespace QuyouCore.Core.Entity
{
    public class Prompt
    {
        public int Number
        {
            get; set;
        }

        public string Msg
        {
            get;
            set;
        }

        public static string ToJson(int number, string msg)
        {
            var prompt = new Prompt {Number = number, Msg = msg};
            return JsonMapper.ToJson(prompt);
        }

        public static string ToJson<T>(int number, string msg, List<T> data)
        {
            var prompt = new PromptTemplate<T> { Number = number, Msg = msg, DataList = data };
            return JsonMapper.ToJson(prompt);
        }
    }
}
