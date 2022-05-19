using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BandPlayLoop : MonoBehaviour
{
    public List<AudioClip> goodBandClips;
    public List<AudioClip> badBandClips;

    public List<band> bandList;
    public TMP_Text bandListings;
    public TMP_Text currBand;

    public Transform drumpos;
    public Transform guitpos;
    public Transform basspos;

    public Button restartButton;
    

    AudioSource bandSource;

    public void startBandLoop(List<band> bandsToUse)
    {
        bandList = bandsToUse;
        bandSource = GetComponent<AudioSource>();
        foreach (band oneBand in bandList)
        {
            bandListings.text = bandListings.text + oneBand.bName + "\n";
        }

        StartCoroutine("BandLoop");
    }

    IEnumerator BandLoop()
    {

        foreach(band oneBand in bandList)
        {
            bool goodBand = true;
            if (oneBand.baseObj.GetComponent<birdmusicer>().mType != musicianType.bassist) goodBand = false;
            if (oneBand.guitarObj.GetComponent<birdmusicer>().mType != musicianType.guitarist) goodBand = false;
            if (oneBand.drummerObj.GetComponent<birdmusicer>().mType != musicianType.drummer) goodBand = false;
            AudioClip clipToUse;
            if (goodBand)
            {
                Debug.Log("Good band");
                clipToUse = goodBandClips[Random.Range(0, goodBandClips.Count)];
            } else
            {
                Debug.Log("Bad band");
                clipToUse = badBandClips[Random.Range(0, badBandClips.Count)];
            }

            currBand.text = oneBand.bName;
            oneBand.baseObj.transform.position = basspos.transform.position;
            oneBand.drummerObj.transform.position = drumpos.transform.position;
            oneBand.guitarObj.transform.position = guitpos.transform.position;


            yield return new WaitForSeconds(1f);
            bandSource.clip = clipToUse;
            bandSource.Play();
            yield return new WaitForSeconds(clipToUse.length);
            oneBand.baseObj.transform.position = new Vector2(500, 500);
            oneBand.drummerObj.transform.position = new Vector2(500, 500);
            oneBand.guitarObj.transform.position = new Vector2(500, 500);
            yield return new WaitForSeconds(1f);
            

        }

        Debug.Log("All Done!");
        restartButton.gameObject.SetActive(true);
    }
}
