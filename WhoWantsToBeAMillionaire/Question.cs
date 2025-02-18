using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    class Question : IQuest
    {
        public string Text { get; private set; }
        public string[] Answers { get; private set; }
        public int RightAnswer { get; private set; }
        public int Level { get; private set; }
        public Question(string[] s)
        {
            Text = s[0];
            Answers = new string[4];
            for (int i = 0; i < 4; i++)
                Answers[i] = s[i + 1];
            RightAnswer = int.Parse(s[5]);
            Level = int.Parse(s[6]);
        }
    }

    class QuestionSQL : IQuest
    {
        public string Text { get; private set; }
        public string[] Answers { get; private set; }
        public int RightAnswer { get; private set; }
        public int Level { get; private set; }

        public QuestionSQL(SQLiteDataReader dr)
        {
            Text = dr["Text"].ToString();
            Answers = new string[4] { dr["Answer1"].ToString(),
            dr["Answer2"].ToString(), dr["Answer3"].ToString(), dr["Answer4"].ToString()};
            RightAnswer = int.Parse(dr["RightAnswer"].ToString());
            Level = int.Parse(dr["Level"].ToString());
        }
    }
}
