using Moq.AutoMock;

namespace Bitspace.Tests.Base;

public class UnitTestBase<T> where T : class
{
    protected UnitTestBase()
    {
        Mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
        Sut = Mocker.CreateInstance<T>();
        SutMock = Mocker.GetMock<T>();
        SutMock.CallBase = true;
        Faker = new Faker();
    }

    protected T Sut { get; }
    protected Mock<T> SutMock { get; }
    protected AutoMocker Mocker { get; }
    protected Faker Faker { get; }
}