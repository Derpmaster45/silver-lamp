using System;
using System.Collections.Concurrent;
using System.Drawing;
using DH4.Classes;
using DH4.Enums;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Collections;
using System.Security.Cryptography;
using System.Runtime.ConstrainedExecution;
namespace DH4
{
    class Game
    {
       
        public static void SerializeCharacter(Character characterToSave, string checkpoint)
        {
            string checkpointToSave=checkpoint;
            Character characterToSerialize= new Character();
            characterToSerialize.PlayerName=characterToSave.PlayerName;
            characterToSerialize.PlayerLevel=characterToSave.PlayerLevel;
            characterToSerialize.AttackPoints=characterToSave.AttackPoints;
            characterToSerialize.PlayerClass=characterToSave.PlayerClass;
            characterToSerialize.PlayerDefensePoints=characterToSave.PlayerDefensePoints;
            characterToSerialize.PlayerHealth=characterToSave.PlayerHealth;
            characterToSerialize.PlayerManaAttackPoints=characterToSave.PlayerManaAttackPoints;
            characterToSerialize.PlayerMaxManaPoints=characterToSave.PlayerMaxManaPoints;
            characterToSerialize.PlayerManaDefensePoints=characterToSave.PlayerManaDefensePoints;
            characterToSerialize.PlayerManaPoints=characterToSave.PlayerManaPoints;
            characterToSerialize.MostRecentCheckpoint=checkpointToSave;
           // data for file
           string saveName="DH4.Json";
           string jsonObjectString=JsonSerializer.Serialize(characterToSerialize);
           File.WriteAllText(saveName,jsonObjectString);
           // output for testing purposes
           //Console.WriteLine(File.ReadAllText(saveName));
        }
        public static void LoadGame(string saveName)
        {
        // read from most recent checkpoint
            saveName="DH4.Json";

            string SaveName= saveName;
            string jsonObjectString=File.ReadAllText(SaveName);
            Character characterToLoad= JsonSerializer.Deserialize<Character>(jsonObjectString);
            // TODO: pull data from most recent checkpoint and load the section of story based off of the information from the player class.
            // ex goto AngelBattle.
          //  goto AngelBattle;
          /*
          switch(characterToLoad.MostRecentCheckpoint.ToLower())
          {
            case Character Created:

            break; 
          }
          */

        }
        public static void Main(string[] args)
        {
            // function to save game goes here.
           
            EnemyNames enemyNames = new EnemyNames();
            string MainMenuOption="";
            PlayerClassTypes playerclasslist=new PlayerClassTypes();
            DarkMageMagic dmMagicSpells= new DarkMageMagic();
            DarkSwordsmanMagic DSMagicSpells=new DarkSwordsmanMagic();
            MageSpells spells =new MageSpells();
            KnightSpecialAttacks knightAttacks=new KnightSpecialAttacks();

            //DS Character creation
            Character DSCharacter= new Character();
            DSCharacter.PlayerName="Dark Swordsman";
            DSCharacter.PlayerHealth=600;
            DSCharacter.CurrentHealthPoints=DSCharacter.PlayerHealth;
            DSCharacter.AttackPoints=50;
            DSCharacter.PlayerLevel=5;
            DSCharacter.PlayerManaPoints=200;
            DSCharacter.PlayerDefensePoints=50;
            DSCharacter.PlayerManaDefensePoints=50;
            DSCharacter.PlayerManaAttackPoints=30;
            DSCharacter.PlayerClass=PlayerClassTypes.DARKSWORDSMAN;
            // ds Character Creation end
             void ShowEndofGameMessage()
        {
            Console.WriteLine("Thanks for playing, Hope you enjoyed the game!");
            System.Console.WriteLine("Closing Game in 5 seconds!");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }


            Enemy enemy= new Enemy();
            void CheckPlayerLevel(Character player)
            {
                if(player.PlayerExpPoints==50)
                {
                    player.PlayerLevel+=1;
                    player.PlayerHealth+=100;
                    player.CurrentHealthPoints=player.PlayerHealth;
                    player.AttackPoints+=50;
                    player.PlayerDefensePoints+=50;
                    player.PlayerManaAttackPoints+=25;
                    player.PlayerManaDefensePoints+=30;
                    player.PlayerMaxManaPoints+=50;
                    player.PlayerManaPoints=player.PlayerMaxManaPoints;
                }
                else if(player.PlayerExpPoints==150)
                {
                    player.PlayerLevel+=1;
                    Console.WriteLine($"{player.PlayerName} is now level{player.PlayerLevel} \n");
                     //player.PlayerLevel+=1;
                    player.PlayerHealth+=100;
                    player.CurrentHealthPoints=player.PlayerHealth;
                    player.AttackPoints+=50;
                    player.PlayerDefensePoints+=50;
                    player.PlayerManaAttackPoints+=25;
                    player.PlayerManaDefensePoints+=30;
                    player.PlayerMaxManaPoints+=50;
                    player.PlayerManaPoints=player.PlayerMaxManaPoints;

                }
                else if(player.PlayerExpPoints==300)
                {
                    player.PlayerLevel+=1;
                    Console.WriteLine($"{player.PlayerName} is now level {player.PlayerLevel}");
                    // player.PlayerLevel+=1;
                    player.PlayerHealth+=100;
                    player.CurrentHealthPoints=player.PlayerHealth;
                    player.AttackPoints+=50;
                    player.PlayerDefensePoints+=50;
                    player.PlayerManaAttackPoints+=25;
                    player.PlayerManaDefensePoints+=30;
                    player.PlayerMaxManaPoints+=50;
                    player.PlayerManaPoints=player.PlayerMaxManaPoints;
                }
                else if(player.PlayerExpPoints==400)
                {
                    player.PlayerLevel+=1;
                    Console.WriteLine($"{player.PlayerName} is now level {player.PlayerLevel}");
                    player.PlayerHealth+=100;
                    player.CurrentHealthPoints=player.PlayerHealth;
                    player.AttackPoints+=50;
                    player.PlayerDefensePoints+=50;
                    player.PlayerManaAttackPoints+=25;
                    player.PlayerManaDefensePoints+=30;
                    player.PlayerMaxManaPoints+=50;
                    player.PlayerManaPoints=player.PlayerMaxManaPoints;

                }
            }
            // show player level is a debug function to display player stats.
            void ShowPlayerStats(Character player)
            {
                // display player Name followed by level
                Console.WriteLine($"Name: {player.PlayerName}\n Player Level: {player.PlayerLevel}\n");
                Console.WriteLine($"Player Health: {player.CurrentHealthPoints}\n");
                Console.WriteLine($"Maximum Player Health Points: {player.PlayerHealth}\n");
                // display Attack points mana points 
                Console.WriteLine($"Max Player Mana Points:{player.PlayerMaxManaPoints}\n");
                Console.WriteLine($"Current Player Mana Points: {player.PlayerManaPoints}\n");
                Console.WriteLine($"Player Attack Points: {player.AttackPoints}\n");
                Console.WriteLine($"Player Magic Attack Points:{player.PlayerManaAttackPoints}\n");
                Console.WriteLine($"Player Defense Points : {player.PlayerDefensePoints}\n");
                Console.WriteLine($"Player Magic Defense points: {player.PlayerManaDefensePoints}\n");


            }
            void RoomAlreadyCleared(bool bRoomIsCleared, string checkpointString)
            {
                System.Console.WriteLine("This room has already been cleared");
                checkpointString="";
            }
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
                            DamageDealtToPlayer=0;
                            return DamageDealtToPlayer;
                        }
                        else
                        {
                            switch(magicAction)
                            {
                                case 1:
                                Console.WriteLine($"{enemy.EnemyName} used bite.\n");
                                DamageDealtToPlayer= character.CurrentHealthPoints-=enemy.EnemyAttackPoints/character.PlayerDefensePoints;
                                enemy.EnemyManaPoint-=15;
                                break;
                                case 2:
                                Console.WriteLine($"{enemy.EnemyName} used PLACEHOLDER\n");
                                break;
                                case 3:
                                Console.WriteLine($"{enemy.EnemyName} used a different PLACEHOLDER\n");
                                break;
                                default:
                                Console.WriteLine("ERR: Selected Attack does not exsist (Number Generator error)");
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
                                DamageDealtToPlayer=0;

                            }
                            else
                            {
                                switch(angelMagicAction)
                                {
                                    case 1:
                                    Console.WriteLine("Angel used Ball of Light\n");
                                     DamageDealtToPlayer=0;
                                    break;
                                    case 2:
                                    Console.WriteLine("Angel used PLACEHOLDER 2\n");
                                      DamageDealtToPlayer=0;
                                    break;
                                    case 3:
                                    Console.WriteLine("Angel used PLACEHOLDER 3\n");
                                      DamageDealtToPlayer=0;
                                    break;
                                    default:
                                    Console.WriteLine("ERR: Selected Attack is not real. (Number Generator error)");
                                    DamageDealtToPlayer=0;
                                    break;


                                }
                            }
                        break;
                        case EnemyNames.DARKSWORDSMAN:
                        // choose from the list of spells using random values
                        int dsMagicAction=magicinput.Next(1,3);
                        switch(dsMagicAction)
                        {
                            case 1:
                            // rename attack 
                            Console.WriteLine("Dark Swordsman used Acid Rain");
                            double baseDamage=78;
                                    double DamageDeal=character.PlayerManaDefensePoints /(enemy.EnemyManaAttackPoints+baseDamage);
                                   DamageDealtToPlayer= character.CurrentHealthPoints-=DamageDeal;
                                    Console.WriteLine($"You deal {DamageDeal.ToString()} points of damage from acid rain");
					                double acidRainPointsRequired=15;
					                character.PlayerManaPoints-=acidRainPointsRequired;
                            break;
                            case 2:
                            Console.WriteLine("Dark Swordsman used Void");
                                    double voidDamageDealt= character.PlayerManaDefensePoints/(enemy.EnemyManaAttackPoints*.25);
                                    DamageDealtToPlayer=character.CurrentHealthPoints-=voidDamageDealt;
                                    double voidManaCost=95;
                                    enemy.EnemyManaPoint-=voidManaCost;
                                    DamageDealtToPlayer=voidDamageDealt;
                            break;
                            case 3:
                            Console.WriteLine("Dark Swordsman used Double attack");
                            for (int i=0;i<2; i++ )
                            {

                            }
                            // DamageDealtToPlayer=0;
                            break;
                            default:
                            Console.WriteLine("ERR: Number Generator error");
                            break;
                        }
                        break;
                        case EnemyNames.VAMPIRE:
                        if(enemy.EnemyManaPoint<=0)
                            {
                                Console.WriteLine($"The {enemy.EnemyName} has no mana points, so the {enemy.EnemyName} plans its next attack.");
                                DamageDealtToPlayer=0;

                            }
                        // choose from the list of spells using random values
                        int vampireMagicAction=magicinput.Next(1,3);
                        switch(vampireMagicAction)
                        {
                            case 1:
                            Console.WriteLine("Vampire used Bite\n");
                            DamageDealtToPlayer= character.CurrentHealthPoints-=enemy.EnemyAttackPoints/character.PlayerDefensePoints;
                             enemy.EnemyManaPoint-=15;
                            break; 
                            case 2:
                            Console.WriteLine("Vampire used Life Drain\n");
                             Console.WriteLine($"{enemy.EnemyName} has used life drain\n");
                                double lifeTaken=character.CurrentHealthPoints-50;
                                enemy.CurrentHealthPoints+=lifeTaken;
                                Console.WriteLine($"it dealt {lifeTaken} points and healed the {enemy.EnemyName}. {enemy.EnemyHealth}'s new health is{enemy.CurrentHealthPoints}");
                            break;
                            case 3:
                            Console.WriteLine("Vampire transforms into mist\n");
                            enemy.CurrentHealthPoints=0;
                            DamageDealtToPlayer=0;
                            break;
                            default:
                            Console.WriteLine("ERR: Selected Attack is not in game. (Number Generator error)");
                            DamageDealtToPlayer=0;
                            break;
                        }
                        break;
                        case EnemyNames.ZOMBIE:
                        // choose from the list of spells using random values
                        int zombieMagicAction=magicinput.Next(1,3);
                        switch(zombieMagicAction)
                        {
                            case 1:
                            Console.WriteLine("Zombie used Bite");
				                double biteManaCost=10;
				                enemy.EnemyManaPoint-=biteManaCost;
				
                                // add in damage equation here
                                double biteDamageDealt=enemy.EnemyManaAttackPoints/character.PlayerManaDefensePoints;
                                DamageDealtToPlayer=biteDamageDealt;
                                //DamageDealt=biteDamageDealt;
                            break;
                            case 2:
                            Console.WriteLine("Zombie used PLACEHOLDER 1"); 
                            DamageDealtToPlayer=0;

                            break;
                            case 3:
                            Console.WriteLine("Zombie used PLACEHOLDER 2");
                            DamageDealtToPlayer=0;
                            break;
                            default:
                            Console.WriteLine("ERR: Selected Attack does not exsist (Number Generator error)");
                            DamageDealtToPlayer=0;
                            break;
                        }
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
		    HORNET,
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
                    enemyToCreate.EnemyManaDefensePoints=35;
                    enemyToCreate.EnemyManaPoint=50;
                    enemyToCreate.EnemyDefensePoints=70;
                break;
                case EnemyNames.VAMPIRE:
                enemyToCreate.EnemyName="Vampire";
                enemyToCreate.EnemyHealth=650;
                enemyToCreate.CurrentHealthPoints=enemyToCreate.EnemyHealth;
                enemyToCreate.EnemyManaDefensePoints=70;
                enemyToCreate.EnemyManaPoint=100;
                enemyToCreate.EnemyDefensePoints=80;
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

	// unknown enemy type (TBD Goes here)
    	case EnemyNames.Kitsune:
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

                default:
                Console.WriteLine("Err: Unrecognized Enemy Type\n Probably not created yet in the creation method");
                break;
		
            }
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
         Character CreateCharacter(PlayerClassTypes playerclass)
        {

            Character characterToCreate=new Character();
            while(characterToCreate.PlayerName=="")
            {
                System.Console.WriteLine("What is your name?\n");
                characterToCreate.PlayerName=Console.ReadLine();
            }
            characterToCreate.PlayerLevel=1;
            // set the player defense points by class not like below
            characterToCreate.PlayerDefensePoints=30;
            characterToCreate.PlayerClass=playerclass;
            switch(characterToCreate.PlayerClass)
            {
                case PlayerClassTypes.KNIGHT:
                    characterToCreate.AttackPoints=30;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=10;
                    characterToCreate.PlayerMaxManaPoints=20;
                    characterToCreate.PlayerManaPoints=characterToCreate.PlayerMaxManaPoints;
                break;
                case PlayerClassTypes.DARKMAGE:
                    characterToCreate.AttackPoints=30;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=60;
                    characterToCreate.PlayerManaDefensePoints=30;
                    characterToCreate.PlayerMaxManaPoints=350;
                    characterToCreate.PlayerManaPoints=characterToCreate.PlayerMaxManaPoints;

                break;
                case PlayerClassTypes.DARKSWORDSMAN:
                    characterToCreate.AttackPoints=40;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=300;
                    characterToCreate.PlayerManaDefensePoints=30;
                    characterToCreate.PlayerMaxManaPoints=characterToCreate.PlayerManaPoints;

                break;
                case PlayerClassTypes.MAGE:
                    characterToCreate.AttackPoints=30;
                    characterToCreate.PlayerHealth=300;
                    characterToCreate.CurrentHealthPoints=characterToCreate.PlayerHealth;
                    characterToCreate.PlayerExpPoints=0;
                    characterToCreate.PlayerManaAttackPoints=60;
                    characterToCreate.PlayerManaDefensePoints=30;
                    characterToCreate.PlayerMaxManaPoints=350;
                    characterToCreate.PlayerManaPoints=characterToCreate.PlayerMaxManaPoints;
                break;
            }
       
        
            return characterToCreate;
        }

            void BattleSystem(Character PlayerParty, Enemy enemy, MageSpells SpellList, DarkMageMagic DMSpellList, DarkSwordsmanMagic DSMagicList, string CheckpointName, bool BCanLose)
            {
                // if enemy is petrified increment the turnsSincePetrify at the end of each turn
               bool bIsPetrified=false;
               int turnsSincePetrify=0;
               double SpellCost=0;
               Console.WriteLine($"{enemy.EnemyName} has appeared!");
               string battlesystemchoice="" ;
               double DamageDealt=0;
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
                    DamageDealt=PlayerParty.AttackPoints-enemy.EnemyDefensePoints;
                    
                    if(DamageDealt<0)
                    {
                        DamageDealt*=-1;
                        enemy.CurrentHealthPoints-=DamageDealt;
                    } else
                    {
                        enemy.CurrentHealthPoints-=DamageDealt;
                    }
                   // System.Console.WriteLine($"DEBUG: ENEMY HAS  {enemy.CurrentHealthPoints.ToString()} of {enemy.EnemyHealth.ToString()}");
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
                                MageMagicChoice=Console.ReadLine();
                                switch(MageMagicChoice.ToLower())
                                {
                                    case"1":
                                    case"heal":
                                    MageMagicChoice=magicattackchoice;
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
                                    DamageDealt=0;
                                    //MageMagicChoice="";
                                   // System.Console.WriteLine($"DEBUG INFO MAGEMAGICATTACK={MageMagicChoice}");
                                    //battlesystemchoice="";
                                    break;
                                    case "2":
                                    case"fire":
                                    MageMagicChoice=magicattackchoice;
                                    Console.WriteLine($"{PlayerParty.PlayerName} casts fire");
                                    SpellCost=25; 
                                    double fireBaseDamage=25;
                                    DamageDealt=enemy.EnemyHealth-=(fireBaseDamage+PlayerParty.PlayerManaAttackPoints)/enemy.EnemyManaDefensePoints;
                                    PlayerParty.PlayerManaPoints-=SpellCost;
                                    Console.WriteLine($"You have {PlayerParty.PlayerManaPoints.ToString()} mana points remaining");
                                    // call damage dealt function
                                    //MageMagicChoice="";
                                     battlesystemchoice="";
                                    System.Console.WriteLine($"DEBUG INFO MAGEMAGICATTACK={MageMagicChoice}");
                                    break;
                                    default:
                                    //MageMagicChoice="";
                                    magicattackchoice="";
                                    ResetAndClear("Unexpected Input, resetting in 5 seconds",battlesystemchoice,5000, PlayerParty); 
                                    break;
                                    
                                }
                                break;
                            }
                            break;
                            
                            case PlayerClassTypes.DARKMAGE:
                            if(PlayerParty.PlayerManaPoints<=0)
                            {
                                Console.WriteLine("You dont have mana points please choose another option.\n");
                                battlesystemchoice="";
                            }
                            else {
                            string DarkMageMagicAttackChoice="";
                            while(DarkMageMagicAttackChoice=="")
                            {
                             Console.WriteLine("What magic attack would you like to use? \n 1)Lightning \n 2)Life Drain\n 3)Petrifaction\n");
                              DarkMageMagicAttackChoice=Console.ReadLine();
                              switch(DarkMageMagicAttackChoice.ToLower())
                              {
                                case"1":
                                case "lighting":
                                DarkMageMagicAttackChoice=magicattackchoice;
                                Console.WriteLine($"You used lightning\n");
                                int lightingBaseDamage=50;
                                DamageDealt=enemy.EnemyHealth-=(lightingBaseDamage*PlayerParty.AttackPoints)/enemy.EnemyManaDefensePoints;
                                Console.WriteLine($"You deal {DamageDealt} to the {enemy.EnemyName}");
                                //DarkMageMagicAttackChoice="";
                                battlesystemchoice="";
                                System.Console.WriteLine($"DEBUG INFO:DARKMAGEMAGICATTACKCHOICE= {DarkMageMagicAttackChoice}");

                                break;
                                case"2":
                                case"life drain":
                                DarkMageMagicAttackChoice=magicattackchoice;
                                Console.WriteLine($"{PlayerParty.PlayerName} has used life drain\n");
                                double lifeTaken=enemy.CurrentHealthPoints-50;
                                PlayerParty.CurrentHealthPoints+=lifeTaken;
                                DamageDealt=lifeTaken;
                                
                                Console.WriteLine($"it dealt {DamageDealt} points and healed the player. Your new health is{PlayerParty.CurrentHealthPoints}");
                                double maxHealth=PlayerParty.PlayerHealth;
                                if(PlayerParty.CurrentHealthPoints>maxHealth)
                                {
                                    PlayerParty.CurrentHealthPoints=maxHealth;
                                }
                                battlesystemchoice="";
                                //DarkMageMagicAttackChoice="";
                                 //System.Console.WriteLine($"DEBUG INFO:DARKMAGEMAGICATTACKCHOICE= {DarkMageMagicAttackChoice}");
                                break;
                                case"3":
                                case"petrification":
                                    // Come up with a way to have a damage dealt function that will have the player class, and the magic value
                                    enemy.bIsPetrified=true;
                                    DarkMageMagicAttackChoice=magicattackchoice;
                                    // if bIsPetrified =true; enemy cannot attack for 4 turns per spell cast;
                                     //System.Console.WriteLine($"DEBUG INFO:DARKMAGEMAGICATTACKCHOICE= {DarkMageMagicAttackChoice}");
                                    battlesystemchoice="";
                                break;
                                default:
                                ResetAndClear("Select from the 2 above options\n resetting in 5 seconds",battlesystemchoice,5000,PlayerParty);
                                break;

                              }
                              
                              Console.WriteLine($"You have {PlayerParty.PlayerManaPoints} mana points remaining. ");

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
                                    magicattackchoice =DarkswordsmanMagicChoice;
				                    double baseDamage=78;
                                    double DamageDeal= (PlayerParty.PlayerManaAttackPoints*baseDamage)/enemy.EnemyManaDefensePoints;
                                    enemy.CurrentHealthPoints-=DamageDeal;
                                    DamageDealt=DamageDeal;
                                    Console.WriteLine($"You deal {DamageDeal.ToString()} points of damage from acid rain");
					                double acidRainPointsRequired=15;
					                PlayerParty.PlayerManaPoints-=acidRainPointsRequired;
                                    battlesystemchoice="";
                                    //DamageDealtToPlayer();
                                    Console.WriteLine($"DEBUG INFO: DarkSwordsmanMagicChoice={DarkswordsmanMagicChoice}");

                                    break;
                                    case "2":
                                    case"void":
                                    // write void to take a quarter of health but take a high amount of mana points
                                    double voidDamageDealt= (PlayerParty.PlayerManaAttackPoints*25)/enemy.EnemyManaDefensePoints;
                                    enemy.CurrentHealthPoints-=voidDamageDealt;
                                    double voidManaCost=95;
                                    PlayerParty.PlayerManaPoints-=voidManaCost;
                                    DamageDealt=voidDamageDealt;
                                    magicattackchoice =DarkswordsmanMagicChoice;
                                    Console.WriteLine($" The {enemy.EnemyName} has taken {DamageDealt}");
                                    
                                    battlesystemchoice="";
                                    //Console.WriteLine($"DEBUG INFO: DarkSwordsmanMagicChoice={DarkswordsmanMagicChoice}");
                                    //DarkswordsmanMagicChoice="";
                                    break;
                                    default:
                                    ResetAndClear("Select from the 2 above options\n resetting in 5 seconds",battlesystemchoice,5000,PlayerParty);
                                    break;

                                }
                                
                            }
                            break;
                            case PlayerClassTypes.KNIGHT:
                            string knightSpcialOption="";
                            while(knightSpcialOption=="")
                            Console.WriteLine("What special attacks would you like to use?\n 1) Double attack\n");
                            knightSpcialOption=Console.ReadLine();
                            switch(knightSpcialOption.ToLower())
                            {
                                case"1":
                                case"double attack":
                                knightSpcialOption=magicattackchoice;
                                Console.WriteLine($"{PlayerParty.PlayerName} used double attack ");
                                double attackDoubleDamageDealt=PlayerParty.AttackPoints/enemy.EnemyDefensePoints;
                                // if it iterates once change the comparison to 2
                                for(int doubleAttackNum=0; doubleAttackNum<1; doubleAttackNum++)
                                {
                                    Console.WriteLine($"{PlayerParty.PlayerName} attacks dealing {attackDoubleDamageDealt.ToString()}points of damage");
                                    DamageDealt=enemy.CurrentHealthPoints-=attackDoubleDamageDealt*2;
                                }
                                // set damage dealt variable.
                                //Console.WriteLine($"KnightspcialOption= {knightSpcialOption}");
                                break;
                            }
                            

                            break;
                            default:
                            string errmessage="ERR: Unrecognized class please try something else";
                            ResetAndClear(errmessage,battlesystemchoice,5000,PlayerParty);
                            break;
                          }
                          
                           }
                           DoDamageToPlayer(PlayerParty,enemyNames, enemy);
                        }
                    
                    //Console.WriteLine("PLACEHOLDER: No Magic attacks\n");
                    break;
                    case"3":
                    // add in ai attack pattern
                    System.Console.WriteLine("You decided to Defend against the next attack.\n");
                    if(enemy.bIsPetrified==false)
                    {
                          // defend player is used for when the player decides to defend against an attack
                         double defendPlayer =DoDamageToPlayer(PlayerParty,enemyNames, enemy)*.2;
                         Console.WriteLine($"You have taken {defendPlayer} points of damage");
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
                        enemy.bIsPetrified=false;
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
                if(enemy.bIsPetrified==false)
                {
                      DoDamageToPlayer(PlayerParty,enemyNames, enemy);
                }
                else
                {
                    Console.WriteLine($"the {enemy.EnemyName} is petrified and cannot move");
                }
		// add a check to see if player health is 0 and if bCanLoose is ==true;
               
              
            }
         }
           //string MainMenuOption="";
           while(MainMenuOption=="")
           {
            Console.WriteLine("DH4 New Generation\n 1) New Game\n 2) Quit\n");
            MainMenuOption=Console.ReadLine();
            // menu switch
            switch(MainMenuOption.ToLower())
            {
                case"1":
                case"New Game":
                case "new game":
                string CheckpointName="AngelBattle";
                DSCharacter.MostRecentCheckpoint=CheckpointName;
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
                    
                    // this is the angel battle label called in the example of load game
                 // angel enemy object creation
                 enemyNames= EnemyNames.ANGEL;
                   Enemy AngelEnemy= CreateEnemy(enemyNames);
                
                 
                 BattleSystem(DSCharacter,AngelEnemy, spells, dmMagicSpells, DSMagicSpells, CheckpointName,false);
                System.Console.WriteLine("After a tense fight you beat the angel, however he is keen to let you know its not over.\n Angel: You haven’t won yet it is you who have underestimated the church and our leader. \nThe church is going to have your heads.");
                System.Console.WriteLine("Mage: We will deal with that when the time comes\n");
                PromptedClearScreen();
                System.Console.WriteLine("\n Chapter 1:The beginning\n400 Years Later\n");
                System.Console.WriteLine("Capt.Smith: Hey, wake up!\n you took quite a bump to the head.\n");
                System.Console.WriteLine("Capt. Smith:Can you tell me what your name is?\n");
                // character creation function goes here
                string playerName=Console.ReadLine();
                
              
                // set player class here
             
            string playerclass="";
            
            while(playerclass=="")
            {
                System.Console.WriteLine("What class would you like to be (Subject to change)\n1) Knight\n2)Dark Mage\n3) Mage\n4) Dark Swordsman");
                playerclass=Console.ReadLine();
                if(playerclass.ToLower()=="Knight" || playerclass.ToLower()=="1")
                {
                    playerclasslist=PlayerClassTypes.KNIGHT;
                     Character knightplayercharacter=CreateCharacter(playerclasslist);
                }
                else if(playerclass.ToLower()=="Mage"|| playerclass.ToLower()=="3")
                {
                    playerclasslist=PlayerClassTypes.MAGE;
                    Character mageplayercharacter=CreateCharacter(playerclasslist);              
                }
                else if (playerclass.ToLower()=="Dark Mage" || playerclass.ToLower()=="2")
                {
                    playerclasslist=PlayerClassTypes.DARKMAGE;
                     Character dmplayercharacter=CreateCharacter(playerclasslist);
                }
                else if(playerclass.ToLower()=="Dark Swordsman"|| playerclass.ToLower()=="4")
                {
                    playerclasslist=PlayerClassTypes.DARKSWORDSMAN;
                  
                }
                else 
                {
                    Console.WriteLine("Please Select from the 4 options");
                }
            }
                
              
               Character playercharacter=CreateCharacter(playerclasslist);
               playercharacter.PlayerName=playerName;
                
                System.Console.WriteLine($"Player Name: {playercharacter.PlayerName}\n Class: {playercharacter.PlayerClass}\n Level: {playercharacter.PlayerLevel}");
                System.Console.WriteLine("Capt.Smith: We will give you a few days to recover.\n");
                PromptedClearScreen();
                System.Console.WriteLine("A few days pass, and Capt smith returns to your quarters\n Captain Smith:We have a new order from her majesty\n ");
                System.Console.WriteLine($"{playercharacter.PlayerName}: What caused this uprising? \n Capt. Smith: Not really sure, but the church has been trying to occupy Askela village for as long as i can remember. \n Capt. Smith: They have been trying to rebuild it since the darkswordsman burned down the village unprovoked\n. ");
                string initBranchingPath="";
                playercharacter.MostRecentCheckpoint=initBranchingPath;
                int LiesTold=0;
                int TruthsTold=0;
                CheckpointName="Character Created";
                SerializeCharacter(playercharacter,CheckpointName);
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
                                       CheckpointName="AngelBattleRecollection";
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
                                                                                        SerializeCharacter(playercharacter, CheckpointName);
                                                                                        break;
                                                                                    case "2":
                                                                                        // battlesystem and zombie enemy creation goes here.
                                                                                        enemyNames = EnemyNames.ZOMBIE;
                                                                                        Enemy zombieEnemy = CreateEnemy(enemyNames);
                                                                                        BattleSystem(playercharacter, zombieEnemy, spells, dmMagicSpells, DSMagicSpells, TownPathLie,false);
                                                                                        CheckPlayerLevel(playercharacter);
                                                                                        SerializeCharacter(playercharacter,CheckpointName);
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
                                                                                            CheckpointName="Mission 1 AltPathTaken";
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
													                                                CheckpointName="ZombieBattlePostBeach1";
                                                                                                    bLiedAboutBeach=true;
                                                                                                    break;
                                                                                                    case"inform about zombies on the beach":
													                                                CheckpointName="ZombieBattlePostBeach2";
                                                                                                    Console.WriteLine($"{playercharacter.PlayerName}:Sorry, I had to sneak past a horde of zombies on the beach");
												                                                    Console.WriteLine("Captain Smith: Well, I am glad you made it out in one piece. \nYou're objective to go to what we believe is the house of the dark swordsman, and find out what he is planning ");
												                                                    Console.WriteLine("You start making your way through the  overrun village when suddenly...");
													                                                enemyNames=EnemyNames.BAT;
													                                                Enemy BatEnemy=CreateEnemy(enemyNames);
													                                                BattleSystem(playercharacter,BatEnemy, spells,dmMagicSpells,DSMagicSpells,dolieaboutbeach,false); 
                                                                                                    CheckPlayerLevel(playercharacter);
                                                                                                    SerializeCharacter(playercharacter,CheckpointName);
													                                                PromptedClearScreen();
                                                                                                    string help="";
                                                                                                    while(help=="")
                                                                                                    {
                                                                                                     Console.WriteLine("You defeated the bat, when you hear a cry for help do you \n 1) Investigate \n 2)Ignore it\n");   
                                                                                                     help=Console.ReadLine();
                                                                                                     switch(help.ToLower())
                                                                                                     {
                                                                                                        case"investigate":
                                                                                                        case"1":
                                                                                                        Console.WriteLine("You decide to disregard orders for the time being, and investigate where the scream came from.\n You head in the direction the scream came from.\n You find two zombies ");
                                                                                                        for(int numOfZombies=0; numOfZombies<1; numOfZombies++)
                                                                                                        {
                                                                                                            enemyNames=EnemyNames.ZOMBIE;
                                                                                                            Enemy zombieEnemyPostBeach=CreateEnemy(enemyNames);
                                                                                                            BattleSystem(playercharacter,zombieEnemyPostBeach,spells,dmMagicSpells,DSMagicSpells,help,false);
                                                                                                            CheckPlayerLevel(playercharacter);
                                                                                                            ShowPlayerStats(playercharacter); 
                                                                                                            SerializeCharacter(playercharacter,CheckpointName);
                                                                                                        }
                                                                                                        break;
                                                                                                        case "ignore":
                                                                                                        case "2":
                                                                                                        Console.WriteLine("You decide to ignore the scream and head to the house.");
                                                                                                        string dsHouseDecision="";
                                                                                                        while(dsHouseDecision=="")
                                                                                                        {
                                                                                                            CheckpointName="Mission 1 Halfway Point";
                                                                                                            SerializeCharacter(playercharacter,CheckpointName);
                                                                                                            Console.WriteLine("You walk up to the house, its a medium size house. What do you do?\n");
                                                                                                            Console.WriteLine("1) Walk around house \n2) Go inside \n");
                                                                                                            dsHouseDecision=Console.ReadLine();
                                                                                                            switch(dsHouseDecision.ToLower())
                                                                                                            {

                                                                                                                case"walk around house": 
                                                                                                                case"1":
                                                                                                                    Console.WriteLine("You walk aound the house, and on the left side of the house you find a garden full of fruits and vegetables.\n Though the house is not in disrepair, the lawn is overgrown, with green grass and daffodills.\n At the back of the house there is a swamp, you can hear the birds and cicadas. You decide to head back to the front of the building to go and explore the house itself.\n");
                                                                                                                    dsHouseDecision="";
                                                                                                                break;
                                                                                                                case "2":
                                                                                                                case "go inside house":

                                                                                                                    //Console.WriteLine("You walk into the house.");
                                                                                                                Console.WriteLine($"You go inside the house, walking into the kitchen, before you can look around and examine the house you see someone walking to a door. You call out to them\n {playercharacter.PlayerName}: Hello! My name is {playercharacter.PlayerName}\n Before you can finish your sentence they are gone.\n ");
                                                                                                                string dhinteriorpathalt="";
                                                                                                                while(dhinteriorpathalt=="")
                                                                                                                {
                                                                                                                    System.Console.WriteLine("Do you 1) Follow them\n 2) Leave and tell the captain that there was nothing here.");
                                                                                                                    dhinteriorpathalt=Console.ReadLine();
                                                                                                                    switch(dhinteriorpathalt.ToLower())
                                                                                                                    {
                                                                                                                        case"1":
                                                                                                                        case"follow them":
                                                                                                                        case "follow":
																                                                            Console.WriteLine("You decide to follow the figure. When you get to the door you shout 'Anyone there!?!?!' you get no response.\n ");
																                                                            Console.WriteLine("You enter a hallway that has three doors, a door to your left, a door to you right,and a door at the end of the hallway.\n Do you 1) take the door on your left\n  2)take the door on your right ");
																                                                            int roomsCleared=0;
 																                                                            // bools to check if each room has been cleared 
																                                                            bool bIsRightRoomCleared=false;
																                                                            bool bIsLeftRoomCleared=false;
																                                                            bool bIsLibraryCleared=false;
																                                                                while(roomsCleared<3)
																                                                                {
																	                                                                string roomChoice="";
																	                                                                    while(roomChoice=="")
																	                                                                        {
																		                                                                        Console.WriteLine("Which door would you like to check 1) the door on the left \n2) the door on the right \n 3) door at the end of the hallway.\n");
																		                                                                        roomChoice= Console.ReadLine();
																		                                                                            switch(roomChoice.ToLower())  
																			                                                                        {
																				                                                                        case"1":
																				                                                                        case"left":
																				                                                                        case"door on the left":
																					                                                                        if(bIsLeftRoomCleared==false)
																					                                                                        {
																						                                                                        // four hornets checking the players status everytime
																						                                                                        for(int numOfHornetsDefeated=0; numOfHornetsDefeated<4; numOfHornetsDefeated++)
																						                                                                        {
																							                                                                        enemyNames=EnemyNames.HORNET;
																							                                                                        Enemy HornetLRoomBoss=CreateEnemy(enemyNames); 
																							                                                                        BattleSystem(playercharacter, HornetLRoomBoss, spells,dmMagicSpells,DSMagicSpells,roomChoice,false);
                                                                                                                                                                    CheckPlayerLevel(playercharacter);
                                                                                                                                                                    ShowPlayerStats(playercharacter);
																						                                                                        }																						 
																						                                                                        bIsLeftRoomCleared=true;
																						                                                                        roomsCleared++;
																						                                                                        roomChoice="";
																						
																					                                                                        }
																					                                                                        else
																					                                                                        {
																						                                                                        Console.WriteLine("You have already cleared this room please clear the other rooms");
																						                                                                        roomChoice="";
																					                                                                        }
																					                                                                        break;
																				                                                                            case"2":
																				                                                                            case"right":
																				                                                                            case"door on the right":
																					                                                                            if(bIsRightRoomCleared==false)
																					                                                                            {
																						                                                                            // horde of zombies fight goes here
																						                                                                            for(int numOfZombiesDefeated=0; numOfZombiesDefeated<4; numOfZombiesDefeated++)
																						                                                                            {
																							                                                                            enemyNames=EnemyNames.ZOMBIE;
																							                                                                            Enemy ZombieHordeRightRoom=CreateEnemy(enemyNames);
																							                                                                            BattleSystem(playercharacter,ZombieHordeRightRoom,spells,dmMagicSpells,DSMagicSpells, roomChoice,false );
																							                                                                            // show player stats
                                                                                                                                                                        CheckPlayerLevel(playercharacter);
                                                                                                                                                                        ShowPlayerStats(playercharacter);
																					    	                                                                        }

																						                                                                            bIsRightRoomCleared=true;
																						                                                                            roomsCleared++;
																						                                                                            roomChoice="";
																					                                                                            }
																					                                                                            else
																					                                                                            {
																						                                                                            Console.WriteLine("You have already cleared this room please clear the other rooms");
																						                                                                            roomChoice="";
																					                                                                            }
																					
																				                                                                            break;
																			                                                                            	case"3":
																				                                                                            case"end of hallway":
                                                                                                                                                            playercharacter.CurrentHealthPoints=playercharacter.PlayerHealth;
																				
																				                                                                                // story before battle
																				                                                                                if(bIsLeftRoomCleared==true && bIsRightRoomCleared==true && roomsCleared==2)
																				                                                                                {
																					                                                                                //bossfight code (DarkSwordsman) goes here along with the story
																					                                                                                Console.WriteLine("You walk through the door to the library, it is dimly lit, and you see an a figure...");
																					                                                                                //Console.WriteLine("I have finally caught up to you!");
																					                                                                                string dsConfrontationPathChoice="";
																					                                                                                    while(dsConfrontationPathChoice=="")
																					                                                                                    {
																						                                                                                    Console.WriteLine("Something feels off. You can't quite put your finger on, but the presence in this room feels different. How do you proceed \n1) Approach with caution \n Approach with confidence.\n");
																							                                                                                dsConfrontationPathChoice=Console.ReadLine();
																							                                                                                    switch(dsConfrontationPathChoice.ToLower())
																							                                                                                    {
																								                                                                                    case"1":
																								                                                                                    case"approach with caution":
																								                                                                                    break;
																								                                                                                    case"2":
																								                                                                                    case "approach with confidence":
																								                                                                                        Console.WriteLine("We need to leave this area. It is over run with monsters!\n The figure stands with their back turned to you. Come with me if you want to live. Still no response from the figure. DID YOU HEAR ME YOUR LIFE IS IN DANGER!!!\nIf my  life was truely in danger I woudl be out there fighting until my final breath. The figure responds. ");
                                                                                                                                                                                        enemyNames=EnemyNames.DARKSWORDSMAN;
																					                                                                                                    Enemy DSBOSS1=CreateEnemy(enemyNames);
																					                                                                                                    BattleSystem(playercharacter, DSBOSS1,spells,dmMagicSpells,DSMagicSpells,roomChoice,true);
                                                                                                                                                                                        ShowEndofGameMessage(); 
                                                                                                                                                                                        bIsLibraryCleared=true;

																								                                                                                    break;
																								                                                                                    default:
                                                                                                                                                                                        ResetAndClear("Please select from the 2 above options. Resetting in 5 seconds\n",dsConfrontationPathChoice,5000,playercharacter);
																								                                                                                    break;
                                                                                                                                                                                     
																							                                                                                    }
																					                                                                                    }
																					


																				}																				
																				break;
																
																			}
																	}
																	
																}
                                                                                                                        break;
                                                                                                                        case "2":
                                                                                                                        case"Tell the captain nothing was here":
                                                                                                                        case"leave":
                                                                                                                        break;
                                                                                                                    }
                                                                                                                }
                                                                                                                break;
                                                                                                                default:
                                                                                                                ResetAndClear("Please select from the 2 above options!\n Reseting to current checkpoint in 5 seconds", dsHouseDecision,5000,playercharacter);
                                                                                                                break;
                                                                                                            }

                                                                                                        }
                                                                                                        break;
                                                                                                        default:
                                                                                                         ResetAndClear("Please select from the 2 above options!\n Reseting to current checkpoint in 5 seconds", help,5000,playercharacter);
                                                                                                        //reset and clear screen prompting the user to select one onf the 2 options listed
                                                                                                        break;
                                                                                                     }
                                                                                                    }
                                                                                                    break;
                                                                                                }
                                                                                            }


                                                                                        }
                                                                                        else if(TookAltPath==false)
                                                                                        {
                                                                                            CheckpointName="Mission 1";
                                                                                            Console.WriteLine($"You meet Captain smith in the village.\n {playercharacter.PlayerName}:woah, this town is over run with zombies and bats\n Captain smith: You're objective is to go to the house of the darkswordsman and see what is causing this infestation.\n");
												                                            Console.WriteLine("You start making your way through the  overrun village when suddenly...\n");
													                                        enemyNames=EnemyNames.BAT;
													                                        Enemy BatEnemy=CreateEnemy(enemyNames);
													                                        BattleSystem(playercharacter,BatEnemy,spells,dmMagicSpells,DSMagicSpells,forkingpathchoice,false); 
                                                                                            CheckPlayerLevel(playercharacter);
                                                                                            SerializeCharacter(playercharacter,CheckpointName);
                                                                                            // add in the story points here to keep the program going
                                                                                            System.Console.WriteLine("You hear a cry for help what do you do? \n 1) Help \n 2) ignore it\n");
                                                                                            string help=Console.ReadLine();
                                                                                            while(help=="")
                                                                                            {
                                                                                                if(help=="")
                                                                                                {
                                                                                                    System.Console.WriteLine("You hear a cry for help \n 1) Help \n 2) ignore it\n");
                                                                                                } 
                                                                                                else
                                                                                                {
                                                                                                    switch(help.ToLower())
                                                                                                    {
                                                                                                        case"1":
                                                                                                        case"help":
                                                                                                        case "investigate":
                                                                            
                                                                                                          Console.WriteLine("You decide to disregard orders for the time being, and investigate where the scream came from.\n You head in the direction the scream came from.\n You find two zombies ");
                                                                                                        for(int numOfZombies=0; numOfZombies<1; numOfZombies++)
                                                                                                        {
                                                                                                            enemyNames=EnemyNames.ZOMBIE;
                                                                                                            Enemy zombieEnemyPostBeach=CreateEnemy(enemyNames);
                                                                                                            BattleSystem(playercharacter,zombieEnemyPostBeach,spells,dmMagicSpells,DSMagicSpells,help,false);
                                                                                                            CheckPlayerLevel(playercharacter);
                                                                                                            SerializeCharacter(playercharacter,CheckpointName);
                                                                                                        }
                                                                                                         CheckpointName="Mission 1 Halfway Point";
                                                                                                         string dsHouseDecisionpath1="";
                                                                                                         while(dsHouseDecisionpath1=="")
                                                                                                         {
                                                                                                            System.Console.WriteLine("Do you 1)\nwalk around the outside of the house \n 2) go inside the house\n");
                                                                                                            dsHouseDecisionpath1=Console.ReadLine();
                                                                                                            switch (dsHouseDecisionpath1.ToLower())
                                                                                                            {
                                                                                                                case "1":
                                                                                                                case"Walk around outside of the house":
                                                                                                                case "walk around house":
                                                                                                                //System.Console.WriteLine("You decide to walk around the house\n");
                                                                                                                Console.WriteLine("You walk aound the house, and on the left side of the house you find a garden full of fruits and vegetables.\n Though the house is not in disrepair, the lawn is overgrown, with green grass and daffodills.\n At the back of the house there is a swamp, you can hear the birds and cicadas. You decide to head back to the front of the building to go and explore the house itself.\n");
                                                                                                                dsHouseDecisionpath1="";
                                                                                                                break;
                                                                                                                case "2":
                                                                                                                case "go inside":
                                                                                                                case"go inside house":
                                                                                                                 Console.WriteLine($"You go inside the house, walking into the kitchen, before you can look around and examine the house you see someone walking to a door. You call out to them\n {playercharacter.PlayerName}: Hello! My name is {playercharacter.PlayerName}\n Before you can finish your sentence they are gone.\n");
                                                                                                                 string dhinteriorpath="";
                                                                                                                 while(dhinteriorpath=="")
                                                                                                                 {
                                                                                                                    System.Console.WriteLine("Do you \n1) Follow them\n 2) Leave and tell the captain there was nothing here.\n");
                                                                                                                    dhinteriorpath=Console.ReadLine();
                                                                                                                    switch(dhinteriorpath.ToLower())
                                                                                                                    {
                                                                                                                        case"1":
                                                                                                                        case "follow them":
                                                                                                                        case "follow":
                                                                                                                        System.Console.WriteLine(" You walk through the door Anyone here!?!? \n No response.");
                                                                                                                        System.Console.WriteLine("You are now in a long hallway, with three doors, a door on the left, one on the right and one at the end of the hallway.");
                                                                                                                        string roomChoice="";
                                                                                                                        bool bIsLeftRoomCleared=false;
                                                                                                                        bool bIsRightRoomCleared=false;
                                                                                                                        bool bIsLibraryCleared=false;
                                                                                                                        int roomsCleared=0;
                                                                                                                        while(roomChoice==""|| roomsCleared<3)
                                                                                                                        {
                                                                                                                            System.Console.WriteLine("Which room would you like to invesigate 1) The room on the left\n 2) the room on the right \n 3) the room at the end of the hallway?\n");
                                                                                                                            roomChoice=Console.ReadLine();
                                                                                                                            switch(roomChoice.ToLower())
                                                                                                                            {
                                                                                                                                case "1":
                                                                                                                                case"left":
                                                                                                                                    // check to see if left room has already been cleared.
                                                                                                                                    if(bIsLeftRoomCleared==true)
                                                                                                                                    {
                                                                                                                                     RoomAlreadyCleared(bIsLeftRoomCleared,roomChoice);
                                                                                                                                    } 
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                    // horde of hornets 
                                                                                                                                    for (int numOfHornetsDefeated=0; numOfHornetsDefeated<4; numOfHornetsDefeated++)
                                                                                                                                    {
                                                                                                                                        enemyNames=EnemyNames.HORNET;
                                                                                                                                        Enemy HornetHorde= CreateEnemy(enemyNames);
                                                                                                                                        BattleSystem(playercharacter,HornetHorde,spells,dmMagicSpells,DSMagicSpells,roomChoice,false);
                                                                                                                                        playercharacter.CurrentHealthPoints=playercharacter.PlayerHealth;
                                                                                                                                        CheckPlayerLevel(playercharacter);
                                                                                                                                         ShowPlayerStats(playercharacter);
                                                                                                                                    }
                                                                                                                                    bIsLeftRoomCleared=true;
                                                                                                                                    }
                                                                                                                                break;
                                                                                                                                case"right":
                                                                                                                                case"2":
                                                                                                                                    if(bIsRightRoomCleared==true)
                                                                                                                                    {
                                                                                                                                        RoomAlreadyCleared(bIsRightRoomCleared,roomChoice);
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        // horde of zombies
                                                                                                                                        for(int numOfZombiesDefeated=0; numOfZombiesDefeated<6; numOfZombiesDefeated++)
                                                                                                                                        {
                                                                                                                                            enemyNames=EnemyNames.ZOMBIE;
                                                                                                                                            Enemy ZombieHorde2= CreateEnemy(enemyNames);
                                                                                                                                           BattleSystem(playercharacter,ZombieHorde2,spells,dmMagicSpells,DSMagicSpells,roomChoice,false);
                                                                                                                                           playercharacter.CurrentHealthPoints=playercharacter.PlayerHealth;
                                                                                                                                           CheckPlayerLevel(playercharacter);
                                                                                                                                            ShowPlayerStats(playercharacter);

                                                                                                                                        }
                                                                                                                                        bIsRightRoomCleared=true;
                                                                                                                                    }
                                                                                                                                break;
                                                                                                                                case"3":
                                                                                                                                case "end of hallway":
                                                                                                                                    playercharacter.CurrentHealthPoints=playercharacter.PlayerHealth;
                                                                                                                                    // story before boss battle
                                                                                                                                    if(bIsLeftRoomCleared==true&& bIsRightRoomCleared==true && roomsCleared==2)
                                                                                                                                    {
                                                                                                                                        if(LiesTold==2)
                                                                                                                                        {
                                                                                                                                            // add in lines to story to hint
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            string DSLibraryChoice="";
                                                                                                                                            while (DSLibraryChoice=="")
                                                                                                                                            {
                                                                                                                                                System.Console.WriteLine($"You walk through the door, it leads to a dimly lit library, You feel a hostile presence,\n Hello, my name is {playercharacter.PlayerName}, you shout. You get no response. \n Do you \n 1) Explore the library \n 2) Ask again to see if anyone responds");
                                                                                                                                                DSLibraryChoice=Console.ReadLine();
                                                                                                                                                switch(DSLibraryChoice.ToLower())
                                                                                                                                                {
                                                                                                                                                    case "1":
                                                                                                                                                    case "explore":
                                                                                                                                                    case "explore the library":
                                                                                                                                                        System.Console.WriteLine($"You explore the library going down each row of books, some look familar to you. As you pull out one of the books, a voice yells WHO GOES THERE?\n {playercharacter.PlayerName} you respond sheepishly.\n  ");
                                                                                                                                                        break;
                                                                                                                                                    case "2":
                                                                                                                                                    case"ask again":
                                                                                                                                                            Console.WriteLine($"Hello, my name is {playercharacter.PlayerName}. you belt out.\n Unknown voice: Who goes there?!");
                                                                                                                                                            PromptedClearScreen();
                                                                                                                                                            Console.WriteLine($"Weren't you listening? My name is {playercharacter.PlayerName} What busniess do you have here, the figure asks angerliy. \nI am investigaiting an infestation of the undead. My superiors have asked me to come here and see if the dark swordsman can give me some information on what happened.\n");
                                                                                                                                                            Console.WriteLine("The figure steps out from behind a bookshelf,\n the figure is revealed to be the dark swordsman. Really, thats interesting. He says sarcastically. \n  Before he continues, he looks at you, examining the crest on your armor. That crest, The order of the peace. Why have you come in search of me? he asked\n");
                                                                                                                                                            // prompt to see if the player wants to lie to the darkswordsman
                                                                                                                                                            string DSdialogChoice="";
                                                                                                                                                            while(DSdialogChoice=="")
                                                                                                                                                            {
                                                                                                                                                                Console.WriteLine("Do you \n 1) lie \n 2) Tell the truth.");
                                                                                                                                                                DSdialogChoice=Console.ReadLine();
                                                                                                                                                                switch(DSdialogChoice.ToLower()){
                                                                                                                                                                    case "1":
                                                                                                                                                                    case"lie":
                                                                                                                                                                        break;
                                                                                                                                                                    case"2":
                                                                                                                                                                    case"tell the truth":
                                                                                                                                                                        break;
                                                                                                                                                                    default:
                                                                                                                                                                       //esetAndClear()
                                                                                                                                                                        break;
                                                                                                                                                                }
                                                                                                                                                            }

                                                                                                                                                        break;
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }

                                                                                                                                    }
                                                                                                                                break;
                                                                                                                                default:
                                                                                                                                ResetAndClear("Please select from the 3 options. Resetting in 5 seconds\n",roomChoice,5000,playercharacter);
                                                                                                                                break;

                                                                                                                            }
                                                                                                                        }
                                                                                                                        break;
                                                                                                                        case"2": 
                                                                                                                        case "leave":
                                                                                                                        case"tell the captain":
                                                                                                                        System.Console.WriteLine("");
                                                                                                                        break;
                                                                                                                        default:
                                                                                                                        ResetAndClear("Please select from the 2 options above. Resetting in 5 Seconds",dhinteriorpath,5000,playercharacter);
                                                                                                                        break;
                                                                                                                    }
                                                                                                                 }
                                                                                                                 

                                                                                                                break;
                                                                                                                default:
                                                                                                                ResetAndClear("Please choose from the 2 options listed resetting in five seconds",dsHouseDecisionpath1,5000,playercharacter);
                                                                                                                break;
                                                                                                            }
                                                                                                         }
                                                                                                        break;
                                                                                                        case"2":
                                                                                                        case"ignore it":
                                                                                                        case"ignore":
                                                                                                        CheckpointName="Mission 1 Halfway Point";
                                                                                                         string dhHousePath="";
                                                                                                         while(dhHousePath=="")
                                                                                                         {
                                                                                                            System.Console.WriteLine("You ignore the cry for help and head to your objective.\n When you arrive at your destination  you see a ghostly figure, as you approach the house the figure goes inide the house. Do you follow the figure or explore the property\n");
                                                                                                            dhHousePath=Console.ReadLine();
                                                                                                            switch(dhHousePath.ToLower())
                                                                                                            {
                                                                                                                case"1":
                                                                                                                case"follow them":

                                                                                                                string dhHouseChoice="";
                                                                                                                while (dhHouseChoice=="")
                                                                                                                {
                                                                                                                    System.Console.WriteLine("You follow the figure into the house, you walk in the door to find that the figure is not there, you hear a scream from the hallway connected to the kitchen to the left of the entry way. What do you do? \n 1) Investigate the source of the scream \n 2) Exit the house");
                                                                                                                    dhHouseChoice=Console.ReadLine();
                                                                                                                    switch (dhHouseChoice.ToLower())
                                                                                                                    {
                                                                                                                        case"1":
                                                                                                                            string roomChoice="";
                                                                                                                            int roomsCleared=0;
                                                                                                                            while(roomChoice=="" || roomsCleared<3)
                                                                                                                            {
                                                                                                                                 System.Console.WriteLine("You decide to investigate, You enter the hallway, and you see a door at the very end, you also notice a door on your left and right. Which room would you like to investigate? \n 1) Left \n 2) Right \n 3) end of the hallway\n");
                                                                                                                                 roomChoice=Console.ReadLine();
                                                                                                                                 bool bIsLeftRoomCleared=false;
                                                                                                                                 bool  bIsRightRoomCleared=false;
                                                                                                                                 bool bIsLibraryCleared=false;
                                                                                                                                 switch(roomChoice.ToLower())
                                                                                                                                 {
                                                                                                                                    case"1":
                                                                                                                                    System.Console.WriteLine("You walk throught the door on your left, and you see 3 zombies");
                                                                                                                                    enemyNames=EnemyNames.ZOMBIE;
                                                                                                                                    for(int numOfZombiesDefeated=0; numOfZombiesDefeated<3; numOfZombiesDefeated++)
                                                                                                                                    {
                                                                                                                                        Enemy ZombieHorde=CreateEnemy(enemyNames);
                                                                                                                                        BattleSystem(playercharacter, ZombieHorde, spells, dmMagicSpells, DSMagicSpells, roomChoice,false);
                                                                                                                                        CheckPlayerLevel(playercharacter);
                                                                                                                                        ShowPlayerStats(playercharacter);
                                                                                                                                        PromptedClearScreen();
                                                                                                                                    }
                                                                                                                                    bIsLeftRoomCleared=true;
                                                                                                                                    roomsCleared++;
                                                                                                                                    if(bIsLeftRoomCleared==true)
                                                                                                                                    {
                                                                                                                                        // show message stating the the room was already cleared.
                                                                                                                                            RoomAlreadyCleared(bIsLeftRoomCleared, roomChoice);
                                                                                                                                    }
                                                                                                                                    break;
                                                                                                                                    case"2":
                                                                                                                                    // honet battle goes here
                                                                                                                                        System.Console.WriteLine();
                                                                                                                                        if(bIsRightRoomCleared==true)
                                                                                                                                        {
                                                                                                                                            RoomAlreadyCleared(bIsRightRoomCleared, roomChoice);
                                                                                                                                        }      
                                                                                                                                    break; 
                                                                                                                                    case "3":
                                                                                                                                    break;
                                                                                                                                 }
                                                                                                                            }
                                                                                                                        break;
                                                                                                                        case "2":
                                                                                                                        break;
                                                                                                                        default:
                                                                                                                        ResetAndClear("Please select from the 2 options. \nResetting in 5 seconds",dhHouseChoice,5000,playercharacter);
                                                                                                                        break;
                                                                                                                    }
                                                                                                                }
                                                                                                                break;
                                                                                                                case"2":
                                                                                                                case"explore the property":
                                                                                                                break;
                                                                                                                default:
                                                                                                                ResetAndClear("Please Choose from the 2 options listed.\n Resetting in 5 seconds",dhHousePath,5000,playercharacter);
                                                                                                                break;
                                                                                                            }
                                                                                                         }
                                                                                                         
                                                                                                        break;
                                                                                                        default:
                                                                                                        ResetAndClear("Please select from the above options. Resetting in 5 seconds",help,5000,playercharacter);
                                                                                                        break;
                                                                                                    }
                                                                                                }
                                                                                            }

                                                                                        }
											                                            PromptedClearScreen();
											
                                                                                        break;
                                                                                        case "2":
                                                                                        case "take other path":
                                                                                        TookAltPath=true;
                                                                                        //Console.WriteLine("You take the other path, it leads to a dead end.\n Do you \n 1) Explore the surrounding area \n 2) go back to the start of the path\n ");
                                                                                        string dogoback="";
                                                                                        while(dogoback=="")
                                                                                        {
                                                                                            
                                                                                            dogoback=Console.ReadLine();
                                                                                            Console.WriteLine("You take the other path, it leads to a dead end.\n Do you \n 1) Go back to the start of the path\n 2) Explore the surrounding area\n");
                                                                                            switch(dogoback.ToLower())
                                                                                            {
                                                                                                case"1":
                                                                                                case"go back to town":

                                                                                                Console.WriteLine("Decide to head back to the start of the path. ");
                                                                                                forkingpathchoice="";
                                                                                                break;
                                                                                                case"2":
                                                                                                case"keep exploring":
                                                                                                Console.WriteLine("You keep exploring, you find a river, however you dont have anything to fish with.\n");
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
                                        // start of game recollection.
                                        break;
                                        default:
                                        break;

                                    }
                                }
                                break;
                                case"2":
                                // question events lie path
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
               /* case "load game":
                case "3":
                case "load":
                LoadGame("DH4.Json");
                break; */
            }

           }
           
           
            
        }


    }
}
