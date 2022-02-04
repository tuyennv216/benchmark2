# benchmark2

Sau khi chạy thì mình có một vài kết quả.  

***
### - Duyệt array xuôi và ngược  
|                   Method |     Mean |    Error |    StdDev |   Median |     Gen 0 |     Gen 1 |    Gen 2 | Allocated |
|------------------------- |---------:|---------:|----------:|---------:|----------:|----------:|---------:|----------:|
| BenmarkForDecrementIndex | 128.1 ms | 37.28 ms | 109.93 ms | 57.73 ms | 1500.0000 |  500.0000 |        - |     14 MB |
| BenmarkForIncrementIndex | 112.5 ms | 29.45 ms |  85.91 ms | 61.75 ms | 1750.0000 | 1000.0000 | 250.0000 |     14 MB |

***
### - Dùng for và yield  
|          Method |      Mean |     Error |    StdDev |   Median |     Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|---------------- |----------:|----------:|----------:|---------:|----------:|---------:|---------:|----------:|
|   BenmarkForvar | 108.82 ms | 30.529 ms | 90.017 ms | 58.60 ms | 1600.0000 | 800.0000 | 200.0000 |     14 MB |
| BenmarkForyield |  56.04 ms |  1.586 ms |  4.007 ms | 53.93 ms | 1600.0000 | 800.0000 | 200.0000 |     14 MB |

***
### - Dùng rẽ nhánh và không dùng rẽ nhánh  
|           Method |     Mean |     Error |    StdDev |   Median |      Gen 0 |     Gen 1 |    Gen 2 | Allocated |
|----------------- |---------:|----------:|----------:|---------:|-----------:|----------:|---------:|----------:|
|        BenmarkIf | 283.1 ms |   7.34 ms |  18.95 ms | 274.5 ms | 10000.0000 | 3000.0000 |        - |     95 MB |
| BenmarkWithoutIf | 651.8 ms | 179.84 ms | 530.27 ms | 331.4 ms | 11000.0000 | 3500.0000 | 500.0000 |     95 MB |

***
### - Dùng string builder và string list  
|               Method |      Mean |     Error |    StdDev |    Median |     Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|--------------------- |----------:|----------:|----------:|----------:|----------:|---------:|---------:|----------:|
| BenmarkStringBuilder |  4.841 ms | 0.1133 ms | 0.2905 ms |  4.753 ms |  562.5000 | 281.2500 |  31.2500 |      4 MB |
|    BenmarkStringList | 14.798 ms | 0.6697 ms | 1.7167 ms | 14.685 ms | 2333.3333 | 666.6667 | 166.6667 |     18 MB |

***
### - Tuần tự và dùng parallel  
|          Method |       Mean |   Error |  StdDev | Allocated |
|---------------- |-----------:|--------:|--------:|----------:|
| BenmarkParallel |   509.5 ms | 1.52 ms | 1.42 ms |      3 KB |
| BenmarkSequence | 1,532.5 ms | 1.57 ms | 1.47 ms |      2 KB |
