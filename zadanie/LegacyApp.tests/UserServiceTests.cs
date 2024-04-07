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
    public void AddUser_ReturnsFalseWhenLastNameIsEmpty()
    {
        //Arrange
        var UserService = new UserService();

        //Act
        var result = UserService.AddUser(
            "Jan",
            null,
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
            100
        );
        
        //Assert
        Assert.Throws<ArgumentException>(action);

    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        //Arrange
        var UserService = new UserService();
        
        //Act
        var result = UserService.AddUser(
            "Jan",
            "Kowalski",
            "kowalskimailcom",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        //Arrange
        var UserService = new UserService();
        
        //Act
        var result = UserService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@mail.com",
            DateTime.Parse("2024-01-01"),
            1
        );
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        //Arrange
        var UserService = new UserService();
        
        //Act
        var user = UserService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@mail.com",
            DateTime.Parse("2024-01-01"),
            1
        );
        var clientRepository = new ClientRepository();
        var client = clientRepository.GetById(1);
        var result = client.Type.Equals("VeryImportantClient");
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        //Arrange
        var UserService = new UserService();
        
        //Act
        var user = UserService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@mail.com",
            DateTime.Parse("2024-01-01"),
            1
        );
        var clientRepository = new ClientRepository();
        var client = clientRepository.GetById(1);
        var result = client.Type.Equals("ImportantClient");
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        //Arrange
        var UserService = new UserService();
        
        //Act
        var user = UserService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@mail.com",
            DateTime.Parse("2024-01-01"),
            1
        );
        var clientRepository = new ClientRepository();
        var client = clientRepository.GetById(1);
        var result = client.Type.Equals("NormalClient");
        
        //Assert
        Assert.True(result);
    }
 
    // [Fact]
    // public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    // {
    //     //Arrange
    //     var UserService = new UserService();
    //     
    //     //Act
    //     var user = UserService.AddUser(
    //         "Jan",
    //         "Kowalski",
    //         "kowalski@mail.com",
    //         DateTime.Parse("2024-01-01"),
    //         1
    //     );
    //     var clientRepository = new ClientRepository();
    //     var client = clientRepository.GetById(1);
    //     bool result;
    //
    //     var x = user.HasCreditLimit;
    //     if (client.Type.Equals("NormalClient") && user.HasCreditLimit)
    //     {
    //         result = false;
    //     }
    //     else
    //     {
    //         result = true;
    //     }
    //     
    //     //Assert
    //     Assert.False(result);
    // }
    
    
    // [Fact]
    // public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    // {
    //     //Arrange
    //     var UserService = new UserService();
    //     
    //     //Act
    //     var user = UserService.AddUser(
    //         "Jan",
    //         "Kowalski",
    //         "kowalski@mail.com",
    //         DateTime.Parse("2024-01-01"),
    //         1
    //     );
    //     var clientRepository = new ClientRepository();
    //     var client = clientRepository.GetById(1);
    //     bool result;
    //
    //     var x = user.HasCreditLimit;
    //     if (client.Type.Equals("NormalClient") && user.HasCreditLimit)
    //     {
    //         result = false;
    //     }
    //     else
    //     {
    //         result = true;
    //     }
    //     
    //     //Assert
    //     Assert.False(result);
    // }
}