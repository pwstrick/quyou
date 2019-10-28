using System.Collections.Generic;

namespace QuyouCore.Core.Entity
{
    public class PromptTemplate<T> : Prompt
    {
        public List<T> DataList
        {
            get;
            set;
        }
    }
}
