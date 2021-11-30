using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ShapeType
{
    Circle,
    Diamond,
    Hexagon,
    Square,
    Triangle
}

public enum ColorType
{
    Blue,
    Red,
    Magenta,
    Grey,
    Cyan,
    Yellow

}

public class GameManager : MonoBehaviour
{

    public Dictionary<ColorType, Color> mColors =
    new Dictionary<ColorType, Color>();

    public ColorType mRequestedColor;
    public ShapeType mRequestedShape;
    public Image mShapeIndicatorUI;

    public Sprite[] mUISprites;

    //public Sprite SpriteUI;
    private bool isCoroutineExecuting = false;

    public static bool mClicked;
    private bool mFirstPlay = true;

    void Awake()
    {
        mColors.Add(ColorType.Blue, Color.blue);
        mColors.Add(ColorType.Red, Color.red);
        mColors.Add(ColorType.Magenta, Color.magenta);
        mColors.Add(ColorType.Grey, Color.grey);
        mColors.Add(ColorType.Cyan, Color.cyan);
        mColors.Add(ColorType.Yellow, Color.yellow);

        //mShapeIndicatorUI.sprite = SpriteUI;

    }

    private void Update()
    {
        if(mFirstPlay)
        {
            Reset();
            mFirstPlay = false;
        }
        
        StartCoroutine("ExecuteAfterTime");
    }


    public void Reset()
    {
        
        int randomColorIdex = (int)(ColorType)Random.Range(0, 6);
        int randomShapeIdex = (int)(ShapeType)Random.Range(0, 5);


        mRequestedColor = (ColorType)randomColorIdex;
        mRequestedShape = (ShapeType)randomShapeIdex;


        mShapeIndicatorUI.sprite = mUISprites[randomShapeIdex];
        mShapeIndicatorUI.color = mColors[mRequestedColor];

        mClicked = true;
    }

    IEnumerator ResetGame()
    { 

        yield return new WaitForSeconds(10);


    }


    IEnumerator ExecuteAfterTime()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(4);

        // Code to execute after the delay
        Reset();

        isCoroutineExecuting = false;
    }

}
