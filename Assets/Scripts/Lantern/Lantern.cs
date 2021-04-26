using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField]
    Sprite mySprite;
    [SerializeField]
    GameObject myProjectile;
    PlayerTorsoAnimation torso;
    PlayerOilController oil;
    bool shooting = false;
    float shotSpeed = 0.3f;
    string lantName = "Hood Lantern";

    private void Awake()
    {
        ShopNode temp = GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>().currLantern;
        ShipOfTheseus(temp.getName(), temp.getInGameSprite(), temp.getProjectile(), temp.getShotSpeed());
        torso = transform.parent.gameObject.GetComponent<PlayerTorsoAnimation>();
        oil = transform.parent.parent.gameObject.GetComponent<PlayerOilController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (oil.inDark)
            {
                StartCoroutine(ShootYourShot());
            }
        }
    }

    public void ShipOfTheseus(string newName, Sprite newSprite, GameObject newProjectile, float newShotSpeed)
    {
        lantName = newName;
        mySprite = newSprite;
        GetComponent<SpriteRenderer>().sprite = mySprite;
        myProjectile = newProjectile;
        shotSpeed = newShotSpeed;
    }

    private IEnumerator ShootYourShot()
    {
        if (shooting)
        {
            yield break;
        }
        shooting = true;
        torso.shooting = false;
        float temp = Mathf.Rad2Deg * Mathf.Atan2((Input.mousePosition.y - Screen.height / 2), (Input.mousePosition.x - Screen.width / 2));
        if (temp < 0)
        {
            temp = 360 + temp;
        }
        torso.shotAngle = temp;
        torso.ShootAtDirection();
        GameObject shotProjectile = ShootTheWayIWantYouTo();
        oil.LoseOilAmount(shotProjectile.GetComponent<Projectile>().GetCost());
        yield return new WaitForSeconds(shotSpeed);
        for (int i = 0; i < 5; i++) // this is dumb but so is Unity so what can i say ¯\_(ツ)_/¯
        {
            torso.an.SetLayerWeight(i, 0);
        }
        torso.an.SetLayerWeight(0, 1);
        torso.shooting = false;
        shooting = false;
        yield return null;
    }

    public GameObject ShootTheWayIWantYouTo()
    {
        if (lantName == "Hood Lantern" || lantName == "Lava Lantern" || lantName == "Tiki Lantern")
        {
            Vector2 delta = new Vector2(Input.mousePosition.y - Screen.height / 2, Input.mousePosition.x - Screen.width / 2);
            float theta = Mathf.Atan2(delta.x, delta.y);
            Vector2 shootDirection = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)).normalized;
            GameObject shotProjectile = Instantiate(myProjectile, transform.position, Quaternion.identity);
            shotProjectile.GetComponent<Rigidbody2D>().velocity = shootDirection * shotProjectile.GetComponent<Projectile>().speed;
            return shotProjectile;
        } else if (lantName == "Candle Lantern")
        {

        }
        return Instantiate(myProjectile, transform.position, Quaternion.identity);
    }
}
