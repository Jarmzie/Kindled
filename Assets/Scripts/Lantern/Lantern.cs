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
    float shotSpeed = 1;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = mySprite;
        torso = transform.parent.gameObject.GetComponent<PlayerTorsoAnimation>();
        oil = transform.parent.gameObject.GetComponent<PlayerOilController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootYourShot());
        }
    }

    private IEnumerator ShootYourShot()
    {
        if (shooting)
        {
            yield break;
        }
        shooting = true;
        float temp = Mathf.Rad2Deg * Mathf.Atan2((Input.mousePosition.y - Screen.height / 2), (Input.mousePosition.x - Screen.width / 2));
        if (temp < 0)
        {
            temp = 360 + temp;
        }
        torso.shotAngle = temp;
        torso.ShootAtDirection();
        Vector2 delta = new Vector2(Input.mousePosition.y - Screen.height / 2, Input.mousePosition.x - Screen.width / 2);
        float theta = Mathf.Atan2(delta.x, delta.y);
        Vector2 shootDirection = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)).normalized;
        GameObject shotProjectile = Instantiate(myProjectile, transform.position, Quaternion.identity);
        shotProjectile.GetComponent<Rigidbody2D>().velocity = shootDirection * shotProjectile.GetComponent<Projectile>().speed;
        oil.LoseOilAmount(shotProjectile.GetComponent<Projectile>().GetDamage());
        yield return new WaitForSeconds(shotSpeed);
        shooting = false;
        yield return null;
    }
}
