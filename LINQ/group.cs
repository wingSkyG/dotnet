string[] words = ["blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese"];
var wordGroups =
    from w in words
    group w by w[0];
foreach (var wordGroup in wordGroups)
{
    Console.WriteLine("{0}", wordGroup.Key);
    foreach (var word in wordGroup)
    {
        Console.WriteLine(word);
    }
}