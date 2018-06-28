using System;
using System.Collections.Generic;
using System.Linq;

namespace HuffmanAndMorseCompare
{
    public static class Compare
    {

        private static readonly string Text = $@"It was the White Rabbit, trotting slowly back again, and
looking anxiously about as it went, as if it had lost something;
and she heard it muttering to itself `The Duchess!  The Duchess!
Oh my dear paws!  Oh my fur and whiskers!  She'll get me
executed, as sure as ferrets are ferrets!  Where CAN I have
dropped them, I wonder?'  Alice guessed in a moment that it was
looking for the fan and the pair of white kid gloves, and she
very good-naturedly began hunting about for them, but they were
nowhere to be seen--everything seemed to have changed since her
swim in the pool, and the great hall, with the glass table and
the little door, had vanished completely.

  Very soon the Rabbit noticed Alice, as she went hunting about,
and called out to her in an angry tone, `Why, Mary Ann, what ARE
you doing out here?  Run home this moment, and fetch me a pair of
gloves and a fan!  Quick, now!'  And Alice was so much frightened
that she ran off at once in the direction it pointed to, without
trying to explain the mistake it had made.

  `He took me for his housemaid,' she said to herself as she ran.
`How surprised he'll be when he finds out who I am!  But I'd
better take him his fan and gloves--that is, if I can find them.'
As she said this, she came upon a neat little house, on the door
of which was a bright brass plate with the name `W. RABBIT'
engraved upon it.  She went in without knocking, and hurried
upstairs, in great fear lest she should meet the real Mary Ann,
and be turned out of the house before she had found the fan and
gloves.

  `How queer it seems,' Alice said to herself, `to be going
messages for a rabbit!  I suppose Dinah'll be sending me on
messages next!'  And she began fancying the sort of thing that
would happen:  `""Miss Alice!  Come here directly, and get ready
for your walk!"" ""Coming in a minute, nurse!  But I've got to see
that the mouse doesn't get out.""  Only I don't think,' Alice went
on, `that they'd let Dinah stop in the house if it began ordering
people about like that!'

  By this time she had found her way into a tidy little room with
a table in the window, and on it (as she had hoped) a fan and two
or three pairs of tiny white kid gloves:  she took up the fan and
a pair of the gloves, and was just going to leave the room, when
her eye fell upon a little bottle that stood near the looking-
glass.  There was no label this time with the words `DRINK ME,'
but nevertheless she uncorked it and put it to her lips.  `I know
SOMETHING interesting is sure to happen,' she said to herself,
`whenever I eat or drink anything; so I'll just see what this
bottle does.  I do hope it'll make me grow large again, for
really I'm quite tired of being such a tiny little thing!'

  It did so indeed, and much sooner than she had expected:
before she had drunk half the bottle, she found her head pressing
against the ceiling, and had to stoop to save her neck from being
broken.  She hastily put down the bottle, saying to herself
`That's quite enough--I hope I shan't grow any more--As it is, I
can't get out at the door--I do wish I hadn't drunk quite so
much!'

  Alas! it was too late to wish that!  She went on growing, and
growing, and very soon had to kneel down on the floor:  in
another minute there was not even room for this, and she tried
the effect of lying down with one elbow against the door, and the
other arm curled round her head.  Still she went on growing, and,
as a last resource, she put one arm out of the window, and one
foot up the chimney, and said to herself `Now I can do no more,
whatever happens.  What WILL become of me?'

  Luckily for Alice, the little magic bottle had now had its full
effect, and she grew no larger:  still it was very uncomfortable,
and, as there seemed to be no sort of chance of her ever getting
out of the room again, no wonder she felt unhappy.

  `It was much pleasanter at home,' thought poor Alice, `when one
wasn't always growing larger and smaller, and being ordered about
by mice and rabbits.  I almost wish I hadn't gone down that
rabbit-hole--and yet--and yet--it's rather curious, you know,
this sort of life!  I do wonder what CAN have happened to me!
When I used to read fairy-tales, I fancied that kind of thing
never happened, and now here I am in the middle of one!  There
ought to be a book written about me, that there ought!  And when
I grow up, I'll write one--but I'm grown up now,' she added in a
sorrowful tone; `at least there's no room to grow up any more
HERE.'

  `But then,' thought Alice, `shall I NEVER get any older than I
am now?  That'll be a comfort, one way--never to be an old woman-
-but then--always to have lessons to learn!  Oh, I shouldn't like
THAT!'

  `Oh, you foolish Alice!' she answered herself.  `How can you
learn lessons in here?  Why, there's hardly room for YOU, and no
room at all for any lesson-books!'

  And so she went on, taking first one side and then the other,
and making quite a conversation of it altogether; but after a few
minutes she heard a voice outside, and stopped to listen.

  `Mary Ann!  Mary Ann!' said the voice.  `Fetch me my gloves
this moment!'  Then came a little pattering of feet on the
stairs.  Alice knew it was the Rabbit coming to look for her, and
she trembled till she shook the house, quite forgetting that she
was now about a thousand times as large as the Rabbit, and had no
reason to be afraid of it.

  Presently the Rabbit came up to the door, and tried to open it;
but, as the door opened inwards, and Alice's elbow was pressed
hard against it, that attempt proved a failure.  Alice heard it
say to itself `Then I'll go round and get in at the window.'

  `THAT you won't' thought Alice, and, after waiting till she
fancied she heard the Rabbit just under the window, she suddenly
spread out her hand, and made a snatch in the air.  She did not
get hold of anything, but she heard a little shriek and a fall,
and a crash of broken glass, from which she concluded that it was
just possible it had fallen into a cucumber-frame, or something
of the sort.";
        
        public static void Main(string[] args)
        {
            Perform();
        }

        private static void Perform()
        {
            var t = Text.ToLower();
            HuffmanCoding.Coder.Perform(t);
            MorseCoding.Coder.Perform(t);

            var huffmanCodingTable = HuffmanCoding.Coder.GetCodingTable();
            var morseCodingTable = MorseCoding.Coder.GetCodingTable();

          
            // Remove non alphanumeric chars
            var nonAlphaNumericLettes = huffmanCodingTable.Where(item => !char.IsLetterOrDigit(item.Key)).ToArray();
            foreach (var item in nonAlphaNumericLettes)
            {
                huffmanCodingTable.Remove(item.Key);
            }


            // Remove not used chars in Morse coding table
            var notUsedChars = new List<char>();
            foreach (var item in morseCodingTable)
            {
                if (!huffmanCodingTable.ContainsKey(item.Key))
                    notUsedChars.Add(item.Key);
            }
  
            foreach (var c in notUsedChars)
            {
                morseCodingTable.Remove(c);
            }

            var huffmanCodingSortedTable = huffmanCodingTable.OrderBy(item => item.Key).ToArray();
            var morseCodingSortedTable = morseCodingTable.OrderBy(item => item.Key).ToArray();

            Console.WriteLine("Coding efficiency:");
            Console.WriteLine($"|{"Character",15}" +
                            $"|{$"Huffman coding",20}" +
                            $"|{$"Morse coding",15}");
            for (int i = 0; i < huffmanCodingSortedTable.Length; i++)
            {
                Console.WriteLine($"|{huffmanCodingSortedTable[i].Key,15}" +
                                  $"|{$"{huffmanCodingSortedTable[i].Value}({huffmanCodingSortedTable[i].Value.Length})",20}" +
                                  $"|{$"{morseCodingSortedTable[i].Value}({morseCodingSortedTable[i].Value.Length})",15}");
            }


            Console.ReadKey();
        }
    }
}