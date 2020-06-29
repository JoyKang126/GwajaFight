using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
    }

    //Reloads the Level
	public void Reload(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//controls the pausing of the scene
	public void pauseControl(){
		Debug.Log("pauseControl");
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
		if(Time.timeScale == 1)
		{
			Debug.Log("init");
			foreach (GameObject p in objs)
			{
				PlayerMovement instance = p.GetComponent<PlayerMovement>();
				instance.setFreeze(true);
			}
			Time.timeScale = 0;
			showPaused();
		} else {
			Debug.Log("it ran");
			foreach (GameObject p in objs)
			{
				PlayerMovement instance = p.GetComponent<PlayerMovement>();
				instance.setFreeze(false);
				Debug.Log("unpaused");
			}
			Time.timeScale = 1;
			hidePaused();
		}
	}

    //shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level){
		SceneManager.LoadScene(level);
	}
}
