namespace Dataloader
{
    public class Key
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public string UserID { get; set; }
        public Key(string username, string password, string userID)
        {
            Username = username;
            Password = password;
            UserID = userID;
        }
    }
}