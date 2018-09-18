using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {
	//移動スピード
	public float speed;

	//弾を打つ間隔
	public float shotDelay;

	//弾のprefab
	public GameObject bullet;

	//弾を打つかどうか
	public bool canShot;

	//爆発のprefab
	public GameObject explosion;

	//アニメーターコンポーネント
	private Animator animator;
	//爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	//弾の作成
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
	}

	public Animator GetAnimator()
	{
		return animator;
	}
		
}
