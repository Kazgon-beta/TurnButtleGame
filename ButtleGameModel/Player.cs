using System;
using System.ComponentModel;

namespace ButtleGameModel
{
    internal class Player:Character
    {
        public int Level { get; private set; }
        public int Exp { get; private set; }
        public int ExpToNextLevel {  get; private set; }
        public int HealPower { get; private set; }
        public int Gold { get; private set; } = 0;

        public Player(string name,int hp,int attack,int healPower):base(name,hp,attack)
        {
            // 【: base(...) とは？】
            // 親クラス（Character）のコンストラクタを呼び出す記法です。
            // 「共通の初期化は親に任せて、自分は自分専用の部分だけ初期化する」
            // という意味です。
            Level = 1;
            Exp = 0;
            ExpToNextLevel = 30;
            HealPower = healPower;
        }

        public void UseHerb()
        {
            Console.WriteLine($"{Name}は薬草を使った！");
            Heal(HealPower);
        }

        public void GainExp(int exp)
        {
            Exp += exp;
            Console.WriteLine($"{exp}EXPを獲得！({Exp}/{ExpToNextLevel})");

            if(Exp >= ExpToNextLevel)
            {
                LevelUp();
            }
        }

        public void EarnGold(int amount)
        {
            Gold += amount;
            Console.WriteLine($"{amount}Gを獲得！(全財産{Gold}G)");
        }

        public void LevelUp()
        {
            Level++;
            Exp -= ExpToNextLevel;
            ExpToNextLevel = (int)(ExpToNextLevel * 1.5f);

            //ステータスアップ
            //protected のおかげで子クラス空は編集が可能

            MaxHP += 20;
            HP = MaxHP;//レベルアップ時はHP全快
            Attack += 5;

            Console.WriteLine($"レベルアップ！Lv{Level}になった！");
            Console.WriteLine($"MaxHP =>{MaxHP} Attack+5 => {Attack}");
        }

        public override void ShowStatus()
        {
            //overrideとは
            //親クラスのvirtualと書かれたメソッドを上書きする宣言
            //プレイヤーはレベルや経験値も表示したいので独自の表示にします。

            base.ShowStatus();
            Console.WriteLine($"Lv:{Level} EXP:{Exp}/{ExpToNextLevel}");
        }

    }



}
