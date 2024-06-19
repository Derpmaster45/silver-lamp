using System;
using DH4.Enums;
namespace DH4.Classes
{
    class Enemy
    {
        public string EnemyName{get;set;}
        public double EnemyAttackPoints{get;set;}
        public double EnemyDefensePoints{get; set;}
        public double EnemyHealth{get;set;}
        public double EnemyManaPoint{get;set;}
        public double EnemyMaxManaPoints{get; set;}
        public double CurrentHealthPoints{get;set;}
        public EnemyNames enemyType {get;set;}
        public int ExpValue {get;set;}
<<<<<<< HEAD
        public bool bIsPetrified{get;set;}
=======
        public bool bIsPetrified {get;set;}
>>>>>>> 478dc2f (bacon)
    }
}