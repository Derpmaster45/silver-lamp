using System;
using System.Drawing;
using DH4.Classes;
namespace DH4
{
    class Game
    {
        public static void Main(string[] args)
        {
            string MainMenuOption="";
           /* double DoDamageToPlayer(Character[] characters, Enemy[] enemies)
            {
                for(int i=0; i<characters.Length;)
                {
                    for (int j=0; j<enemies.Length j++)
                    {
                        double DamageDealt=characters[i].PlayerHeath -enemies[j].EnemyAttackPoints/characters[i].PlayerDefensePoints;
                        if(characters[i])    
                        
                    }
                    
                }
                return Dama
            } */
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
            void BattleSystem(Character[] PlayerParty, Enemy[] enemy,  string CheckpointName)
            {
               System.Console.WriteLine("Batte intro message goes here.");
              for(int i=0;i<enemy.Length; i++)
              {
                for(int j=0; j<PlayerParty.Length; j++)
                {
                    
                    while(enemy[i].EnemyHeath<=0|| PlayerParty[j].PlayerHeath<=0)
                    {
                        System.Console.WriteLine("What would "+PlayerParty[j].PlayerName+" like to do \n 1) Attack \n 2) Magic Attack\n 3)Defend\n");
                        string BattleOption=Console.ReadLine();
                        Random AIInput  = new Random();
                        int randInput=AIInput.Next(1,3);
                        switch(BattleOption)
                        {
                            case"1":
                            System.Console.WriteLine(PlayerParty[i].PlayerName+" goes for a physical attack\n");
                            // do damage to ai function call (not programmed in yet)
                            break;
                            case"2":
                            System.Console.WriteLine(PlayerParty[i].PlayerName+"What magic attack would you like to use?\n");
                            break;
                            case"3":
                            System.Console.WriteLine(PlayerParty[i]+"Who would you like to defend?\n");
                            break;
                            default:
                            System.Console.WriteLine("ERR: Unrecognized Command!\n");
                            break;
                        }
                        if(PlayerParty[i].CurrentHealthPoints==0)
                        {
                            string ERRMessage="Game over\n";
                            ResetAndClear(ERRMessage,MainMenuOption,5000);
                        }

                    }
                    
                    
                }
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
                // party setup for prologue     
                Character[] MageAndSwordsman=new Character[2];
                MageAndSwordsman[0].PlayerName="Mage";
                MageAndSwordsman[1].PlayerName="Swordsman";
                MageAndSwordsman[0].PlayerLevel=10; 
                MageAndSwordsman[1].PlayerLevel=10;
                MageAndSwordsman[0].AttackPoints=40;
                MageAndSwordsman[1].AttackPoints=40;
                MageAndSwordsman[0].PlayerDefensePoints=2;
                MageAndSwordsman[1].PlayerDefensePoints=2;
                MageAndSwordsman[0].PlayerManaPoints=0;
                MageAndSwordsman[1].PlayerManaPoints=500;
                MageAndSwordsman[0].PlayerHeath=1000;
                MageAndSwordsman[1].PlayerHeath=950;
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
                 Enemy[] AngelEnemy= new Enemy[1];
                 AngelEnemy[0].EnemyName="Angel";
                 AngelEnemy[0].EnemyHeath=900;
                 
                 BattleSystem(MageAndSwordsman,AngelEnemy,CheckpointName);
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

        private static void BattleSystem(Character character, Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}