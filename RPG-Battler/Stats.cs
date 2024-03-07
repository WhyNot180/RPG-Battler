using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG_Battler
{
    public class Stats
    {

        public int HP {  get; set; }
        public int MaxHP { get; set; }
        public int SP { get; set; }
        public int MaxSP { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int Luck { get; set; }
        public int Resistance { get; set; }
        public int Accuracy { get; set; }

        public Stats(Stats stats) : this()
        {
            addAll(stats);
        }

        public Stats(int maxHP, int maxSP, int speed, int damage, int defense, int luck, int resistance, int accuracy)
        {
            HP = maxHP;
            MaxHP = maxHP;
            SP = maxSP;
            MaxSP = maxSP;
            Speed = speed;
            Damage = damage;
            Defense = defense;
            Luck = luck;
            Resistance = resistance;
            Accuracy = accuracy;
        }

        public Stats()
        {
            HP = 0;
            MaxHP = 0;
            SP = 0;
            MaxSP = 0;
            Speed = 0;
            Damage = 0;
            Defense = 0;
            Luck = 0;
            Resistance = 0;
            Accuracy = 0;
        }

        public Stats addAll(Stats stats)
        {
            int maxHP = stats.MaxHP + this.MaxHP;
            int maxSP = stats.MaxSP + this.MaxSP;
            int speed = stats.Speed + this.Speed;
            int damage = stats.Damage + this.Damage;
            int defense = stats.Defense + this.Defense;
            int luck = stats.Luck + this.Luck;
            int resistance = stats.Resistance + this.Resistance;
            int accuracy = stats.Accuracy + this.Accuracy;

            return new Stats(maxHP, maxSP, speed, damage, defense, luck, resistance, accuracy);
        }
    }
}
