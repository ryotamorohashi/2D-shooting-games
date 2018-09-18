using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	//スコアを表示するGUIText
	//public GUIText scoreGUIText;
	public Text scoreGUIText;

	//ハイスコアを表示するGUIText;
	//public GUIText highScoreGUIText;
	public Text highScoreGUIText;
	//スコア
	private int score;

	//ハイスコア
	private int highScore;

	//PlayerPrefsで保存するためのキー
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		//スコアがハイスコアよりも大きければ
		if (highScore < score) {
			highScore = score;
	}

		//スコア・ハイスコアを表示する
		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.ToString ();
}

//ゲーム開始前の状態に戻す
	private void Initialize ()
	{
		//スコアを０に戻す
		score = 0;

		//ハイスコアを取得する。保存されてなければ０を取得する。
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}

	//ポイントの追加
	public void AddPoint (int point){
		score = score + point;
	}

	//ハイスコアの保存
	public void Save(){
		//ハイスコアを保存する
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();

		//ゲーム開始前の状態に戻す
		Initialize ();
	}
}