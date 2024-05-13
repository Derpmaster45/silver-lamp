using System;
using System.Dynamic;
using DH4.Enums;
namespace DH4.Classes
{
    public class Character
    {
         public string PlayerName{get;set;}
        public double AttackPoints{get;set;}
        public double PlayerDefensePoints{get; set;}
        public double PlayerHeath{get;set;}
        public int PlayerLevel{get;set;}
        public double PlayerManaPoints{get;set;}
        public double CurrentHealthPoints{get;set;}
        public PlayerClassTypes PlayerClass{get;set;}
        public int PlayerExpPoints{get;set;}

    }
}