// See https://aka.ms/new-console-template for more information
//インスタンスの作成
//インスタンスとは、クラスを基に作った実体のこと。
//Charactorという設計図を基に「勇者」「スライム」というキャラクターを一体作る。

using ButtleGameModel;

Character player = new Character("勇者", hp: 100, attack: 20);
Character enemy = new Character("スライム",hp:80,attack: 20);

//クラスが一つでも異なるインスタンスを作成することができる。

//次はバトルクラスからインスタンスを生成。
//引数として、playerとenemyをセット。
//バトルクラス内のメソッドStartBattleを使ってバトル開始。

BattleSystem battle = new BattleSystem(player, enemy);
battle.StartBattle();





