using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLivesBar : MonoBehaviour
{
    //[SerializeField]
   // private float ratio = 0.03F;
    private float length = 0.3F;

    private GameObject monsterLivesBarFull;

    private void Awake()
    {
        monsterLivesBarFull = GameObject.Find("MonsterLivesBarFull");
        //monsterLivesBarFull.transform.localScale += Vector3.forward * length;
        monsterLivesBarFull.transform.localScale = new Vector3(length,transform.localScale.y,transform.localScale.z);
     //   Debug.Log("mons");
    }

    public void Refresh(int lives, int livesMax)
    {
        // float scaleX =length - length / lives;
        //   float sector = length / livesMax*lives;
        // Узнаем длину каждого сектора
        float sectors = length / livesMax;
        // Длина каждого сектора
        //float sectorLength = length / sectors;
        // Всего нужно секторов
        float all = sectors * lives;

      //  transform.localScale = new Vector3(ratio*lives,transform.localScale.y,transform.localScale.z);
        transform.localScale = new Vector3(all,transform.localScale.y,transform.localScale.z);
    }
}
