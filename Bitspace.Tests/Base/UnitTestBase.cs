using Moq;
using Moq.AutoMock;

namespace Bitspace.Tests.Base;

public class UnitTestBase<T> where T : class
{
    public UnitTestBase()
    {
        Mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
        Sut = Mocker.CreateInstance<T>();
        SutMock = Mocker.GetMock<T>();
        SutMock.CallBase = true;
    }

    public T Sut { get; }
    public Mock<T> SutMock { get; }
    public AutoMocker Mocker { get; }
}