using DH4.Classes;
using DH4.Enums;
using System;
namespace DH4
{
    class Game
    {
        public void BattleSystem(Enemy enemy, Character playercharacter)
        {
            /**/
            while(playercharacter.CurrentHealthPoints==0|| enemy.CurrentHealthPoints==0)
            {
                
            }
        }
        public void QuitGame()
        {
            System.Console.WriteLine("Quittig game in 3 seconds\n");
            Thread.Sleep(3000);
            System.Console.WriteLine("GoodBye");
            Environment.Exit(0);
        }
        // game code goes here
        public static void Main(string[] args)
        {
            // title screen goes here

        }
    }
}