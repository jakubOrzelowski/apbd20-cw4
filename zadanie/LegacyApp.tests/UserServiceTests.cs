namespace LegacyApp.tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
     //Arrange
     var UserService = new UserService();

     //Act
     var result = UserService.AddUser(
         null,
         "Kowalski",
         "kowalski@mail.com",
         DateTime.Parse("2000-01-01"),
         1
     );

     //Assert
    Assert.False(result);

    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExists()
    {
        //Arrange
        var UserService = new UserService();

        //Act
        Action action = () => UserService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@mail.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        //Assert
        Assert.Throws<ArgumentException>(action);

    }
}