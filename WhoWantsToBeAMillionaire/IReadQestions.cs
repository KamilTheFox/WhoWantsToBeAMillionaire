using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    public interface IReadQestions
    {
        void Initialize();
        IQuest GetQuestion(int level);
    }
}
