using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace WebServerUtilities.Tests
{
    public class InternalServerErrorStatusCodeMiddlewareTests
    {
        [Fact]
        public async Task Middleware_CatchesExceptionsAndSetsStatusCodeTo500()
        {
            // Assemble
            var next = new RequestDelegate(ctx => throw new Exception("root"));
            var middleware = new InternalServerErrorStatusCodeMiddleware();
            var context = new DefaultHttpContext();

            // Act
            await middleware.InvokeAsync(context, next);

            // Assert
            Assert.Equal(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
        }

        [Fact]
        public async Task Middleware_DoesNothingIfNoExceptionIsThrown()
        {

            // Assemble
            var next = new RequestDelegate(ctx => Task.CompletedTask);
            var middleware = new InternalServerErrorStatusCodeMiddleware();
            var context = new DefaultHttpContext();

            // Act
            await middleware.InvokeAsync(context, next);

            // Assert
            Assert.NotEqual(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
        }
    }
}
