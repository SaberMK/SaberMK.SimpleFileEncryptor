﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaberMK.SimpleFileEncryptor
{
    public partial class EnterPasswordForm : Form
    {
        public EnterPasswordForm()
        {
            InitializeComponent();
        }

        private void EnterPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void End()
        {
            GlobalData.Key = txtPassword.Text;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            End();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                End();
            }
        }
    }
}
