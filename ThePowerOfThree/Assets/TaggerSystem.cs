using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaggerSystem : MonoBehaviour
{

    public birdmusicer storedBird;
    public birdmusicer selectedDrummer;
    public birdmusicer selectedGuitarist;
    public birdmusicer selectedBassist;
    public string selectedBandName;
    public GetBandName gbn;
    public MusicianSpawner ms;
    public List<band> bandsFormed;
    public TMP_Text bandText;
    public TMP_Text insText;
    public Transform moveToSpot;
    public BandPlayLoop bpl;
    bool allBandsFormed = false;

    private void Start()
    {
        selectedBandName = gbn.getBandName();
        bandsFormed = new List<band>();
    }

    // Update is called once per frame
    void Update()
    {
        if (storedBird == null) return;
        if (storedBird.tagged) return;
        //j drums, k guitar, l base
        if (Input.GetKeyDown(KeyCode.J)) {
            if (selectedDrummer == null)
            {
                selectedDrummer = storedBird;
                storedBird.setTag(musicianType.drummer);
                storedBird = null;
            }
        } else if (Input.GetKeyDown(KeyCode.K))
        {
            if (selectedGuitarist == null)
            {
                selectedGuitarist = storedBird;
                storedBird.setTag(musicianType.guitarist);
                storedBird = null;
            }
        } else if (Input.GetKeyDown(KeyCode.L))
        {
            if (selectedBassist == null)
            {
                selectedBassist = storedBird;
                storedBird.setTag(musicianType.bassist);
                storedBird = null;
            }
        }

        if (selectedDrummer != null && selectedGuitarist != null && selectedBassist != null)
        {
            formBand();
        }
        if (!allBandsFormed) updateUI();

    }

    private void updateUI()
    {
        string dname = "";
        if (selectedDrummer != null)
        {
            dname = selectedDrummer.musicianName;
        }
        string gname = "";
        if (selectedGuitarist != null)
        {
            gname = selectedGuitarist.musicianName;
        }
        string bname = "";
        if (selectedBassist != null)
        {
            bname = selectedBassist.musicianName;
        }
        bandText.text = "Band Name: " + selectedBandName + "\n" +
            "Drummer(J): " + dname + "\n" +
            "Guitarist(K): " + gname + "\n" +
            "Bassist(L): " + bname + "\n" +
            "Bands Formed: " + bandsFormed.Count;
    }

    private void formBand()
    {
        band newBand = new band();
        newBand.bName = selectedBandName;
        newBand.drummerObj = selectedDrummer.gameObject;
        newBand.guitarObj = selectedGuitarist.gameObject;
        newBand.baseObj = selectedBassist.gameObject;
        selectedBandName = gbn.getBandName();
        selectedDrummer.assignToBand();
        selectedGuitarist.assignToBand();
        selectedBassist.assignToBand();
        bandsFormed.Add(newBand);
        selectedDrummer = null;
        selectedGuitarist = null;
        selectedBassist = null;

        if (bandsFormed.Count == ms.triosToMake)
        {
            allBandsFormed = true;
            Debug.Log("All bands made. Now what?");
            transform.position = moveToSpot.position;
            GetComponent<FourDirectionMovement>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera myCam = GetComponentInChildren<Camera>();
            myCam.transform.localPosition = new Vector3(0, 3.5f, -10);
            myCam.orthographicSize = 7;
            bandText.text = "";
            insText.text = "";
            bpl.startBandLoop(bandsFormed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we're at a bird
        if (collision.tag == "bird")
        {
            //if we don't have one stored
            if (storedBird == null)
            {
                //if the bird is not
                birdmusicer bm = collision.gameObject.GetComponent<birdmusicer>();
                
                if (!bm.tagged)
                {
                    storedBird = bm;
                    bm.selectBird();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (storedBird != null)
        {
            if (collision.GetComponent<birdmusicer>().musicianName == storedBird.musicianName)
            {
                storedBird.unselectBird();
                storedBird = null;
            }
        }
    }
        
}


public struct band
{
    public string bName;
    public GameObject drummerObj;
    public GameObject guitarObj;
    public GameObject baseObj;

}
