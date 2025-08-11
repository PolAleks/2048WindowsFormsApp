namespace _2048.Common
{
    public class User
    {
        public User(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }

    }
}
