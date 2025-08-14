namespace _2048.Common
{
    public class User
    {
        public User()
        {

        }
        public User(string name) : this(name, 0)
        {
            Name = name;
        }

        public User(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }

    }
}
