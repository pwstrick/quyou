using LitJson;
using QuyouCore.Core.Entity;
using QuyouCore.Core.Enum;

namespace QuyouTests
{
    public class BaseTest
    {
        protected string PromptToJson(int error)
        {
            var prompt = new Prompt
            {
                Number = error,
                Msg = EnumCommon.GetPrompt()[error]
            };
            return JsonMapper.ToJson(prompt);
        }
    }
}
