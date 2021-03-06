using System;
/*Author: Sarthak Patel
 *Date: April 21st,2021
 *Description: Roullete Game
 *Player all bet stored in array
 *user all activivty stored in structure of array
 */

namespace roulette_final
{
    public struct playerSelection
    {
        public int amount;
        public int winAmount;
        public int number;
        public bool firstRaw;
        public bool secondRaw;
        public bool thirdRaw;
        public bool firstTwelve;
        public bool secondTwelve;
        public bool thirdTwelve;
        public bool oneToEighteen;
        public bool Even;
        public bool Red;
        public bool Black;
        public bool Odd;
        public bool ninteenToThirtysix;
        public bool zeroDoublezero;

    }
    class Program
    {
        private static Random randValue = new Random();

        static void gameMode()
        {
            Console.ForegroundColor = ConsoleColor.Green; // list of the all table at when player can place bet
            Console.WriteLine("pelase select number from the following for the bet!");
            Console.WriteLine("A : 2 to 1(upperraw)");
            Console.WriteLine("B : 2 to 1(middleraw)");
            Console.WriteLine("c : 2 to 1(loweraw)");
            Console.WriteLine("D : 1st twelve");
            Console.WriteLine("E : 2nd twelve");
            Console.WriteLine("F : 3rd twelve");
            Console.WriteLine("G : 1 to 18");
            Console.WriteLine("H : even");
            Console.WriteLine("I : red");
            Console.WriteLine("J : black");
            Console.WriteLine("K : odd");
            Console.WriteLine("L : 19 to 36");
            Console.WriteLine("M : 0 and 00");
        }
        static void rouletteTable()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n                                        Roullet Table                                              ");
            Console.WriteLine("{0,10}", "       ------------------------------------------------------------------------------");
            Console.WriteLine("{0,10}", "       |      |    |    |    |    |    |    |     |    |    |    |    |    |        |");
            Console.WriteLine("{0,10}", "       |      | 3  | 6  | 9  | 12 | 15 | 18 | 21  | 24 | 27 | 30 | 33 | 36 | 2 to 1 |");
            Console.WriteLine("{0,10}", "       |  00  |    |    |    |    |    |    |     |    |    |    |    |    |        |");
            Console.WriteLine("{0,10}", "       |      -----------------------------------------------------------------------");
            Console.WriteLine("{0,10}", "       |      |    |    |    |    |    |    |     |    |    |    |    |    |        |");
            Console.WriteLine("{0,10}", "       -------| 2  | 5  | 8  | 11 | 14 | 17 | 20  | 23 | 26 | 29 | 32 | 35 | 2 to 1 |");
            Console.WriteLine("{0,10}", "       |      |    |    |    |    |    |    |     |    |    |    |    |    |        |");
            Console.WriteLine("{0,10}", "       |      -----------------------------------------------------------------------");
            Console.WriteLine("{0,10}", "       |   0  |    |    |    |    |    |    |     |    |    |    |    |    |        |");
            Console.WriteLine("{0,10}", "       |      | 1  | 4  | 7  | 10 | 13 | 16 | 19  | 22 | 25 | 28 | 31 | 34 | 2 to 1 |");
            Console.WriteLine("{0,10}", "       |      |    |    |    |    |    |    |     |    |    |    |    |    |        |");
            Console.WriteLine("{0,10}", "       ------------------------------------------------------------------------------");
            Console.WriteLine("{0,10}", "              |                   |                    |                     |");
            Console.WriteLine("{0,10}", "              |      1st 12       |       2nd 12       |       3rd 12        |");
            Console.WriteLine("{0,10}", "              |                   |                    |                     |");
            Console.WriteLine("{0,10}", "              ----------------------------------------------------------------");
            Console.WriteLine("{0,10}", "              |         |         |         |           |         |          |");
            Console.WriteLine("{0,10}", "              | 1 to 18 |  even   |  <red>  |  <black>  |  odd    | 19 to 36 |");
            Console.WriteLine("{0,10}", "              |         |         |         |           |         |          |");
            Console.WriteLine("{0,10}", "              ----------------------------------------------------------------");
        }
        static string askBetPlace()
        {
            string betNumber;

            bool incorrect = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n=>please select on which part you want to make a bet?"); // ask player to choose any box from roulette table
                Console.ForegroundColor = ConsoleColor.White;
                betNumber = Console.ReadLine();
                try
                {
                    int Number = int.Parse(betNumber);
                    if (Number >= 1 && Number <= 36)
                    {
                        incorrect = false;
                    }
                }
                catch
                {
                    if (betNumber == "A" || betNumber == "B" || betNumber == "C" || betNumber == "D" || betNumber == "E" || betNumber == "F" || betNumber == "G" ||
                        betNumber == "H" || betNumber == "I" || betNumber == "J" || betNumber == "K" || betNumber == "L" || betNumber == "M" || betNumber == "quit")
                    {
                        incorrect = false;
                    }
                    else
                    {
                        Console.WriteLine("=>\nYou typed invalid input !!");
                        incorrect = true;
                    }
                }
            } while (incorrect == true);
            return betNumber;
        }

        static int askBetAmount(string betNumber, int remainingBalance)
        {
            int betAmount;
            bool incorrect = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n=>how many $ you want to put on selected place?"); //ask plaer to put chips on choosen box of roulette table
                Console.ForegroundColor = ConsoleColor.White;
                betAmount = int.Parse(Console.ReadLine());
                if (betAmount != 0 && betAmount <= remainingBalance)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n=>You put " + betAmount + " on " + betNumber); // player put this money on this place
                    Console.ForegroundColor = ConsoleColor.White;
                    incorrect = false;
                }
                else if (betAmount > remainingBalance)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n=>sorry! you dont have enough money, your remaining balance is: $" + remainingBalance); //if player wants to more than 500$
                    Console.ForegroundColor = ConsoleColor.White;
                    incorrect = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n=>You type invalid input"); // if player input invalid
                    Console.ForegroundColor = ConsoleColor.White;
                    incorrect = true;
                }
            } while (incorrect == true);
            return betAmount;
        }
        static int RandomRoullete()
        {
            int randomNumberRoullete = randValue.Next(1, 39);
            return randomNumberRoullete;
        }
        static int entryExists(playerSelection[] selectionofBet, int arraySize, int randomNumberRoullete)
        {
            int totalWin = 0;
            for (int i = 0; i < arraySize; i++)
            {
                if (selectionofBet[i].firstRaw == true)
                {
                    if (checkFirstRawNumbers(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 3;
                    }
                }
                if (selectionofBet[i].secondRaw == true)
                {
                    if (checkSecondRawNumbers(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 3;
                    }
                }
                if (selectionofBet[i].thirdRaw == true)
                {
                    if (checkThirdRawNumbers(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 3;
                    }
                }
                if (selectionofBet[i].Even == true)
                {
                    if (checkEvenNumbers(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 5;
                    }
                }
                if (selectionofBet[i].firstTwelve == true)
                {
                    if (checkFirstTwelve(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 5;
                    }
                }
                if (selectionofBet[i].secondTwelve == true)
                {
                    if (checkSecondTwelve(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 5;
                    }
                }
                if (selectionofBet[i].thirdTwelve == true)
                {
                    if (checkThirdTwelve(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 5;
                    }
                }
                if (selectionofBet[i].oneToEighteen == true)
                {
                    if (checkOneToEighteen(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 15;
                    }
                }
                if (selectionofBet[i].Red == true)
                {
                    if (checkRedNumbers(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 5;
                    }
                }
                if (selectionofBet[i].Black == true)
                {
                    if (checkBlueNumbers(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 5;
                    }
                }
                if (selectionofBet[i].Odd == true)
                {
                    if (checkOddNumbers(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 5;
                    }
                }
                if (selectionofBet[i].ninteenToThirtysix == true)
                {
                    if (checkNineteenToThirtysix(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 15;
                    }
                }
                if (selectionofBet[i].zeroDoublezero == true)
                {
                    if (checkZeroDoublezero(randomNumberRoullete))
                    {
                        selectionofBet[i].winAmount = selectionofBet[i].amount * 10;
                    }
                }
                totalWin += selectionofBet[i].winAmount;
            }
            return totalWin;
        }
        static bool checkFirstRawNumbers(int randomNumberRoullete)
        {
            int[] firstRaw = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 }; //function for check random number is in first raw numbers
            for (int i = 0; i < firstRaw.Length; i++)
            {
                if (firstRaw[i] == randomNumberRoullete)
                {
                    return true;
                }
            }
            return false;
        }
        static bool checkSecondRawNumbers(int randomNumberRoullete)
        {
            int[] secondRaw = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 }; //function for check random number is in second raw numbers
            for (int i = 0; i < secondRaw.Length; i++)
            {
                if (secondRaw[i] == randomNumberRoullete)
                {
                    return true;
                }
            }
            return false;
        }
        static bool checkThirdRawNumbers(int randomNumberRoullete)
        {
            int[] thirdRaw = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 }; //function for check random number is in third raw numbers
            for (int i = 0; i < thirdRaw.Length; i++)
            {
                if (thirdRaw[i] == randomNumberRoullete)
                {
                    return true;
                }
            }
            return false;
        }
        static bool checkEvenNumbers(int randomNumberRoullete) // function for check random number is in the even numbers
        {
            if (0 == randomNumberRoullete % 2)
            {
                return true;
            }
            return false;
        }
        static bool checkFirstTwelve(int randomNumberRoullete)// function for check random number is in the firstTwelve
        {
            if (randomNumberRoullete <= 12)
            {
                return true;
            }
            return false;
        }
        static bool checkSecondTwelve(int randomNumberRoullete) // function for check random number is in the secondTwelve
        {
            if (randomNumberRoullete >= 12 && randomNumberRoullete <= 24)
            {
                return true;
            }
            return false;
        }
        static bool checkThirdTwelve(int randomNumberRoullete) // function for check random number is in the thirdTwelve
        {
            if (randomNumberRoullete >= 24 && randomNumberRoullete <= 36)
            {
                return true;
            }
            return false;
        }
        static bool checkOneToEighteen(int randomNumberRoullete) // function for check random number is in one to eighteen numbers
        {
            if (randomNumberRoullete >= 1 && randomNumberRoullete <= 18)
            {
                return true;
            }
            return false;
        }
        static bool checkRedNumbers(int randomNumberRoullete) //function for check random is match to the red numbers
        {
            int[] Red = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 }; 
            for (int i = 0; i < Red.Length; i++)
            {
                if (Red[i] == randomNumberRoullete)
                {
                    return true;
                }
            }
            return false;
        }
        static bool checkBlueNumbers(int randomNumberRoullete) //function for check random is match to the blue numbers
        {
            int[] Black = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 }; 
            for (int i = 0; i < Black.Length; i++)
            {
                if (Black[i] == randomNumberRoullete)
                {
                    return true;
                }
            }
            return false;
        }
        static bool checkOddNumbers(int randomNumberRoullete) //function to check random numbner is match to the odd numbers
        {
            if (0 != randomNumberRoullete % 2)
            {
                return true;
            }
            return false;
        }
        static bool checkNineteenToThirtysix(int randomNumberRoullete)// function to check random number is in nineteen to thirtysix number 
        {
            if (randomNumberRoullete >= 19 && randomNumberRoullete <= 36)
            {
                return true;
            }
            return false;
        }
        static bool checkZeroDoublezero(int randomNumberRoullete) // function for if random number is 37 or 38 to check for 0 and 00
        {
            if (randomNumberRoullete == 37 || randomNumberRoullete == 38)
            {
                return true;
            }
            return false;
        }

        static int CheckTotalBetMoney(playerSelection[] array, int sizeOfArray) //function for player how much money place for bet
        {
            int totalLoss = 0;
            for (int i = 0; i < sizeOfArray; i++)
            {
                totalLoss += array[i].amount;
            }
            return totalLoss;

        }
        static void Main(string[] args)
        {

            playerSelection[] selectionofBet = new playerSelection[10];
            string playerBet;
            int balance = 500;

            bool quit = false;
            do
            {
                rouletteTable();
                gameMode();
                Console.ForegroundColor = ConsoleColor.Yellow;
                int betNumberIndex = 0;
                bool moreBets = true;
                do
                {

                    string PlayerAns;
                    playerBet = askBetPlace();


                    switch (playerBet)
                    {
                        case "A":
                            selectionofBet[betNumberIndex].firstRaw = true; 
                            Console.WriteLine("You put your bet on : 2 to 1(upperraw)");
                            break;
                        case "B":
                            selectionofBet[betNumberIndex].secondRaw = true;
                            Console.WriteLine("You put your bet on : 2 to 1(middleraw)");
                            break;
                        case "C":
                            selectionofBet[betNumberIndex].thirdRaw = true;
                            Console.WriteLine("You put your bet on : 2 to 1(loweraw)");
                            break;
                        case "D":
                            selectionofBet[betNumberIndex].firstTwelve = true;
                            Console.WriteLine("You put your bet on : 1st twelve");
                            break;
                        case "E":
                            selectionofBet[betNumberIndex].secondTwelve = true;
                            Console.WriteLine("You put your bet on : 2nd twelve");
                            break;
                        case "F":
                            selectionofBet[betNumberIndex].thirdTwelve = true;
                            Console.WriteLine("You put your bet on : 3rd twelve");
                            break;
                        case "G":
                            selectionofBet[betNumberIndex].oneToEighteen = true;
                            Console.WriteLine("You put your bet on : 1 to 18");
                            break;
                        case "H":
                            selectionofBet[betNumberIndex].Even = true;
                            Console.WriteLine("You put your bet on : even");
                            break;
                        case "I":
                            selectionofBet[betNumberIndex].Red = true;
                            Console.WriteLine("You put your bet on : red");
                            break;
                        case "J":
                            selectionofBet[betNumberIndex].Black = true;
                            Console.WriteLine("You put your bet on : balck");
                            break;
                        case "K":
                            selectionofBet[betNumberIndex].Odd = true;
                            Console.WriteLine("You put your bet on : odd");
                            break;
                        case "L":
                            selectionofBet[betNumberIndex].ninteenToThirtysix = true;
                            Console.WriteLine("You put your bet on : 19 to 36");
                            break;
                        case "M":
                            selectionofBet[betNumberIndex].zeroDoublezero = true;
                            Console.WriteLine("You put your bet on : 0 or 00");
                            break;
                        case "quit":
                            moreBets = false;
                            quit = true;
                            break;
                        default:
                            selectionofBet[betNumberIndex].number = int.Parse(playerBet);
                            break;
                    }
                    if (quit == true)
                    {
                        break;
                    }
                    if ((moreBets != false) && (balance >= 0))
                    {
                        selectionofBet[betNumberIndex].amount = askBetAmount(playerBet, balance);
                        balance = balance - selectionofBet[betNumberIndex].amount;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n=>Your remaining balance is :" + balance + " !!! \n"); //remaining balance from 500
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    betNumberIndex++;

                    bool incorrect = false;
                    do
                    {
                        if (moreBets == false)
                        {
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n=>You want to place any other bat!(yes/no)"); //ask a question for another bet
                        Console.ForegroundColor = ConsoleColor.White;
                        PlayerAns = Console.ReadLine();

                        if (PlayerAns == "yes")
                        {
                            moreBets = true;
                            incorrect = false;
                        }
                        else if (PlayerAns == "no")
                        {
                            moreBets = false;
                            incorrect = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n=>You have to select yes/no!"); // if person input is wrong
                            Console.ForegroundColor = ConsoleColor.White;
                            moreBets = true;
                            incorrect = true;
                        }
                    } while (incorrect == true);

                } while (moreBets == true);

                if (quit != true)
                {
                    int randNum = RandomRoullete();
                    string printRandNum = randNum.ToString();

                    if (randNum == 37)
                    {
                        printRandNum = "00"; // if random number is 37 then it will be count 00
                    }
                    else if (randNum == 38)
                    {
                        printRandNum = "0"; // if random number is 38 then it will be count 00
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\n*********** Number is :" + printRandNum + " *******\n\n"); //print random number from the random function
                    Console.ForegroundColor = ConsoleColor.White;
                    int winAmount = entryExists(selectionofBet, betNumberIndex, randNum);
                    if (winAmount != 0)
                    {
                        balance += winAmount; // person winning ammount add in balance
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n=>You Won " + winAmount + " !!!\n"); //if player won bet
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        int totalLoss = CheckTotalBetMoney(selectionofBet, betNumberIndex);
                        balance -= totalLoss;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n=>You Loose " + totalLoss + " !!! \n"); // if player lost bet
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n=>Your total balance is :" + balance + " !!! \n"); // player total winning/lost amount
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Threading.Thread.Sleep(3000);
                }


            } while ((quit == false) && (balance >= 0)); // if person wants to quit
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nGAME OVER\n");


        }
    }
}
