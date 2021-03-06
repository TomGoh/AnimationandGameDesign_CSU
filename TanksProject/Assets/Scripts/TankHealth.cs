using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankHealth : MonoBehaviour
{

    public int hp = 100;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;
    public GameObject winText1;
    public GameObject winText2;

    public Slider hpSlider;

    private int hpTotal;

    
    // Start is called before the first frame update
    void Start()
    {
        hpTotal=hp;
        hpSlider.value = 1.0f;
        winText1.SetActive(false);
        winText2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TankDamaged()
    {
        if (hp <= 0)
        {
            return;
        }
        hp -= Random.Range(10, 20);
        hpSlider.value=(float)hp/hpTotal;
      
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio,transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            Destroy(this.gameObject);
            if (GameObject.Find("Tank1") == this)
            {
                winText1.SetActive(true);
            }
            else
            {
                winText2.SetActive(true);
            }
        }
    }
}