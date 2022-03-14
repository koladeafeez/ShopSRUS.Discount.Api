using ShopsRCUS.Discount.API.Services.Interfaces;

namespace ShopsRCUS.Discount.API.Services.Implementations
{
    public class BcryptHashService : IHashingService
    {
        public string HashString(string value)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
            return passwordHash;
        }

        public bool VerifyHash(string value,string hash)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(value, hash);
            return verified;
        }
    }
}
