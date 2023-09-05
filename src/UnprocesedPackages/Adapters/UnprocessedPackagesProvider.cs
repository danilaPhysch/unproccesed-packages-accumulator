using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using UnprocessedPackages.Application;

namespace UnprocessedPackages.Adapters;

public class UnprocessedPackagesProvider : UnprocessedPackagesSender.UnprocessedPackagesSenderBase
{
    private readonly ILogger<UnprocessedPackagesProvider> _logger;

    public UnprocessedPackagesProvider(ILogger<UnprocessedPackagesProvider> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override async Task GetFgbUnprocessedPackages(Empty request, IServerStreamWriter<UnprocessedFgbPackage> responseStream, ServerCallContext context)
    {
        _logger.LogInformation("Method {MethodName} was subscribed", nameof(GetFgbUnprocessedPackages));

        while (!context.CancellationToken.IsCancellationRequested)
        {
            var fgbUnprocessedPackage = GenerateRandomPackages.GetUnprocessedFgbPackage();
            await responseStream.WriteAsync(fgbUnprocessedPackage);

            _logger.LogInformation("Fgb package with message {Message} was sent", fgbUnprocessedPackage.Message);

            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        _logger.LogInformation("Method {MethodName} was unsubscribed", nameof(GetFgbUnprocessedPackages));
    }

    public override async Task GetSgbUnprocessedPackages(Empty request, IServerStreamWriter<UnprocessedSgbPackage> responseStream, ServerCallContext context)
    {
        _logger.LogInformation("Method {MethodName} was subscribed", nameof(GetSgbUnprocessedPackages));

        while (!context.CancellationToken.IsCancellationRequested)
        {
            var sgbUnprocessedPackage = GenerateRandomPackages.GetUnprocessedSgbPackage();
            await responseStream.WriteAsync(sgbUnprocessedPackage);

            _logger.LogInformation("Sgb package with message {Message} was sent", sgbUnprocessedPackage.Message);

            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        _logger.LogInformation("Method {MethodName} was unsubscribed", nameof(GetSgbUnprocessedPackages));
    }
}