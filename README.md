This package allows you to build validation stacks using decorators.  This means that you can construct complex validation paths in which each component behaves according to obvious and easily readable rules.  Let's build a password complexity validator.

All validators start with a base case.  If everything else passes, the base case returns true providing an end to the logical chain.  We'll start by creating a string base case.

    Validator<string> myValidator = new ValidatorBaseCase<string>();

Now we want to add our first condition.  

    myValidator = new StringValidator_MinSymbolChars(myValidator, 1, "Requires at least one symbol.");

Note that the `StringValidator_MinSymbolChars` constructor in not generic; that's because it only applies to `Validator<string>` objects.  Also note that we passed `myValidator` into `StringValidator_MinSymbolChars`.  In this way we have wrapped `StringValidator_MinSymbolChars` around the `ValidatorBaseCase<string>`.  When we validate, validation will occur from the outside going in, meaning that the first validator we add will be the last we evaluate.  

Let's add a few more validators

    myValidator = new StringValidator_MinNumericChars(myValidator, 2, "Requires at least two numbers.");
    myValidator = new StringValidator_MinLength(myValidator, 11, "Must be at least 11 characters long.");
    myValidator = new StringValidator_NotEmpty(myValidator, "Can not be empty.");

Now let's test the resulting validator.  Remember, validation happens from the outside in.  This means that the last validator we defined `StringValidator_NotEmpty` is the first to fire.  We could accomplish the same thing with `StringValidator_MinLength` but this gives us a more specific message for the user.  

    myValidator.Validate("1234567890!"); //returns true
    myValidator.Validate("ABCDEFGHIJ!"); //returns false
    myValidator.Validate("123456789!"); //returns false
    myValidator.Validate("           "); //returns false

Validators also tell you why they failed.  

    myValidator.Validate("ABCDEFGHIJ!"); 
      Console.WriteLine(myValidator.ErrorMessage); //Requires at least two numbers.
    myValidator.Validate("123456789!"); //returns false
      Console.WriteLine(myValidator.ErrorMessage); //Must be at least 11 characters long.
    myValidator.Validate("           "); //returns false
      Console.WriteLine(myValidator.ErrorMessage); //Can not be empty.

At present Validators use shortcut logic so they only tell you the outermost reason they failed.  A future update (soon) will incorporate non-shortcut logic, allowing full stack error reporting. 

    
