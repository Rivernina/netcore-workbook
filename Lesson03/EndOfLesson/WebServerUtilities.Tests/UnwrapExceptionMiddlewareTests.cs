using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace WebServerUtilities.Tests
{
    public class UnwrapExceptionMiddlewareTests
    {
        [Fact]
        public async Task Middleware_CatchesExceptions()
        {
            // Assemble
            var next = new RequestDelegate(ctx => throw new Exception("not root", new Exception("root")));
            var middleware = new UnwrapExceptionMiddleware();
            var context = new DefaultHttpContext();
            Exception exception = null;

            // Act
            try
            {
                await middleware.InvokeAsync(context, next);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.Equal("root", exception?.Message);
        }

        [Fact]
        public async Task Middleware_DoesNothingIfNoExceptionIsThrown()
        {
            // Assemble
            var next = new RequestDelegate(ctx => Task.CompletedTask);
            var middleware = new UnwrapExceptionMiddleware();
            var context = new DefaultHttpContext();
            Exception exception = null;

            // Act
            try
            {
                await middleware.InvokeAsync(context, next);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task Middleware_UnwrapsExceptionCorrectlyForTimeouts()
        {
            // Assemble
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();
            // .Wait() causes the OperationCanceledException to be wrapped 
            // in an AggregateException. We want to test that 
            // this middleware handles that correctly
            var next = new RequestDelegate(async ctx => Task.Run(() => cancellationTokenSource.Token.ThrowIfCancellationRequested()).Wait());
            var middleware = new UnwrapExceptionMiddleware();
            var context = new DefaultHttpContext();
            Exception exception = null;

            // Act
            try
            {
                await middleware.InvokeAsync(context, next);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsType<OperationCanceledException>(exception);
        }
    }
}
