using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{

    public bool mChangeColor;
    public ShapeType mShapeType;
    public ColorType mColor;
    public GameManager mGameManager;

    private SpriteRenderer mSpriteRenderer;
    private bool mOtherShape;

    void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.mClicked)
        {
            if (mGameManager.mRequestedShape == mShapeType)
            {
                SetShapeColor(mGameManager.mRequestedColor);
                //mOtherShape = true;
            }

            // TODO rethink this logic
            // the shape should have any color randomally other than the requested color

            //else if(mGameManager.mRequestedShape != mShapeType && mOtherShape)
            //{
            //    int randomColorIdex = (int)(ColorType)Random.Range(0, 6);

            //    if(randomColorIdex != (int)mGameManager.mRequestedColor)
            //    {
            //        ColorType randColor = (ColorType)randomColorIdex;
            //        SetShapeColor(randColor);
            //    }

            //    mOtherShape = false;

            //}
        }

    }



    public void SetShapeColor(ColorType color)
    {
        mColor = color;
        mSpriteRenderer.color = mGameManager.mColors[color];
    }

    public ColorType GetShapeColor()
    {
        return this.mColor;
    }
}
