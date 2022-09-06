using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace UATPRapidPay.Card.Tests.EndToEnd
{
    public class ApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
    {
        protected override IHostBuilder? CreateHostBuilder()
        {
            return base.CreateHostBuilder().UseEnvironment("tests");
        }
    }
}