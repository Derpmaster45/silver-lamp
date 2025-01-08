using DH4.Classes;
using DH4.Enums;
using System;
using System.Security.Cryptography.X509Certificates;
namespace DH4
{
    class Game
    {
        TextColorOptions textColorOptions=new TextColorOptions();

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
                    characterToCreate.CurrentPlayerManaPoints=characterToCreate.PlayerMaxManaPoints;
                break;
                case PlayerClassTypes.DARKMAGE:
                    characterToCreate.AttackPoints=10;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=60;
                    characterToCreate.PlayerManaDefensePoints=40;
                    characterToCreate.CurrentPlayerManaPoints=600;
                    characterToCreate.PlayerMaxManaPoints=characterToCreate.CurrentPlayerManaPoints; 
                break;
                case PlayerClassTypes.CURSEDSWORDSMAN:
                    characterToCreate.AttackPoints=50;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=300;
                    characterToCreate.PlayerManaDefensePoints=30;
                    characterToCreate.CurrentPlayerManaPoints=250;
                    characterToCreate.PlayerMaxManaPoints=characterToCreate.CurrentPlayerManaPoints;
                break;
                case PlayerClassTypes.MAGE:
                    characterToCreate.AttackPoints=10;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=60;
                    characterToCreate.PlayerManaDefensePoints=40;
                    characterToCreate.CurrentPlayerManaPoints=600;
                    characterToCreate.PlayerMaxManaPoints=characterToCreate.CurrentPlayerManaPoints; 
                break;

            }
            textColorOptions=TextColorOptions.PLAYER;
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
                    enemyToCreate.EnemyCurrentManaPoints=50;
                    enemyToCreate.EnemyManaAttackPoints=25;
                break;
                case EnemyNames.ANGEL:
                    enemyToCreate.EnemyName="Angel";
                    enemyToCreate.EnemyHealth=400;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyDefensePoints=300;
                    enemyToCreate.EnemyManaDefensePoints=75;
                    enemyToCreate.EnemyAttackPoints=40;
                    enemyToCreate.EnemyCurrentManaPoints=200;
                break;
                case EnemyNames.CURSEDSWORDSMAN:
                    enemyToCreate.EnemyName="Cursed Swordsman";
                    enemyToCreate.EnemyHealth=600;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyAttackPoints=50;
                    enemyToCreate.EnemyCurrentManaPoints=100;
                    enemyToCreate.EnemyDefensePoints=50;
                break;
                case EnemyNames.HORNET:
                    enemyToCreate.EnemyName="Hornet"; 
        	        enemyToCreate.EnemyHealth=110; 
        	        enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
		            enemyToCreate.EnemyCurrentManaPoints=50;
	    	        enemyToCreate.EnemyManaDefensePoints=15;
	    	        enemyToCreate.EnemyDefensePoints=25;
	    	        enemyToCreate.EnemyAttackPoints=30;
                break;
                case EnemyNames.ZOMBIE:
                    enemyToCreate.EnemyName="Zombie";
                    enemyToCreate.EnemyHealth=150;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyManaDefensePoints=35;
                    enemyToCreate.EnemyCurrentManaPoints=50;
                    enemyToCreate.EnemyDefensePoints=70;
                break;
                case EnemyNames.KITSUNE:
                    enemyToCreate.EnemyName="Kitsune";
    	            enemyToCreate.EnemyHealth=150;
    	            enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
    	            enemyToCreate.EnemyDefensePoints=35;
    	            enemyToCreate.EnemyCurrentManaPoints=50;
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
                    enemyToCreate.EnemyCurrentManaPoints=100;
                    enemyToCreate.EnemyDefensePoints=80;
                break;
                default:
                break;
            }
            return enemyToCreate;
        }
        public static void ChangeTextColor(TextColorOptions textColor)
        {
            switch(textColor)
            {
                case TextColorOptions.DEFAULT:
                    Console.ForegroundColor=ConsoleColor.Gray;
                break;
                case TextColorOptions.DEBUG:
                    Console.ForegroundColor=ConsoleColor.White;
                break;
                case TextColorOptions.GAMEMESSAGE:
                    Console.ForegroundColor=ConsoleColor.Yellow;
                break;
                case TextColorOptions.ERROR:
                    Console.ForegroundColor=ConsoleColor.Red;
                break;
                case TextColorOptions.ENEMY:
                    Console.ForegroundColor=ConsoleColor.Green;
                break;
                case TextColorOptions.NPC:
                    Console.ForegroundColor=ConsoleColor.Magenta;
                break;
                case TextColorOptions.PLAYER:
                    Console.ForegroundColor=ConsoleColor.Blue;
                break;

            }
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
                //ChangeTextColor(ConsoleColor.Gray);
                System.Console.WriteLine($"{enemy.EnemyName} has appeared\n");
               string initTurnChoice="";
               // stats and damage values
               double DamageDealt=0;
               bool bIsPetrified;
               double SpellCost=0;
               bool bIsDefending;
               while(initTurnChoice=="")
               {
                    System.Console.WriteLine($"What would you like to do: \n 1) Attack\n2) Magic/Special\n3)Defend\n");
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
                            if(playercharacter.CurrentPlayerManaPoints<=0)
                            {
                                
                                System.Console.WriteLine("You do not have enough mana points\n");
                                initTurnChoice="";
                                Console.ForegroundColor=ConsoleColor.Gray;
                            }
                            else
                            {
                                string magicmenuchoice="";
                                while(magicmenuchoice=="")
                                {
                                    switch(playercharacter.PlayerClass)
                                    {
                                        case PlayerClassTypes.MAGE:
                                            System.Console.WriteLine("Which magic attack would you like to use?\n1) Heal\n2)Fire\n");
                                            magicmenuchoice=Console.ReadLine();
                                            // switch based on the users input 
                                            switch(magicmenuchoice.ToLower())
                                            {
                                                case"1":
                                                case"heal":
                                                    SpellCost=25;
                                                    if(playercharacter.CurrentPlayerManaPoints<SpellCost)
                                                    {
                                                        System.Console.WriteLine("You do not have enough mana points, please select another option.\n");
                                                        magicmenuchoice="";
                                                    }
                                                    playercharacter.CurrentPlayerManaPoints-=SpellCost;
                                                    System.Console.WriteLine($"{playercharacter.PlayerName} casts heal");
                                                    // take player health and mulitply it by .20
                                                    playercharacter.CurrentHealthPoints*=.20;
                                                    // if the player health is greater than the max health set health to max health value
                                                    if(playercharacter.CurrentHealthPoints>playercharacter.PlayerHealth)
                                                    {
                                                        playercharacter.CurrentHealthPoints=playercharacter.PlayerHealth;
                                                    }
                                                   // ChangeTextColor(ConsoleColor.White);
                                                    System.Console.WriteLine($"DEBUG current health points {playercharacter.CurrentHealthPoints} Player max health points {playercharacter.PlayerHealth}");
                                                  //  ChangeTextColor(ConsoleColor.Gray);
                                                    initTurnChoice="";
                                                break;
                                                case "2":
                                                case"fire":
                                                    System.Console.WriteLine($"{playercharacter.PlayerName} casts fire!\n");
                                                    SpellCost=25;
                                                    playercharacter.CurrentPlayerManaPoints-=SpellCost;
                                                    double firebasedamage=30;
                                                    DamageDealt=(playercharacter.PlayerManaAttackPoints+firebasedamage)/enemy.EnemyManaDefensePoints;
                                                    enemy.CurrentHealthPoints-=DamageDealt;
                                                    initTurnChoice="";

                                                break;
                                                default:
                                                    //ChangeTextColor(ConsoleColor.Red);
                                                    System.Console.WriteLine("ERR: Unknown Attack!/n Please try again.");
                                                    ClearAndReset(playercharacter);
                                                    //ChangeTextColor(ConsoleColor.Gray);
                                                    magicmenuchoice="";
                                                break;
                                            }
                                        break;
                                        case PlayerClassTypes.CURSEDSWORDSMAN:

                                            System.Console.WriteLine("What magic attack would you like to use?\n1) void\n2) TBD\n");
                                            magicmenuchoice=Console.ReadLine();
                                            switch(magicmenuchoice.ToLower())
                                            {
                                                case"1":
                                                case"void":
                                                    if(playercharacter.CurrentPlayerManaPoints<SpellCost)
                                                    {
                                                       // ChangeTextColor(ConsoleColor.Yellow);
                                                        System.Console.WriteLine("You do not have enough mana points, please select another option.\n");
                                                        //ChangeTextColor(ConsoleColor.Gray);
                                                        magicmenuchoice="";
                                                    }
                                                    else if(playercharacter.CurrentPlayerManaPoints<=0)
                                                    {
                                                        //ChangeTextColor(ConsoleColor.Yellow);

                                                        System.Console.WriteLine("You have no mana points. Please choose a different action\n");
                                                        //ChangeTextColor(ConsoleColor.Gray);

                                                    }
                                                    else
                                                    {
                                                        System.Console.WriteLine($"{playercharacter.PlayerName} used VOID");
                                                        int VoidBaseDamage=10;
                                                        DamageDealt=VoidBaseDamage*(playercharacter.PlayerManaAttackPoints /enemy.EnemyManaDefensePoints);
                                                    }
                                                  
                                                break;
                                                case"2":
                                                    // setup a new attack for the cursed swordsman 
                                                    // set damage params for the function to return so that we can have the enemy attack the player and deal damage.
                                                    if(playercharacter.CurrentPlayerManaPoints<SpellCost)
                                                    {
                                                        System.Console.WriteLine("You have no mana points, please select another option\n");
                                                    }
                                                break;
                                                default:
                                                      //  ChangeTextColor(ConsoleColor.Red);
                                                        System.Console.WriteLine("ERR: Unknown Attack!/n Please try again.");
                                                        ClearAndReset(playercharacter);
                                                      //  ChangeTextColor(ConsoleColor.Gray);
                                                        magicmenuchoice="";
                                                break;
                                            
                                            }
                                            

                                        break;
                                        case PlayerClassTypes.DARKMAGE:
                                            System.Console.WriteLine("What magic attack would you like to use \n1) Drain Life /n2)Lightning \n3) Petrification\n");
                                            magicmenuchoice=Console.ReadLine();
                                            switch(magicmenuchoice.ToLower())
                                            {
                                                case "1":
                                                if(playercharacter.CurrentPlayerManaPoints<SpellCost)
                                                {
                                                    System.Console.WriteLine("You dont have enough mana points,please select another option\n");
                                                    magicmenuchoice="";
                                                }
                                                else if(playercharacter.CurrentPlayerManaPoints==0)
                                                {
                                                    System.Console.WriteLine("You have no mana points, please select a different attack\n");
                                                    magicmenuchoice="";
                                                    initTurnChoice="";
                                                }
                                                break;
                                                case "2":
                                                if(playercharacter.CurrentPlayerManaPoints<SpellCost)
                                                {
                                                   // ChangeTextColor(ConsoleColor.Yellow);
                                                    System.Console.WriteLine("You dont have enough mana points, please select another option\n");
                                                   // ChangeTextColor(ConsoleColor.Gray);
                                                    magicmenuchoice="";
                                                    initTurnChoice="";

                                                }
                                                else if(playercharacter.CurrentPlayerManaPoints<=0)
                                                {
                                                    System.Console.WriteLine("You have no mana points please select another option\n");
                                                    magicmenuchoice="";
                                                    initTurnChoice="";
                                                }
                                                break;
                                                case"3":
                                                if(playercharacter.CurrentPlayerManaPoints<SpellCost)
                                                {
                                                    System.Console.WriteLine("You dont have enough mana points, please select another option");
                                                }
                                                else if(playercharacter.CurrentPlayerManaPoints==0)
                                                {
                                                   // ChangeTextColor(ConsoleColor.Yellow);
                                                    System.Console.WriteLine("You have no mana points");
                                                    //ChangeTextColor(ConsoleColor.Gray);
                                                }
                                                else{}
                                                break;
                                            }
                                        break;
                                        case PlayerClassTypes.KNIGHT:
                                        break;
                                    }
                                }
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