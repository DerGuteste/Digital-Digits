namespace DigitalRotatingDigits
{
    internal class Program
    {
        static string[][] digits = new string[][]
        {
            new string[4] //0
            {
                " _ ",
                "| |",
                "| |",
                " ¯ "
            },
            new string[4] //1
            {
                "   ",
                "|  ",
                "|  ",
                "   "
            },
            new string[4] //2
            {
                " _ ",
                " _|",
                "|  ",
                " ¯ "
            },
            new string[4] //3
            {
                " _ ",
                " _|",
                "  |",
                " ¯ "
            },
            new string[4] //4
            {
                "   ",
                "|_|",
                "  |",
                "   "
            },
            new string[4] //5
            {
                " _ ",
                "|_ ",
                "  |",
                " ¯ "
            },
           new string[4] //6
            {
                " _ ",
                "|_ ",
                "| |",
                " ¯ "
            },
            new string[4] //7
            {
                " _ ",
                "  |",
                "  |",
                "   "
            },
            new string[4] //8
            {
                " _ ",
                "|_|",
                "| |",
                " ¯ "
            },
            new string[4] //9
            {
                " _ ",
                "|_|",
                "  |",
                "   "
            },
            new string[7] //stick man
            {
                "  _  ",
                " | | ",
                "  ¯ |",
                "¯¯|¯ ",
                "  |  ",
                " | | ",
                " | | "
            },
        };


        static void Main(string[] args)
        {
            int height = 4;
            int width = 16;

            #region get input

            string input;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter input:");

                input = Console.ReadLine();

                if(input.Length > 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: More than 4 digits entered.");
                    continue;
                }

                try
                {
                    Convert.ToInt32(input);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Characters entered.");
                    continue;
                }

                break;
            }

            while (input.Length < 4)
            {
                input = input.Insert(0, "0");
            }

            #endregion

            Console.Clear();

            // no need to allocate every itteration
            ConsoleKeyInfo keyinfo;
            int index;
            int stX = Console.CursorLeft;
            int stY = Console.CursorTop;

            while (true)
            {
                #region print

                for (int i = 0; i < 4; i++)
                {
                    printDigit(digits[input[i] - '0']);
                }

                #endregion

                #region rotate

                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.X) { 
                    for(int i = 0; i < 4; i++)
                    {
                        index = input[i] - '0';
                        digits[index] = dRotX(digits[index]);
                    }

                    if(stY == height)
                    {
                        stY = 0;
                    }
                    else
                    {
                        stY = height;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Y)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        index = input[i] - '0';
                        digits[index] = dRotY(digits[index]);
                    }

                    input = sRotY(input);

                    if(stX == width)
                    {
                        stX = 0;
                    }
                    else
                    {
                        stX = width;
                    }
                }

                #endregion


                Console.Clear();
                Console.CursorLeft = stX;
                Console.CursorTop = stY;
            }

            #region stick man

            height = 7;
            width = 5;

            while (true)
            {
                printDigit(digits[10]);

                #region rotate

                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.X)
                {
                    digits[10] = dRotX(digits[10]);

                    if (stY == height)
                    {
                        stY = 0;
                    }
                    else
                    {
                        stY = height;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Y)
                {
                    digits[10] = dRotY(digits[10]);

                    if (stX == width)
                    {
                        stX = 0;
                    }
                    else
                    {
                        stX = width;
                    }
                }

                #endregion

                Console.Clear();
                Console.CursorLeft = stX;
                Console.CursorTop = stY;
            }

            #endregion

        }

        /// <summary>
        /// rotates a string[] 180° around the X-Axis
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string[] dRotX(string[] digit)
        {
            string[] output = new string[digit.Length];

            for(int i = 0; i < digit.Length; i++)
            {
                output[i] = digit[digit.Length - i - 1];

                for(int j = 0; j < output[i].Length; j++)
                {
                    if (output[i][j] == '_')
                    {
                        output[i] = output[i].Remove(j, 1).Insert(j, "¯");
                    }
                    else if (output[i][j] == '¯')
                    {
                        output[i] = output[i].Remove(j, 1).Insert(j, "_");
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// rotates a string[] 180° around the Y-Axis
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string[] dRotY(string[] digit)
        {
            string[] output = new string[digit.Length];

            for(int i = 0; i < digit.Length; i++)
            {
                output[i] = sRotY(digit[i]);
            }

            return output;
        }

        /// <summary>
        /// mirrors a string (rotates it 180° around the Y-Axis)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string sRotY(string str)
        {
            char[] output = new char[str.Length];
            
            for(int i = 0; i < str.Length; i++)
            {
                output[i] = str[str.Length - i - 1]; 
            }

            return new string(output);
        }

        /// <summary>
        /// print a string[] 
        /// </summary>
        /// <param name="digit"></param>
        static void printDigit(string[] digit)
        {
            int posX = Console.CursorLeft;
            int posY = Console.CursorTop;

            int x = digit.Length;
            int y = digit[0].Length;

            for(int i = 0; i < x; i++)
            {
                Console.CursorTop = posY + i;
                Console.CursorLeft = posX;
                
                Console.Write(digit[i]);
            }

            Console.CursorTop = posY;
            Console.CursorLeft++;
        }

    }
}