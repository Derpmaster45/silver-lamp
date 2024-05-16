﻿using System;
using System.Collections.Concurrent;
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
                double DamageDealtToPlayer=0;
                if(action == 1)
                {
                     DamageDealtToPlayer=character.PlayerDefensePoints-enemy.EnemyAttackPoints;
                    System.Console.WriteLine(enemy.EnemyName.ToString()+"has taken a swing at "+character.PlayerName+" and dealt "+DamageDealtToPlayer.ToString()+"points of damage");
                    
                }

                return DamageDealtToPlayer; 
           }
           Enemy CreateEnemy(EnemyNames namelist)
           {
            Enemy enemyToCreate= new Enemy();
            enemyToCreate.enemyType=namelist;
            if(enemyToCreate.enemyType==EnemyNames.BAT)
            {
                enemyToCreate.EnemyName="Bat";
                enemyToCreate.EnemyHeath=100;
                enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHeath;
                enemyToCreate.EnemyDefensePoints=10;
                enemy.EnemyAttackPoints=20;
                enemy.EnemyManaPoint=0;
            }
            else if(enemyToCreate.enemyType==EnemyNames.ANGEL)
            {
                enemyToCreate.EnemyName="Angel";
                enemyToCreate.EnemyHeath=400;
                enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHeath;
                enemyToCreate.EnemyDefensePoints=300;
                enemy.EnemyAttackPoints=40;
                enemyToCreate.EnemyManaPoint=200;
            }
            // testing purposes DELETE LATER
           // System.Console.WriteLine($"Enemy {enemyToCreate.EnemyName} created!");
            return enemyToCreate;
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
         Character CreateCharacter()
        {

            Character characterToCreate=new Character();
            while(characterToCreate.PlayerName=="")
            {
                System.Console.WriteLine("What is your name?\n");
                characterToCreate.PlayerName=Console.ReadLine();
            }
            characterToCreate.PlayerLevel=1;
            characterToCreate.PlayerDefensePoints=20;
            characterToCreate.AttackPoints=20;
            characterToCreate.PlayerHeath=300;
            characterToCreate.PlayerExpPoints=0;
            System.Console.WriteLine("What class would you like to be (Subject to change) 1) Knight\n 2)Dark Mage \n3) Mage\n  4) Dark Swordsman");
            string playerclass="";
            playerclass=Console.ReadLine();
            while(playerclass=="")
            {
                switch(playerclass.ToLower())
                {
                    case"1":
                    case"knight":
                    characterToCreate.PlayerClass=PlayerClassTypes.KNIGHT;
                    characterToCreate.PlayerManaPoints=0;
                    break;
                    case"2":
                    case"dark mage":
                    characterToCreate.PlayerClass=PlayerClassTypes.DARKMAGE;
                    characterToCreate.PlayerManaPoints=100;
                    break;
                    case"3":
                    case"mage":
                    characterToCreate.PlayerClass=PlayerClassTypes.MAGE;
                    characterToCreate.PlayerManaPoints=100;
                    break;
                    case"4":
                    case"dark swordsman":
                    characterToCreate.PlayerClass=PlayerClassTypes.DARKSWORDSMAN;
                    characterToCreate.PlayerManaPoints=100;
                    break;
                    default:
                    string errormessage="Please choose from one of the 4 options";
                    ResetAndClear(errormessage,playerclass,5000,characterToCreate);
                    break;
                }
            }
       
        
            return characterToCreate;
        }

            void BattleSystem(Character PlayerParty, Enemy enemy,  string CheckpointName)
            {
               
               Console.WriteLine("Batte intro message goes here.");
               string battlesystemchoice="" ;
               while(PlayerParty.CurrentHealthPoints>0 && enemy.CurrentHealthPoints>0)
               {
                Console.WriteLine("Would you like to \n1) Attack \n 2) Magic  \n 3) Block\n");
                battlesystemchoice=Console.ReadLine();
                switch(battlesystemchoice)
                {
                    case"1":
                    double DamageDealt=enemy.EnemyDefensePoints-PlayerParty.AttackPoints;
                    enemy.CurrentHealthPoints-=DamageDealt;
                    //System.Console.WriteLine($"DEBUG: ENEMY HAS  {enemy.CurrentHealthPoints.ToString()} of {enemy.EnemyHeath.ToString()}");
                    System.Console.WriteLine($"You take a swing at the enemy\n dealing {DamageDealt.ToString()}");
                    break;
                    case"2":
                    // WIP Add in magic attack function and spells for player to learn.
                    break;
                    case"3":
                    // add in ai attack pattern
                    System.Console.WriteLine("You decided to Defend against the next attack.\n");
                    DoDamageToPlayer(PlayerParty,enemyNames, enemy);
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
                 enemyNames= EnemyNames.ANGEL;
                   Enemy AngelEnemy= CreateEnemy(enemyNames);
                
                 
                 BattleSystem(DSCharacter,AngelEnemy,CheckpointName);
                System.Console.WriteLine("After a tense fight you beat the angel, however he is keen to let you know its not over.\n Angel: You haven’t won yet it is you who have underestimated the church and our leader. \nThe church is going to have your heads.");
                System.Console.WriteLine("Mage: We will deal with that when the time comes\n");
                PromptedClearScreen();
                System.Console.WriteLine("\n CHapter 1:The beginning\n400 Years Later\n");
                System.Console.WriteLine("Capt.Smith: Hey, wake up!\n you took quite a bump to the head.\n");
                System.Console.WriteLine("Capt. Smith:Can you tell me what your name is?\n");
                // character creation function goes here
                Character playercharacter=CreateCharacter();
                //System.Console.WriteLine($"Player Name: {playercharacter.PlayerName}\n Class: {playercharacter.PlayerClass}\n Level: {playercharacter.PlayerLevel}");
                System.Console.WriteLine("Capt.Smith: We will give you a few days to recover.\n");
                PromptedClearScreen();
                System.Console.WriteLine("A few days pass, and Capt smith returns to your quarters\n Captain Smith:We have a new order from her majesty\n ");
                System.Console.WriteLine($"{playercharacter.PlayerName}: What caused this uprising? \n Capt. Smith: Not really sure, but the church has been trying to occupy Askela village for as long as i can remember. \n Capt. Smith: They have been trying to rebuild it since the darkswordsman burned down the village unprovoked\n. ");
                string initBranchingPath="";
                int LiesTold=0;
                int TruthsTold=0;
                while(initBranchingPath=="")
                {
                    System.Console.WriteLine("Tutorial: This is a branching path, your actions affect the story. Do you want to \n1) Lie \n2) Tell the truth");
                    initBranchingPath=Console.ReadLine();
                    switch(initBranchingPath.ToLower())
                    {
                        case"1":
                        case"lie":
                        LiesTold++;
                        Console.WriteLine($"{playercharacter.PlayerName}: That's not exactly what happened.\n Captain Smith: Enlighten me, what happened?\n{playercharater.PlayerName}?");
                        Console.WriteLine("Do you want to\n 1) Blame the angel\n 2) agree with the captain?\n");
                        string questionEventsPrologue="";
                        while(questionEventsPrologue=="")
                        break;
                        case"2":
                        case"truth":
                        TruthsTold++;
                        break;
                        default:
                        string errormessage="Please Choose from the above 2 options\n Resetting in 5 seconds";
                        ResetAndClear(errormessage,initBranchingPath,5000,playercharacter);
                        break;
                    }

                }
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