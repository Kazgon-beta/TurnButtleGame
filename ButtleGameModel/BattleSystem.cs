using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleGameModel
{
    internal class BattleSystem
    {
        private Player _player;
        private Enemy _enemy;

       

        //アンダースコアを書く理由
        //クラスのフィールド＝メンバ変数であることを一目で分かるようにするための
        //コーディング規約


        //コンストラクタ:バトルの参加者をセットする。
        public BattleSystem(Player player,Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        private void PlayerTurn()
        {
            Console.WriteLine("行動を入力 attack or heal");
            string action = Console.ReadLine();
            Console.WriteLine("▶ プレイヤーのターン");

            if (action == "attack")
            {
                _player.AttackTo(_enemy);
                
            }
            else if (action == "heal")
            {
                _player.UseHerb();
            }
            else
            {
                Console.WriteLine("正しい文字を入力してください。");
            }
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

                PlayerTurn();

                //敵が倒れたか確認
                if (!_enemy.IsAlive())
                {
                    OnEnemyDefined();
                    
                    break;
                }

                //敵のターン
                bool enemyEscaped = _enemy.TakeTurn(_player);
                if(enemyEscaped)
                {
                    break;
                }
                Console.WriteLine();
               
          


                turn++;
            }

            ShowBattleResult();
        }

        private void ShowBattleResult()
        {
            Console.WriteLine("================================");

            if (_player.IsAlive() && !_enemy.IsAlive())
            {
                //プレイヤーが生き残っていたら勝利
                Console.WriteLine($"{_player.Name}の勝利");
            }
            else if (!_player.IsAlive() && _enemy.IsAlive())
            {
                Console.WriteLine($"{_enemy.Name}の勝利");
            }
            else
            {
                Console.WriteLine($"{_enemy.Name}は逃げ去った。");
            }

            Console.WriteLine("================================");
        }

       

        private void OnEnemyDefined()
        {
            Console.WriteLine($"{_enemy.Name}を倒した！");
            _player.GainExp(_enemy.ExpReward);
            _player.EarnGold(_enemy.GoldReward);
        }
    }
}
