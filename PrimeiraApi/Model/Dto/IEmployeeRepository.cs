namespace PrimeiraApi.Model.Dto
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<Employee> GetAll();
    }
}
