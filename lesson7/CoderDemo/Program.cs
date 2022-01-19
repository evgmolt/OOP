using CoderDemo;

ICoder coderA = new ACoder();
string testString = "ABCD";
testString = coderA.Encode(testString);
Console.WriteLine(testString);
testString = coderA.Decode(testString);
Console.WriteLine(testString);

ICoder coderB = new BCoder();
testString = "ABCD";
testString = coderB.Encode(testString);
Console.WriteLine(testString);

testString = "аб%вг";
testString = coderB.Encode(testString);
Console.WriteLine(testString);
testString = coderB.Decode(testString);
Console.WriteLine(testString);


