using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JCLib;

namespace JCTest
{
    public class InputValidationTest
    {
        [Theory]
        [InlineData("1")]
        [InlineData("9")]
        public void ValidateDigitInputShouldReturnTrue(string input)
        {
            bool isDigitValidated = InputValidator.ValidateDigitInput(input);

            Assert.True(isDigitValidated);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("b")]
        public void ValidateDigitInputShouldReturnFalse(string input)
        {
            bool isDigitValidated = InputValidator.ValidateDigitInput(input);

            Assert.False(isDigitValidated);
        }

        [Theory]
        [InlineData("Mary")]
        [InlineData("Michael")]
        public void ValidateNameInputShouldReturnTrue(string input)
        {
            bool isNameValidated = InputValidator.ValidateNameInput(input);

            Assert.True(isNameValidated);
        }

        [Theory]
        [InlineData("Mary1")]
        [InlineData("Michael B")]
        public void ValidateNameInputShouldReturnFalse(string input)
        {
            bool isNameValidated = InputValidator.ValidateNameInput(input);

            Assert.False(isNameValidated);
        }

        [Theory]
        [InlineData("ThisIsPassword")]
        [InlineData("Shortpw")]
        public void ValidatePasswordInputShouldReturnTrue(string input)
        {
            bool isPasswordValidated = InputValidator.ValidatePasswordInput(input);

            Assert.True(isPasswordValidated);
        }

        [Theory]
        [InlineData("hi")]
        [InlineData("my password")]
        public void ValidatePasswordInputShouldReturnFalse(string input)
        {
            bool isPasswordValidated = InputValidator.ValidatePasswordInput(input);

            Assert.False(isPasswordValidated);
        }

        [Theory]
        [InlineData("Y")]
        [InlineData("N")]
        public void ValidateYesNoInputShouldReturnTrue(string input)
        {
            bool isYesNoValidated = InputValidator.ValidateYesOrNoInput(input);

            Assert.True(isYesNoValidated);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("No")]
        public void ValidateYesNoInputShouldReturnFalse(string input)
        {
            bool isYesNoValidated = InputValidator.ValidateYesOrNoInput(input);

            Assert.False(isYesNoValidated);
        }

        [Theory]
        [InlineData("Hello99@melon.net")]
        [InlineData("43770FREND@smileyface.com")]
        public void ValidateEmailInputShouldReturnTrue(string input)
        {
            bool isEmailValidated = InputValidator.ValidateEmailInput(input);

            Assert.True(isEmailValidated);
        }

        [Theory]
        [InlineData("Hellooooooooooooooo99@melon.net")]
        [InlineData("43770FREND@smileyface.gov")]
        public void ValidateEmailInputShouldReturnFalse(string input)
        {
            bool isEmailValidated = InputValidator.ValidateEmailInput(input);

            Assert.False(isEmailValidated);
        }
    }
}
