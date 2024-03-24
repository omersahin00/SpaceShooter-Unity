using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    public float heartPoint = 6;

    public Texture2D fullHeart;
    public Texture2D halfHeart;
    public Texture2D emptyHeart;

    private RawImage heart1;
    private RawImage heart2;
    private RawImage heart3;
    private RawImage heart4;
    private RawImage heart5;
    private RawImage heart6;

    private List<RawImage> heartList;

    void Start()
    {
        heart1 = transform.Find("Heart1").GetComponent<RawImage>();
        heart2 = transform.Find("Heart2").GetComponent<RawImage>();
        heart3 = transform.Find("Heart3").GetComponent<RawImage>();
        heart4 = transform.Find("Heart4").GetComponent<RawImage>();
        heart5 = transform.Find("Heart5").GetComponent<RawImage>();
        heart6 = transform.Find("Heart6").GetComponent<RawImage>();

        heartList = new List<RawImage> { heart1, heart2, heart3, heart4, heart5, heart6 };

        UpdateHeartImage();
    }


    public void DecreaseHeart(float amount)
    {
        if (heartPoint > 0)
            heartPoint -= amount;
        UpdateHeartImage();
    }


    private void UpdateHeartImage()
    {
        int decimalPart = ((int)(heartPoint * 10)) - (((int)heartPoint) * 10);

        int i;
        for (i = 0; i < (int) heartPoint; i++)
        {
            heartList[i].texture = fullHeart;
        }

        if (i == 6) return;

        if (decimalPart == 5) heartList[i++].texture = halfHeart;
        else if (decimalPart == 0) heartList[i++].texture = emptyHeart;

        if (i == 6) return;

        for ( ; i < 6; i++)
        {
            heartList[i].texture = emptyHeart;
        }
    }
}
