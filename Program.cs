using DH4.Classes;
using DH4.Enums;
using System;
using System.Security.Cryptography.X509Certificates;
namespace DH4
{
    class Game
    {
        
        public Character CharacterToCreate(PlayerClassTypes playerClass)
        {
            Character characterToCreate=new Character();
            //prompt for player name before function
            characterToCreate.PlayerLevel=1;
            characterToCreate.PlayerClass=playerClass;
            // sets stats based on class
            switch(characterToCreate.PlayerClass)
            {
                case PlayerClassTypes.KNIGHT:
                    characterToCreate.AttackPoints=30;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=20;
                    characterToCreate.PlayerMaxManaPoints=20;
                    characterToCreate.PlayerManaPoints=characterToCreate.PlayerMaxManaPoints;
                break;
                case PlayerClassTypes.DARKMAGE:
                    characterToCreate.AttackPoints=10;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=60;
                    characterToCreate.PlayerManaDefensePoints=40;
                    characterToCreate.PlayerManaPoints=600;
                    characterToCreate.PlayerMaxManaPoints=characterToCreate.PlayerManaPoints; 
                break;
                case PlayerClassTypes.CURSEDSWORDSMAN:
                    characterToCreate.AttackPoints=50;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=300;
                    characterToCreate.PlayerManaDefensePoints=30;
                    characterToCreate.PlayerManaPoints=250;
                    characterToCreate.PlayerMaxManaPoints=characterToCreate.PlayerManaPoints;
                break;
                case PlayerClassTypes.MAGE:
                    characterToCreate.AttackPoints=10;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=60;
                    characterToCreate.PlayerManaDefensePoints=40;
                    characterToCreate.PlayerManaPoints=600;
                    characterToCreate.PlayerMaxManaPoints=characterToCreate.PlayerManaPoints; 
                break;

            }
            return characterToCreate;
        }
        public Enemy CreateEnemy (EnemyNames enemyType)
        {
            Enemy enemyToCreate=new Enemy();
            enemyToCreate.enemyType=enemyType;
            switch(enemyToCreate.enemyType)
            {
                case EnemyNames.BAT:
                    enemyToCreate.EnemyName="Bat";
                    enemyToCreate.EnemyHealth=100;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyDefensePoints=10;
                    enemyToCreate.EnemyManaDefensePoints=5;
                    enemyToCreate.EnemyAttackPoints=20;
                    enemyToCreate.EnemyManaPoint=50;
                    enemyToCreate.EnemyManaAttackPoints=25;
                break;
                case EnemyNames.ANGEL:
                    enemyToCreate.EnemyName="Angel";
                    enemyToCreate.EnemyHealth=400;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyDefensePoints=300;
                    enemyToCreate.EnemyManaDefensePoints=75;
                    enemyToCreate.EnemyAttackPoints=40;
                    enemyToCreate.EnemyManaPoint=200;
                break;
                case EnemyNames.CURSEDSWORDSMAN:
                    enemyToCreate.EnemyName="Cursed Swordsman";
                    enemyToCreate.EnemyHealth=600;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyAttackPoints=50;
                    enemyToCreate.EnemyManaPoint=100;
                    enemyToCreate.EnemyDefensePoints=50;
                break;
                case EnemyNames.HORNET:
                    enemyToCreate.EnemyName="Hornet"; 
        	        enemyToCreate.EnemyHealth=110; 
        	        enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
		            enemyToCreate.EnemyManaPoint=50;
	    	        enemyToCreate.EnemyManaDefensePoints=15;
	    	        enemyToCreate.EnemyDefensePoints=25;
	    	        enemyToCreate.EnemyAttackPoints=30;
                break;
                case EnemyNames.ZOMBIE:
                    enemyToCreate.EnemyName="Zombie";
                    enemyToCreate.EnemyHealth=150;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyManaDefensePoints=35;
                    enemyToCreate.EnemyManaPoint=50;
                    enemyToCreate.EnemyDefensePoints=70;
                break;
                case EnemyNames.KITSUNE:
                    enemyToCreate.EnemyName="Kitsune";
    	            enemyToCreate.EnemyHealth=150;
    	            enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
    	            enemyToCreate.EnemyDefensePoints=35;
    	            enemyToCreate.EnemyManaPoint=50;
    	            enemyToCreate.EnemyAttackPoints=50;
    	            enemyToCreate.EnemyDefensePoints=25;
    	            enemyToCreate.EnemyManaAttackPoints=25;
   	                enemyToCreate.EnemyManaDefensePoints=12;
                break;
                case EnemyNames.VAMPIRE:
                    enemyToCreate.EnemyName="Vampire";
                    enemyToCreate.EnemyHealth=650;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyManaDefensePoints=70;
                    enemyToCreate.EnemyManaPoint=100;
                    enemyToCreate.EnemyDefensePoints=80;
                break;
                default:
                break;
            }
            return enemyToCreate;
        }
        public static void ChangeTextColor(ConsoleColor textColor)
        {
            Console.ForegroundColor=textColor;
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
            while(playercharacter.CurrentHealthPoints>0&& enemy.CurrentHealthPoints>0)
            {
               string initTurnChoice="";
               // stats and damage values
               double DamageDealt=0;
               bool bIsPetrified=false;
               double SpellCost=0;
               bool bIsDefending=false;
               while(initTurnChoice=="")
               {
                    System.Console.WriteLine($"{enemy.EnemyName} has appeared! \n What would you like to do: \n 1) Attack\n2) Magic/Special\n3)Defend\n");
                    Console.ReadLine();
                    switch(initTurnChoice.ToLower())
                    {
                        //standard attack
                        case"1":
                        case"attack":
                            DamageDealt=playercharacter.AttackPoints-enemy.EnemyDefensePoints;
                            enemy.CurrentHealthPoints-=DamageDealt;
                            if(DamageDealt<0)
                            {
                                DamageDealt*=-1;
                                enemy.CurrentHealthPoints-=DamageDealt;
                            }
                        break;
                        //magic or special attack (class dependent)
                        case"2":
                        case"magic":
                            // check to see if player has enough mana points to use magic
                            if(playercharacter.PlayerManaPoints<=0)
                            {
                                Console.ForegroundColor=ConsoleColor.Red;
                                System.Console.WriteLine("You do not have enough mana points\n");
                                initTurnChoice="";
                                Console.ForegroundColor=ConsoleColor.Gray;
                            }
                        break;
                        case "3":
                        case"defend":
                         bIsDefending=true;
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
                    default:
                    Console.ForegroundColor=ConsoleColor.Yellow;
                    System.Console.WriteLine("Please choose from the above 2 options\n1)new game \n2) quit\n ");
                    Console.ForegroundColor=ConsoleColor.Gray;
                    TitleScreenOption="";
                    break;
                }
            }

        }
        public static void QuitGame()
        {
            Console.ForegroundColor=ConsoleColor.Yellow;
            System.Console.WriteLine("Quitting game in 3 seconds\n");
            Thread.Sleep(3000);
            Console.ForegroundColor=ConsoleColor.Gray;
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
                Console.ForegroundColor=ConsoleColor.Yellow;
                System.Console.WriteLine("Resetting the battle in three seconds\n ");
                playercharacter.CurrentHealthPoints=playercharacter.PlayerHealth;
                Console.ForegroundColor=ConsoleColor.Gray;
                PromptedClearScreen();

            }
            else
            {
                Console.ForegroundColor=ConsoleColor.Red;
                System.Console.WriteLine("Please choose from the above options\n resetting to the most recent checkpoint");
                Console.ForegroundColor=ConsoleColor.Gray;
            }
        }
    }
}