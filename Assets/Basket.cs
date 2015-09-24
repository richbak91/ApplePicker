using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;


	
	// Update is called once per frame
	void Update () {
		Vector3 mousepos2D = Input.mousePosition;
		mousepos2D.z = -Camera.main.transform.position.z;
		
		Vector3 mousepos3D = Camera.main.ScreenToWorldPoint (mousepos2D);
		Vector3 pos = this.transform.position;
		pos.x = mousepos3D.x;
		this.transform.position = pos;
	}

	void Start () {
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		scoreGT = scoreGO.GetComponent<GUIText> ();
		scoreGT.text = "0";	
	}

	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy(collidedWith);
		}

		int score = int.Parse (scoreGT.text);
		score += 100;
		scoreGT.text = score.ToString ();

		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}
