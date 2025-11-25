# F10Y.L0060
.NET 6.0 language-only (foundation) library.

The main reasons for this library are:

- Introduction of DateOnly and TimeOnly types.
- .NET 6.0 includes full development of System.Text.Json source-generation features.

Allowed dependencies:

	- net6.0
	- Language libraries of prior .NET versions:
		- F10Y.L0000 - netstandard2.1 language library.


## F10Y.L0024

The F10Y.L0024 library contains the same functionality, but based on the System.Text.Json package for use in prior versions of .NET.

This library, the F10Y.L0060 .NET 6.0 foundation library, is the primary home of System.Text.Json functionality.
But the F10Y.L0024 library is provided as a clone for use in prior versions of .NET.
However, the F10Y.L0024 library might be behind the F10Y.L0060 library.


## Prior Work

* R5T.L0072