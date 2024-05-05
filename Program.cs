using System;
using DH4.Classes;
namespace DH4
{
    class Game
    {
        public static void Main(string[] args)
        {
            void QuitGame()
            {
                Console.WriteLine("Quitting the game in 5 seconds\n");
                Thread.Sleep(5000);
                Console.WriteLine("Goodbye!\n");
            }
            void PromptedClearScreen()
            {
                Console.WriteLine("Press any enter to continue\n");
                Console.ReadKey();
                Console.Clear();
            }
            void ResetAndClear(string errormessage,string switchinput,int threadsleepparam )
            {
                Console.WriteLine(errormessage);
                Console.WriteLine("Resetting to the previous checkpoint in "+threadsleepparam+" milliseconds.");
                Thread.Sleep(threadsleepparam);
                Console.Clear();
                switchinput="";
                
            }
           string MainMenuOption="";
           while(MainMenuOption=="")
           {
            Console.WriteLine("DH4 New Generation\n 1) New Game\n 2) Quit\n");
            MainMenuOption=Console.ReadLine();
            // menu switch
            switch(MainMenuOption)
            {
                case"1":
                case"New Game":
                case "new game":
                // start the game
                Console.WriteLine("Chapter 1 Prologue\n");
                Console.WriteLine("The year is 1015, The people of askela are celebrating the anniversary of the villages founding, when suddenly an angel appears. \n");
                Console.WriteLine("Angel: I have been summoned here by the Great spirit to wipe out his enemies.\n Starting with the dark swordsman and the mage that lives in this village.\n ");
                Console.WriteLine("The crowd of people start muttering in confusion and fear, until someone pipes up with, Who?\n");
                Console.WriteLine("Angel: If you value your life, you will help me find them. If you dont help me,  I will burn this village down!\n");
                Console.WriteLine("Town Elder: Please sir, You must understand we have no idea who you are talking about. He says very dishonestly.\n");
                Console.WriteLine("Angel: I know your lying, my superiors told me that they would be here, and that they were seen here earlier today.\n");
                PromptedClearScreen();
                Console.WriteLine("Angel: You leave me no choice.\n The angel raises his hand with a fire burning on his palm.\n Town Elder: WAIT! We will take you to them! Please don't harm the village.\n");
                Console.WriteLine("The villagers take the angel, to a house on lake askela, on the outskrits of the village.\n");
                Console.WriteLine("Angel: Dark swordsman, you, and the mage have been given up by the villagers.\n");           
                break;
                // quit game case
                case"2":
                case"Quit":
                case "quit":
                case"quit game":
                case "Quit Game":
                QuitGame();
                break;
            }

           }
           
           
            
        }
    }
}