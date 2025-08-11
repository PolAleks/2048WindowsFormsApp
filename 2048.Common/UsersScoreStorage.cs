using System.Collections.Generic;
using System.Linq;

namespace _2048.Common
{
    public class UsersScoreStorage
    {
        private static string _file = "score.json";
        private static IConverter _converter = new JsonConverter();
        public static List<User> GetAll()
        {
            if(FileProvider.Exists(_file))
            {
                var data = FileProvider.Load(_file);
                return _converter.Deserialize<List<User>>(data);
            }
            return new List<User>();
        }

        public static void Add(User user) 
        {
            var listScores = GetAll();
            listScores.Add(user);
            listScores.Sort(new ScoreComparer());

            string data = _converter.Serialize(listScores);
            FileProvider.Save(_file, data);
        }

        public static User GetBestScore()
        {
            return GetAll().FirstOrDefault();
        }
    }
}
