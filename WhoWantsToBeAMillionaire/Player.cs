using System.Collections.Generic;
using System.Data.SQLite;

public static class Player
{
    private static readonly string connectionString = @"Data Source=WhoWantsToBeAMillionaire.db;Version=3;Pooling=True;Cache=Shared";
    private static readonly SQLiteConnection persistentConnection;

    public static int currentRecord { get; set; }
    public static string name { get; set; }

    static Player()
    {
        persistentConnection = new SQLiteConnection(connectionString);
        persistentConnection.Open();
    }

    public static int AddPlayer(string playerName, int initialRecord = 0)
    {
        using (var checkCommand = persistentConnection.CreateCommand())
        {
            checkCommand.CommandText = "SELECT Record FROM Players WHERE Name = @Name";
            checkCommand.Parameters.AddWithValue("@Name", playerName);

            using (var reader = checkCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    currentRecord = reader.GetInt32(0);
                    name = playerName;
                    return currentRecord;
                }
            }

            using (var insertCommand = persistentConnection.CreateCommand())
            {
                insertCommand.CommandText = "INSERT INTO Players (Name, Record) VALUES (@Name, @Record)";
                insertCommand.Parameters.AddWithValue("@Name", playerName);
                insertCommand.Parameters.AddWithValue("@Record", initialRecord);
                insertCommand.ExecuteNonQuery();

                currentRecord = initialRecord;
                name = playerName;
                return initialRecord;
            }
        }
    }

    public static void UpdateRecord(string playerName, int newRecord)
    {
        if (newRecord <= currentRecord) return;

        using (var updateCommand = persistentConnection.CreateCommand())
        {
            updateCommand.CommandText = @"
                UPDATE Players 
                SET Record = @Record 
                WHERE Name = @Name AND Record < @Record";

            updateCommand.Parameters.AddWithValue("@Name", playerName);
            updateCommand.Parameters.AddWithValue("@Record", newRecord);

            if (updateCommand.ExecuteNonQuery() > 0)
            {
                currentRecord = newRecord;
            }
        }
    }

    public static List<(string Name, int Record)> GetLeaderboard()
    {
        var leaderboard = new List<(string Name, int Record)>(10);

        using (var command = persistentConnection.CreateCommand())
        {
            command.CommandText = @"
                SELECT Name, Record 
                FROM Players 
                ORDER BY Record DESC 
                LIMIT 10";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    leaderboard.Add((
                        reader.GetString(0),
                        reader.GetInt32(1)
                    ));
                }
            }
        }

        return leaderboard;
    }

    public static void Cleanup()
    {
        persistentConnection?.Close();
        persistentConnection?.Dispose();
    }
}