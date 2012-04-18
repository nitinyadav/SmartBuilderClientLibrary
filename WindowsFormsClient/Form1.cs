using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        DeuffService.bugData requestObj;
        SearchResultForm resultWindow;
        string error ;
        
        public Form1()
        {
            InitializeComponent();
            resultWindow = new SearchResultForm();
        }
        public Form1(string eror)
        {
            InitializeComponent();
            resultWindow = new SearchResultForm();
            error = eror;
            properties.init(error, "visual-studio,c#");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void objInitialize()
        {
            textBox1.Text = properties.errorMessage;
            textBox2.Text = properties.tags;
            textBox3.Text = properties.filename;
            textBox4.Text = properties.nameSpace;
            textBox5.Text = properties.guid;
            textBox6.Text = properties.moreOption;
            textBox7.Text = properties.info;
            textBox8.Text = properties.stacktrace;
            textBox8.Multiline = true;
            textBox8.AllowDrop = true;
            textBox9.Text = properties.version;
            textBox10.Text = properties.os;
        }

        private void populate(DeuffService.bugData robj)
        {
            robj.UserId = properties.userId;
            robj.Filename = textBox3.Text;
            robj.NameSpace = textBox4.Text;
            robj.Guid = textBox5.Text;
            robj.MoreOptions = 0;
            robj.OutputText = properties.output;
            robj.SoftwareInfo = robj.SoftwareInfo;
            robj.Version = textBox9.Text;
            robj.Vendor = properties.group;
            robj.StackTrace = textBox8.Text;
            robj.OperatingSystem = textBox10.Text;
            robj.ErrorMessage = textBox1.Text;
            robj.Tags = new string[] { "visual-studio", "c#" };
            robj.BugId = "";
        }

        public void changeQuestion()
        {
            requestObj.MoreOptions++;
            button1_Click(null,null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeuffService.IService1 obj = new DeuffService.Service1Client();
            DeuffService.responseInfo resultObj = obj.GetAnswer(requestObj);
            requestObj.BugId = resultObj.BugId;
            resultWindow.populate(resultObj);
            DialogResult dres= resultWindow.ShowDialog();
            if (dres == DialogResult.Retry)
                changeQuestion();
            else
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            requestObj = new DeuffService.bugData();
            objInitialize();
            populate(requestObj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
