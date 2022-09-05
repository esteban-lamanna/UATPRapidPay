using Newtonsoft.Json;
using Shouldly;
using System.Net;
using System.Text;
using UATPRapidPay.Card.Api;
using UATPRapidPay.Card.Api.Models.Card;

namespace UATPRapidPay.Card.Tests.EndToEnd
{
    public class CreateCardShould : IClassFixture<ApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public CreateCardShould(ApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task CreateACardSuccessfully()
        {
            var body = new CreateCardRequest()
            {
                Limit = 3
            };

            var validPersonId = Guid.Parse("75057B75-7A7C-4A09-A4AB-17CD035ED156");

            var message = await _httpClient.PostAsync($"Person/{validPersonId}/Card", GetContent(body));

            var response = JsonConvert.DeserializeObject<CreateCardResponse>(await message.Content.ReadAsStringAsync());

            response.ShouldNotBeNull();
            response.CardNumber.ShouldNotBeNull();
        }


        [Fact]
        public async Task CreateACard_InvalidPerson_Receives_BadRequest()
        {
            var body = new CreateCardRequest()
            {
                Limit = 3
            };

            var invalidPersonId = Guid.NewGuid();

            var message = await _httpClient.PostAsync($"Person/{invalidPersonId}/Card", GetContent(body));

            message.ShouldNotBeNull();
            message.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.BadRequest);
        }

        private static StringContent GetContent(object value)
          => new(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
    }
}