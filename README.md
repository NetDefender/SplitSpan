# Split Options

>BenchmarkDotNet v0.13.12
>Windows 10
>AMD Ryzen 7 1700 1 CPU 16 logical 8 physical cores
>10000 Items


| Method               | Runtime            | Mean (us)| Gen0     | Gen1     | Gen2    | Allocated (Bytes)|
|----------------------|--------------------|---------:|---------:|---------:|--------:|------------:|
| SplitClassic         | .NET Framework 4.8 | 1.313    | 140      |  70      | 70      |  721.536  |
| SplitClassic         | .NET 8.0           |   313    |  78      |  33      |         |  400.024  |
| SplitRegex           | .NET Framework 4.8 | 4.287    | 507      | 132      | 62      | 3.230.939 |
| SplitRegex           | .NET 8.0           | 1.136    | 103      |  62      | 41      |  662.495  |
| SplitRefStruct       | .NET Framework 4.8 |   173    |          |          |         |           |
| SplitRefStruct       | .NET 8.0           |   118    |          |          |         |           |
| SplitEnumeratorStruct| .NET Framework 4.8 |   334    |          |          |         |        44 |
| SplitEnumeratorStruct| .NET 8.0           |   132    |          |          |         |        40 |