namespace WcfService.Shared
{
    public class TestService : ITestService, ICarService
    {
        public bool GetTestData()
        {
            return true;
        }

        public bool GetCar()
        {
            return false;
        }
    }
}
