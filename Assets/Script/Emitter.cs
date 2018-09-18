using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

	//waveプレハブを格納する
	public GameObject[] waves;



	//現在のwave
	private int currentWave;

	private int n;

	//Managerをコンポーネント
	private Manager manager;

	IEnumerator Start ()
	{

		//Managerコンポーネントをシーン内から取得する
		manager = FindObjectOfType<Manager> ();

		//Waveが存在しなければこルーチンを終了する
		if (waves.Length == 0) {
			yield break;
		}
			
		while (n++ < 5) {

			//タイトル表示中は待機
			while (manager.IsPlaying () == false) {
				yield return new WaitForEndOfFrame ();
			}

			//Waveを作成する
			GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);

			//WaveをEmitterの子要素にする
			wave.transform.parent = transform;

			//Waveの子要素のEnemyがすべて削除されるまで待機する
			while (wave.transform.childCount != 0) {
				yield return new WaitForEndOfFrame ();
			}

			//Waveの削除
			Destroy (wave);

			//格納されているWaveをすべて実行したらCurrentWaveを０にする(最初から　→ ループ)
			if (waves.Length <= ++currentWave) {
				currentWave = 0;
			}
		}
		FindObjectOfType<Manager>().GameOver();
	}
}
