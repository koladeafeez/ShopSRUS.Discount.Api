namespace ShopsRCUS.Discount.API.Services.Interfaces
{
    public interface IHashingService
    {

        public string HashString(string value);

        public bool VerifyHash(string value,string hash);
    }
}
