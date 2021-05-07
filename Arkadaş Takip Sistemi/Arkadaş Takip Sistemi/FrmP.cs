using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkadaş_Takip_Sistemi
{
    public partial class FrmP : Form
    {
        public FrmP()
        {
            InitializeComponent();
        }

        private void FrmP_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 10;

          
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            sayac++;
            if (sayac == 6)
            {
                this.Close();
            }
        }
    }
}
