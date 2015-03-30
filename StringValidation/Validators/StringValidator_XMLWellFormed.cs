using DecoratorValidation.Core;
using System;
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

        

        public override bool Validate(string toValidate, ref string errorMessage)
        {
            bool validates;
            try
            {
                if (string.IsNullOrEmpty(toValidate))
                    return false;
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(toValidate);
                validates = true;
            }
            catch (XmlException)
            {
                //If this is bothering you on debug, go to Debug / Exceptions... / Common Language Runtime Exceptions.
                //Find System.Xml.XmlException, then make sure only "User-unhandled" is ticked 
                validates = false;
            }

            if (validates == false) 
                errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;
            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}
