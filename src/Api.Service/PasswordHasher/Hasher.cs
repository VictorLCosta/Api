using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;

namespace Api.Service.PasswordHasher
{
    public class Hasher
    {
        public async Task<byte[]> HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8;
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 400;

            return await argon2.GetBytesAsync(16);
        }

        public async Task<bool> VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            var newHash = await HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

        public byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
    }
}