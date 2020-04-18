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
        public void TestOrder()
        {
            var order = new Order();
            order.CustomerName = "UnitTest";
            var validationResults = ValidateModel(order);
            Assert.True(validationResults.Count == 0);
        }

        [Fact]
        public void TestOrderCustomerNameIsRequired()
        {
            var order = new Order();
            var validationResults = ValidateModel(order);
            Assert.Contains(validationResults, a => a.MemberNames.Contains("CustomerName"));
        }

        [Fact]
        public void TestOrderCustomerNameShouldBeMoreThan3Characters()
        {
            var order = new Order();
            order.CustomerName = "123";
            var validationResults = ValidateModel(order);
            Assert.Contains(validationResults, a => a.MemberNames.Contains("CustomerName"));
        }

        [Fact]
        public void TestOrderCustomerNameShouldBeMoreLessThan50Characters()
        {
            var order = new Order();
            order.CustomerName = "123456789112345678921234567893123456789412345678951";
            var validationResults = ValidateModel(order);
            Assert.Contains(validationResults, a => a.MemberNames.Contains("CustomerName"));
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
