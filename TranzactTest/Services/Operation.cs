using System.Collections.Generic;

namespace TranzactTest.Services
{
    public class Operation : IOperation
    {
        private int[] numbersOut;

        public int GetCurrentMaxArea(int[] numbers)
        {
            numbersOut = numbers;
            int currentMaxArea = 0;
            int currentMaxAreaByIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                currentMaxAreaByIndex = GetCurentMaxAreaByIndex(i);
                if (currentMaxArea < currentMaxAreaByIndex)
                    currentMaxArea = currentMaxAreaByIndex;
            }

            return currentMaxArea;
        }

        private int[] GetIndexBiggerThanMe(int currentIndex)
        {
            List<int> indexBiggerThanMe = new List<int>();
            int currentNumber = numbersOut[currentIndex];
            for (int i = 0; i < numbersOut.Length; i++)
            {
                if (currentIndex != i && numbersOut[i] >= currentNumber)
                    indexBiggerThanMe.Add(i);
            }

            return indexBiggerThanMe.ToArray();
        }

        private int GetCurentMaxAreaByIndex(int currentIndex)
        {
            int currentMaxArea = 0;
            int[] indexesBiggerThanMe = GetIndexBiggerThanMe(currentIndex);
            foreach (var item in indexesBiggerThanMe)
            {
                int currentArea = 0;
                currentArea = GetCurrentAreaByIndex(currentIndex, item);
                if (currentArea > currentMaxArea)
                    currentMaxArea = currentArea;
            }

            return currentMaxArea;
        }

        private int GetCurrentAreaByIndex(int currentIndex, int comparativeIndex)
        {
            int currentArea = 0;
            int currentNumber = numbersOut[currentIndex];
            if (currentIndex < comparativeIndex)
                currentArea = currentNumber * comparativeIndex;
            else
                currentArea = currentNumber * (currentIndex - comparativeIndex);

            return currentArea;
        }
    }
}
