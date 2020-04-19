using InternalOrderBusiness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace InternalOrderBusinessTest.Models
{
    public class UnitTestOrder
    {
        [Fact]
        public void TestOrderCustomerName()
        {
            var order = new Order();
            order.CustomerName = "UnitTest";
            var validationResults = ValidateModel(order);
            Assert.True(validationResults.Count == 0);
        }

        [Theory]
        [InlineData("", "CustomerName is Required")]
        [InlineData("123", "CustomerName should be more than 3 characters")]
        [InlineData("123456789112345678921234567893123456789412345678951", "CustomerName should be less than 51 characters")]
        public void TestOrderCustomerNameRestrictions(string orderName, string message)
        {
            var order = new Order();
            order.CustomerName = orderName;
            var validationResults = ValidateModel(order);
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
