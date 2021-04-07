using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLogic : MonoBehaviour
{
    public GameObject enemySpawn, player;
    private Image transitionImage;
    public GameObject[] currSpawnLocations;
    public Door exit, entrance;
    private GameObject levelTransition;
    public int currLevel = 0, roomsPerUpgrade = 3;
    private bool inUpgradeRoom = false;

    void Awake()
    {
        player = GameObject.FindWithTag("PlayerLegs");
        transitionImage = player.transform.Find("Canvas").transform.Find("Image").GetComponent<Image>();
        levelTransition = transform.Find("ExitTrigger").gameObject;
        DontDestroyOnLoad(this.gameObject);
    }

    public void RoomFinished()
    {
        player.GetComponent<PlayerOilController>().inDark = false;
        player.GetComponent<PlayerOilController>().GainOilAmount(50);
        //Make player stop losing oil
        exit.GetComponent<Door>().Open();
    }

    void UpdateLevelLogic()
    {
        entrance = GameObject.FindWithTag("Entrance").GetComponent<Door>();
        entrance.Close();
        exit = GameObject.FindWithTag("Exit").GetComponent<Door>();
        exit.Close();
        levelTransition.transform.position = exit.transform.position;
    }

    //Everything under here can be cleaned up

    public void NewRoom()
    {
        print("Level: " + currLevel + " InRoom?: " + inUpgradeRoom);
        if (currLevel != 0 && currLevel % roomsPerUpgrade == 0 && !inUpgradeRoom)
        {
            print("To Upgrade Room!");
            inUpgradeRoom = true;
            StartCoroutine(NewUpgradeRoom());
            return;
        } else if (inUpgradeRoom) {
            inUpgradeRoom = false;
        }
        print("To Random Room!");
        StartCoroutine(NewRandomRoom());
    }

    IEnumerator NewRandomRoom()
    {
        currLevel++;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerAnimation>().enabled = false;
        transitionImage.GetComponent<Animator>().SetTrigger("EnterBlack");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(Random.Range(1,4));
        yield return new WaitForSeconds(1);

        //Updates LevelLogic objects
        UpdateLevelLogic();

        //Sets up Enemy Spawner
        EnemySpawner roomES = Instantiate(enemySpawn, Vector2.zero, Quaternion.identity).GetComponent<EnemySpawner>();
        roomES.GeneralSetUp(currLevel, this);

        //Puts player into new level
        player.transform.position = entrance.transform.position + new Vector3(0, -1, 0);
        transitionImage.GetComponent<Animator>().SetTrigger("ExitBlack");
        player.GetComponent<PlayerOilController>().inDark = true;
        player.GetComponent<PlayerAnimation>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        yield return null;
    }

    IEnumerator NewUpgradeRoom()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerAnimation>().enabled = false;
        transitionImage.GetComponent<Animator>().SetTrigger("EnterBlack");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("UpgradeLevel");
        yield return new WaitForSeconds(1);

        //Updates LevelLogic objects
        UpdateLevelLogic();

        //Puts player into new level
        player.transform.position = entrance.transform.position + new Vector3(0, -1, 0);
        transitionImage.GetComponent<Animator>().SetTrigger("ExitBlack");
        player.GetComponent<PlayerAnimation>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        yield return null;
    }
}
