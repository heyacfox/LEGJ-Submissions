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

        addDrummers();

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

    public void addDrummers()
    {
        drumEles.Add(new musicianEles("Christian Vander", "I only perform in Kobaïan, the language I invented.", musicianType.drummer));
        drumEles.Add(new musicianEles("Travis Barker", "I'm an animalistic artist who performs fiercely and is unafraid to go theatrical.", musicianType.drummer));
        drumEles.Add(new musicianEles("Steven Adler", "I've got an exuberant, whiskey-soaked, youth-gone-wild pulse.", musicianType.drummer));
        drumEles.Add(new musicianEles("Cindy Blackman", "I've got improvisational instincts and formidable intergenre prowess.", musicianType.drummer));
        drumEles.Add(new musicianEles("Larry Mullen Jr.", "I've got an ear for the click track", musicianType.drummer));
        drumEles.Add(new musicianEles("Chris Dave", "I bring class to my bands", musicianType.drummer));
        drumEles.Add(new musicianEles("Meg White", "I'm childlike and incredible and inspiring", musicianType.drummer));
        drumEles.Add(new musicianEles("Tomas Haske", "I sound like the mechanized revving of a Lamborghini Diablo SV", musicianType.drummer));
        drumEles.Add(new musicianEles("Ralph Molina", "I'm the furthest thing imaginable from a cookie-cutter virtuoso.", musicianType.drummer));
        drumEles.Add(new musicianEles("Brian Chippendale", "I'm a study of extremes that you can dance to", musicianType.drummer));
        drumEles.Add(new musicianEles("Janet Weiss", "I'm the ferocious foundation of the alt-rock institution.", musicianType.drummer));
        drumEles.Add(new musicianEles("Bill Stevenson", "I fuel the exploration of everything from monolithic art metal to spastic punk-gone-jazz.", musicianType.drummer));
        drumEles.Add(new musicianEles("Jon Theodore", "I'm a player who has internalized the styles of key Seventies touchstones.", musicianType.drummer));
        drumEles.Add(new musicianEles("George Hurley", "I fuse funk, avant-rock and folk into beautifully abbreviated blasts of knotty revelation.", musicianType.drummer));
        drumEles.Add(new musicianEles("Phil Rudd", "I lay it down in the most economical, yet effective way.", musicianType.drummer));
        drumEles.Add(new musicianEles("Tommy Lee", "I have a fully see-through kit now so people can check out exactly what I'm doing", musicianType.drummer));
        drumEles.Add(new musicianEles("John Stanier", "My work is in reaction to the multi-instrumentality and complexity of the other guys", musicianType.drummer));
        drumEles.Add(new musicianEles("Ronald Shannon Jackson", "I synthesize blues shuffles with African syncopations through the lens of someone who gives vent to all manner of emotions", musicianType.drummer));
        drumEles.Add(new musicianEles("Glenn Kotche", "I have an indie rocker's experimental urges and some solid dad-rock chops", musicianType.drummer));
        drumEles.Add(new musicianEles("JR Robinson", "I have an innate ability to supercharge songs with subtle gestures.", musicianType.drummer));
        drumEles.Add(new musicianEles("Steve Jordan", "I'm a versatile performer equally skilled in extemporaneous jazz fusion and sparse, straightforward, soulful rock.", musicianType.drummer));
        drumEles.Add(new musicianEles("Mick Avory", "My playing is refined and low-key", musicianType.drummer));
        drumEles.Add(new musicianEles("Micky Waller", "I'm a jazz-trained fixture on the London blues scene", musicianType.drummer));
        drumEles.Add(new musicianEles("Moe Tucker", "I seem to dispense with keeping time altogether, swelling and stuttering with the emotional ebb and flow of the song.", musicianType.drummer));
        drumEles.Add(new musicianEles("Earl Young", "I invented the disco beat.", musicianType.drummer));
        drumEles.Add(new musicianEles("Earl Hudson", "I'm the chief architect of American hardcore.", musicianType.drummer));
        drumEles.Add(new musicianEles("Michael Shrieve", "I have a unique fusion of infectious Latin rhythms and explosive psychedelic rock", musicianType.drummer));
        drumEles.Add(new musicianEles("Pete Thomas", "I have an intuitive sense yielded by long-term collaboration.", musicianType.drummer));
        drumEles.Add(new musicianEles("James \"Diamond\" Williams", "My steady funk bottom can burst unexpectedly into rambunctious fills.", musicianType.drummer));
        drumEles.Add(new musicianEles("Butch Tracks and Jaimoe", "I mesh with Trucks' bluesy, rock-steady pulse to form a syncopated beat-logic all my own.", musicianType.drummer));
        drumEles.Add(new musicianEles("Tommy Ramone", "I made a call to arms for everyone to start their own bands.", musicianType.drummer));
        drumEles.Add(new musicianEles("Dale Crover", "I am equal parts earthquake machine, hard-sticking showman and ad hoc mathematician.", musicianType.drummer));
        drumEles.Add(new musicianEles("Jerome \"Bigfoot\" Brailey", "I've done shows with Parliament where I was so funky I could feel it inside my bones and that's when the audience can feel it too.", musicianType.drummer));
        drumEles.Add(new musicianEles("Greg Errico", "I make people's hair stand up, where that stage lifted off like a 747 and flew.", musicianType.drummer));
        drumEles.Add(new musicianEles("Kenny Aronoff", "My job is to listen, learn, lead. And I understand I'm not the boss.", musicianType.drummer));
        drumEles.Add(new musicianEles("Sly Dunbar", "My playing marks the place where roots reggae evolved into its dancehall successor.", musicianType.drummer));
        drumEles.Add(new musicianEles("Chad Smith", "I mix the quick-footedness of classic funk with an arena-rocker's power and volume.", musicianType.drummer));
        drumEles.Add(new musicianEles("Dennis Chambers", "I've honed a style built around bombastic grooves and scorched-earth Buddy Rich–esque fills that seemed to defy time.", musicianType.drummer));
        drumEles.Add(new musicianEles("Tony Thompson", "I hit the drums very hard. That's it!", musicianType.drummer));
        drumEles.Add(new musicianEles("Clem Burke", "I bring unexpected rhythm to the raw punk and New Wave roaring out of Seventies New York clubs like CBGBs.", musicianType.drummer));
        drumEles.Add(new musicianEles("Mick Fleetwood", "I have instinctive flair and childlike glee.", musicianType.drummer));
        drumEles.Add(new musicianEles("Jim Gordon", "I have a combination of bluesy feeling and professional finesse.", musicianType.drummer));
        drumEles.Add(new musicianEles("Sheila E.", "I bring a bringing her crisp, pristine, polyrhythmic style.", musicianType.drummer));
        drumEles.Add(new musicianEles("Manu Katché", "I vacillates between reggae lite, a jazz break and some mid-Eighties hip-hop boom 'n' pound with the smoothness of a DJ.", musicianType.drummer));
        drumEles.Add(new musicianEles("Richie Hayward", "I navigate discombobulated prog-boogie and unorthodox song structures while adding high vocal harmonies.", musicianType.drummer));
        drumEles.Add(new musicianEles("Max Winberg", "They ask, and I deliver for them night after night.", musicianType.drummer));
        drumEles.Add(new musicianEles("Ahmir \"Questlove\" Thompson", "I can sit in that pocket and drive it and think in terms of a wider landscape.", musicianType.drummer));
        drumEles.Add(new musicianEles("Jimmy Chamberlin", "I play like a deadly serious, jazz-indebted muso.", musicianType.drummer));
        drumEles.Add(new musicianEles("Matt Cameron", "I'm kind of known for playing weird, crazy fills and sometimes playing things I shouldn't be playing", musicianType.drummer));
        drumEles.Add(new musicianEles("Alex Van Halen", "I once played the entire opening with my hand broken in four places.", musicianType.drummer));
        drumEles.Add(new musicianEles("Cozy Powell", "I'm a hard-hitting power player vital to the development of English hard rock and heavy metal.", musicianType.drummer));
        drumEles.Add(new musicianEles("Vinnie Colaiuta", "I'm not there to show off a bunch of crap or be the center of attention. I'm there to blend in and be a part of it.", musicianType.drummer));
        drumEles.Add(new musicianEles("John \"Drumbo\" French", "I have a clattering and chaotic yet fiercely controlled approach. ", musicianType.drummer));
        drumEles.Add(new musicianEles("Dave Lombardo", "I'm a caffeine-head. I'm always ampin'. I can't sit still.", musicianType.drummer));
        drumEles.Add(new musicianEles("Dave Garibaldi", "I have sleek percolation.", musicianType.drummer));
        drumEles.Add(new musicianEles("Bily Cobham", "I marry jaw-dropping jazz-honed dexterity with pulverizing rock power.", musicianType.drummer));
        drumEles.Add(new musicianEles("Jerry Allison", "I once convinced my bandmate to change the name of a song to the name of a woman I was hoping to impress.", musicianType.drummer));
        drumEles.Add(new musicianEles("Phil Collins", "I became a vocalist because of severe nerve damage to my hands.", musicianType.drummer));
        drumEles.Add(new musicianEles("Bill Ward", "I brought a sense of stylish elasticity to the ominous trudge that defined my band's early work.", musicianType.drummer));
        drumEles.Add(new musicianEles("Carter Beauford", "I fill out even the most popular tracks with wildly complicated, incredibly busy licks.", musicianType.drummer));
        drumEles.Add(new musicianEles("Jack DeJohnette", "I like boxing, I'm a big boxing fan.", musicianType.drummer));
        drumEles.Add(new musicianEles("Ramon \"Tiki\" Fullwood", "My heavy style signaled the end of the band wearing suits, and turning towards a psychedelic potpourri that would change the world.", musicianType.drummer));
        drumEles.Add(new musicianEles("Jim Keltner", "I'm known for my solid backing, easygoing feel, jazz-schooled subtlety and versatility.", musicianType.drummer));
        drumEles.Add(new musicianEles("Jeff Porcano", "I always come up with the best parts instantly, like I've been playing the song for years.", musicianType.drummer));
        drumEles.Add(new musicianEles("Steve Smith", "I tour on the jazz fusion circuit.", musicianType.drummer));
        drumEles.Add(new musicianEles("Fred Below", "My range and virtuosic touch are crystal clear; without fuss or flourish, I fuel Chess' electric-blues engine.", musicianType.drummer));
        drumEles.Add(new musicianEles("Mickey Hart and Bill Kreutzmann", "Our duet evolved into a freely improvised ticket to unexplored musical regions, bringing the avant-garde to fields of rock fans the world over.", musicianType.drummer));
        drumEles.Add(new musicianEles("Tony Allen", "I'm a radically polyrhythmic groove machine. I'm a cool person.", musicianType.drummer));
        drumEles.Add(new musicianEles("James Gadson", "I just look over and smile and nail that fuckin' beat.", musicianType.drummer));
        drumEles.Add(new musicianEles("Roger Hawkins", "I excel at adapting my personal style to the needs of a session.", musicianType.drummer));
        drumEles.Add(new musicianEles("Clifton James", "I birthed that iconic proto-rock rumble.", musicianType.drummer));
        drumEles.Add(new musicianEles("Carlton Barrett", "I decelerate rocksteady's rhythm into the locked-in slow grooves that define classic roots reggae.", musicianType.drummer));
        drumEles.Add(new musicianEles("Carmine Appice", "I'm a valuable team player as well as a bruising power hitter with an instantly identifiable style.", musicianType.drummer));
        drumEles.Add(new musicianEles("Dave Grohl", "I turn independent grunge band to multi-platinum icons.", musicianType.drummer));
        drumEles.Add(new musicianEles("Danny Carey", "I don’t want to have people say, \"That guy is burning.\" I would rather hear them say, \"That reminds me of the Moors running down the hill, or Scotsmen attacking with their heads on fire, butt - naked in the middle of winter.\"", musicianType.drummer));
        drumEles.Add(new musicianEles("Earl Palmer", "I played the Flintstones theme.", musicianType.drummer));
        drumEles.Add(new musicianEles("Steve Gadd", "I give a decade of rock music a deep and gentle funkiness.", musicianType.drummer));
        drumEles.Add(new musicianEles("Elvin Jones", "Some people are more sensitive to rhythmic pulses, and the more sensitive you are, the more you can utilize the subtleties of timekeeping.", musicianType.drummer));
        drumEles.Add(new musicianEles("Levon Helm", "I have an inimitable deep-pocket groove and proudly drawling vocal style.", musicianType.drummer));
        drumEles.Add(new musicianEles("Iuan Paice", "I'm like a gigantic locomotive thundering down the tracks with everything totally in sync.", musicianType.drummer));
        drumEles.Add(new musicianEles("Bernard Purdie", "I got my start doing sessions with jazz artists like Nina Simone and Gabor Szabo.", musicianType.drummer));
        drumEles.Add(new musicianEles("Tony Williams", "I've re-committed myself to acoustic jazz, playing, as ever, take-no-prisoners intensity.", musicianType.drummer));
        drumEles.Add(new musicianEles("Joseph \"Zigaboo\" Modeliste", "I throw standard technique to the wind… punching out rollicking… rhythms with a stiff-armed attack.", musicianType.drummer));
        drumEles.Add(new musicianEles("Terry Bozzio", "I'm not really interested in the circus act part of it at all.", musicianType.drummer));
        drumEles.Add(new musicianEles("Bill Bruford", "I can find fresh angles in set-list staples, night after night, while also conjuring new music out of thin air.", musicianType.drummer));
        drumEles.Add(new musicianEles("Buddy Rich", "I did a sort of press-roll thing which lasted for about five minutes. It started off as a whisper, which you could barely hear, and it got so it filled the whole room of about 3,500 people and it was like thunder.", musicianType.drummer));
        drumEles.Add(new musicianEles("Ringo Starr", "My steady reliability is an early gold standard for no-nonsense rock players, serving each song with feel, swing and unswerving reliability.", musicianType.drummer));
        drumEles.Add(new musicianEles("D.J. Fontana", "I have incredible technique and fast hands.", musicianType.drummer));
        drumEles.Add(new musicianEles("Charlie Watts", "I have swinging grooves, taut four-on-the-floor rhythms, and understated impressionism.", musicianType.drummer));
        drumEles.Add(new musicianEles("Benny Benjamin", "I have a pulse, a steadiness, that keeps the tempo better than a metronome.", musicianType.drummer));
        drumEles.Add(new musicianEles("Steewart Copeland", "I'm known for my use of space, subtlety and aggression.", musicianType.drummer));
        drumEles.Add(new musicianEles("Al Jackson Jr.", "I helped pave the rhythmic future for both funk and hip-hop.", musicianType.drummer));
        drumEles.Add(new musicianEles("Mitch Mitchell", "I construct a tense, heavy groove then veer off into a fluid yet structured counterpoint.", musicianType.drummer));
        drumEles.Add(new musicianEles("Gene Krupa", "I do fundamentally easy things, but always made them look spectacular.", musicianType.drummer));
        drumEles.Add(new musicianEles("Clyde Stubblefield and John \"Jabo\" Starks", "Our innovations dictated the entire feel of hip-hop's Golden Era.", musicianType.drummer));
        drumEles.Add(new musicianEles("Hal Blaine", "I’m not flashy. I want to be a great accompanist.", musicianType.drummer));
        drumEles.Add(new musicianEles("Neil Peart", "I'm an obsessive craftsman and wildly ambitious artiste.", musicianType.drummer));
        drumEles.Add(new musicianEles("Ginger Baker", "I combine jazz training with a powerful polyrhythmic style.", musicianType.drummer));
        drumEles.Add(new musicianEles("Keith Moon", "I try to play with everyone in the band at once.", musicianType.drummer));
        drumEles.Add(new musicianEles("John Bonham", "I'm heavy, lively, virtuosic and deliberate.", musicianType.drummer));

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
