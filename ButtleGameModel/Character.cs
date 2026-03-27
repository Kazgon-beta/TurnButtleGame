using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleGameModel
{
    internal class Character
    {

        //フィールド
        //protected とは、このクラスと子クラスからしか編集できないということ。
        //子クラスからは使えるが、外からは触れない状態。（カプセル化）
        //get set の部分をプロパティと言う。getは読み込み、setは書きこみ。

        public string Name { get; protected set;}//名前
        public int HP{ get; protected set; }//現在のHP
        public int MaxHP{ get; protected set; }//最大HP
        public int Attack { get; protected set; }//攻撃力

        //コンストラクタ
        //クラスを基にインスタンスを作る時に
        //自動で一度だけ呼ばれる処理をコンストラクタという。

        public Character(string name,int hp,int attack)
        {
            Name = name;
            MaxHP = hp;
            HP = hp;
            Attack = attack;
        }

        //メソッド
        //クラスが持つ「行動の定義」
        //今回は攻撃「AttackTo」被攻撃「TakeDamage」の処理

        public void AttackTo(Character target)
        {
            Console.WriteLine($"{Name}の攻撃！");
            target.TakeDamage(Attack);
        }


        public void TakeDamage(int damage)
        {
            HP -= damage;
            if(HP < 0)
            {
                HP = 0;
            }

            Console.WriteLine($"{Name}は{damage}のダメージを受けた！（残りHP{HP}/{MaxHP}）");
        }

        public void Heal(int amount)
        {
            HP += amount;
            if (HP > MaxHP)
            {
                HP = MaxHP;
            }
            Console.WriteLine($"{Name}は{amount}回復した。（残りHP{HP}/{MaxHP}）");
        }



        //生きているかどうかを返す。
        //式形式メンバー　処理が一行のメソッドを短く書く。

        public bool IsAlive() => HP > 0;

        //HPバーの表示
        public virtual void ShowStatus()
        {
            //[virtualとは]
            //子クラス（override）で上書きしてもよいとい宣言
            string hpBar = GetHPBar();
            Console.WriteLine($"[{Name}] HP: {HP}/{MaxHP} {hpBar}");
        }
        //バーを文字で表現する
        private string GetHPBar()
        {
            int barLength = 10;
            int filledLength = (int)((float)HP / MaxHP * barLength);
            //int型をfloat型に変換、（最大HP１００で残り５０とかだと、int型だと0になる。）
            //割合を出す（上の例なら0.5）
            //バーの長さを10マス中いくつ埋まるかで表現(0.5*10＝５)
            //(int)で小数を切り捨て


            string filled = new string('█', filledLength);           // HP残量
            //new string(char, int)同じ文字を指定回数並べた文字列を作成する。
            string empty = new string('░', barLength - filledLength); // HP欠損分

            return $"[{filled}{empty}]";
        }
    }
}
