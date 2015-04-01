using DecoratorValidation.Core;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_Email : ValidatorDecorator<String>
    {
        private readonly String _regEx;
        private readonly String _errorMessage;

        public StringValidator_Email(Validator<String> a, String errorMessage)
            : base(a)
        {
            //From this site: http://www.regular-expressions.info/email.html
            // "Some people, when confronted with a problem, think 'I know, I'll use regular expressions.'
            // Now they have two problems." --  Jamie Zawinski
            _regEx = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
            _errorMessage = errorMessage;
        }

        public override bool Validate(String toValidate)
        {
           

            Regex pattern = new Regex(_regEx, RegexOptions.IgnoreCase);
            isValid =  pattern.IsMatch(toValidate);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}