using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace ClearArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action act = () => new Product(1, "Product Name", "Lorem Ipsum Dolor", 10, 1, "TETETETETETETETETE");

            act.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact]
        public void CreateProduct_WithNegativeIdValue_ResultObjectInvalid()
        {
            Action act = () => new Product(-1, "Product Name", "Lorem Ipsum Dolor", 10, 1, "TETETETETETETETETE");

            act.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Ca", "Lorem Ipsum Dolor", 10, 1, "TETETETETETETETETE");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short minimum 5 characters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Lorem Ipsum Dolor", 10, 1, "TETETETETETETETETE");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name. Name is required");
        }

        [Fact]
        public void CreateProduct_WithNegativePrice_DomainExceptionPriceLowerThanZero()
        {
            Action action = () => new Product(1, "Product Name", "Lorem Ipsum Dolor", -1, 1, "TETETETETETETETETE");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact]
        public void CreateProduct_WithNegativeStock_DomainExceptionPriceLowerThanZero()
        {
            Action action = () => new Product(1, "Product Name", "Lorem Ipsum Dolor", 1, -1, "TETETETETETETETETE");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact]
        public void CreateProduct_WhereNameIsNull_ResultObjectInvalid()
        {
            Action act = () => new Product(1, null, "Lorem Ipsum Dolor", 10, 1, "TETETETETETETETETE");

            act.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
