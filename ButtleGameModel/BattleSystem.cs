using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleGameModel
{
    internal class BattleSystem
    {
        private Character _player;
        private Character _enemy;

        //アンダースコアを書く理由
        //クラスのフィールド＝メンバ変数であることを一目で分かるようにするための
        //コーディング規約


        //コンストラクタ:バトルの参加者をセットする。
        public BattleSystem(Character player,Character enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public void StartBattle()
        {
            Console.WriteLine("================================");
            Console.WriteLine("             バトル開始！！　　　　");
            Console.WriteLine("================================");
            Console.WriteLine();

            int turn = 1;

            //バトルループ

            while(_player.IsAlive()&& _enemy.IsAlive())
            {
                Console.WriteLine($"--------ターン{turn}-----------");

                //ステータス表示
                _player.ShowStatus();
                _enemy.ShowStatus();
                Console.WriteLine();

                //プレイヤーのターン
                Console.WriteLine("▶ プレイヤーのターン");
                _player.AttackTo(_enemy);
                Console.WriteLine();

                //敵が倒れたか確認
                if(!_enemy.IsAlive())
                {
                    break;
                }

                //敵のターン
                Console.WriteLine("▶ 敵のターン");
                _enemy.AttackTo(_player);
                Console.WriteLine();

                turn++;
            }

            ShowBattleResult();
        }

        private void ShowBattleResult()
        {
            Console.WriteLine("================================");

            if(_player.IsAlive())
            {
                //プレイヤーが生き残っていたら勝利
                Console.WriteLine($"{_player.Name}の勝利");
            }
            else
            {
                Console.WriteLine($"{_enemy.Name}の勝利");
            }

            Console.WriteLine("================================");
        }
    }
}
