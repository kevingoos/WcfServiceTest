using System.ServiceModel;

namespace WcfService.Shared
{
    [ServiceContract]
    public interface ICarService
    {
        [OperationContract]
        bool GetCar();
    }
}
