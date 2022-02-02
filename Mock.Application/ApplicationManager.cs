namespace Mock.Application
{
    public class ApplicationManager
    {
        private readonly IAgeValidatorService _ageValidatorService;

        public ApplicationManager(IAgeValidatorService ageValidatorService)
        {
            _ageValidatorService = ageValidatorService ?? throw new ArgumentNullException(nameof(ageValidatorService), "Validator should not be null.");
        }

        public ApplicationStatus CheckApplication(StudentApplication application)
        {
            var isValid = this._ageValidatorService.IsValidAge(application.Age);
            if (!isValid)
            {
                return ApplicationStatus.Rejected;
            }

            if (application.GradeAverage >= 4)
            {
                return ApplicationStatus.Accepted;
            }
            else if (application.GradeAverage >= 3 && application.GradeAverage < 4)
            {
                return ApplicationStatus.InProgress;
            }

            return ApplicationStatus.Rejected;

        }

        public ApplicationStatus CheckApplicationOut(StudentApplication application)
        {

            this._ageValidatorService.IsValidAgeWithOutParam(application.Age, out bool result);
            if (!result)
            {
                return ApplicationStatus.Rejected;
            }

            if (application.GradeAverage >= 4)
            {
                return ApplicationStatus.Accepted;
            }
            else if (application.GradeAverage >= 3 && application.GradeAverage < 4)
            {
                return ApplicationStatus.InProgress;
            }

            return ApplicationStatus.Rejected;

        }

        public ApplicationStatus CheckApplicationGeneric(StudentApplication application)
        {

            var result = this._ageValidatorService.ValidateGeneric<StudentApplication>(application);

            if (!result)
            {
                return ApplicationStatus.Rejected;
            }

            if (application.GradeAverage >= 4)
            {
                return ApplicationStatus.Accepted;
            }
            else if (application.GradeAverage >= 3 && application.GradeAverage < 4)
            {
                return ApplicationStatus.InProgress;
            }

            return ApplicationStatus.Rejected;

        }

        public async Task<ApplicationStatus> CheckApplicationAsync(StudentApplication application)
        {

            var isValid = await this._ageValidatorService.IsValidAgeAsync(application.Age).ConfigureAwait(false);
            if (!isValid)
            {
                return ApplicationStatus.Rejected;
            }

            if (application.GradeAverage >= 4)
            {
                return ApplicationStatus.Accepted;
            }
            else if (application.GradeAverage >= 3 && application.GradeAverage < 4)
            {
                return ApplicationStatus.InProgress;
            }

            return ApplicationStatus.Rejected;

        }
    }
}
