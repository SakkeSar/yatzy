using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noppapeli
{
    // Luo luokka "Noppa", jossa on tallessa nopan arvo 1-6
    // nopalla on myös "Heitto"-metodi, joka arpoo sille arvon 1-6
    // Anna nopalle myös constructor-metodi, joka heti alussa arpoo arvon

    // Lähde tekemään Yatzi-peli

    // Lisää nopalle kuvat 1-6

    public partial class Form1 : Form
    {
        // property
        private Random rng = new Random();
        //Noppa noppa1 = new Noppa(6);
        List<Noppa> Nopat = new List<Noppa>();
        public Form1() // constructor, suoritetaan heti alussa
        {
            InitializeComponent();
            // luodaan 5 noppaa
            for (int i = 0; i < 5; i++)
            {
                PictureBox tempPB = new PictureBox();

                this.Controls.Add(tempPB);

                Noppa tempNoppa = new Noppa(6, tempPB);

                Nopat.Add(tempNoppa);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // for käy läpi kaikki listan nopat
            for (int i = 0; i < Nopat.Count; i++)
            {
                Nopat[i].Heitto(rng);
                editPictureBox(Nopat[i], i);
                //label1.Text = noppa1.Luku.ToString();
            }
            //noppa1.Heitto();
            //editPictureBox(noppa1, 1);
            //label1.Text = noppa1.Luku.ToString();
            // lisää nopalle property "Koko", jolla määritellään
            // montako silmälukua nopalla on
            // ja käytetään sitä luvun arvonnassa
            // nopan koko annetaan sitä generoidessa
        }

        private void editPictureBox(Noppa jokuNoppa, int count)
        {
            const int spacing = 60;

            string key = jokuNoppa.GetNoppaKey();
            jokuNoppa.Boxi.Image = Noppa.GetPictureResX(key);
            jokuNoppa.Boxi.Location = new 
                Point(13 + count * spacing, 13);
        }

        private void buttonOnes_Click(object sender, EventArgs e)
        {
            int summayksi = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 1) 
                {
                    summayksi += Nopat[i].Luku;
                    
                }
            }
            buttonOnes.Text = summayksi.ToString();
        }

        private void buttonTwos_Click(object sender, EventArgs e)
        {
            int summakaksi = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 2)
                {
                    summakaksi += Nopat[i].Luku;
                }
            }
            buttonTwos.Text = summakaksi.ToString();
        }

        private void buttonThrees_Click(object sender, EventArgs e)
        {

            int summakolme = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 3)
                {
                    summakolme += Nopat[i].Luku;
                }
            }
            buttonThrees.Text = summakolme.ToString();
        }

        private void buttonFours_Click(object sender, EventArgs e)
        {
            int summanelja = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 4)
                {
                    summanelja += Nopat[i].Luku;
                }
            }
            buttonFours.Text = summanelja.ToString();
        }

        private void buttonFives_Click(object sender, EventArgs e)
        {
            int summaviisi = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 5)
                {
                    summaviisi += Nopat[i].Luku;
                }
            }
            buttonFives.Text = summaviisi.ToString();
        }

        private void buttonSixes_Click(object sender, EventArgs e)
        {
            int summakuusi = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 6)
                {
                    summakuusi += Nopat[i].Luku;
                }
            }
            buttonSixes.Text = summakuusi.ToString();
        }

        private void buttonPair_Click(object sender, EventArgs e)
        {
            int[] pairs = new int[6];
            int[] pairValues = new int[6];
            const int multiplier = 2;

            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = Nopat.Where(noppa =>
                    noppa.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 1)
                {

                    pairValues[i] = (i + 1) * multiplier;
                }

            }

            buttonPair.Text = pairValues.Max().ToString();
        }   

        private void buttonTwoPairs_Click(object sender, EventArgs e)
        {
            int[] pairs = new int[6];
            // {0, 0, 0, 8, 10, 0}
            int[] pairValues = new int[6];
            const int multiplier = 2;
            int pareja = 0;

            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = Nopat.Where(noppa =>
                    noppa.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {

                if (pairs[i] > 1)
                {
                    // tässä löytyy pari
                    pareja++;
                    pairValues[i] = (i + 1) * multiplier;
                }

            }

            if (pareja > 1)
            {

                buttonTwoPairs.Text = pairValues.Sum().ToString();
            }
            else
            {

                buttonTwoPairs.Text = "0";
            }
        }

        private void button3OfKind_Click(object sender, EventArgs e)
        {
            int[] pairs = new int[6];
            int[] pairValues = new int[6];
            const int multiplier = 3;

            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = Nopat.Where(noppa =>
                    noppa.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 2)
                {

                    pairValues[i] = (i + 1) * multiplier;
                }

            }

            button3OfKind.Text = pairValues.Max().ToString();
        }

        private void button4OfKind_Click(object sender, EventArgs e)
        {
            int[] pairs = new int[6];
            int[] pairValues = new int[6];
            const int multiplier = 4;

            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = Nopat.Where(noppa =>
                    noppa.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 3)
                {

                    pairValues[i] = (i + 1) * multiplier;
                }

            }

            button4OfKind.Text = pairValues.Max().ToString();

        }

        private void buttonSmallStraight_Click(object sender, EventArgs e)
        {

        }

        private void buttonLargeStraight_Click(object sender, EventArgs e)
        {

        }

        private void buttonFullHouse_Click(object sender, EventArgs e)
        {

        }

        private void buttonChance_Click(object sender, EventArgs e)
        {
            int summachance = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                
                
                    summachance += Nopat[i].Luku;
                
            }
            buttonChance.Text = summachance.ToString();
        }

        private void buttonYatzy_Click(object sender, EventArgs e)
        {
            int[] pairs = new int[6];
            int[] pairValues = new int[6];
            const int multiplier = 5;

            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = Nopat.Where(noppa =>
                    noppa.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 4)
                {

                    pairValues[i] = (i + 1) * multiplier;
                }

            }

            buttonYatzy.Text = pairValues.Max().ToString();
        }
    }
}
