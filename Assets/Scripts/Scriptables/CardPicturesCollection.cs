using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardPicCollection", menuName = "CreateCardPictureList")]
public class CardPicturesCollection : ScriptableObject
{
    public List<CardPictue> allCardPictures;
}
