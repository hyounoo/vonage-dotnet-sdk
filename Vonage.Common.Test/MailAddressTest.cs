using Vonage.Common.Failures;
using Vonage.Common.Test.Extensions;

namespace Vonage.Common.Test;

public class MailAddressTest
{
    [Theory]
    [InlineData("dummy-vonage.com")]
    [InlineData("123456789")]
    [InlineData("test@test@test.com")]
    public void Parse_ShouldReturnFailure_GivenAddressIsInvalid(string email) =>
        MailAddress.Parse(email).Map(value => value.Address).Should()
            .BeFailure(ResultFailure.FromErrorMessage("Email is invalid."));

    [Theory]
    [InlineData("dummy@vonage.com")]
    [InlineData("dum@von.co.uk")]
    public void Parse_ShouldReturnSuccess_GivenAddressIsValid(string email) =>
        MailAddress.Parse(email).Map(value => value.Address).Should().BeSuccess(email);
}