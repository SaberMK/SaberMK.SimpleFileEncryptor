using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaberMK.SimpleFileEncryptor
{
    public partial class FileEncryptorForm : Form
    {
        private readonly string _path;
        public FileEncryptorForm(string path = "")
        {
            _path = path;
            InitializeComponent();
        }


        private void FileEncryptor_Load(object sender, EventArgs e)
        {
#warning Save last window size and position!

            Hide();
            new EnterPasswordForm().ShowDialog();
            Show();

            var data = File.ReadAllText(_path);
            rtbData.Text = DecryptData(data);
        }

        private void rtbData_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(_path, EncryptData(rtbData.Text));
        }

        public string EncryptData(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                var encrypted = Cipher.Encrypt(data, GlobalData.Key);
                return encrypted;
            }
            return "";
        }

        public string DecryptData(string encrypted)
        {
            if (!string.IsNullOrEmpty(encrypted))
            {
                var data = Cipher.Decrypt(encrypted, GlobalData.Key);
                return data;
            }
            return "";
        }
    }
}
