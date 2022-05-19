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
    public int triosToMake = 5;



    public void Start()
    {
        drumEles = new List<musicianEles>();
        guitEles = new List<musicianEles>();
        bassEles = new List<musicianEles>();

        drumElesDecr = new List<musicianEles>();
        guitElesDecr = new List<musicianEles>();
        bassElesDecr = new List<musicianEles>();

        addDrummers();

        addGuitars();

        addBase();

        
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

    public void addGuitars()
    {
        guitEles.Add(new musicianEles("Lindsey Buckingham", "I transmute the folk music of my banjo-playing youth into stadium rock: glistening harmonized leads, crisply snapping chords and frenetic arpeggiated breakdowns.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Thurston Moore", "I mix strange drone tunings, jamming screwdrivers or drumsticks under my strings, and blast out feedback-swirled punk jams.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Alex Lifeson", "I have a seamless mix of lush arpeggios and rock crunch that sounds like at least two players at once.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Steve Jones", "Actually, I'm not into music. I'm into chaos.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Bruce Spingsteen", "I coax emotion from steel and wood.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Roger McGuinn", "My early hits were the sonic bridge between folk and rock.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Peter Buck", "My sound is both gorgeous and matter-of-factly aggressive.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Paul Simon", "I was weaned on early doo-wop and rock & roll and got caught up in the folk revival during the mid-Sixties.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Dimebag Darell", "I combine brutally precise, punk-honed grooves with splatter-paint melodic runs.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Dave Davies", "I created my signature distortion by slicing an amp speaker with a razor.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Tom Verlaine", "I'm a model for generations of guitarists with a taste for both punk violence and melodic flight.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Bonnie Raitt", "I fingerpick with the best and wield a slide like an old master.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Carl Perkins", "I have a bright, trebly style.", musicianType.guitarist));
        guitEles.Add(new musicianEles("James Hetfield", "I use a palm-muted, ultra-percussive chug.", musicianType.guitarist));
        guitEles.Add(new musicianEles("J Mascis", "I combine Black Sabbath savagery, melodic Neil Young soul, and punk-rock pig slop.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Andy Summers", "I recast jazz chords and reggae rhythms as headlong rock & roll.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Joe Perry", "My monstrous, blues-on-steroids riffs have a caffeinated energy.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Eddie Hazel", "I bring a thrilling mix of lysergic vision and groove power to all of my work.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Nels Cline", "I lurch into extended seizures or spiral into lyrical jam flights.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Lou Reed", "I'm proud of my own soloing, but resigned to the fact that most people aren't ready for it.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Buddy Holly", "I have an elemental style: an antsy mix of country and blues that merges rhythm and lead.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Mike Campbell", "I prefer the challenge to make your statement in a short amount of time as opposed to just stretching out.", musicianType.guitarist));
        guitEles.Add(new musicianEles("John Fahey", "I'm a master eccentric, a dazzling fingerpicker who transforms traditional blues forms with the advanced harmonies of modern classical music, then mines that beauty with a prankster's wit.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Willie Nelson", "My playing is deceptively laidback, playfully offbeat and instantly recognizable. ", musicianType.guitarist));
        guitEles.Add(new musicianEles("Robby Krieger", "I always feel like three players simultaneously.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Joni Mitchell", "I'm a folkie who learned to play what I call an indicated arrangement, where you are like a band in the way you approach a chord and string the melody along.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Dick Dale", "I have a hyperpercussive style I invented for my jukebox wonders and pioneered the sound of surf rock.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Kurt Cobain", "I use unconventional chord progressions and  and have a mastery of quiet-loud-quiet dynamics.", musicianType.guitarist));
        guitEles.Add(new musicianEles("John Frusciante", "I beef up sound with both well-placed fire and remarkable elegance.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Robert Johnson", "My style is slide and rhythm parts yelping in dialogue, riffs emerging from the mist.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Jack White", "I reconnect hard rock and roots music and show that a blues-based band can escape note-pushing Stratocaster white-blues bullshit.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Richard Thompson", "I use life-affirming riffs amid lyrics that made you want to jump off a bridge with a rock flatpick attack and speedy fingerpicking.", musicianType.guitarist));
        guitEles.Add(new musicianEles("John McLaughlin", "I'm a breakneck stylist, mixing psychedelic rock, R&B, gypsy jazz, flamenco and Indian raga techniques.", musicianType.guitarist));
        guitEles.Add(new musicianEles("T-Bone Walker", "I invented the guitar solo, building a new style on fluid phrasing, bluesy bends and vibrato.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Leslie West", "I play roughened blues lines with deceiving facility and an R&B flair, through a black forest of stressed-amp distortion.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Slash", "I bring good taste and restraint back to hard-rock.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Duane Eddy", "My style is curled with country twang and rippling with tremolo used it to thrash the music.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Johnny Winter", "I am both the whitest and the fastest.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Robert Fripp", "I am a singular blend of distorted complexity and magisterial sustain.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Dickey Betts", "I've got blues and slide chops,  but my roots are in jazz.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Ron Asheton", "I make the classic three-digit barre chord feel more like a superpowered battering ram: droning, relentless and almost mystical.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Robbie Robertson", "I want to do things that are so tasteful and discreet and subtle.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Peter Green", "I have Chicago-informed aggression heightened by melodic adventure.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Rory Gallagher", "I electrify Chicago and Delta styles with scalding slide work and hard-boiled songwriting.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Albert Collins", "I play with my thumb and forefinger instead of a pick to put a muscular snap into my piercing, trebly solos.", musicianType.guitarist));
        guitEles.Add(new musicianEles("John Lennon", "I'm not technically good, but I can make it fucking howl and move.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Joe Walsh", "I'm a fluid and intelligent player.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Otis Rush", "I've got a grittytreble tone and lacerating attack.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Clarence White", "I have dynamic precision and melodic symmetry.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Johnny Marr", "I'm not a showboating soloist, but a technician who can sound like a whole band.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Ritchie Blackmore", "I mix intricate classical composition with raw-knuckled blues rock.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Muddy Waters", "The way I play is lower, guttural, and it sounds like I'm about to rip the strings off.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Johnny Greenwood", "I'm an effects-loving wizard whose endlessly mutable style has powered my band's restless travels.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Stephen Stills", "I have a Latin-and country-inflected chime and a fervor for adventurous shredding.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Jerry Garcia", "I've got a theme in my playing, like putting beads on a string, instead of throwing them around a room.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Link Wray", "I stabbed my amplifier's speaker cone with a pencil to create the distorted, overdriven sound that would reverberate through metal, punk and grunge.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Mark Knopfler", "I show remarkable command over a range of tones and textures.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Hubert Sumlin", "I try to tell a story, tell it right, you live the story.nIt may be a little faster or a little classier, but it comes down to you playin' the blues or you ain't.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Mike Bloomfield", "I've got a piercing clean-treble tone and solos that take off with fluid, modal-jazz ecstasy.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Mick Ronson", "I want people to say, \"Wow, isn't that great, and isn't it simple ? \" If you get sort of fancy and cluttered, you're just baffling people with science.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Tom Morello", "I lean heavily on my effects pedals to create a new sonic vocabulary.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Steve Cropper", "I don't care about being center stage. I'm a band member, always been a band member.", musicianType.guitarist));
        guitEles.Add(new musicianEles("The Edge", "There's not a lot of strumming in my playing; I'm very much a servant to the melody.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Mick Taylor", "I've got a melodic touch, a beautiful sustain and a way of reading a song.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Randy Rhoads", "I play precise, architectural, hyperspeed solos.", musicianType.guitarist));
        guitEles.Add(new musicianEles("John Lee Hooker", "I perfected a droning, stomping groove, often in idiosyncratic time signatures and locked on one chord, with an ageless power.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Curtis Mayfield", "My music is built around flickering funk rhythms and spare, gestural, wah-wah-inflected lead parts.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Prince", "I played the greatest power-ballad solo in history, I can bring the nasty funk, and I can shread like the fiercest metalhead.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Billy Gibbons", "I'm spankin' the plank.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Ry Cooder", "I'm some kind of steam device gone out of control.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Elmore James", "My style is real simple, but every note is in the right spot – funky and nasty. ", musicianType.guitarist));
        guitEles.Add(new musicianEles("Scotty Moore", "My concise, aggressive runs mix country picking and blues phrasing into a new instrumental language.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Johnny Ramone", "I have a slashing, minimalist style that has appropriately become known as \"buzzsaw.\"", musicianType.guitarist));
        guitEles.Add(new musicianEles("Bo Diddley", "I unleash a superpowered version of a West African groove that was handed down by slaves.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Brian May", "I'm a brainy adventurer with an astrophysics degree who's always seeking new effects.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Tony Iommi", "There's a real finesse to my playing; it's not all that fast. My phrasing has such a classic vibe.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Angus Young", "I have a manic style. It's a color; I put it in for excitement.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Buddy Guy", "My flamboyant playing – huge bends, prominent distortion, frenetic licks, raise the standard.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Frank Zappa", "I fuse doo-wop, urban blues, big-band jazz and orchestral modernism with an iron hand.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Chet Atkins", "I invented the popwise \"Nashville sound\" that rescued country music from a commercial slump.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Carlos Santana", "My crystalline tone and clean arcing sustain make me the rare instrumentalist who can be identified in just one note.", musicianType.guitarist));
        guitEles.Add(new musicianEles("James Burton", "My trademark \"chicken pickin'\" style – bright, crisp and concise – is one of the most unique sounds in country music, and a huge influence on rock as well.",musicianType.guitarist));
        guitEles.Add(new musicianEles("Les Paul", "I created a groundbreaking series of technical innovations, including multilayered studio overdubs and varispeed tape playback, to achieve sounds nobody had ever come up with.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Neil Young", "My playing is like an open tube from my heart right to the audience.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Derek Trucks", "My style incorporates Delta blues, hard-bop jazz, the vocal ecstasies of Southern black gospel, and Indian-raga modality and rhythms.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Freddy King", "My style is sharpened-treble tone and curt melodic hooks.", musicianType.guitarist));
        guitEles.Add(new musicianEles("David Gilmour", "I'm drawn to floating, dreamy textures, but with a tone that would basically rip your face off. ", musicianType.guitarist));
        guitEles.Add(new musicianEles("Albert King", "Everything I do is wrong. ", musicianType.guitarist));
        guitEles.Add(new musicianEles("Stevie Ray Vaughan", "My monster tone, casual virtuosity and impeccable sense of swing can make a blues shuffle like \"Pride and Joy\" hit as hard as metal.", musicianType.guitarist));
        guitEles.Add(new musicianEles("George Harrison", "I have a way of getting right to the business, of finding the right thing to play.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Pete Townshend", "I'm exciting and aggressive – I'm a savage player, in a way.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Duane Allman", "I slide all over that melody.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Eddie Van Halen", "I get sounds that are a lot of harmonics, textures.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Chuck Berry", "I play a slightly heated-up version of Chicago blues, but I take it up to another level.", musicianType.guitarist));
        guitEles.Add(new musicianEles("B.B. King", "I play in shortened bursts, with a richness and robust delivery. And there is a technical dexterity, a cleanly delivered phrasing.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Jeff Beck", "My tone is so pure and delicate. It’s like there's a vocalist singing.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Keith Richards", "I don't think anyone has ever created a mood that dark and sinister as mine.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Jimmy Page", "My playing evolves through so many different changes – louder, quieter, softer, louder again.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Eric Clapton", "There is a basic simplicity to my playing, his style, my vibe and my sound.", musicianType.guitarist));
        guitEles.Add(new musicianEles("Jimi Hendeix", "My riffs are a pre-metal funk bulldozer, and my lead lines are an electric LSD trip down to the crossroads, where I pimp-slapped the devil.", musicianType.guitarist));

    }

    public void addBase()
    {
        bassEles.Add(new musicianEles("Thundercat", "I  combine a deep love of classic funk and fusion with influences ranging from yacht rock to nu-metal and neosoul.", musicianType.bassist));
        bassEles.Add(new musicianEles("Duff McKagan", "I don’t know where I’m rated. I don’t pay attention to that. I’m really so just all into my craft.", musicianType.bassist));
        bassEles.Add(new musicianEles("Kim Deal", "I have a distinct lack of needless flash.", musicianType.bassist));
        bassEles.Add(new musicianEles("Leland Sklar", "I'm a backup musician who can anchor ballads and midtempo rockers while never distracting from the singer or the song.", musicianType.bassist));
        bassEles.Add(new musicianEles("Peter Hook", "I'm a groove master cranking out the definitive riffs of my era, with plenty of outlaw mystique.", musicianType.bassist));
        bassEles.Add(new musicianEles("Esperanza Spalding", "I can croon old-school standardsand perform boldly futuristic originals that draw equally on smooth R&B and gnarly prog rock.", musicianType.bassist));
        bassEles.Add(new musicianEles("Joseph Makwela", "My aggressive yet buoyant style defines the mbaqanga groove on classics.", musicianType.bassist));
        bassEles.Add(new musicianEles("Mike Watt", "I rethink punk music from the ground up, creating short, sharp songs that incorporated funk, jazz, folk, blues, and even rap into my sound.", musicianType.bassist));
        bassEles.Add(new musicianEles("Tony Levin", "My style is, in simple terms, it’s finding just the right notes and playing them with just the right feel.", musicianType.bassist));
        bassEles.Add(new musicianEles("George Porter Jr.", "I provide round, fluid riffs that strut like a Second Line parade and rattle speakers with their heaviness.", musicianType.bassist));
        bassEles.Add(new musicianEles("Bill Black", "I can slap that thing!", musicianType.bassist));
        bassEles.Add(new musicianEles("Kin Gordon", "I have a guttural groove that sounds like an oncoming subway train.", musicianType.bassist));
        bassEles.Add(new musicianEles("Pino Palladino", "I lay down smooth, syncopated grooves.", musicianType.bassist));
        bassEles.Add(new musicianEles("John McVie", "I mix old-school rock solidity and California smooth, grounding the band’s sound.", musicianType.bassist));
        bassEles.Add(new musicianEles("Les Claypool", "One of the big things I decided to do when I was starting out was to play with three fingers. A lot of guys play with two fingers, so I figured if I played with three, I could be faster.", musicianType.bassist));
        bassEles.Add(new musicianEles("Louis Johnson", "I understand the value of Larry Graham’s window-rattling “thumpin’ and pluckin'” technique.", musicianType.bassist));
        bassEles.Add(new musicianEles("Richard Davis", "I'm at my best in intimate settings, where my profoundly empathic playing can shine.", musicianType.bassist));
        bassEles.Add(new musicianEles("Lemmy", "My aesthetic is all about reckless abandon.", musicianType.bassist));
        bassEles.Add(new musicianEles("Sting", "My throbbing, melodic lines cement my band’s iconic blend of New Wave and reggae.", musicianType.bassist));
        bassEles.Add(new musicianEles("Bernard Edwards", "I turn instantly head-nodding riffs into dance and pop classics.", musicianType.bassist));
        bassEles.Add(new musicianEles("Bob Moore", "My sophisticated stylings helped transform Nashville into one of the nation’s musical power centers", musicianType.bassist));
        bassEles.Add(new musicianEles("Tina Weymouth", "I set the stage for a tale of madness and fear.", musicianType.bassist));
        bassEles.Add(new musicianEles("Aston \"Family Man\" Barrett", "It’s like I am singing baritone. I create a melodic line each time.", musicianType.bassist));
        bassEles.Add(new musicianEles("David Hood", "I'm just trying to make pop music.", musicianType.bassist));
        bassEles.Add(new musicianEles("Israel Cachao López", "I hot-wire stately Havana ballroom music to create mambo, an Afro-Cuban fusion that would influence salsa, Cuban jazz, R&B, rock & roll, and by extension the entire constellation of Latin-influenced modern pop.", musicianType.bassist));
        bassEles.Add(new musicianEles("Cliff Burton", "I add orchestral flourishes and technical virtuosity to some of the hardest-hitting songs.", musicianType.bassist));
        bassEles.Add(new musicianEles("Geddy Lee", "My playing is tough and sinewy yet beautifully nimble and accented with just the right amount of daredevil flash.", musicianType.bassist));
        bassEles.Add(new musicianEles("Bill Wyman", "If I was ambitious I’d practice, but I don’t.", musicianType.bassist));
        bassEles.Add(new musicianEles("Flea", "I have an earthy, wildly charismatic hybrid of punk, funk, and psychedelia.", musicianType.bassist));
        bassEles.Add(new musicianEles("Geezer Butler", "I just play what I think is necessary for each song.", musicianType.bassist));
        bassEles.Add(new musicianEles("Rick Danko", "My work is spare, stylish, and always situated deep in the pocket.", musicianType.bassist));
        bassEles.Add(new musicianEles("Verdine White", "What I have to do on record is make sure that I’m complementing the singer. If I don’t hear the singer, I’m gonna play it, but it won’t have any imagination.", musicianType.bassist));
        bassEles.Add(new musicianEles("Chris Squire", "I have a thick, melodic tone.", musicianType.bassist));
        bassEles.Add(new musicianEles("Robbie Shakespeare", "I excel in the rubbery negative space of dub.", musicianType.bassist));
        bassEles.Add(new musicianEles("Charlie Haden", "I give even the most contemporary of styles a feeling of the eternal.", musicianType.bassist));
        bassEles.Add(new musicianEles("Donald \"Duck\" Dunn", "I master urbane pop balladry, country-soul shuffles, and uptempo gospel-infused soul all the same.", musicianType.bassist));
        bassEles.Add(new musicianEles("John Paul Jones", "I silently challenge everyone.", musicianType.bassist));
        bassEles.Add(new musicianEles("Stanly Clarke", "I have astonishing technique while always minding the groove.", musicianType.bassist));
        bassEles.Add(new musicianEles("Willie Dixon", "I developed my own undulating, genre-defining style.", musicianType.bassist));
        bassEles.Add(new musicianEles("Phil Lesh", "I ignore standard clichés.", musicianType.bassist));
        bassEles.Add(new musicianEles("Ron Carter", "Whether in a low-key duo or buoyant big band, I always add a touch of pure class.", musicianType.bassist));
        bassEles.Add(new musicianEles("Paul McCartney", "My playing conveys the yearning for a freer or more exciting life behind everyday lyrics.", musicianType.bassist));
        bassEles.Add(new musicianEles("Jaco Pastorius", "I play high-speed bebop with ease and dazzle with chiming harmonics.", musicianType.bassist));
        bassEles.Add(new musicianEles("Larry Graham", "I make all the melodic information mixed very loud … and the rhythmic information is mixed rather quietly.", musicianType.bassist));
        bassEles.Add(new musicianEles("Jack Bruce", "I play jittery, tumbling lines under the group's vocals.", musicianType.bassist));
        bassEles.Add(new musicianEles("Carol Kaye", "I give the title songs for everything from Batman to Mission Impossible their uniquely groovy backbone.", musicianType.bassist));
        bassEles.Add(new musicianEles("Bootsy Collins", "I sing cartoonish love songs with comic-book enthusiasm.", musicianType.bassist));
        bassEles.Add(new musicianEles("John Entwistle", "Every time I play a note it sounds like a vicious storm coming over the horizon.", musicianType.bassist));
        bassEles.Add(new musicianEles("Charles Mingus", "I have a relentless rhythmic drive that flows from my fingers through the strings and directly into my bands, making it sound as though the soloists are jumping on a giant trampoline.", musicianType.bassist));
        bassEles.Add(new musicianEles("James Jamerson", "I jolt my parts with extra syncopation, additional chords that add melodic depth and complexity, and make tonal choices that evoke gospel harmony.", musicianType.bassist));

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
