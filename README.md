# Overview

This fork provides portable version of libphonenumber-cshap project, only changes that where requried to compile as portable where made.

--

# libphonenumber-csharp
Clone of original C# port here:  https://bitbucket.org/pmezard/libphonenumber-csharp/wiki/Home

All I've ever done is pull updated metadata from Google's project.

# From the original WIKI
## Conversion Notes

C# port of Google's libphonenumber library:

  [[https://github.com/googlei18n/libphonenumber]]

  The code was rewritten from the Java source mostly unchanged, please refer to the original documentation for sample code and API documentation.

  The original Apache License 2.0 was preserved.

  See [[https://bitbucket.org/pmezard/libphonenumber-csharp/src/tip/csharp/README.txt|csharp/README.txt]] for details about the port.

## Features

  * Parsing/formatting/validating phone numbers for all countries/regions of the world.
  * GetNumberType - gets the type of the number based on the number itself; able to distinguish Fixed-line, Mobile, Toll-free, Premium Rate, Shared Cost, VoIP and Personal Numbers (whenever feasible).
  * IsNumberMatch - gets a confidence level on whether two numbers could be the same.
  * GetExampleNumber/GetExampleNumberByType - provides valid example numbers for 218 countries/regions, with the option of specifying which type of example phone number is needed.
  * IsPossibleNumber - quickly guessing whether a number is a possible phonenumber by using only the length information, much faster than a full validation.
  * AsYouTypeFormatter - formats phone numbers on-the-fly when users enter each digit.
  * FindNumbers - finds numbers in text input 
