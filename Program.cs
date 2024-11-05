using DH4.Classes;
using DH4.Enums;
using System;
namespace DH4
{
    class Game
    {
        public void BattleSystem(Enemy enemy, Character playercharacter)
        {
            /*Todo:
            Change color for player attacks and enemy attacks
            let player know what enemy has been encountered.
            have a boolen for petrification
            set parameters for the above state
            test changes 
            */
            while(playercharacter.CurrentHealthPoints==0|| enemy.CurrentHealthPoints==0)
            {
                
            }
        }
        
        // game code goes here
        public static void Main(string[] args)
        {
            // title screen goes here
            string TitleScreenOption="";
            while (TitleScreenOption=="")
            {
                System.Console.WriteLine("Demon Hunters 5 New Generation\n 1) New Game \n 2) Quit\n");
                TitleScreenOption=Console.ReadLine();
                switch (TitleScreenOption.ToLower())
                {
                    // new game option
                    case "1":
                    case "new game":
                    break;
                    // quit game option
                    case "2":
                    case "quit":
                        QuitGame();
                    break;
                }
            }

        }
        public static void QuitGame()
        {
            System.Console.WriteLine("Quitting game in 3 seconds\n");
            Thread.Sleep(3000);
            System.Console.WriteLine("GoodBye");
            Environment.Exit(0);
        } 
        void PromptedClearScreen()
        {
            Console.WriteLine("Press any key to continue \n");
            Console.ReadKey();
            Console.Clear();
        }
        void ClearAndReset(Character playercharacter)
        {
            if(playercharacter.CurrentHealthPoints<=0)
            {
                System.Console.WriteLine("Resetting the battle in three seconds\n ");
                playercharacter.CurrentHealthPoints=playercharacter.PlayerHealth;
                PromptedClearScreen();

            }
            else
            {

            }
        }
    }
}