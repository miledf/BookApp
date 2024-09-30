using BookApp.Infrastructure.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookApp.Common.report
{
    public class BookViewGenerate
    {
        public async Task<string> ToHtmlAsync(List<BooksView> books) { 
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            var serviceProvider = services.BuildServiceProvider();

            var logginFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            await using var htmlRenderer = new HtmlRenderer(serviceProvider, logginFactory);

            var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
            {
                var dictionary = new Dictionary<string, object?>
                {
                    { "BooksView", books }
                };

                var parameters = ParameterView.FromDictionary(dictionary);
                var output = await htmlRenderer.RenderComponentAsync<BookViewReport>(parameters);

                return output.ToHtmlString();
            });

            return html;
        }
    }
}
