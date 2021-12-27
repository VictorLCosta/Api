using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Api.Data;
using Api.Domain.DTO.Account;
using application;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static Api.Test.Services.BaseServiceTest;

namespace Api.Test.Integration
{
    public class BaseIntegration : IDisposable
    {
        public ApplicationDbContext MyContext { get; private set; }
        public HttpClient Client { get; private set; }
        public IConfiguration Config { get; private set; }

        public IMapper Mapper { get; set; }
        public string HostApi { get; set; }
        public HttpResponseMessage Response { get; set; }

        public BaseIntegration()
        {
            HostApi = "http://localhost:5000/api/v1/";

            var dir = Directory.GetParent("Test").FullName;

            Config = new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseConfiguration(Config)
                .UseKestrel(opt => opt.Listen(IPAddress.Any, 80))
                .UseStartup<Startup>();

            var server = new TestServer(builder);

            MyContext = server.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            MyContext.Database.Migrate();

            Mapper = new AutoMapperFixture().GetMapper();

            Client = server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:5000");

        }

        public async Task AddTokenAsync()
        {
            var loginDto = new LoginDto()
            {
                // Name = "Kelly Hackett",
                Email = "Kelly49@yahoo.com",
                Password = "YL5qazrNoo"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{HostApi}account", Client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var objLogin = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objLogin.AccessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string uri, HttpClient client)
        {
            return await client.PostAsync(uri, 
                new StringContent(JsonConvert.SerializeObject(dataclass), Encoding.UTF8, "application/json"));
        }

        public static async Task<HttpResponseMessage> PutJsonAsync(object dataclass, string uri, HttpClient client)
        {
            return await client.PutAsync(uri, 
                new StringContent(JsonConvert.SerializeObject(dataclass), Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            MyContext.Dispose();
            Client.Dispose();
        }
    }
}