using Moq;
using Xunit;

namespace Mock.Application.Tests
{
    public class StudentApplicationManagerTest
    {
        Mock<IAgeValidatorService> mockValidator;

        public StudentApplicationManagerTest()
        {
            mockValidator = new Mock<IAgeValidatorService>();
        }


        [Fact]
        public void ShouldBeAccepted()
        {            
            mockValidator.Setup(x => x.IsValidAge(It.Is<int>(x=> x >= 18))).Returns(true);

            ApplicationManager applicationManager = new ApplicationManager(mockValidator.Object);
            var result = applicationManager.CheckApplication(new StudentApplication() { GradeAverage = 4.15 , Age = 18 });

            Assert.Equal(ApplicationStatus.Accepted, result);

        }

        [Fact]
        public void ShouldBeRejected()
        {
            
            mockValidator.Setup(x => x.IsValidAge(It.IsAny<int>())).Returns(true);
            
            ApplicationManager applicationManager = new ApplicationManager(mockValidator.Object);
            var result = applicationManager.CheckApplication(new StudentApplication() { GradeAverage = 2, Age = 4 });

            Assert.Equal(ApplicationStatus.Rejected, result);

        }

        [Fact]
        public void ShouldBeInProgress()
        {
            
            mockValidator.Setup(x=> x.IsValidAge(It.IsInRange<int>(18,30, Moq.Range.Inclusive))).Returns(true);

            ApplicationManager applicationManager = new ApplicationManager(mockValidator.Object);
            var result = applicationManager.CheckApplication(new StudentApplication() { GradeAverage = 3, Age = 18 });

            Assert.Equal(ApplicationStatus.InProgress, result);

        }

        [Fact]
        public void ShouldBeInProgress_OutParam()
        {
            
            bool isValidAge = true;
            mockValidator.Setup(x => x.IsValidAgeWithOutParam(It.IsAny<int>(), out isValidAge));

            ApplicationManager applicationManager = new ApplicationManager(mockValidator.Object);
            var result = applicationManager.CheckApplicationOut(new StudentApplication() { GradeAverage = 3, Age = 18 });

            Assert.Equal(ApplicationStatus.InProgress, result);

        }

        //Behaivors
        [Fact]
        public void ShouldBe_IsValidAge_Verified()
        {

            mockValidator.Setup(x => x.IsValidAge(It.IsAny<int>())).Returns(true);

            ApplicationManager applicationManager = new ApplicationManager(mockValidator.Object);
            var result = applicationManager.CheckApplication(new StudentApplication() { GradeAverage = 3, Age = 18 });

            //mockValidator.Verify(x => x.IsValidAge(It.IsAny<int>()));
            //mockValidator.Verify(x => x.IsValidAge(It.IsAny<int>()), Times.Once);
            mockValidator.Verify(x => x.IsValidAge(18), Times.Once);
        }

        //Async
        [Fact]
        public void ShouldBe_IsValidAgeAsync_Verified()
        {
            //mockValidator.Setup(x => x.IsValidAgeAsync(It.IsAny<int>())).Returns(Task.FromResult(true));
            mockValidator.Setup(x => x.IsValidAgeAsync(It.IsAny<int>())).ReturnsAsync(true);

            ApplicationManager applicationManager = new ApplicationManager(mockValidator.Object);
            var result = applicationManager.CheckApplicationAsync(new StudentApplication() { GradeAverage = 3, Age = 18 });

            //mockValidator.Verify(x => x.IsValidAge(It.IsAny<int>()));
            //mockValidator.Verify(x => x.IsValidAge(It.IsAny<int>()), Times.Once);
            mockValidator.Verify(x => x.IsValidAgeAsync(18), Times.Once);
        }

        [Fact]
        public void ShouldBe_ValidateGeneric_Verified()
        {
            //It.IsAny<It.IsAnyType>())
            mockValidator.Setup(x => x.ValidateGeneric(It.IsAny<It.IsAnyType>())).Returns(true);

            ApplicationManager applicationManager = new ApplicationManager(mockValidator.Object);

            var student = new StudentApplication() { GradeAverage = 3, Age = 18 };
            var result = applicationManager.CheckApplicationGeneric(student);
            
            mockValidator.Verify(x => x.ValidateGeneric(student), Times.Once);
        }


    }
}