
using BenchmarkDotNet.Running;
using Benmark2.Array;
using Benmark2.If;
using Benmark2.String;
using Benmark2.Task_Thread;

var summary1 = BenchmarkRunner.Run<For_increment_vs_decrement_index>();
var summary2 = BenchmarkRunner.Run<For_var_vs_yield>();
var summary3 = BenchmarkRunner.Run<If_vs_without_if>();
var summary4 = BenchmarkRunner.Run<String_builder_vs_string_list>();
var summary5 = BenchmarkRunner.Run<Sequence_vs_parallel>();
