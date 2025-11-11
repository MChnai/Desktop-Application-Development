using BTN_QLDA_12_.Forms.Student_Forms;
using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    public partial class My_Topics_W_GV2 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        public My_Topics_W_GV2(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblAccountName.Text = _Account.FullName;
            LoadTopics();
        }
        private void LoadTopics()
        {
            List<Topics> topics = _context.Topics.Where(t => t.LecturerID == _Account.UserId).ToList();
            List<ProjectPeriods> pp = _context.ProjectsPeriods.ToList();
            foreach(var t in topics) 
                foreach(var p in pp)
                    if(t.ProjectPeriodID == p.ProjectPeriodID)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = t.Title;
                        item.SubItems.Add(p.Name);
                        item.SubItems.Add(t.Status);
                        item.SubItems.Add(t.MaxStudents.ToString());
                        item.SubItems.Add(t.TopicID.ToString());
                        lvTopic.Items.Add(item);
                    }
        }
        private void tmSideBar_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                pnSideBar.Width -= 10;//decrease 10 pixcel each tick of time        
                var X = pictureBox11.Location.X - 10;
                pictureBox11.Location = new Point(X, pictureBox11.Location.Y);
                if (pnSideBar.Width == pnSideBar.MinimumSize.Width)
                {
                    menuExpand = false;
                    tmSideBar.Stop();
                }
            }
            else
            {
                pnSideBar.Width += 10;//Increase 10 pixcel each tick of time
                var X = pictureBox11.Location.X + 10;
                pictureBox11.Location = new Point(X, pictureBox11.Location.Y);
                if (pnSideBar.Width == pnSideBar.MaximumSize.Width)
                {
                    menuExpand = true;
                    tmSideBar.Stop();
                }
            }
        }
        private void pnlDashboard_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Lecturer_Dashboard_W_GV1(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Approve_Registrations_W_GV3(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Account_Information_W2();
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }
        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muón đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Application.Restart();
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var newTopic = new Project_Detail_W_GV2_Detail(_context, _Account);
            newTopic.FormClosed += new FormClosedEventHandler(My_Topics_W_GV2_FormClosed);
            newTopic.ShowDialog();
        }

        private void My_Topics_W_GV2_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadTopics();
        }
        private void xemSinhViênCủaĐồÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvTopic.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lvTopic.SelectedItems[0].SubItems[4].Text);
                Projects pro = _context.Projects
                                .Where(p => p.TopicID == id)
                                .FirstOrDefault();
                if (pro != null)
                {
                    var form = new Project_Students_W_GV2_Detail(_context, pro, _Account);
                    form.ShowDialog();
                }
                else
                    MessageBox.Show("Đồ án chưa có sinh viên!!!");
            }
        }

        private void xemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lvTopic.Items.Count; i++)
            {
                if (lvTopic.Items[i].Selected)
                {
                    string topicName = lvTopic.Items[i].SubItems[0].Text;
                    Topics topic = _context.Topics
                                        .Where(u => u.Title == topicName)
                                        .FirstOrDefault();
                    Projects project = _context.Projects
                                        .Where(p => p.TopicID == topic.TopicID)
                                        .FirstOrDefault();
                    if(project != null)
                    {
                        var form = new Project_Detail_Process_W_GV4(_context, _Account, project);
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show("Vì đồ án chưa có sinh viên nên chưa thể đánh giá điểm");
                }
            }
        }
    }
}
