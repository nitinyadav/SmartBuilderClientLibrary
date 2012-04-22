using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace WindowsFormsClient
{
    public partial class SearchResultForm : Form
    {
        DeuffService.responseInfo response;
        
        public SearchResultForm()
        {
            InitializeComponent();
        }

        public void populate(DeuffService.responseInfo res)
        {
            this.response = res;
            this.textBox1.Text = response.Question;
            if (res.Solution != null)
            {
                for (int i = 1; i <= response.Solution.Length; i++)
                {
                    if (i == 1 && (response.Solution[0] != null))
                    {
                        this.textBox2.Text = response.Solution[0].ToString();
                        this.button8.Text = response.Vote[0].ToString();
                        this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    }
                    if (i == 2 && (response.Solution[1] != null))
                    {
                        this.textBox3.Text = response.Solution[1].ToString();
                        this.button9.Text = response.Vote[1].ToString();
                        this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    }
                    if (i == 3 && (response.Solution[2] != null))
                    {
                        this.textBox4.Text = response.Solution[2].ToString();
                        this.button10.Text = response.Vote[2].ToString();
                        this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// To change the question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //to update answer on server
            DeuffService.suggestAnswer ans = new DeuffService.suggestAnswer();
            ans.ErrorMessage = properties.errorMessage;
            
            ans.Answer = textBox5.Text;
            
            ans.Vote = 0;
            ans.Filename = properties.filename;
            ans.Info = properties.info;
            ans.Stacktrace = properties.stacktrace;
            ans.Tags = properties.stacktrace;
            ans.UserId = properties.userId;
            ans.Guid = properties.guid;
            ans.Info = properties.info;
            ans.NameSpace = properties.nameSpace;
            ans.Os = properties.os;
            ans.SoftwareName = properties.projectTitle;
            ans.Tags = properties.tags;
            ans.Version = properties.version;
            ans.Vendor = properties.vendor;
            DeuffService.IService1 obj = new DeuffService.Service1Client();
            obj.updateAnswer(ans);

            //close the dialog box
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //to update answer on server
            DeuffService.suggestAnswer ans = new DeuffService.suggestAnswer();
            ans.ErrorMessage = properties.errorMessage;
            ans.Answer = textBox2.Text;
            DeuffService.IService1 obj = new DeuffService.Service1Client();
            obj.voteAnswer(ans);

            //close the dialog box
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //to update answer on server
            DeuffService.suggestAnswer ans = new DeuffService.suggestAnswer();
            ans.ErrorMessage = properties.errorMessage;
            ans.Answer = textBox3.Text;
            DeuffService.IService1 obj = new DeuffService.Service1Client();
            obj.voteAnswer(ans);

            //close the dialog box
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //to update answer on server
            DeuffService.suggestAnswer ans = new DeuffService.suggestAnswer();
            ans.ErrorMessage = properties.errorMessage;
            ans.Answer = textBox4.Text;
            DeuffService.IService1 obj = new DeuffService.Service1Client();
            obj.voteAnswer(ans);

            //close the dialog box
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
