using DH4.Classes;
using DH4.Enums;
using System;
namespace DH4
{
    class Game
    {
        public Character CharacterToCreate()
        {
            Character characterToCreate=new Character();
            return characterToCreate;
        }
        public void BattleSystem(Enemy enemy, Character playercharacter)
        {
            /*Todo:
            Change color for player attacks and enemy attacks
            let player know what enemy has been encountered.
            have a boolen for petrification
            set parameters for the above state
            test changes 
            */
            while(playercharacter.CurrentHealthPoints>0|| enemy.CurrentHealthPoints>0)
            {
               string initTurnChoice="";
               while(initTurnChoice=="")
               {
                    System.Console.WriteLine($"{enemy.EnemyName} has appeared! \n What would you like to do: \n 1) Attack\n2) Magic/Special\n3)Defend\n");
                    Console.ReadLine();
                    switch(initTurnChoice.ToLower())
                    {
                        //standard attack
                        case"1":
                        case"attack":
                        break;
                        //magic or special attack (class dependent)
                        case"2":
                        case"magic":
                        break;
                        case "3":
                        case"defend":
                        break;
                        default:
                        ClearAndReset(playercharacter);
                        initTurnChoice="";
                        break;

                    }
               }

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
                    System.Console.WriteLine("new game started\n");
                    EnemyNames enemyNames=new EnemyNames();
                    // create the player character and angel enemy object.
                    
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
            System.Console.WriteLine("Goodbye\n");
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
                System.Console.WriteLine("Please choose from the above options\n resetting to the most recent checkpoint");
            }
        }
    }
}