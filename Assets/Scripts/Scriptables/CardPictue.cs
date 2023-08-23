using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CardPic", menuName = "CreateCardPicture")]
public class CardPictue : ScriptableObject
{
    public int cardPictureID = -1;
    public Sprite cardDefaultSprite;
    public Sprite cardPictureSprite;
}



