using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace ClearArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action act = () => new Category(1, "Category Name");

            act.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }


        [Fact]
        public void CreateCategory_WithNegativeIdValue_ResultObjectInvalid()
        {
            Action act = () => new Category(-1, "Category Name");

            act.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id value.");
        }


        [Fact]
        public void CreateCategory_WhereNameIsNull_ResultObjectInvalid()
        {
            Action act = () => new Category(1, null);

            act.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
