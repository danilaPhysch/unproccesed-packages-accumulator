using AutoFixture;

namespace UnprocessedPackages.Application;

public static class GenerateRandomPackages
{
    private static readonly Fixture _fixture = new();

    public static UnprocessedFgbPackage GetUnprocessedFgbPackage()
    {
        return _fixture.Create<UnprocessedFgbPackage>();
    }

    public static UnprocessedSgbPackage GetUnprocessedSgbPackage()
    {
        return _fixture.Create<UnprocessedSgbPackage>();
    }
}