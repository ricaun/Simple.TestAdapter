# Simple.TestAdapter

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![Build](../../actions/workflows/Build.yml/badge.svg)](../../actions)

This is a simple TestAdapter to get all the methods with a attribute in the assembly, and run a fake test.

## Usage

The `Simple.TestAdapter` only gonna discovery test if the file name of the assembly end with `Tests`.

By default all tests gonna `Passed` except if the name of the method has `Failed`, `Skipped`, `None`, `NotFound` in it.

## Example

The project [TestProject.Tests](TestProject.Tests) has some sample methods to test.

## License

This package is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this package? Please [star this project on GitHub](../../stargazers)!