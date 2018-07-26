using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamHW.Modul
{
   public class Services
    {
        private static bool IsFib(List<int> numbers)
        {
            bool res = false; 
            for (int i = 0; i < numbers.Count - 2; i++)
            {
                if (numbers[i] + numbers[i + 1] == numbers[i + 2])
                    res = true;
                else
                    return false;
            }
            return res;
        }

       private static List<int> MakeFib(List<int> numbers)
        {
            int size = numbers.Count;
            for (int i = size - 1; i < (size * 4) - 1; i++)
            {
                numbers.Add(numbers[i - 1] + numbers[i]);
            }
            return numbers;
        }
        public static void Task1()
        {
            string path = @"";

            string[] words;
            List<int> numbers = new List<int>();

            using (StreamReader stream = new StreamReader(path + "FIB1.txt"))
            {
                string text = stream.ReadLine();

                words = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            bool isInt = false;
            foreach (string item in words)
            {
                int number;
                isInt = int.TryParse(item, out number);

                if (isInt)
                    numbers.Add(number);
            }

            if (IsFib(numbers))
            {
                numbers = MakeFib(numbers);

                foreach (int item in numbers)
                {
                    Console.Write(item + "  ");
                }


                using (FileStream stream = new FileStream(path + "FIB2.txt", FileMode.Create))
                {
                    string data = String.Join<int>(" ", numbers);

                    byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);

                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            else
            {
                Console.WriteLine("Последовательность не является рядом Фибоначчи");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void Task2()
        {
            string path = @"";

            string[] words;
            List<int> numbers = new List<int>();

            using (StreamReader stream = new StreamReader(path + "input.txt"))
            {
                string text = stream.ReadLine();

                words = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            bool isInt = false;
            foreach (string item in words)
            {
                int number;
                isInt = int.TryParse(item, out number);

                if (isInt)
                    numbers.Add(number);
            }

            int result = numbers[0] + numbers[1];

            Console.WriteLine(numbers[0] + " + " + numbers[1] + " = " + result);

            using (FileStream stream = new FileStream(path + "output.txt", FileMode.Create))
            {
                string data = result.ToString();

                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);

                stream.Write(bytes, 0, bytes.Length);
            }
            Console.WriteLine();
        }

    }
}
