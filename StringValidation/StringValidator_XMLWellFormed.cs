using DecoratorValidation.Core;
using System;
using System.Text;
using System.Xml;

namespace DecoratorValidation.StringValidation.Validators
{
    public class StringValidator_XMLWellFormed : ValidatorDecorator<String>
    {
        private readonly string _errorMessage;

        public StringValidator_XMLWellFormed(Validator<String> a, string errorMessage) : base(a)
        {
            _errorMessage = errorMessage;
        }



        public override bool Validate(string toValidate)
        {
            try
            {
                if (string.IsNullOrEmpty(toValidate))
                    return false;
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(toValidate);
                isValid = true;
            }
            catch (XmlException)
            {
                //If this is bothering you on debug, go to Debug / Exceptions... / Common Language Runtime Exceptions.
                //Find System.Xml.XmlException, then make sure only "User-unhandled" is ticked 
                isValid = false;
            }

            AppendErrorMessage(_errorMessage);
            return isValid && base.Validate(toValidate);
        }
    }
}
