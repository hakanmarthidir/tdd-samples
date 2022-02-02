namespace Mock.Application
{
    public class AgeValidatorService : IAgeValidatorService
    {
        public bool IsValidAge(int age)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidAgeAsync(int age)
        {
            throw new NotImplementedException();
        }

        public void IsValidAgeWithOutParam(int age, out bool isValid)
        {
            throw new NotImplementedException();
        }

        public bool ValidateGeneric<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
