using System.ServiceModel;

namespace WcfService.Shared
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        bool GetTestData();
    }
}
