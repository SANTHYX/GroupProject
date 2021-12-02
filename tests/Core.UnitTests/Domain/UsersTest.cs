using Core.Domain;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace Core.UnitTests.Domain
{
    public class UsersTest
    {
    //    private readonly SignUpValidator _validator;

    //    public UsersTest()
    //    {
    //        _validator = new();
    //    }

    //    [Fact]
    //    public void Login_should_throw_when_given_value_will_be_empty()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Login = null;

    //        var result = _validator.TestValidate(user);
    //        result.ShouldHaveValidationErrorFor(x => x.Login);

    //        user.Login = "   ";

    //        var result2 = _validator.TestValidate(user);
    //        result2.ShouldHaveValidationErrorFor(x => x.Login);

    //        user.Login = "";

    //        var result3 = _validator.TestValidate(user);
    //        result3.ShouldHaveValidationErrorFor(x => x.Login);
    //    }

    //    [Fact]
    //    public void Login_should_pass_when_value_wont_be_any_kind_emtpy()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Login = "Jon";

    //        var result = _validator.TestValidate(user);
    //        result.ShouldNotHaveValidationErrorFor(x => x.Login);
    //    }

    //    [Fact]
    //    public void Password_should_throw_when_given_value_will_be_empty()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Password = null;

    //        var result = _validator.TestValidate(user);
    //        result.ShouldHaveValidationErrorFor(x => x.Password);

    //        user.Password = "   ";

    //        var result2 = _validator.TestValidate(user);
    //        result2.ShouldHaveValidationErrorFor(x => x.Password);

    //        user.Password = "";

    //        var result3 = _validator.TestValidate(user);
    //        result3.ShouldHaveValidationErrorFor(x => x.Password);
    //    }

    //    [Fact]
    //    public void Password_should_pass_when_value_wont_be_any_kind_emtpy()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Password = "Secret@password";

    //        var result = _validator.TestValidate(user);
    //        result.ShouldNotHaveValidationErrorFor(x => x.Password);
    //    }

    //    [Fact]
    //    public void Salt_should_throw_when_given_value_will_be_empty()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Salt = null;

    //        var result = _validator.TestValidate(user);
    //        result.ShouldHaveValidationErrorFor(x => x.Salt);

    //        user.Salt = "   ";

    //        var result2 = _validator.TestValidate(user);
    //        result2.ShouldHaveValidationErrorFor(x => x.Salt);

    //        user.Salt = "";

    //        var result3 = _validator.TestValidate(user);
    //        result3.ShouldHaveValidationErrorFor(x => x.Salt);
    //    }

    //    [Fact]
    //    public void Salt_should_pass_when_value_wont_be_any_kind_emtpy()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Salt = "Saltxeqw";

    //        var result = _validator.TestValidate(user);
    //        result.ShouldNotHaveValidationErrorFor(x => x.Salt);
    //    }

    //    [Fact]
    //    public void Email_should_throw_when_given_value_will_be_empty()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Email = null;

    //        var result = _validator.TestValidate(user);
    //        result.ShouldHaveValidationErrorFor(x => x.Email);

    //        user.Email = "   ";

    //        var result2 = _validator.TestValidate(user);
    //        result2.ShouldHaveValidationErrorFor(x => x.Email);

    //        user.Email = "";

    //        var result3 = _validator.TestValidate(user);
    //        result3.ShouldHaveValidationErrorFor(x => x.Email);
    //    }

    //    [Fact]
    //    public void Email_should_throw_when_email_value_will_have_invalid_signature()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Email = "xdddddgmail.com";

    //        var result = _validator.TestValidate(user);
    //        result.ShouldHaveValidationErrorFor(x => x.Email);
    //    }

    //    [Fact]
    //    public void Email_should_pass_when_mail_will_have_valid_signature()
    //    {
    //        var user = Mock.Of<User>();

    //        user.Email = "xddddd@gmail.com";

    //        var result = _validator.TestValidate(user);
    //        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    //    }
    }
}
