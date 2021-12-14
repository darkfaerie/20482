using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2048
{
    class musicin
    {
        SoundPlayer sp = new SoundPlayer(); MediaPlayer player = new MediaPlayer();
        public void startmusic()
        {
            player.Open(new Uri(@"C:\Users\Дом\source\repos\2048\2048\NewFolder1\GenshinImpactOSTWolfAndriusXStormterrorDvalinFinalBattle_(allmp3.su).mp3"));
            player.Volume = 0.1;
            player.Play();
            player.MediaEnded += Player_MediaEnded;
        }
        public void playmusic()
        {
            player.Play();
        }
        public void stopmusic()
        {
            player.Pause();
        }
        public void stopfullmusic()
        {
            player.Stop();
        }
        public void playmeow()
        {
            sp.Stream = Properties.Resources.ANMLCat_Meow_cat_2__ID_1890__BSB;
            sp.Play();
        }
        public void playapplause()
        {
            sp.Stream = Properties.Resources.CRWDCheer_Applause_concert_bar_8__ID_2486__BSB;
            sp.Play();
        }
        private void Player_MediaEnded(object sender, EventArgs e)
        {
            player.Position = new TimeSpan(0, 0, 0);
        }
    }
}
