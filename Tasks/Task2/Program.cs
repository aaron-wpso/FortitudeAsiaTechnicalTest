internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"The special digit for the number {20191001187} is {GenerateSpecialDigit(20191001187)}");
        Console.WriteLine($"The special digit for the number {9729923302749217} is {GenerateSpecialDigit(9729923302749217)}");
        DetermineWhetherSpecialDigitIsEvenlyDistributed(201, 999);
    }

    public static long GenerateSpecialDigit(long referenceNumber)
    {
        var referenceNumberDigitList = SeparateDigitsOfAnIntegerToAList(referenceNumber);
        var referenceNumberDictionary = new Dictionary<string, List<long>>();
        for (int i = 1; i <= referenceNumberDigitList.Count; i++)
        {
            long transformedNumber = 0;
            switch (i % 5)
            {
                case 1:
                    transformedNumber = referenceNumberDigitList[i - 1] * 10;
                    if (referenceNumberDictionary.ContainsKey("A"))
                        referenceNumberDictionary["A"].Add(transformedNumber);
                    else
                        referenceNumberDictionary.Add("A", new List<long>() { transformedNumber });
                    break;
                case 2:
                    transformedNumber = referenceNumberDigitList[i - 1] * 8;
                    if (referenceNumberDictionary.ContainsKey("B"))
                        referenceNumberDictionary["B"].Add(transformedNumber);
                    else
                        referenceNumberDictionary.Add("B", new List<long>() { transformedNumber });
                    break;
                case 3:
                    transformedNumber = referenceNumberDigitList[i - 1] * 6;
                    if (referenceNumberDictionary.ContainsKey("C"))
                        referenceNumberDictionary["C"].Add(transformedNumber);
                    else
                        referenceNumberDictionary.Add("C", new List<long>() { transformedNumber });
                    break;
                case 4:
                    transformedNumber = referenceNumberDigitList[i - 1] * 4;
                    if (referenceNumberDictionary.ContainsKey("D"))
                        referenceNumberDictionary["D"].Add(transformedNumber);
                    else
                        referenceNumberDictionary.Add("D", new List<long>() { transformedNumber });
                    break;
                case 0:
                    transformedNumber = referenceNumberDigitList[i - 1] * 2;
                    if (referenceNumberDictionary.ContainsKey("E"))
                        referenceNumberDictionary["E"].Add(transformedNumber);
                    else
                        referenceNumberDictionary.Add("E", new List<long>() { transformedNumber });
                    break;
                default:
                    break;
            }
        }

        long sum = 0;

        foreach (var item in referenceNumberDictionary)
        {
            sum += item.Value.Sum();
        }

        var sumDigitList = SeparateDigitsOfAnIntegerToAList(sum);
        var specialDigit = sumDigitList.Sum();

        return specialDigit;
    }

    public static List<long> SeparateDigitsOfAnIntegerToAList(long num)
    {
        List<long> digits = new List<long>();
        while (num > 0)
        {
            long digit = num % 10;
            digits.Insert(0, digit);  // Insert to preserve order
            num = num / 10;
        }

        return digits;
    }

    public static void DetermineWhetherSpecialDigitIsEvenlyDistributed(long startingNumber, long endingNumber)
    {
        var specialNumberDictionary = new Dictionary<long, long>();
        for (long i = startingNumber; i <= endingNumber; i++)
        {
            var specialDigit = GenerateSpecialDigit(i);
            if (specialNumberDictionary.ContainsKey(specialDigit))
                specialNumberDictionary[specialDigit]++;
            else specialNumberDictionary[specialDigit] = 1;
        }
        var sortedDict = specialNumberDictionary.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (KeyValuePair<long, long> pair in sortedDict)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }

        var highestSpecialDigitOccurance = sortedDict.MaxBy(pair => pair.Value).Key;
        var lowestSpecialDigitOccurance = sortedDict.MinBy(pair => pair.Value).Key;

        Console.WriteLine($"Highest special digit occurrences between {startingNumber} and {endingNumber}: {highestSpecialDigitOccurance} with occurrences of {sortedDict[highestSpecialDigitOccurance]} times");
        Console.WriteLine($"Lowest special digit occurrences between {startingNumber} and {endingNumber}: {lowestSpecialDigitOccurance} with occurrences of {sortedDict[lowestSpecialDigitOccurance]} times");
    }
}