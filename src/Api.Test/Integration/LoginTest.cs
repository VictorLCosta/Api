using System.Threading.Tasks;
using Xunit;

namespace Api.Test.Integration
{
    public class LoginTest : BaseIntegration
    {
        [Fact]
        public async Task CreateAccessToken()
        {
            await AddTokenAsync();
        }
    }
}