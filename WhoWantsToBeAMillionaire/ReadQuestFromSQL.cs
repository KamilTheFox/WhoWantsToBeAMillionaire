using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    public class ReadQuestFromSQL : IReadQestions
    {
        public IQuest GetQuestion(int level)
        {

            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = @"Data Source=WhoWantsToBeAMillionaire.db;Version=3";

            cn.Open();

            var cmd = new SQLiteCommand($@"select * from Questions WHERE Level={level} 
                                            order by Random() LIMIT 1", cn);

            var dr = cmd.ExecuteReader();
            dr.Read();
            IQuest q = new QuestionSQL(dr);
            dr.Close();
            cmd.Dispose();
            cn.Close();

            return q;
        }

        public void Initialize()
        {
            
        }
    }
}
