using UnityEngine;

using UnityEngine.UI; // обязательно добавляем библиотеку пользовательского интерфейса, без нее кино не будет

using System.Collections;

public class BackgroundHelper : MonoBehaviour
{

    public float speed = 0; //эта публичная переменная отобразится в инспекторе, там же мы ее можем и менять. Это очень удобно, чтобы настроить скорость разным слоям картинки

   // public GameObject player;

    float pos = 0; //переменная для позиции картинки

    public RawImage image; //создаем объект нашей картинки

 //   public float playerSpeed;

    public float height = 3;

    Vector3 startPos;


    void Start()
    {

      //  image = GetComponent<RawImage>();//в старте получаем ссылку на картинку

    //    startPos = player.transform.position;

    }



    void Update()
    {
      //  float playerY = player.transform.position.y;

   //     transform.position = new Vector3(transform.position.x, startPos.y+height, transform.position.z);
        //в апдейте прописываем как, с какой скоростью и куда мы будем двигать нашу картинку

        pos += speed*Time.deltaTime;

            if (pos > 1.0F)

            pos -= 1.0F;

        image.uvRect = new Rect(pos, 0, 1, 1);

    }



}