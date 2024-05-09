using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using DH4.Classes;
using DH4.Enums;
namespace DH4
{
    class Game
    {
        public static void Main(string[] args)
        {
            EnemyNames enemyNames = new EnemyNames();
            string MainMenuOption="";
            Character DSCharacter= new Character();
            DSCharacter.PlayerName="Dark Swordsman";
            DSCharacter.PlayerHeath=600;
            DSCharacter.CurrentHealthPoints=DSCharacter.PlayerHeath;
            DSCharacter.AttackPoints=50;
            DSCharacter.PlayerLevel=5;
            DSCharacter.PlayerManaPoints=200;
            DSCharacter.PlayerDefensePoints=50;
            


            Enemy enemy= new Enemy();
           double DoDamageToPlayer(Character character, EnemyNames namelist, Enemy enemy)
           {
                Random aiInput = new Random();
                int action =aiInput.Next(1,3);
                if(action == 1)
                {
                    double DamageDealtToPlayer=enemy.EnemyAttackPoints/character.PlayerDefensePoints;
                    System.Console.WriteLine(enemy.EnemyName.ToString()+"has taken a swing at "+character.PlayerName+" and dealt "+DamageDealtToPlayer.ToString()+"points of damage");
                    
                }

                return 0; 
           }
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
            void ResetAndClear(string errormessage,string switchinput,int threadsleepparam, Character character)
            {
                Console.WriteLine(errormessage);
                Console.WriteLine("Resetting to the previous checkpoint in "+threadsleepparam+" milliseconds.");
                Thread.Sleep(threadsleepparam);
                Console.Clear();
                switchinput="";
                character.CurrentHealthPoints=character.PlayerHeath;
                
            }
            void BattleSystem(Character PlayerParty, Enemy enemy,  string CheckpointName)
            {
               
               Console.WriteLine("Batte intro message goes here.");
               string battlesystemchoice="" ;
               while(PlayerParty.CurrentHealthPoints>=0 || enemy.CurrentHealthPoints>0 || battlesystemchoice=="")
               {
                Console.WriteLine("Would you like to 1) Attack \n 2) Magic  \n 3) Block\n");
                battlesystemchoice=Console.ReadLine();
                switch(battlesystemchoice)
                {
                    case"1":
                    double DamageDealt=PlayerParty.AttackPoints/enemy.EnemyDefensePoints;
                    System.Console.WriteLine("You take a swing at the enemy\n dealing");
                    enemy.CurrentHealthPoints-=DamageDealt;
                    break;
                    case"2":
                    // WIP Add in magic attack function and spells for player to learn.
                    break;
                    case"3":
                    // add in ai attack pattern
                    System.Console.WriteLine("You decided to Defend against the next attack.\n");
                    break;
                    default:
                    string errormessage="Please choose from the above options";
                    ResetAndClear(errormessage,CheckpointName,5000,PlayerParty);
                    break;
                
                // add fuctionality for ai to attack player}
               }
               DoDamageToPlayer(PlayerParty,enemyNames,enemy);
              
            }
            }
           //string MainMenuOption="";
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
                string CheckpointName="AngelBattle";
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
                // party setup complete
                Console.WriteLine("The door swings open, out steps a man who is average in build, and not very intimidating.\n");
                Console.WriteLine("Angel: Ha ha ha, you're the dark swordsman? \nFrom the stories I have heard, I expected you to be scarier.\n");
                Console.WriteLine("Unphazed by the comments of the angel, THe dark swordsman, takes a deep breath.\n Dark Swordsman: Who might you be?\n");
                Console.WriteLine("I am a follower of the Great Spirit. The god that you 'killed' with that mage, speaking of which where is she.\n  Dark swordsman:She's busy. \n");
                Console.WriteLine("Dark Swordsman: Wsat do you want.\n Angel: It's quite simple really, I want to destroy you and the mage.\n");
                PromptedClearScreen();
                 Console.WriteLine("If I just take you on, it won't be much fun. It seems like the stories are wrong.\nYou were made out to be this unstoppable force.\n");
                 Console.WriteLine("Before the dark swordsman can respond a woman steps out from the empty doorway.\n Mage: Whats going on\n");
                 Console.WriteLine("The angel has come here for a fight, however the angel has gotten the village involved.\n");
                 Console.WriteLine("Mage: If you want a fight with us, we will give it to you, howeverleave the villagers out of this. \nThey have done nothing to deserve your anger\n");
                 Console.WriteLine("Angel: They coexsisted with you, they did not try to exspell you from the village.\nThey are as guilty as you, for lettingyou exsist on this plane.\n");
                 Console.WriteLine("With that last statement, the dark swordsman looks at the mage, she nods, as if they are planning something \n Angel:Enough of this It is time for you to meet you maker");
                 Console.WriteLine("The mage snaps her fingers and the villagers disapear\n");
                 Console.WriteLine("The angel looks around in shock, and anger.\n Angel: WHAT HAPPENED!\n Mage: The villagers safety was in jeopardy, we could not allow you to harm innocent bystanders\n Dark swordsman: Now it is time for you to send a message to your master!\n Dark swordsman: As you know, DEAD MEN TELL NO TALES\n");

                 // angel enemy object creation
                 
                Enemy AngelEnemy= new Enemy();
                AngelEnemy.enemyType=EnemyNames.ANGEL;
                AngelEnemy.EnemyName="Angel";
                AngelEnemy.EnemyHeath=500;
                
                 
                // BattleSystem(DSCharacter,AngelEnemy,CheckpointName);
                System.Console.WriteLine("After a tense fight you beat the angel, however he is keen to let you know its not over.\n Angel: You haven’t won yet it is you who have underestimated the church and our leader. \nThe church is going to have your heads.");
                System.Console.WriteLine("Mage: We will deal with that when the time comes\n");
                PromptedClearScreen();
                System.Console.WriteLine("400 Years Later\n");
                System.Console.WriteLine("Hey, wake up!");
                System.Console.WriteLine("What is your name?\n");
                string PlayerName=Console.ReadLine();
                Character playerCharacter=new Character();
                playerCharacter.PlayerName=PlayerName;
                playerCharacter.PlayerLevel=1;
                playerCharacter.PlayerHeath=100;

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