using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardsSortsType
{
    ByColoumn,
    ByRow,
}

[Serializable]
public class CardsLayout
{
    public int noOfColOrRow;
    public CardsSortsType sortType;
    public Vector2 cardsWidthHeightMultiplier;
    public Vector2 cardsDistanceMultiplier;
}

public class CardsLayoutHandler : MonoBehaviour
{
    public Vector2 cardsWidthHeight;
    public Vector2 cardsDistance;
    public GridLayoutGroup cardsGridLayoutGroup;

    public List<CardsLayout> cardsLayoutsByLevels;

    CardsLayout currentLayout;
    GridLayout tempLayout;
    public void AdjustCardsLayoutByLevelNumber(int levelNumber)
    {
        currentLayout = cardsLayoutsByLevels[levelNumber];
        cardsGridLayoutGroup.constraintCount = currentLayout.noOfColOrRow;
        
        if (currentLayout.sortType == CardsSortsType.ByColoumn)
            cardsGridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        else if (currentLayout.sortType == CardsSortsType.ByRow)
            cardsGridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;

        cardsGridLayoutGroup.cellSize = new Vector2(currentLayout.cardsWidthHeightMultiplier.x * cardsWidthHeight.x, currentLayout.cardsWidthHeightMultiplier.y * cardsWidthHeight.y);
        cardsGridLayoutGroup.spacing = new Vector2(currentLayout.cardsDistanceMultiplier.x * cardsDistance.x, currentLayout.cardsDistanceMultiplier.y * cardsDistance.y);

    }

    public void ToggleGridLayout(bool toggle)
    {
        cardsGridLayoutGroup.enabled = toggle;
    }


}
