using System.ServiceModel;

namespace WcfConsole.Shared
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        bool GetTestData();
    }
}
