namespace UnitTestTutorial.TestDoubles
{
    public interface IDatabase
    {
        void Save(string data);
    }

    public class Database : IDatabase
    {
        public void Save(string data)
        {
            // Actual implementation to save data to the database
        }
    }

    public class FakeDatabase : IDatabase
    {
        private readonly List<string> _data = new List<string>();

        public void Save(string data)
        {
            _data.Add(data);
        }

        public List<string> GetAllData()
        {
            return _data;
        }
    }

    public class Service
    {
        private readonly IDatabase _database;

        public Service(IDatabase database)
        {
            _database = database;
        }

        public void SaveData(string data)
        {
            _database.Save(data);
        }
    }
}
