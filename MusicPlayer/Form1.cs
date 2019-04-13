using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Media;




namespace MusicPlayer
{
    public partial class Form1 : Form
    {
       WindowsMediaPlayer chose = new WindowsMediaPlayer();
          public Form1()
        {
            InitializeComponent();
           }

     
        int Startindex = 0;
        string[] files, paths;
         

        private void Form1_Load(object sender, EventArgs e)
        {
            Startindex = 0;
            
           
          }
        public void playfile(int playlistindex)
        {
            if (Playlist.Items.Count <= 0)
            { return; }
            if (playlistindex < 0)
            {
                return;
            }
            chose.settings.autoStart = true;
            chose.URL=paths[playlistindex];
            chose.controls.next();
            chose.controls.play();
            }
             private void addSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Startindex=0;
             
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "MP3 (*.mp3)|*.mp3|" +
                         "WMA (*.wma)|*.wma|" +
                         "WAV (*.wav)|*.wav";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                files = open.SafeFileNames;
                paths = open.FileNames;
                

                for (int i = 0; i <= files.Length-1; i++)
                {
                    Playlist.Items.Add(files[i]);
                   
                }
                Startindex = 0;
                playfile(0);
                
            }

             }
       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Startindex = Playlist.SelectedIndex;
            
            playfile(Startindex);
           
                
        }

      

       


       
        private void button1_Click(object sender, EventArgs e)
        {
            chose.controls.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chose.controls.pause();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Startindex > 0)
            {
                Startindex = Startindex - 1;
            }

            playfile(Startindex);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Startindex == Playlist.Items.Count - 1)
            {
                Startindex = Playlist.Items.Count - 1;
            }
            else if (Startindex < Playlist.Items.Count)
            {
                Startindex = Startindex + 1;

            }

            playfile(Startindex);             
        }

        private void button7_Click(object sender, EventArgs e)
        {
          playfile(Startindex);
        }

           
      

        private void button8_Click(object sender, EventArgs e)
        {
            
            ListBox.ObjectCollection list = Playlist.Items;
            Random random = new Random();
            int w = list.Count;
            Playlist.BeginUpdate();
            while (w > 1)
            {
                w--;
                int u = random.Next(w + 1);
                object value = list[u];
                list[u] = list[w];
                list[w] = value;

            }
            Playlist.EndUpdate();
            Playlist.Invalidate();
                     
            
            
        }

       
        
       
       

        
    }
}
