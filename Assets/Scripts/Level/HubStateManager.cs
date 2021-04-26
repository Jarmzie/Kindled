using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubStateManager : MonoBehaviour
{
    public ShopState myState = ShopState.FirstLoad;
    public TutorialState myTutState = TutorialState.FirstLoad;
    public ShopNode currLantern;

    [SerializeField]
    private Sprite inGameSprite;
    [SerializeField]
    private GameObject projectile;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        currLantern = new ShopNode(
            inGameSprite,
            inGameSprite,
            projectile,
            0.3f,
            false,
            "Hood Lantern",
            "You're trusty old lantern. Shoots a basic fireball that does decent damage."
        );
    }

    public enum ShopState
    {
        FirstLoad,
        SecondLoad,
        Default,
        ThirdLantern,
        FinishedGameInit,
        FinishedGame
    }

    public enum TutorialState
    {
        FirstLoad,
        GoodToGo
    }
}
