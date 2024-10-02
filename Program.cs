using BenchmarkDotNet.Running;
using Hackbart_EF_Split;

var summary = BenchmarkRunner.Run<EFQueryBenchmark>();
Console.WriteLine(summary);

