using System;
using System.Dynamic;
using DH4.Enums;
namespace DH4.Classes
{
    [Serializable]
    public class Character
    {
         public string PlayerName{get;set;}
        public double AttackPoints{get;set;}
        public double PlayerDefensePoints{get; set;}
        public double PlayerHealth{get;set;}
        public int PlayerLevel{get;set;}
        public double PlayerManaPoints{get;set;}
        public double PlayerMaxManaPoints{get;set;}
        public double CurrentHealthPoints{get;set;}
        public PlayerClassTypes PlayerClass{get;set;}
        public int PlayerExpPoints{get;set;}
        public double PlayerManaAttackPoints{get; set;}
        public double PlayerManaDefensePoints{get;set;}

    }
}