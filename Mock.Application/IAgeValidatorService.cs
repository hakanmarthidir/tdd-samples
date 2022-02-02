namespace Mock.Application
{
    public interface IAgeValidatorService
    {
        bool IsValidAge(int age);
        void IsValidAgeWithOutParam(int age, out bool isValid);
        Task<bool> IsValidAgeAsync(int age);
        bool ValidateGeneric<T>(T entity);
    }
}
