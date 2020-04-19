using InternalDomainCheckerBusiness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace InternalDomainCheckerBusinessTest.Models
{
    public class UnitTestDomain
    {
        [Fact]
        public void TestDomainDomainName()
        {
            var domain = new Domain();
            domain.DomainName = "UnitTest";
            var validationResults = ValidateModel(domain);
            Assert.DoesNotContain(validationResults, a => a.MemberNames.Contains("DomainName"));
        }

        [Theory]
        [InlineData("", "DomainName is Required")]
        [InlineData("123", "DomainName should be more than 3 characters")]
        [InlineData("123456789112345678921234567893123456789412345678951", "DomainName should be less than 51 characters")]
        public void TestDomainDomainNameRestrictions(string domainName, string message)
        {
            var domain = new Domain();
            domain.DomainName = domainName;
            var validationResults = ValidateModel(domain);
            Assert.True(validationResults.Any(a => a.MemberNames.Any(b => b == "DomainName")), message);
        }

        private IList<ValidationResult> ValidateModel(object model) //ToDo: Cross Cutting Concern.
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
