namespace UsersAPI.Helpers
{
    public class JWT
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
       // public string DurationInDays { get; set; }
    }
}
