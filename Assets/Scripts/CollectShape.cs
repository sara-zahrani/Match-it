using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShape : MonoBehaviour
{
    Shape mShape;
    public GameManager mGameManager;
    public Texture2D mCurserImage;
    public AudioClip mBurnSound;
    public AudioClip mWrongShape;

    private AudioSource mAduiosource;


    private void Awake()
    {
        mShape = GetComponent<Shape>();
        mAduiosource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (mShape.mShapeType == mGameManager.mRequestedShape
            && mShape.mColor == mGameManager.mRequestedColor)
        {
            mAduiosource.PlayOneShot(mBurnSound);
            GetComponent<SpriteRenderer>().enabled = false;
        }

        else
        {
            mAduiosource.PlayOneShot(mWrongShape);
        }

    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(mCurserImage, Vector2.zero, CursorMode.ForceSoftware);

    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
