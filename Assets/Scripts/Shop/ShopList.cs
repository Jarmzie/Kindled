using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopList
{
    List<ShopNode> myList = new List<ShopNode>();

    public void addNode(ShopNode newNode)
    {
        myList.Add(newNode);
        if (myList.Count == 1)
        {
            myList[0].next = myList[0];
            myList[0].prev = myList[0];
            return;
        }
        int tempLastIndex = myList.Count - 1;
        myList[tempLastIndex].next = myList[0];
        myList[0].prev = myList[tempLastIndex];
        myList[tempLastIndex].prev = myList[tempLastIndex - 1];
        myList[tempLastIndex - 1].next = myList[tempLastIndex];
    }

    public ShopNode getNode(int index)
    {
        return myList[index];
    }

    public int Count()
    {
        return myList.Count;
    }
}
