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
namespace File_Organization
{
    public partial class Form1 : Form
    {
        BinaryWriter BW;
        int Length;
        private void ClearReacored() => ID.Text = Name1.Text = Phone.Text = Year.Text = Gender.Text = "";
        private void WriteToFile()
        {
            BW.BaseStream.Seek(Length, SeekOrigin.Begin); 
            ID.Text = ID.Text.PadRight(4);
            BW.Write(int.Parse(ID.Text.Substring(0, 4)));
            Name1.Text = Name1.Text.PadRight(9);
            BW.Write(Name1.Text.Substring(0, 9));
            Phone.Text = Phone.Text.PadRight(11);
            BW.Write(Phone.Text.Substring(0, 11));
            Year.Text = Year.Text.PadRight(4);
            BW.Write(int.Parse(Year.Text.Substring(0, 4)));
            BW.Write(Gender.Text.Substring(0, 1));
            Length += Class.Recor_Size;
            ClearReacored();
            TheLabel.Text = "Data is Inserted Successfully";
            BW.Close();
        }
        public Form1() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e) { }
        private void Create_Click(object sender, EventArgs e)
        {
            Class.FileName = Environment.CurrentDirectory.ToString()+ "\\Records" + FileName.Text + ".txt";
            if (!File.Exists(Class.FileName))
            {
                File.Create(Class.FileName).Close();
                TheLabel.Text = "File is Created";
            }
            else
                TheLabel.Text = "File Exists";
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            Class.FileName = Environment.CurrentDirectory.ToString() + "\\Records" + FileName.Text + ".txt";
            File.Delete(Class.FileName);
            TheLabel.Text = "File is Deletd";
        }
        private void Insert_Click(object sender, EventArgs e)
        {
             BW = new BinaryWriter(File.Open(Class.FileName, FileMode.Open, FileAccess.Write));
             Length = (int)BW.BaseStream.Length;
             WriteToFile();
        }
    }
}