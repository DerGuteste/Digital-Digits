namespace DigitalRotatingDigits
{
    internal class Program
    {
        /// <summary>
        /// 1: | 2: _ 3: ‾
        /// </summary>
        static short[][,] digits = new short[][,]
        {
            new short[4, 3] //0
            {
                {0, 2, 0},
                {1, 0, 1},
                {1, 0, 1},
                {0, 3, 0}
            },
            new short[4, 3] //1
            {
                {0, 0, 0},
                {0, 0, 1},
                {0, 0, 1},
                {0, 0, 0}
            },
            new short[4, 3] //2
            {
                {0, 2, 0},
                {0, 2, 1},
                {1, 0, 0},
                {0, 3, 0}
            },
            new short[4, 3] //3
            {
                {0, 2, 0},
                {0, 2, 1},
                {0, 0, 1},
                {0, 3, 0}
            },
            new short[4, 3] //4
            {
                {0, 0, 0},
                {1, 2, 1},
                {0, 0, 1},
                {0, 0, 0}
            },
            new short[4, 3] //5
            {
                {0, 2, 0},
                {1, 2, 0},
                {0, 0, 1},
                {0, 3, 0}
            },
            new short[4, 3] //6
            {
                {0, 2, 0},
                {1, 2, 0},
                {1, 0, 1},
                {0, 3, 0}
            },
            new short[4, 3] //7
            {
                {0, 2, 0},
                {0, 0, 1},
                {0, 0, 1},
                {0, 0, 0}
            },
            new short[4, 3] //8
            {
                {0, 2, 0},
                {1, 2, 1},
                {1, 0, 1},
                {0, 3, 0}
            },
            new short[4, 3] //9
            {
                {0, 2, 0},
                {1, 2, 1},
                {0, 0, 1},
                {0, 0, 0}
            },
            new short[,] // stick man
            {
                {0, 0, 2, 0, 0 },
                {0, 1, 0, 1, 0 },
                {0, 0, 3, 0, 1 },
                {3, 3, 1, 3, 0 },
                {0, 0, 1, 0, 0 },
                {0, 1, 0, 1, 0 },
                {0, 1, 0, 1, 0 },
            }
        };

        static void Main(string[] args)
        {
            #region get input

            string input;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

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

            // no need to allocate every itteration
            ConsoleKeyInfo keyinfo;
            int index;

            while (true)
            {
                #region print

                for (int i = 0; i < 4; i++)
                {
                    printDigit(digits[input[i] - '0']);
                }

                #endregion

                Console.CursorLeft = 0;

                #region rotate

                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.X) { 
                    for(int i = 0; i < 4; i++)
                    {
                        index = input[i] - '0';
                        digits[index] = dRotX(digits[index]);
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
                }

                #endregion

                Console.CursorLeft = 0;
            }

            #region stick man

            //while (true)
            //{
            //    printDigit(digits[10]);

            //    Console.CursorLeft = 0;

                  #region rotate

            //    keyinfo = Console.ReadKey();

            //    if (keyinfo.Key == ConsoleKey.X)
            //    {
            //        digits[10] = dRotX(digits[10]);
            //    }
            //    else if (keyinfo.Key == ConsoleKey.Y)
            //    {
            //        digits[10] = dRotY(digits[10]);

            //    }

                  #endregion

            //    Console.CursorLeft = 0;
            //}

            #endregion

        }

        /// <summary>
        /// rotate the digit on the Y-Axis
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        static short[,] dRotY(short[,] digit)
        {
            int x = digit.GetLength(0);
            int y = digit.GetLength(1);

            short[,] output = new short[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j ++)
                {
                    output[i, j] = digit[i, y - j - 1];
                }
            }

            return output;
        }

        /// <summary>
        /// rotate the digit on the X-Axis
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        static short[,] dRotX(short[,] digit)
        {
            int x = digit.GetLength(0);
            int y = digit.GetLength(1);

            short[,] output = new short[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    output[i, j] = digit[x - i - 1, j];
                    if (output[i, j] == 2)
                    {
                        output[i, j] = 3;
                    }
                    else if(output[i, j] == 3)
                    {
                        output[i, j] = 2;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// mirrors a string
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
        /// print a digit in "digital clock style"
        /// </summary>
        /// <param name="digit"></param>
        static void printDigit(short[,] digit)
        {
            int posX = Console.CursorLeft;
            int posY = Console.CursorTop;

            int x = digit.GetLength(0);
            int y = digit.GetLength(1);

            for(int i = 0; i < x; i++)
            {
                Console.CursorTop = posY + i;
                Console.CursorLeft = posX;

                for (int j = 0; j < y; j++)
                {
                    switch (digit[i, j])
                    {
                        case 0:
                            Console.Write(' ');
                            break;
                        case 1:
                            Console.Write('|');
                            break;
                        case 2:
                            Console.Write('_');
                            break;
                        case 3:
                            Console.Write('\u0305');
                            break;
                    }
                }
            }

            Console.CursorTop = posY;
            Console.CursorLeft++;
        }

    }
}