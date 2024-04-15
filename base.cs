using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursovaya.Forms.Lists;
using Kursovaya.Forms.Other;
using Kursovaya.Forms.Computers;
using Kursovaya.Forms.Logs;

namespace Kursovaya
{
    public partial class @base : Form
    {
        public @base()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void главноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void base_Load(object sender, EventArgs e)
        {

        }

        private void статусыКомпьтеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusList statusList = new statusList();
            statusList.Show();
            this.Hide();
        }

        private void компьютерыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            computers computer = new computers();
            computer.Show();
            this.Hide();
        }

        private void моделиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            models models = new models();
            models.Show();
            this.Hide();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workers workers = new workers();
            workers.Show();
            this.Hide();
        }

        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deportments deportments = new deportments();
            deportments.Show();
            this.Hide();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            positions positions = new positions();
            positions.Show();
            this.Hide();
        }

        private void кабинетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            room room = new room();
            room.Show();
            this.Hide();
        }

        private void журналСостоянийАРМToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusLog statusLog = new statusLog();
            statusLog.Show();
            this.Hide();
        }

        private void журналПеремещенийАРМToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replaceLog replaceLog = new replaceLog();
            replaceLog.Show();
            this.Hide();
        }
    }
}
