using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class LevelLogic : MonoBehaviour
{
    public GameObject enemySpawn, player, dialoguePrefab;
    private Image transitionImage;
    public GameObject[] currSpawnLocations;
    public Door exit, entrance;
    private GameObject levelTransition;
    public int currLevel = 0, roomsPerUpgrade = 3;
    private bool inUpgradeRoom = false;
    public HubStateManager hub;
    private Light2D myLight;

    void Awake()
    {
        player = GameObject.FindWithTag("PlayerLegs");
        transitionImage = player.transform.Find("Canvas").transform.Find("Image").GetComponent<Image>();
        levelTransition = transform.Find("ExitTrigger").gameObject;
        myLight = GetComponent<Light2D>();
        DontDestroyOnLoad(this.gameObject);

        //Update hub manager
        hub = GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>();
        if (hub.myState == HubStateManager.ShopState.FirstLoad)
        {
            hub.myState = HubStateManager.ShopState.SecondLoad;
        }
    }

    public void RoomFinished()
    {
        player.GetComponent<PlayerOilController>().inDark = false;
        if (!inUpgradeRoom)
        {
            player.GetComponent<PlayerOilController>().GainOilAmount(20 + (5 *currLevel));
        }
        foreach (GameObject torch in GameObject.FindGameObjectsWithTag("WallTorch"))
        {
            torch.GetComponent<WallTorch>().LetThereBeLight();
        }
        myLight.intensity = 0.15f;
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
        if (currLevel == 12) {
            StartCoroutine(FinalRoom());
            return;
        } else if (currLevel != 0 && currLevel % roomsPerUpgrade == 0 && !inUpgradeRoom) {
            inUpgradeRoom = true;
            FindObjectOfType<AudioManager>().Stop("CaveMusic");
            FindObjectOfType<AudioManager>().Stop("RuinMusic");
            FindObjectOfType<AudioManager>().Plays("UpgradeMusic");
            StartCoroutine(NewUpgradeRoom());
            return;
        } else if (inUpgradeRoom) {
            FindObjectOfType<AudioManager>().Stop("UpgradeMusic");
            if (currLevel >= 6)
            {
                FindObjectOfType<AudioManager>().Plays("RuinMusic");
            }
            else
            {
                FindObjectOfType<AudioManager>().Plays("CaveMusic");
            }

            inUpgradeRoom = false;
        }
        StartCoroutine(NewRandomRoom());
    }

    IEnumerator FinalRoom()
    {
        player.GetComponent<PlayerMovement>().CutsceneMe(false);
        transitionImage.GetComponent<Animator>().SetTrigger("EnterBlack");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("FinalLevel");
        yield return new WaitForSeconds(1);

        //Updates LevelLogic objects
        UpdateLevelLogic();

        myLight.intensity = 0.0f;
        player.transform.position = entrance.transform.position + new Vector3(0, -1, 0);
        transitionImage.GetComponent<Animator>().SetTrigger("ExitBlack");
        player.GetComponent<PlayerOilController>().inDark = false;
        player.GetComponent<PlayerMovement>().CutsceneMe(true);
        yield return null;
    }

    IEnumerator NewRandomRoom()
    {
        currLevel++;
        player.GetComponent<PlayerMovement>().CutsceneMe(false);
        transitionImage.GetComponent<Animator>().SetTrigger("EnterBlack");
        yield return new WaitForSeconds(1.5f);
        if (currLevel < 7)
        {
            SceneManager.LoadScene(Random.Range(1, 7));
        } else
        {
            SceneManager.LoadScene(Random.Range(7, 13));
        }
        yield return new WaitForSeconds(1);

        //Updates LevelLogic objects
        UpdateLevelLogic();

        //Sets up Enemy Spawner
        EnemySpawner roomES = Instantiate(enemySpawn, Vector2.zero, Quaternion.identity).GetComponent<EnemySpawner>();
        roomES.GeneralSetUp(currLevel, this);

        //Puts player into new level
        myLight.intensity = 0.0f;
        player.transform.position = entrance.transform.position + new Vector3(0, -1, 0);
        transitionImage.GetComponent<Animator>().SetTrigger("ExitBlack");
        player.GetComponent<PlayerOilController>().inDark = true;
        player.GetComponent<PlayerMovement>().CutsceneMe(true);
        yield return null;
    }

    IEnumerator NewUpgradeRoom()
    {
        player.GetComponent<PlayerMovement>().CutsceneMe(false);
        transitionImage.GetComponent<Animator>().SetTrigger("EnterBlack");
        yield return new WaitForSeconds(1.5f);
        if (currLevel < 6)
        {
            SceneManager.LoadScene("UpgradeLevel");
        } else
        {
            SceneManager.LoadScene("RedUpgradeRoom");
        }
        yield return new WaitForSeconds(1);

        //Updates LevelLogic objects
        UpdateLevelLogic();

        //Puts player into new level
        player.transform.position = entrance.transform.position + new Vector3(0, -1, 0);
        transitionImage.GetComponent<Animator>().SetTrigger("ExitBlack");
        player.GetComponent<PlayerMovement>().CutsceneMe(true);
        if (currLevel == 6 && !hub.ThirdLanternAquired)
        {
            if (hub.myState == HubStateManager.ShopState.SecondLoad)
            {
                hub.myState = HubStateManager.ShopState.SkippedSecondLoad2ThirdLoad;
            }
            else if (hub.myState == HubStateManager.ShopState.Default && !hub.ThirdLanternAquired)
            {
                hub.myState = HubStateManager.ShopState.ThirdLantern;
            }
            GameObject temp = Instantiate(dialoguePrefab);
            temp.GetComponent<Dialogue>().RunDialogue("", new string[] {
                "The walls look different here. That might mean I'm making progress.",
                "There's a lantern in the corner. I should take it and show it to the shop keeper."
            });
        }
        yield return null;
    }

    public void StartDeathCoroutine(GameObject player)
    {
        StartCoroutine(RestartForDeath(player));
    }

    public IEnumerator RestartForDeath(GameObject player)
    {
        yield return new WaitForSeconds(3f);
        transitionImage.GetComponent<Animator>().SetTrigger("EnterBlack");
        yield return new WaitForSeconds(1.5f);
        Destroy(player);
        FindObjectOfType<AudioManager>().Stop("CaveMusic");
        FindObjectOfType<AudioManager>().Stop("RuinMusic");
        FindObjectOfType<AudioManager>().Stop("deez");
        SceneManager.LoadScene("TownHub");
        Destroy(gameObject);
        yield return null;
    }

    public void StartRestartForFinish(GameObject player)
    {
        StartCoroutine(RestartForFinish(player));
    }

    private IEnumerator RestartForFinish(GameObject player)
    {
        if (hub.myState == HubStateManager.ShopState.SecondLoad || hub.myState == HubStateManager.ShopState.SkippedSecondLoad2ThirdLoad)
        {
            hub.myState = HubStateManager.ShopState.SkippedSecondLoad2FinalLoad;
        }
        else if (hub.myState == HubStateManager.ShopState.ThirdLantern)
        {
            hub.myState = HubStateManager.ShopState.SkippedThirdLoad;
        }
        else if (hub.myState == HubStateManager.ShopState.Default)
        {
            hub.myState = HubStateManager.ShopState.FinishedGameInit;
        }
        transitionImage.GetComponent<Animator>().SetTrigger("EnterBlack");
        yield return new WaitForSeconds(1.5f);
        Destroy(player);
        FindObjectOfType<AudioManager>().Stop("RuinMusic");
        FindObjectOfType<AudioManager>().Plays("TownHubMusic");
        SceneManager.LoadScene("TownHub");
        Destroy(gameObject);
        yield return null;
    }
}