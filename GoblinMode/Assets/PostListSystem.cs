using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostListSystem : MonoBehaviour
{
    public List<string> goodPostsOrigin;
    public List<string> badPostsOrigin;

    public List<string> goodPostsCopy;
    public List<string> badPostsCopy;

    public void refreshList()
    {
        goodPostsCopy.AddRange(goodPostsOrigin);
        badPostsCopy.AddRange(badPostsCopy);
    }

    public string getGoodPost()
    {
        if (goodPostsCopy.Count <= 0)
        {
            goodPostsCopy.AddRange(goodPostsOrigin);
        }
        int indexChosen = Random.Range(0, goodPostsCopy.Count);
        string chosenstr = goodPostsCopy[indexChosen];
        goodPostsCopy.RemoveAt(indexChosen);
        return chosenstr;
    }

    public string getBadPost()
    {
        if (badPostsCopy.Count <= 0)
        {
            badPostsCopy.AddRange(badPostsOrigin);
        }
        int indexChosen = Random.Range(0, badPostsCopy.Count);
        string chosenstr = badPostsCopy[indexChosen];
        badPostsCopy.RemoveAt(indexChosen);
        return chosenstr;
    }
}
