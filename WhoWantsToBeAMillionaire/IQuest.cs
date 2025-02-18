using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    public interface IQuest
    {
         string Text { get; }
         string[] Answers { get; }
         int RightAnswer { get; }
         int Level { get; }
    }
}
