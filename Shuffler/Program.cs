using Shuffler;
// Because static classes have been used for much of the program object instantiation only occurs within Testing class. 

// Encoding changed to allow for card symbols.
Console.OutputEncoding = System.Text.Encoding.UTF8;
Pack.OutputPack();
// New line for readability, creates space between output.
Console.WriteLine();
// Change this value to increase or decrease number of dealt cards.
// Change position of this method call to after test shuffle for dealt cards to be shuffled, current position tests
// that shuffle can handle packs which are not full.
Testing.TestDeal(5);
// New line for readability, creates space between output.
Console.WriteLine();
Pack.OutputPack();
// New line for readability, creates space between output.
Console.WriteLine();
Testing.TestShuffle();
Pack.OutputPack();


