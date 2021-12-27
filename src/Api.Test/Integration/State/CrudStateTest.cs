using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.DTO.State;
using Newtonsoft.Json;
using Xunit;

namespace Api.Test.Integration.State
{
    public class CrudStateTest : BaseIntegration
    {
        private Guid _id { get; set; } = new("5daf0fe5-8f3c-4154-9a02-4461b24ef4b4");

        [Fact]
        public async Task IsPossibleMakeStateCrud()
        {
            await AddTokenAsync();

            var response = await Client.GetAsync($"{HostApi}state/{_id}");
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<StateDto>(responseJson);

            Assert.Equal(responseData.Name, "São Paulo");
            Assert.Equal(responseData.UF, "SP");

            response = await Client.GetAsync($"{HostApi}state");
            responseJson = await response.Content.ReadAsStringAsync();
            var responseGetAll = JsonConvert.DeserializeObject<IEnumerable<StateDto>>(responseJson);

            Assert.NotEmpty(responseGetAll);
            Assert.True(responseGetAll.Count() == 27);
        }
    }
}