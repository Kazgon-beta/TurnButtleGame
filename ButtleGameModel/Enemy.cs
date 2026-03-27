using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ButtleGameModel
{
    internal class Enemy:Character
    {

        public int ExpReward {  get;private set; }
        public int GoldReward {  get;private set; }

        public Enemy(string name, int hp,int attack,int expRewaed,int goldRewaed):base(name,hp,attack)
        {
            ExpReward = expRewaed;
            GoldReward = goldRewaed;
        }

        public bool TakeTurn(Character target)
        {
            float hpRatio = (float)HP / MaxHP;
            if(hpRatio <= 0.3f)
            {
                return true;
            }
            else
            {
                AttackTo(target);
                return false;
            }
        }

        public void AttackTo(Character target)
        {
            Console.WriteLine($"{Name}の攻撃");
            target.TakeDamage(Attack);
        }

       
        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine($"倒すと{ExpReward}EXP/{GoldReward}G");
        }

    }
}
