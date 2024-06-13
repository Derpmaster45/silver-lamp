using System;
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
            MageSpells spells = new MageSpells();
            DarkMageMagic dmMagicSpells=new DarkMageMagic();
            DarkSwordsmanMagic DSMagicSpells =new DarkSwordsmanMagic();
            //DS Character creation
            Character DSCharacter= new Character();
            DSCharacter.PlayerName="Dark Swordsman";
            DSCharacter.PlayerHealth=600;
            DSCharacter.CurrentHealthPoints=DSCharacter.PlayerHealth;
            DSCharacter.AttackPoints=50;
            DSCharacter.PlayerLevel=5;
            DSCharacter.PlayerManaPoints=200;
            DSCharacter.PlayerDefensePoints=50;
            DSCharacter.PlayerClass=PlayerClassTypes.DARKSWORDSMAN;
            // ds Character Creation end


            Enemy enemy= new Enemy();
           double DoDamageToPlayer(Character character, EnemyNames namelist, Enemy enemy)
           {
             AngelMagicAttacks angelMagic=new AngelMagicAttacks();
             BatSpecialAttack batSpecial=new BatSpecialAttack();
             ZombieSpecialAttacks zombieSpecial=new ZombieSpecialAttacks();
                Random aiInput = new Random();
                int action =aiInput.Next(1,3);
                double DamageDealtToPlayer=0;
                if(action == 1)
                {
                     DamageDealtToPlayer=character.PlayerDefensePoints-enemy.EnemyAttackPoints;
                    System.Console.WriteLine(enemy.EnemyName.ToString()+"has taken a swing at "+character.PlayerName+" and dealt "+DamageDealtToPlayer.ToString()+"points of damage");
                    
                } 
                else if(action==2)
                {
                    Console.WriteLine("This is being worked on at the moment. ");
                    Random magicinput= new Random();
                    switch(enemy.enemyType)
                    {
                        case EnemyNames.BAT:
                        // choose from the list of spells using random values
                        int magicAction=magicinput.Next(1,3);
                        if(enemy.EnemyManaPoint<=0)
                        {
                            Console.WriteLine($"The {enemy.EnemyName} has no special attack points, so it does not attack.\n");
                        }
                        else
                        {
                            switch(magicAction)
                            {
                                case 1:
                                break;
                                case 2:
                                break;
                                case 3:
                                break;
                                default:
                                break;
                            }
                        }
                        break;
                        case EnemyNames.ANGEL:
                            // choose from the list of spells using random values
                            int angelMagicAction=magicinput.Next(1,3);
                            if(enemy.EnemyManaPoint<=0)
                            {
                                Console.WriteLine($"The {enemy.EnemyName} has no mana points, so the {enemy.EnemyName} plans its next attack.");

                            }
                            else
                            {
                                switch(angelMagicAction)
                                {

                                }
                            }
                        break;
                        case EnemyNames.DARKSWORDSMAN:
                        // choose from the list of spells using random values
                        int dsMagicAction=magicinput.Next(1,3);
                        break;
                        case EnemyNames.VAMPIRE:
                        // choose from the list of spells using random values
                        int vampireMagicAction=magicinput.Next(1,3);
                        break;
                        case EnemyNames.ZOMBIE:
                        // choose from the list of spells using random values
                        int zombieMagicAction=magicinput.Next(1,3);
                        break;
                        default:
                        Console.WriteLine("ERR: Unknown Enemy Type");
                        DamageDealtToPlayer=0;
                        break;
                    }
                    /* 
                    ZOMBIE,
                    BAT,
                    ANGEL,
                    VAMPIRE,
                    DARKSWORDSMAN,
                    NONE
                    */
                } 
                else if(action==3)
                {
                    Console.WriteLine($"{enemy.EnemyName} has chosen to defend against your next attack.");
                    DamageDealtToPlayer=0;
                }

                return DamageDealtToPlayer; 
           }
           Enemy CreateEnemy(EnemyNames namelist)
           {
            Enemy enemyToCreate= new Enemy();
            enemyToCreate.enemyType=namelist;
            switch(enemyToCreate.enemyType)
            {
                case EnemyNames.BAT:
                    enemyToCreate.EnemyName="Bat";
                    enemyToCreate.EnemyHealth=100;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyDefensePoints=10;
                    enemy.EnemyAttackPoints=20;
                    enemy.EnemyManaPoint=0;
                break;
                case EnemyNames.ANGEL:
                    enemyToCreate.EnemyName="Angel";
                    enemyToCreate.EnemyHealth=400;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyDefensePoints=300;
                    enemy.EnemyAttackPoints=40;
                    enemyToCreate.EnemyManaPoint=200;
                break;
                case EnemyNames.DARKSWORDSMAN:
                    enemyToCreate.EnemyName="Dark Swordsman";
                    enemyToCreate.EnemyHealth=600;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyAttackPoints=50;
                    enemyToCreate.EnemyManaPoint=100;
                    enemyToCreate.EnemyDefensePoints=50;
                break;
                case EnemyNames.ZOMBIE:
                    enemyToCreate.EnemyName="Zombie";
                    enemyToCreate.EnemyHealth=150;
                    enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                    enemyToCreate.EnemyManaPoint=50;
                    enemyToCreate.EnemyDefensePoints=70;
                break;
                case EnemyNames.VAMPIRE:
                enemyToCreate.EnemyName="Vampire";
                break;
                default:
                Console.WriteLine("Err: Unrecognized Enemy Type\n Probably not created yet in the creation method");
                break;
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
                Console.WriteLine("Press any key to continue\n");
                Console.Read();
                Console.Clear();
            }
            void ResetAndClear(string errormessage,string switchinput,int threadsleepparam, Character character)
            {
                Console.WriteLine(errormessage);
                Console.WriteLine("Resetting to the previous checkpoint in "+threadsleepparam+" milliseconds.");
                Thread.Sleep(threadsleepparam);
                Console.Clear();
                switchinput="";
                if(character.CurrentHealthPoints<=0)
                {
                    character.CurrentHealthPoints=character.PlayerHealth;
                }
                
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
            characterToCreate.PlayerHealth=300;
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
                    characterToCreate.PlayerManaPoints=50;
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

            void BattleSystem(Character PlayerParty, Enemy enemy, MageSpells SpellList, DarkMageMagic DMSpellList, DarkSwordsmanMagic DSMagicList, string CheckpointName)
            {
                // if enemy is petrified increment the turnsSincePetrify at the end of each turn
               bool bIsPetrified=false;
               int turnsSincePetrify=0;
               double SpellCost=0;
               Console.WriteLine($"{enemy.EnemyName} has appeared!");
               string battlesystemchoice="" ;
               while(PlayerParty.CurrentHealthPoints>0 && enemy.CurrentHealthPoints>0)
               {
                battlesystemchoice="";
                while(battlesystemchoice=="")
                {
                Console.WriteLine("Would you like to \n1) Attack \n 2) Magic/Special  \n 3) Block\n");
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
                    // todo: see if player has mana points
                    if(PlayerParty.PlayerManaPoints<=0)
                    {
                        Console.WriteLine("You dont have mana points please choose another option.\n");
                        battlesystemchoice="";
                    }
                    else
                    {
                        string magicattackchoice="";
                        while(magicattackchoice=="")
                        {

                            Console.WriteLine($"What magic attack would you like to use\n");
                          // switch using player class
                          switch(PlayerParty.PlayerClass)
                          {
                            case PlayerClassTypes.MAGE:
                            string MageMagicChoice="";
                            while(MageMagicChoice=="")
                            {
                                Console.WriteLine("Which magic attack would you like to use \n1) Heal \n2) Fire\n");
                                switch(MageMagicChoice.ToLower())
                                {
                                    case"1":
                                    case"heal":
                                    SpellCost=25;
                                    PlayerParty.PlayerManaPoints-=SpellCost;
                                    Console.WriteLine($"{PlayerParty.PlayerName} casts heal!");
                                    // todo: Get the players current health and multiply it by 0.020 and see if the value exceeds the max health value
                                    double updatedHealth=PlayerParty.CurrentHealthPoints*=.020;
                                    PlayerParty.CurrentHealthPoints=updatedHealth;
                                    double maxHealth=PlayerParty.PlayerHealth;
                                    if(updatedHealth>maxHealth)
                                    {
                                        PlayerParty.CurrentHealthPoints=maxHealth;
                                    }
                                    break;
                                    case "2":
                                    case"fire":
                                    Console.WriteLine($"{PlayerParty.PlayerName} casts fire");
                                    SpellCost=25; 
                                    PlayerParty.PlayerManaPoints-=SpellCost;
                                    // call damage dealt function
                                    break;
                                    default:
                                    ResetAndClear("Unexpected Input, resetting in 5 seconds",magicattackchoice,5000, PlayerParty); 
                                    break;
                                    
                                }
                            }
                            break;
                            case PlayerClassTypes.DARKMAGE:
                            string DarkMageMagicAttackChoice="";
                            while(DarkMageMagicAttackChoice=="")
                            {
                             Console.WriteLine("What magic attack would you like to use? \n 1)Lightning \n 2)Life Drain\n 3)Petrifaction\n");
                              DarkMageMagicAttackChoice=Console.ReadLine();
                              switch(DarkMageMagicAttackChoice.ToLower())
                              {
                                case"1":
                                case "lighting":
                                break;
                                case"2":
                                case"life drain":
                                Console.WriteLine($"{PlayerParty.PlayerName} has used life drain\n");
                                double lifeTaken=enemy.CurrentHealthPoints-50;
                                PlayerParty.CurrentHealthPoints+=lifeTaken;
                                Console.WriteLine($"it dealt {lifeTaken} points and healed the player. Your new health is{PlayerParty.CurrentHealthPoints}");
                                break;
                                case"3":
                                case"petrification":
                                    // Come up with a way to have a damage dealt function that will have the player class, and the magic value
                                break;
                                default:
                                ResetAndClear("Select from the 2 above options\n resetting in 5 seconds",DarkMageMagicAttackChoice,5000,PlayerParty);
                                break;

                              }
                            }
                          
                            // list magic attacks then prompt for input
                            break;
                            case PlayerClassTypes.DARKSWORDSMAN:
                            string DarkswordsmanMagicChoice="";
                            while(DarkswordsmanMagicChoice=="")
                            {
                                Console.WriteLine("What magic attack would you like to use\n 1) Acid Rain\n 2) Void ");
                                DarkswordsmanMagicChoice=Console.ReadLine();
                                switch(DarkswordsmanMagicChoice.ToLower())
                                {
                                    case "1":
                                    case"acid rain":
                                    double DamageDeal= enemy.EnemyDefensePoints/PlayerParty.PlayerManaAttackPoints;
                                    enemy.CurrentHealthPoints-=DamageDeal;
                                    Console.WriteLine($"You deal {DamageDeal} points of damage from acid rain");
                                    break;
                                    case "2":
                                    case"void":
                                    // write void to take a quarter of health but take a high amount of mana points
                                    break;
                                    default:
                                    ResetAndClear("Select from the 2 above options\n resetting in 5 seconds",DarkswordsmanMagicChoice,5000,PlayerParty);
                                    break;

                                }
                            }
                            break;
                            case PlayerClassTypes.KNIGHT:
                            string knightSpcialOption="";
                            while(knightSpcialOption=="")
                            Console.WriteLine("What special attacks would you like to use?\n 1) Double attack\n");
                            
                           // PromptedClearScreen();
                           // battlesystemchoice="";

                            break;
                            default:
                            string errmessage="ERR: Unrecognized class please try something else";
                            ResetAndClear(errmessage,battlesystemchoice,5000,PlayerParty);
                            break;
                          }
                          
                           }
                        }
                    
                    //Console.WriteLine("PLACEHOLDER: No Magic attacks\n");
                    break;
                    case"3":
                    // add in ai attack pattern
                    System.Console.WriteLine("You decided to Defend against the next attack.\n");
                    if(bIsPetrified==false)
                    {
                          DoDamageToPlayer(PlayerParty,enemyNames, enemy);
                    }
                    else
                    {
                        Console.WriteLine($"The {enemy.EnemyName} is petrified so it cannot move ");
                        turnsSincePetrify++;
                        // line for testing, delete later
                        Console.WriteLine($"Turns since petrify {turnsSincePetrify}");
                    }
                    if(turnsSincePetrify==4)
                    {
                        bIsPetrified=false;
                        if(enemy.CurrentHealthPoints<=0)
                        {
                            Console.WriteLine($"{enemy.EnemyName} was defeated before they could break the spell.");

                        } else
                        {
                            Console.WriteLine("The spell was broken, the enemy can now move again.");
                        }
                    }
                    break;
                    default:
                    string errormessage="Please choose from the above options";
                    ResetAndClear(errormessage,CheckpointName,5000,PlayerParty);
                    break;
                 
                // add fuctionality for ai to attack player}
               }
                }
                if(bIsPetrified==false)
                {
                      DoDamageToPlayer(PlayerParty,enemyNames, enemy);
                }
                else
                {
                    Console.WriteLine($"the {enemy.EnemyName} is petrified and cannot move");
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
                
                 
                 BattleSystem(DSCharacter,AngelEnemy, spells, dmMagicSpells, DSMagicSpells, CheckpointName);
                System.Console.WriteLine("After a tense fight you beat the angel, however he is keen to let you know its not over.\n Angel: You haven’t won yet it is you who have underestimated the church and our leader. \nThe church is going to have your heads.");
                System.Console.WriteLine("Mage: We will deal with that when the time comes\n");
                PromptedClearScreen();
                System.Console.WriteLine("\n Chapter 1:The beginning\n400 Years Later\n");
                System.Console.WriteLine("Capt.Smith: Hey, wake up!\n you took quite a bump to the head.\n");
                System.Console.WriteLine("Capt. Smith:Can you tell me what your name is?\n");
                // character creation function goes here
                string playerName=Console.ReadLine();
                Character playercharacter=CreateCharacter();
                playercharacter.PlayerName=playerName;
                System.Console.WriteLine($"Player Name: {playercharacter.PlayerName}\n Class: {playercharacter.PlayerClass}\n Level: {playercharacter.PlayerLevel}");
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
                        Console.WriteLine($"{playercharacter.PlayerName}: That's not exactly what happened.\n Captain Smith: Enlighten me, what happened?\n{playercharacter.PlayerName}?");
                        string questionEventsPrologue="";
                        while(questionEventsPrologue=="")
                        {
                            Console.WriteLine("Do you want to\n 1) Blame the angel\n 2) agree with the captain?\n");
                            questionEventsPrologue=Console.ReadLine();
                            switch (questionEventsPrologue.ToLower())
                            {
                                case"1":
                                System.Console.WriteLine($"{playercharacter.PlayerName}: the angel is the one to blame for the events that happened.According to historians, who lived in the area around the time of events in question, the people who lived were celebrating the villages founding anniversary.\n Captain Smith: Why is the angel to blame?\n");
                                string AngelBattleRecollection="";
                                while(AngelBattleRecollection=="")
                                {
                                    System.Console.WriteLine("1) Talk about the oddities \n 2) Say nothing\n");
                                    AngelBattleRecollection=Console.ReadLine();
                                    switch(AngelBattleRecollection.ToLower())
                                    {
                                        case"1":
                                       System.Console.WriteLine($"{playercharacter.PlayerName}: Don't you think that it is a bit strange that there are no recorded survivors, but you know what happened. The Dark swordsman and mage's account end after the battle.\n Did they make it out of the battle alive?\nAccording to the mages account none of the villagers were present, so how did the fire start?\n");
                                       System.Console.WriteLine("Captain Smith: We have records of thier questioning after the events in question\n They refused to answer so, we had them burned at the stake. As that was the leaders wishes at the time.\n How do you know of this anyway?\n"); 
                                       bool didBlameHighPriest;
                                      
                                       string DisscussionChoice="";
                                       while (DisscussionChoice=="")
                                       {
                                         System.Console.WriteLine($"Do you: \n 1)Hide information\n 2) tell the truth\n");
                                         DisscussionChoice=Console.ReadLine();
                                        switch (DisscussionChoice.ToLower())
                                        {
                                            case"Hide Information":
                                            case"1":
                                            System.Console.WriteLine($"{playercharacter.PlayerName} I heard it from a priest. When they told me I thought something seemed off about what they said.");
                                            didBlameHighPriest=true;
                                            LiesTold++;
                                            //System.Console.WriteLine($"lies told: {LiesTold.ToString()} ");
                                        
                                            System.Console.WriteLine($"Captain Smith: Like What?\n {playercharacter.PlayerName}: Oh... you know...\n Captain Smith: No I do not! Get back to your quarters.\n That was close you think to yourself.\n ");
                                            PromptedClearScreen();
                                            if (LiesTold==2)
                                            {
                                                System.Console.WriteLine($"Later that night, you arrive at askela You are about to recieve your marching orders.\nCaptain Smith:We need to quell this uprising in the name of the king and queen!");
                                                System.Console.WriteLine("You take a step off the boat, and you hear a voice saying 'This is not your path.'");
                                                Console.WriteLine("You look around confused\n Captain Smith: Are you alright.");
                                                Console.WriteLine($"{playercharacter.PlayerName}: Yes, I am fine.");
                                                Console.WriteLine("Captain Smith: Well then, get moving!");
                                                                            Console.WriteLine("You step off the boat onto the dock, observing your surroundings you learn that the port is over run by zombies, what do you want to do?\n 1) Sneak past the zombies \n 2) Fight your way through the horde ");
                                                                            string TownPathLie="";
                                                                            while (TownPathLie == "") 
                                                                            {
                                                                                Console.WriteLine("What do you want to do?\n 1) Sneak past the zombies \n 2) Fight your way through the horde");
                                                                                TownPathLie= Console.ReadLine();
                                                                                switch (TownPathLie.ToLower()) 
                                                                                {
                                                                                    case "1":
                                                                                        Console.WriteLine("You decide to sneak past the zombies, Lucky for you the zombies are slow moving. ");
                                                                                        Console.WriteLine("Placeholder: you successfully evaded the zombies.");
                                                                                        break;
                                                                                    case "2":
                                                                                        // battlesystem and zombie enemy creation goes here.
                                                                                        enemyNames = EnemyNames.ZOMBIE;
                                                                                        Enemy zombieEnemy = CreateEnemy(enemyNames);
                                                                                        BattleSystem(playercharacter, zombieEnemy, spells, dmMagicSpells, DSMagicSpells, TownPathLie);
                                                                                        break;
                                                                                    default:
                                                                                        ResetAndClear("Please choose from the 2 above options", TownPathLie, 5000, playercharacter); 
                                                                                        break;
                                                                                }
                                                                                

                                                                            }
                                                                            playercharacter.CurrentHealthPoints=playercharacter.PlayerHealth;
                                                                                PromptedClearScreen();
                                                                                string forkingpathchoice=""; 
                                                                                while(forkingpathchoice=="")
                                                                                {
                                                                                    Console.WriteLine("You head past the zombies, you come to a fork in the path. \n Do you head to town, or see where the other path takes you.\n");
                                                                                    forkingpathchoice=Console.ReadLine();
                                                                                    bool TookAltPath=false;
                                                                                    switch(forkingpathchoice.ToLower())
                                                                                    {
                                                                                        case"1":
                                                                                        case"go to town":
                                                                                        if(TookAltPath==true)
                                                                                        {
                                                                                            Console.WriteLine("You enter the town and you see Captain Smith, and a citizen of the village, and you decide to approach then to get your marching orders.");
                                                                                            Console.WriteLine($"Captain Smith: Where have you been? \n ");
                                                                                            Console.WriteLine("Do you: \n 1) Say you got lost. \n 2) Talk about the zombies on the beach.\n");
                                                                                            string dolieaboutbeach="";
                                                                                            bool bLiedAboutBeach=false;
                                                                                            while(dolieaboutbeach=="")
                                                                                            {
                                                                                                dolieaboutbeach=Console.ReadLine();
                                                                                                switch(dolieaboutbeach.ToLower())
                                                                                                {
                                                                                                    case"1":
                                                                                                    case"say you got lost":
                                                                                                    Console.WriteLine($"{playercharacter.PlayerName}:I got lost on my way to town.Sorry I have taken so long.");
                                                                                                    break;
                                                                                                    case"inform about zombies on the beach":
                                                                                                    Console.WriteLine("");
                                                                                                    break;
                                                                                                }
                                                                                            }


                                                                                        }
                                                                                        else if(TookAltPath==false)
                                                                                        {
                                                                                            Console.WriteLine($"You meet Captain smith in the village.\n {playercharacter.PlayerName}:woah, this town is over run with zombies and bats\n Captain smith: You're objective is to go to the house of the darkswordsman and see what is causing this infestation.\n");

                                                                                        }
                                                                                        break;
                                                                                        case "2":
                                                                                        case "take other path":
                                                                                        TookAltPath=true;
                                                                                        //Console.WriteLine("You take the other path, it leads to a dead end.\n Do you \n 1) Explore the surrounding area \n 2) go back to the start of the path\n ");
                                                                                        string dogoback="";
                                                                                        while(dogoback=="")
                                                                                        {
                                                                                            
                                                                                            dogoback=Console.ReadLine();
                                                                                            Console.WriteLine("You take the other path, it leads to a dead end.\n Do you \n 1) Explore the surrounding area \n 2) go back to the start of the path\n");
                                                                                            switch(dogoback.ToLower())
                                                                                            {
                                                                                                case"go back to town":

                                                                                                Console.WriteLine("Decide to head back to the start of the path. ");
                                                                                                forkingpathchoice="1";
                                                                                                break;
                                                                                                case"keep exploring":
                                                                                                Console.WriteLine("You keep exploring, you find a river, however you dont have anythign to fish with.\n");
                                                                                                dogoback="";
                                                                                                break;

                                                                                            }
                                                                                        }
                                                                                        break;
                                                                                        default:
                                                                                        ResetAndClear("Pick from the above 2 options",forkingpathchoice,5000,playercharacter);
                                                                                        break;

                                                                                    }
                                                                                }




                                            }
                                            break;
                                        }
                                       }

                                        break;
                                        case"2":
                                        break;
                                        default:
                                        break;

                                    }
                                }
                                break;
                                case"2":
                                LiesTold++;
                                break;
                                default:
                                break;
                            }

                        }
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