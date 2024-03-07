# Split Options

> 10000 Items

| Method           | Runtime            | Mean       | Gen0     | Gen1    | Gen2    | Allocated |
|------------------|------------------- |-----------:|---------:|--------:|--------:|----------:|
| Classic          | .NET Framework 4.8 | 1,179.1 us | 140.6250 | 70.3125 | 70.3125 |  721536 B |
| Classic          | .NET 8.0           |   285.0 us |  78.6133 | 33.6914 |       - |  400024 B |
| RefStruct        | .NET Framework 4.8 |   167.8 us |        - |       - |       - |         - |
| RefStruct*       | .NET 8.0           |   107.9 us |        - |       - |       - |         - |
| EnumeratorStruct | .NET Framework 4.8 |   249.8 us |        - |       - |       - |      44 B |
| EnumeratorStruct*| .NET 8.0           |   122.7 us |        - |       - |       - |      40 B |