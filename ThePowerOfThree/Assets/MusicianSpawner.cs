using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicianSpawner : MonoBehaviour
{
    public List<musicianEles> drumEles;
    public List<musicianEles> guitEles;
    public List<musicianEles> bassEles;

    public List<musicianEles> drumElesDecr;
    public List<musicianEles> guitElesDecr;
    public List<musicianEles> bassElesDecr;

    public GameObject birdPrefab;

    public List<Sprite> birdSprites;
    public int triosToMake = 2;



    public void Start()
    {
        drumEles = new List<musicianEles>();
        guitEles = new List<musicianEles>();
        bassEles = new List<musicianEles>();

        drumElesDecr = new List<musicianEles>();
        guitElesDecr = new List<musicianEles>();
        bassElesDecr = new List<musicianEles>();

        drumEles.Add(new musicianEles("Christian Vander", "I only perform in Kobaïan, the language I invented.", musicianType.drummer));
        drumEles.Add(new musicianEles("Travis Barker", "I'm an animalistic artist who performs fiercely and is unafraid to go theatrical.", musicianType.drummer));
        drumEles.Add(new musicianEles("Steven Adler", "I've got an exuberant, whiskey-soaked, youth-gone-wild pulse.", musicianType.drummer));

        guitEles.Add(new musicianEles("Lindsey Buckingham", "I transmute the folk music of my banjo-playing youth into stadium rock: glistening harmonized leads, crisply snapping chords and frenetic arpeggiated breakdowns.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Steve Jones", "Actually, I'm not into music. I'm into chaos.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Thurston Moore", "I mix strange drone tunings, jamming screwdrivers or drumsticks under my strings, and blast out feedback-swirled punk jams.", musicianType.guitarist));

        bassEles.Add(new musicianEles("Thundercat", "I  combine a deep love of classic funk and fusion with influences ranging from yacht rock to nu-metal and neosoul.", musicianType.bassist));
        bassEles.Add(new musicianEles("Duff McKagan", "I don’t know where I’m rated. I don’t pay attention to that. I’m really so just all into my craft.", musicianType.bassist));
        bassEles.Add(new musicianEles("Kim Deal", "I have a distinct lack of needless flash.", musicianType.bassist));

        drumElesDecr.AddRange(drumEles);
        guitElesDecr.AddRange(guitEles);
        bassElesDecr.AddRange(bassEles);
        for (int i = 0; i < triosToMake; i ++)
        {
            MakeBirdTrio();
        }
        
    }

    public void MakeBirdTrio()
    {
        makeOneBird(drumElesDecr);
        makeOneBird(guitElesDecr);
        makeOneBird(bassElesDecr);
    }

   public void makeOneBird(List<musicianEles> decrList)
    {
        GameObject birdd = Instantiate(birdPrefab);
        birdd.GetComponent<SpriteRenderer>().sprite = birdSprites[Random.Range(0, birdSprites.Count)];
        birdmusicer birddm = birdd.GetComponent<birdmusicer>();
        //maybe move it somewhere?
        int selectedd = Random.Range(0, decrList.Count);
        musicianEles ele = decrList[selectedd];
        decrList.RemoveAt(selectedd);
        birddm.setupMusicer(ele.mMess, ele.mName, ele.mType);
        float x = Random.Range(-25, 25);
        float y = Random.Range(-25, 25);
        birdd.transform.position = new Vector2(x, y);
    }

}

public struct musicianEles
{
    public string mName;
    public string mMess;
    public musicianType mType;

    public musicianEles(string n, string m, musicianType t)
    {
        mName = n;
        mMess = m;
        mType = t;
    }
}
