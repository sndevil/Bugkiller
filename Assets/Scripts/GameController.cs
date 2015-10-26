using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public gamestatus stat;
	public RectTransform canvastransform;
	public GameObject firstm, secondm, thirdm;
	public GameObject EndImage;

	public Text Scoretext,Resulttext;

	private int framecounter = 0, timecounter= 0;
	private float enemypersec = 0.2f;
	private bool list1clean = true, list2clean = false;
	private float enemyspeed = 3f;
	private int starttime = 0,levelcounter=0,level = 1,wave = 1;
	private int score = 0,lives = 3;
	private FarsiConvertor Farsisaz = new FarsiConvertor();



	public GameObject EnemyPrefab;

	List<GameObject> Enemylist = new List<GameObject>();
	List<GameObject> Enemylist2 = new List<GameObject>();

	// Use this for initialization
	void Start () {
		stat = gamestatus.running;
		firstm.SetActive (false);
		secondm.SetActive (false);
		thirdm.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			framecounter++;
			if (framecounter >= (int)30 / enemypersec) {
				levelcounter++;
				if (levelcounter > 3) {
					if (level < 10 && wave == 1) {
						enemyspeed += 2f;
						enemypersec *= 2f;
						wave++;
					}else if (level>= 10 && level < 25 && wave== 2)
					{
						enemyspeed += 2f;
						enemypersec *= 2f;
						wave ++;
					} else if (level >= 25 && level < 40 && wave == 3) {
						enemyspeed += 2f;
						enemypersec *= 2f;
						wave++;
					} else if (level >= 40 && level < 70 && wave == 4) {
						enemyspeed += 2f;
						enemypersec *= 2f;
						wave++;
					}

			
					levelcounter = 0;
					level++;
				}
				framecounter = 0;
				var posrnd = (int)(Random.Range (0, 10) / 5f) * level;
				posrnd %= 4;
				makeenemy (posrnd);
				if (levelcounter == (int)(Random.Range (0, 4)))
					makeenemy (posrnd + 1);
			}
		}
		Scoretext.text = score.ToString ();
		//var delta = Unixtime.Now()-

	}

	void makeenemy(int pos)
	{
		Vector3 position = new Vector3 (-400, 0, 0);
		var temp = (GameObject)Instantiate(EnemyPrefab);
		temp.transform.SetParent (canvastransform);
		temp.transform.localScale = new Vector3(1,1);

		var script = temp.GetComponent<AI1> ();
		switch (pos) {
		case 0:
			//entering left ground
			position = new Vector3(-400,0);
			script.goingright = true;
			script.speed = enemyspeed;
			//script.speed =
			break;

		case 1:
			//entering right ground
			position = new Vector3(400,-100);
			script.goingright = false;
			script.speed = -enemyspeed;
			break;

		case 2:
			//entering right sofa
			position = new Vector3(400, 280);
			script.goingright = false;
			script.speed = -enemyspeed;
			break;

		default:
			position = new Vector3(-300, 250);
			script.goingright = true;
			script.speed = enemyspeed;
			break;
		
		}
		//script
		temp.transform.localPosition = position;
		var controllerscript = temp.GetComponent<EnemyController> ();
		int id;
		if (Enemylist.Count >= 100)
			id = 100 + Enemylist2.Count;
		else
			id = Enemylist.Count;
		controllerscript.ID = id;
		controllerscript.ParentScript = this;
		if (id >= 100)
			Enemylist2.Add (temp);
		else
			Enemylist.Add(temp);
	}

	public void killenemy(int ID)
	{
		removeenemy (ID);
		score++;
		//Enemylist.RemoveAt (ID);
	}
	public void enemyscaped(int ID)
	{
		removeenemy (ID);
		lives --;
		if (lives == 2)
			firstm.SetActive (true);
		else if (lives == 1)
			secondm.SetActive (true);
		else if (lives == 0) {
			thirdm.SetActive (true);
			gameEnded();
		}

	}
	public void removeenemy(int ID)
	{
		if (ID >= 100)
			Destroy (Enemylist2 [ID - 100]);
		else
			Destroy (Enemylist [ID]);
		if (ID > 30 && !list2clean) {
			Enemylist2.Clear ();
			list2clean = true;
		} else if (ID == 30 && list2clean)
			list2clean = false;
		
		if (ID > 130 && !list1clean) {
			Enemylist.Clear ();
			list1clean = true;
		} else if (ID == 130 && list1clean)
			list1clean = false;
	}

	public void gameEnded()
	{
		Time.timeScale = 0;
		stat = gamestatus.paused;
		EndImage.SetActive (true);
		Resulttext.text = score.ToString ();
	}
	public void Restart()
	{
		foreach (GameObject g in Enemylist)
			Destroy (g);
		foreach (GameObject g in Enemylist2)
			Destroy (g);
		Enemylist2.Clear ();
		Enemylist.Clear ();
		level = 1;
		enemypersec = 0.2f;
		enemyspeed = 3f;
		score = 0;
		lives = 3;
		levelcounter = 0;
		framecounter = 0;
		timecounter = 0;
		Time.timeScale = 1;
		Start ();
		EndImage.SetActive (false);
	}
	
}
