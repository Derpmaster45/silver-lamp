using System;
using DH4.Enums;
namespace DH4.Classes
{
    class Enemy
    {
        public string EnemyName{get;set;}
        public double EnemyAttackPoints{get;set;}
        public double EnemyDefensePoints{get; set;}
        public double EnemyHeath{get;set;}
        public double EnemyManaPoint{get;set;}
        public double CurrentHealthPoints{get;set;}
        public EnemyNames enemyType {get;set;}
    }
}