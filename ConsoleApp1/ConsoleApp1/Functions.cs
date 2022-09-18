using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Functions
    {
        public static (int, bool) ParseArgs(string[] args)

        { 

            Console.WriteLine("桁数を入力してください");
            string userInput = Console.ReadLine() ?? "";
            int suuti = Int32.Parse(userInput);

            //桁数の特定
            if (args.Length < 1) return (suuti, true);

            int digits;
            if (!int.TryParse(args[0], out digits))
            {
                digits = 10;
            }

            //第二引数が存在して、"0"だったら記号は使わない
            if (args.Length < 2) return (digits, true);
            bool useMark = args[1] != "0";

            return (digits, useMark);
        }

        public static char GetRandomLetter
            (char[] big, char[] little, char[] number, char[] mark,
            System.Random rand, bool useMark)
        {
            char[] target;
            //まずはどの配列から文字を選ぶかサイコロをふる
            int randMax;
            if (useMark)
                randMax = 4;
            else
                randMax = 3;

            switch (rand.Next(randMax))
            {
                case 3:
                    target = mark;
                    break;
                case 0:
                    target = big;
                    break;
                case 1:
                    target = little;
                    break;
                case 2:
                default:
                    target = number;
                    break;
            }

            //次にtargetの中からランダムな文字を選ぶ
            return target[rand.Next(target.Length)];
        }
    }
}