using ExternalSiteInvestigationBusiness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace ExternalSiteInvestigationBusinessTest.Models
{
    public class UnitTestSiteInvestigationRequest
    {
        [Fact]
        public void TestSiteInvestigationRequestDomainName()
        {
            var siteInvestigationRequest = new SiteInvestigationRequest();
            siteInvestigationRequest.CustomerName = "UnitTest";
            var validationResults = ValidateModel(siteInvestigationRequest);
            Assert.DoesNotContain(validationResults, a => a.MemberNames.Contains("CustomerName"));
        }

        [Theory]
        [InlineData("", "CustomerName is Required")]
        [InlineData("123", "CustomerName should be more than 3 characters")]
        [InlineData("123456789112345678921234567893123456789412345678951", "CustomerName should be less than 51 characters")]
        public void TestSiteInvestigationRequestDomainNameRestrictions(string customerName, string message)
        {
            var siteInvestigationRequest = new SiteInvestigationRequest();
            siteInvestigationRequest.CustomerName = customerName;
            var validationResults = ValidateModel(siteInvestigationRequest);
            Assert.True(validationResults.Any(a => a.MemberNames.Any(b => b == "CustomerName")), message);
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
