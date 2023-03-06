using Shuffler;

// Encoding changed to allow for card symbols
Console.OutputEncoding = System.Text.Encoding.UTF8;
Pack.OutputPack();
// New line for readability
Console.WriteLine();
Testing.TestDeal();
// New line for readability
Console.WriteLine();
Pack.OutputPack();
// New line for readability
Console.WriteLine();
Testing.TestShuffle();
Pack.OutputPack();
