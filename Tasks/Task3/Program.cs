using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        char[] input = "GHA14SFSD6K92".ToCharArray();
        char[] output = orderByAlgorithm(input, 16);
        Console.WriteLine(new String(output)); //AF9-SHG-4K2-61D-S
    }

    public static char[] orderByAlgorithm(char[] input, int ordering)
    {
        var orderingCopy = ordering;
        StringBuilder sb = new StringBuilder();

        var inputList = input.ToList();
        var rollover = 0;
        while (inputList.Count > 0)
        {
            if (inputList.Count >= orderingCopy)
            {
                var element = inputList.ElementAt(orderingCopy - 1);
                sb.Append(element);
                var remainingInputList = inputList.Slice(orderingCopy, (inputList.Count - orderingCopy));
                inputList.Remove(element);
                var steppedOverList = inputList.Slice(0, orderingCopy - 1).ToList();
                remainingInputList.AddRange(steppedOverList);
                inputList = remainingInputList;
            }
            else
            {
                do
                {
                    rollover = orderingCopy - inputList.Count;
                    orderingCopy = rollover;
                } while (rollover > inputList.Count);

                var element = inputList.ElementAt(rollover - 1);
                sb.Append(element);
                var remainingInputList = inputList.Slice(rollover, (inputList.Count - rollover));
                inputList.Remove(element);
                var steppedOverList = inputList.Slice(0, rollover - 1).ToList();
                remainingInputList.AddRange(steppedOverList);
                inputList = remainingInputList;
                orderingCopy = ordering;
            }
        }

        for (int i = 3; i < sb.Length; i += 4)
        {
            sb.Insert(i, '-');
        }

        return sb.ToString().ToCharArray();
    }
}