using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using _Code;
using _Idea;
using _Parameters;
using System.Diagnostics;

namespace SortingAlgorithmsGUI
{
    public partial class frmApplication : Form
    {
        #region Public Variables
        public static string PT1 = string.Empty;
        public static string PT2 = string.Empty;
        public static string PT3 = string.Empty;
        public static string PT4 = string.Empty;
        public static string PT5 = string.Empty;
        public static string PT6 = string.Empty;
        public static string PT7 = string.Empty;
        public static string PT8 = string.Empty;
        public static string PT9 = string.Empty;
        public static string PT10 = string.Empty;
        public static string PT11 = string.Empty;
        public static string PT12 = string.Empty;
        public static string PT13 = string.Empty;
        public static string PT14 = string.Empty;
        public static string PT15 = string.Empty;
        #endregion

        #region Variables
        Parameters thamSo = new Parameters();

        Color colorMove = Color.FromArgb(253, 99, 71);
        // Color colorMove = Color.FromArgb(9, 132, 227);
        Color colorComplete = Color.FromArgb(176, 244, 230);
        Color colorDefault = Color.FromArgb(255, 192, 203);
        Color colorMergeU = Color.Linen;
        Color colorMergeD = Color.FromArgb(143, 188, 143);
        #endregion

        #region Initialize
        public frmApplication()
        {
            InitializeComponent();
        }
        #endregion        

        #region Load
        private void frmApplication_Load(object sender, EventArgs e)
        {
            thamSo.nOe = (int)numArray.Value;
            Init();
            thamSo.speed = 60;
            speedTrackBar.Maximum = thamSo.speed;
            speedTrackBar.Minimum = 0;
            speedTrackBar.Value = thamSo.speed / 2;
            speedTrackBar.LargeChange = 1;
            AddPanel();
        }

        public void Init()
        {
            pnlChosesAlgorithms.Enabled = false;
            thamSo.increase = true;
            bntReset.Enabled = false;
            listIdea.Hide();
        }

        #endregion

        #region Complete Swap
        public void CompleteSwap()
        {
            thamSo.nOe = (int)numArray.Value;
            for (int i = 0; i < thamSo.nOe; i++)
                thamSo.arrLbl[i].BackColor = Color.PaleTurquoise;
            Complete();
        }
        #endregion          

        #region numArray_ValueChanged
        private void numArray_ValueChanged(object sender, EventArgs e)
        {
            thamSo.nOe = int.Parse(numArray.Value.ToString());
        }
        #endregion

        #region Hàm phân phối a cho b và c
        #region functions moving
        public void Node_Right(Control t, int Step)
        {
            Application.DoEvents();

            this.Invoke((MethodInvoker)delegate
            {
                int Loop_Count = ((thamSo.sizeN + thamSo.disN)) * Step;//Số lần dịch chuyển
                {
                    while (Loop_Count > 0)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Delay(thamSo.speed);
                        Loop_Count--;
                        t.BackColor = colorDefault;
                    }
                }
                t.Refresh();
            });
        }
        // t dịch chuyển sang trai Step Node
        public void Node_Left(Control t, int Step)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int Loop_Count = ((thamSo.sizeN + thamSo.disN)) * Step; //Số lần dịch chuyển
                while (Loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Left -= 1;
                    Delay(thamSo.speed);
                    Loop_Count--;
                    t.BackColor = colorMove;
                }
                t.Refresh();
            });
        }
        // t dịch chuyển lên với quãng đường S
        public void Node_Up(Control t, int S)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int loop_Count = S;
                //t xuống
                while (loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Top -= 1;
                    Delay(thamSo.speed);
                    loop_Count--;
                    t.BackColor = colorMove;
                }
                t.Refresh();
            });
        }
        // t dịch chuyển xuống với quãng đường S
        public void Node_Down(Control t, int S)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int loop_Count = S;
                // t lên
                while (loop_Count > 0)
                {
                    Application.DoEvents();
                    t.Top += 1;
                    Delay(thamSo.speed);
                    loop_Count--;
                    t.BackColor = colorMove;
                }
                t.Refresh();
            });
        }
        public void toLocaN(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i, 150);//vị trí của Node i
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                t.BackColor = colorMove;
                // Di chuyển nút lên hoặc xuống nữa đường
                if (p1.Y < p2.Y)
                {
                    while (t.Location.Y < p2.Y - ((p2.Y - p1.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top += 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y + ((p1.Y - p2.Y) / 2))
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                // Di chuyển nút qua phải hoặc trái
                if (p1.X < p2.X)
                {
                    while (t.Location.X < p2.X)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                // Tiếp tục di chuyển nút lên hoặc xuống nữa đường còn lại
                if (p1.Y < p2.Y)
                {
                    while (t.Location.Y < p2.Y)
                    {
                        Application.DoEvents();
                        t.Top += 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.Y > p2.Y)
                    {
                        Application.DoEvents();
                        t.Top -= 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
            });
        }
        // Dịch chuyển 1 Node về vị trí bằng với X của Node[i]
        public void Den_tdo_x_node(Control t, int i)
        {
            Point p1 = t.Location; // lưu lại vị trí của t
            Point p2 = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i, 150);//vị trí của Node i
            Application.DoEvents();
            t.BackColor = colorMove;
            this.Invoke((MethodInvoker)delegate
            {
                // Di chuyển nút qua phải hoặc trái
                if (p1.X < p2.X)
                {
                    while (t.Location.X < p2.X)
                    {
                        Application.DoEvents();
                        t.Left += 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }
                else
                {
                    while (t.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        t.Left -= 1;
                        Delay(thamSo.speed);
                        t.Refresh();
                    }
                }

            });
        }
        #endregion
        #region functions conversion
        public void Swap_NodeAn(int a, int b)
        {
            Label temp = thamSo.arrLbl[a];
            thamSo.arrLbl[a] = thamSo.arrLbl[b];
            thamSo.arrLbl[b] = temp;
        }
        public void Swap_Node(Control t1, Control t2)
        {
            Application.DoEvents();
            t1.BackColor = colorMove;
            t2.BackColor = colorMove;
            this.Invoke((MethodInvoker)delegate
            {
                Point p1 = t1.Location; //lưu vị trí ban đầu của t1
                Point p2 = t2.Location; //lưu vị trí ban đầu của t2
                if (p1 != p2)
                {
                    // t1 lên, t2 xuống
                    while ((t1.Location.Y > p1.Y - (thamSo.sizeN + 5)) || (t2.Location.Y < p2.Y + (thamSo.sizeN + 5)))
                    {
                        Application.DoEvents();
                        t1.Top -= 1;
                        t2.Top += 1;
                        Thread.Sleep(thamSo.speed);
                    }
                    // t1 dịch phải, t2 dịch trái
                    if (t1.Location.X < t2.Location.X)
                    {
                        while ((t1.Location.X < p2.X) || (t2.Location.X > p1.X))
                        {
                            Application.DoEvents();
                            t1.Left += 1;
                            t2.Left -= 1;
                            Thread.Sleep(thamSo.speed);
                        }
                    }
                    // t1 dịch trái, t2 dịch phải
                    else
                    {
                        while ((t1.Location.X > p2.X) || (t2.Location.X < p1.X))
                        {
                            Application.DoEvents();
                            t1.Left -= 1;
                            t2.Left += 1;
                            Thread.Sleep(thamSo.speed);
                        }
                    }
                    // t1 xuống, t2 lên
                    while ((t1.Location.Y < p2.Y) || (t2.Location.Y > p1.Y))
                    {
                        Application.DoEvents();
                        t1.Top += 1;
                        t2.Top -= 1;
                        Thread.Sleep(thamSo.speed);
                    }
                    t1.Refresh();
                    t2.Refresh();
                }
            });

        }

        public void Swap_Giatri(ref int i, ref int j)
        {
            int Temp = i;
            i = j;
            j = Temp;
        }
        #endregion
        #region Handing alignment
        private void Alignment()
        {
            listIdea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            listIdea.MeasureItem += lst_MeasureItem;
            listIdea.DrawItem += lst_DrawItem;
        }
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listIdea.Items[e.Index].ToString(), listIdea.Font, listIdea.Width).Height;
        }
        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
           //  e.DrawFocusCircle();
            e.Graphics.DrawString(listIdea.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }
        #endregion
        #endregion
        #region Sort Algorithms

        #region bubble
        private void BubbleSortincrease(int[] arrNode)
        {
            int i, j;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < thamSo.nOe - 1; i++)
                {
                    ShowCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = thamSo.nOe - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ShowCodeListBox(4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y + 2 * thamSo.sizeN + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So sánh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ShowCodeListBox(5);
                        lbl_status_02.Visible = true;
                        if (thamSo.arrNode[j] < thamSo.arrNode[j - 1])
                        {
                            //Hieu ung xem code
                            ShowCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Đổi chỗ(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref thamSo.arrNode[j], ref thamSo.arrNode[j - 1]);
                            Swap_Node(thamSo.arrLbl[j], thamSo.arrLbl[j - 1]);
                            Swap_NodeAn(j, j - 1);
                            thamSo.arrLbl[j - 1].BackColor = colorComplete;
                        }
                        thamSo.arrLbl[j].BackColor = colorDefault;
                    }
                    //Cập nhật Status
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();

                }
                lbl_status_02.Visible = false;
            });
            ShowCodeListBox(0);
        }
        private void BubbleSortGiam(int[] arrNode)
        {
            int i, j;
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < thamSo.nOe - 1; i++)
                {
                    ShowCodeListBox(3);
                    Mui_ten_xanh_xuong_1.Text = "i=" + i;
                    Mui_ten_xanh_xuong_1.Visible = true;
                    Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                    Mui_ten_xanh_xuong_1.Refresh();
                    Application.DoEvents();
                    for (j = thamSo.nOe - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        ShowCodeListBox(4);
                        Mui_ten_xanh_len_1.Text = "j=" + j;
                        Mui_ten_xanh_len_1.Visible = true;
                        Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y + 2 * thamSo.sizeN + 5);
                        Mui_ten_xanh_len_1.Refresh();
                        lbl_status_02.Visible = false;
                        lbl_status_02.Text = "So sánh(a[" + j + "],a[" + (j - 1) + "])";
                        lbl_status_02.Refresh();
                        ShowCodeListBox(5);
                        lbl_status_02.Visible = true;
                        if (thamSo.arrNode[j] > thamSo.arrNode[j - 1])
                        {
                            //Hieu ung xem code
                            ShowCodeListBox(6);
                            lbl_status_02.Visible = true;
                            lbl_status_02.Text = "Hoán vị(a[" + j + "],a[" + (j - 1) + "])";
                            lbl_status_02.Refresh();

                            Swap_Giatri(ref thamSo.arrNode[j], ref thamSo.arrNode[j - 1]);
                            Swap_Node(thamSo.arrLbl[j], thamSo.arrLbl[j - 1]);
                            Swap_NodeAn(j, j - 1);
                            thamSo.arrLbl[j - 1].BackColor = colorComplete;
                        }
                        thamSo.arrLbl[j].BackColor = colorDefault;
                    }
                    //Cập nhật Status
                    lbl_status_02.Visible = true;
                    lbl_status_02.Text = "a[" + i + "] Đã đúng vị trí";
                    lbl_status_02.Refresh();

                }
                lbl_status_02.Visible = false;
            });
            ShowCodeListBox(0);
        }
        #endregion
        
        #region quick
        private void QuickSortincrease(int[] arrNode, int left, int right)
        {
            if (left < right)
            {
                int pivot = thamSo.arrNode[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left


                ShowCodeListBox(2);

                Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * left) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[left].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * right) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[right].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                //

                //doi mau node x


                //Đặt màu nút x                    
                //         
                ShowCodeListBox(3);
                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * cs_x) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[cs_x].Location.Y + 2 * thamSo.sizeN + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Thiết lập mũi tên chỉ i

                ShowCodeListBox(4);
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ShowCodeListBox(5);

                do
                {

                    ShowCodeListBox(7);
                    lbl_status_02.Text = "So sánh(a[" + i + "], a[x])";
                    lbl_status_02.Visible = true;
                    while (thamSo.arrNode[i] < pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        // lbl_status_02.Text = "Compare(a[" + i + "], a[x])";
                    }
                    ShowCodeListBox(8);
                    lbl_status_02.Text = "So sánh(a[" + j + "], a[x])";
                    while (thamSo.arrNode[j] > pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //

                    }
                    ShowCodeListBox(9);

                    if (i <= j)
                    {
                        ShowCodeListBox(11);
                        lbl_status_02.Text = "Đổi chỗ(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref thamSo.arrNode[i], ref thamSo.arrNode[j]);
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        Swap_Node(thamSo.arrLbl[j], thamSo.arrLbl[i]);
                        Swap_NodeAn(j, i);
                        thamSo.arrLbl[j].BackColor = colorComplete;
                        thamSo.arrLbl[i].BackColor = colorDefault;
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * cs_x) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[cs_x].Location.Y + 2 * thamSo.sizeN + 40);
                        Mui_ten_do_len.Text = "X = " + ((left + right) / 2);
                        Mui_ten_do_len.Refresh();
                        ShowCodeListBox(12);
                        i++;
                        j--;
                    }
                }
                while (i <= j);
                ShowCodeListBox(16);
                if (left < j)
                {
                    ShowCodeListBox(17);
                    QuickSortincrease(thamSo.arrNode, left, j);
                }
                ShowCodeListBox(18);
                if (i < right)
                {
                    ShowCodeListBox(19);
                    QuickSortincrease(thamSo.arrNode, i, right);
                }
            }
        }
        private void QuickSortGiam(int[] arrNode, int left, int right)
        {
            if (left < right)
            {
                int pivot = thamSo.arrNode[(left + right) / 2];
                int i = left, j = right;
                int cs_x = (left + right) / 2;
                //đặt mũi tên chỉ left
                Mui_ten_xanh_len_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * left) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[left].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_1.Text = "L = " + left;
                Mui_ten_xanh_len_1.Visible = true;
                Mui_ten_xanh_len_1.Refresh();
                //đặt mũi tên chỉ Right
                Mui_ten_xanh_len_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * right) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[right].Location.Y + 2 * thamSo.sizeN + 5);
                Mui_ten_xanh_len_2.Text = "R = " + right;
                Mui_ten_xanh_len_2.Visible = true;
                Mui_ten_xanh_len_2.Refresh();
                //

                //doi mau node x

                ShowCodeListBox(2);


                cs_x = (left + right) / 2;

                //Thiết lập vị trí của x
                Mui_ten_do_len.Visible = true;
                Mui_ten_do_len.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * cs_x) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[cs_x].Location.Y + 2 * thamSo.sizeN + 40);
                Mui_ten_do_len.Text = "X";
                Mui_ten_do_len.Refresh();
                //
                //Đặt màu nút x                    
                //
                i = left; j = right;
                ShowCodeListBox(3);
                //Thiết lập mũi tên chỉ i
                Mui_ten_xanh_xuong_1.Visible = true;
                Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_1.Text = "i=" + i;
                Mui_ten_xanh_xuong_1.Refresh();
                //Thiết lập mũi tên chỉ j
                Mui_ten_xanh_xuong_2.Visible = true;
                Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                Mui_ten_xanh_xuong_2.Text = "j=" + j;
                Mui_ten_xanh_xuong_2.Refresh();
                //
                ShowCodeListBox(5);
                do
                {
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So sánh(a[" + i + "], a[x])";
                    ShowCodeListBox(7);
                    while (thamSo.arrNode[i] > pivot)
                    {
                        i++;

                        //Thiết lập mũi tên chỉ i
                        Mui_ten_xanh_xuong_1.Visible = true;
                        Mui_ten_xanh_xuong_1.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[i].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_1.Text = "i=" + i;
                        Mui_ten_xanh_xuong_1.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So sánh(a[" + i + "], a[x])";
                    }
                    //Hiệu ứng so sánh
                    lbl_status_02.Text = "So sánh(a[" + j + "], a[x])";
                    ShowCodeListBox(8);
                    while (thamSo.arrNode[j] < pivot)
                    {
                        j--;

                        //Thiết lập mũi tên chỉ j
                        Mui_ten_xanh_xuong_2.Visible = true;
                        Mui_ten_xanh_xuong_2.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * j) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[j].Location.Y - thamSo.sizeN - 70);
                        Mui_ten_xanh_xuong_2.Text = "j=" + j;
                        Mui_ten_xanh_xuong_2.Refresh();
                        //
                        //Hiệu ứng so sánh
                        lbl_status_02.Text = "So sánh(a[" + j + "], a[x])";
                    }
                    ShowCodeListBox(9);
                    if (i <= j)
                    {
                        //status hoán vị             
                        lbl_status_02.Text = "Hoán vị(a[" + i + "], a[" + j + "])";
                        Swap_Giatri(ref thamSo.arrNode[i], ref thamSo.arrNode[j]);
                        ShowCodeListBox(11);
                        //Tìm vị trí mới của x
                        if (i == cs_x)
                        {
                            cs_x = j;
                        }
                        else if (j == cs_x)
                        {
                            cs_x = i;
                        }
                        Swap_Node(thamSo.arrLbl[i], thamSo.arrLbl[j]);
                        Swap_NodeAn(i, j);
                        thamSo.arrLbl[i].BackColor = colorComplete;
                        thamSo.arrLbl[j].BackColor = colorDefault;
                        //Thiết lập vị trí của 
                        Mui_ten_do_len.Visible = true;
                        Mui_ten_do_len.Location = new Point((thamSo.firstN + (thamSo.sizeN + thamSo.disN) * cs_x) + (thamSo.sizeN / 2) - 30, thamSo.arrLbl[cs_x].Location.Y + 2 * thamSo.sizeN + 40);
                        Mui_ten_do_len.Text = "X = " + ((left + right) / 2);
                        Mui_ten_do_len.Refresh();
                        ShowCodeListBox(12);

                        i++; j--;

                    }

                } while (i <= j);
                //Đặt màu nút x
                ShowCodeListBox(16);
                if (left < j)
                {
                    ShowCodeListBox(18);
                    QuickSortGiam(thamSo.arrNode, left, j);
                }
                if (i < right)
                {
                    ShowCodeListBox(19);
                    QuickSortGiam(thamSo.arrNode, i, right);
                }
            }
        }
        #endregion
        
        
        #endregion

        #region Show Code
        private void ShowCode()
        {
            listCode.Items.Clear();
            listIdea.Items.Clear();
            Alignment();
            Idea idea = new Idea();
            Code code = new Code();

            listCode.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            listIdea.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            listIdea.ForeColor = Color.White;
            if (radQuick.Checked)
            {
                code.quicksort(listCode, thamSo.increase);
                idea.Quicksort(listIdea);
            }
            if (radBubble.Checked)
            {
                code.bubblesort(listCode, thamSo.increase);
                idea.Bubblesort(listIdea);
            }
        }
        public void ShowCodeListBox(int viTri)
        {
            Delay(thamSo.speed * 5);
            //listCode.Quicksort = viTri;
            // nếu đang trong chế độ Debug thì dừng sau mỗi câu lệnh chạy xong sẽ dừng lại
            if (ckDebug.Checked)
            {
                thamSo.checkPause = true;
                Play_or_Stop();
            }
        }

        #endregion

        #region Complete
        public void Complete()
        {
            ShowCodeListBox(0);
            ExTime.Stop();
            pnlExTime.Visible = false;
            Init();
            bntReset.Enabled = true;
            bntCreate.Enabled = false;
            Hidelbl();
            MessageBox.Show("Đã sắp xếp xong !\n Thời gian thực hiện: " + lblMinutes.Text + ":" + lblSeconds.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void Hidelbl()
        {
            Mui_ten_xanh_xuong_1.Visible = false;
            Mui_ten_xanh_xuong_2.Visible = false;
            Mui_ten_xanh_len_1.Visible = false;
            Mui_ten_xanh_len_2.Visible = false;
            Mui_ten_do_len.Visible = false;
            lblA.Visible = false;
            lblB.Visible = false;
            lblC.Visible = false;
            lbl_status_02.Visible = false;
        }
        #endregion

        #region AddPanel
        public void AddPanel()
        {
            pnlExcution.Controls.Add(Mui_ten_xanh_xuong_1);
            pnlExcution.Controls.Add(Mui_ten_xanh_xuong_2);
            pnlExcution.Controls.Add(Mui_ten_xanh_len_1);
            pnlExcution.Controls.Add(Mui_ten_xanh_len_2);
            pnlExcution.Controls.Add(Mui_ten_do_len);
            pnlExcution.Controls.Add(lbl_status_02);
            pnlExcution.Controls.Add(lblA);
            pnlExcution.Controls.Add(lblB);
            pnlExcution.Controls.Add(lblC);
        }
        #endregion
        //ToolBox 
        #region Working 
        #region bnt"Initial","Control","Debug","Create Array"_Click
        #region Initial

        public void DeleteArray(Label[] a)
        {

            for (int i = 0; i < thamSo.nOe; i++)
            {
                this.Controls.Remove(a[i]);
            }
        }
        private void bntCreate_Click(object sender, EventArgs e)
        {
            bntCreate.Enabled = false;
            numArray.Enabled = false;
            bntReset.Enabled = true;
            thamSo.checkPause = false;
            //DeleteArray(thamSo.arrLbl);
            if (numArray.Value < 2 )
            {
                MessageBox.Show("Vui lòng nhập từ  2->10 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            else
            {
                switch (thamSo.nOe)
                {
                    case 15:
                    case 14:
                    case 13:
                    case 12:
                    case 11:
                    case 10:
                        thamSo.disN = 18;
                        thamSo.sizeN = 50;
                        thamSo.firstN = (1024 - thamSo.sizeN - thamSo.disN * (thamSo.nOe - 1)) / thamSo.nOe;
                        break;
                    case 9:
                    case 8:
                    case 7:
                    case 6:
                    case 5:
                    case 4:
                    case 3:
                    case 2:
                        thamSo.sizeN = 50;
                        thamSo.disN = 30;
                        thamSo.firstN = (1024 - thamSo.sizeN - thamSo.disN * (thamSo.nOe - 1)) / thamSo.nOe;
                        break;
                }
                thamSo.arrNode = new int[thamSo.nOe];
                thamSo.arrLbl = new Label[thamSo.nOe];
                for (int i = 0; i < thamSo.nOe; i++)
                {
                    Label label = new Label();   
                    label.AutoSize = false;         // tắt kích thước mặc định ( cho phép thay đổi )
                    label.Size = new Size(40, 40);  // thay đổi kích thước 
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // viền của Node 
                    label.Font = new Font("Times New Roman", 14);  // Kiểu chữ số và kích cỡ
                    label.TextAlign = ContentAlignment.MiddleCenter; // Vị trí của chữ số trong Node
                    label.Text = "0";                               // Hiển thị chữ số Node
                    label.BackColor = colorDefault;                 // màu Node được nói ở phần trước
                    label.Location = new Point(thamSo.firstN + (thamSo.sizeN + thamSo.disN) * i, 3 * thamSo.sizeN);
                            // Khởi tạo vị trí cho các Node bằng các phép tính
                    thamSo.arrLbl[i] = label;                       // gán giá trị Node vào mảng
                    pnlExcution.Controls.Add(thamSo.arrLbl[i]);     // thêm Node vào background (panel)
                }
            }
          //  grpCreateArray.Enabled = true;
        }
        private void docFILE_Click(object sender, EventArgs e)
        {
            pnlChosesAlgorithms.Enabled = true;
            StreamReader Re = File.OpenText("TEST.txt");
            string input = null;
            int i = 0;
            int kt = 0;
            int Spt = 0;
            while ((kt < 1) && ((input = Re.ReadLine()) != null))
            {
                Spt = Convert.ToInt32(input);
                kt++;
            }
            while (((input = Re.ReadLine()) != null) && (i < Spt))
            {
                thamSo.arrNode[i] = Convert.ToInt32(input);
                thamSo.arrLbl[i].Text = thamSo.arrNode[i].ToString();
                i++;
            }
            Re.Close();
            ShowCode();
        }

        private void bntReset_Click(object sender, EventArgs e)
        {
            thamSo.programIsStart = false;   // kiểm tra chương trình có đang chạy không ? 
            // Áp dụng cho hàm Debug và khi reset sẽ cho cho giá trị là chương trình không chạy
            numArray.Enabled = true;
            bntCreate.Enabled = true;

            radBubble.Enabled = true;

            radQuick.Enabled = true;

            ckDebug.Checked = false;   // tắt dấu tích trên checkBox ( checkBox Debug )
            Init();                     // Khởi tạo, không cho phép sử dụng một vài tool 
            lblSeconds.Text = "00";     // trả lại giá trị Execution ban đầu ( Giây )
            lblMinutes.Text = "00";     // trả lại giá trị Execution ban đầu ( Phút )
            Hidelbl();
            for (int i = 0; i < thamSo.nOe; i++)
            {
                pnlExcution.Controls.Remove(thamSo.arrLbl[i]); // xóa mảng 
            }
            bntPlay.Show();             // Hiển thị nút Play 
            thamSo.checkSpace = true;   
            speedTrackBar.Value = 30;   //Cho trackBar giá trị mặc định khi reset 
        }
        #endregion

        #region Control
        private void bntPlay_Click(object sender, EventArgs e)
        {
            bntPlay.Hide();             // Ẩn nút Play
            bntPause.Show();            // Hiện nút Pause
            thamSo.checkSpace = false;  // Xác nhận nút Play vừa được nhận 
            pnlExTime.Visible = true;   // Hiển thị Execution Time 
            ExTime.Start();             // Timer ExTime bắt đầu or tiếp tục tính

            #region Enabled Control
            bntReset.Enabled = false;

            // không cho tích dấu vào các ô của thuật toán vì chưa tạo giá trị phù hợp
            // Nên cho các giá trị nhập bằng tay hoặc Random để có thể lựa chọn thuật toán

            radBubble.Enabled = false;

            radQuick.Enabled = false;


            // Kiểm tra các dấu tích, nếu vô thuật toán nào thì thực hiện
            #endregion
            if (thamSo.checkPause == false && thamSo.programIsStart == false) 
            {
                thamSo.programIsStart = true;

                if (radBubble.Checked == true && thamSo.increase == true)
                    BubbleSortincrease(thamSo.arrNode);
                if (radBubble.Checked == true && thamSo.increase == false)
                    BubbleSortGiam(thamSo.arrNode);

                if (radQuick.Checked == true && thamSo.increase == true)
                    QuickSortincrease(thamSo.arrNode, 0, thamSo.nOe - 1);
                if (radQuick.Checked == true && thamSo.increase == false)
                    QuickSortGiam(thamSo.arrNode, 0, thamSo.nOe - 1);

                CompleteSwap(); // Hàm xử lí sau khi hoàn thành
            }
            else
            {
                thamSo.checkPause = false; 
            }
            
        }
        private void bntPause_Click(object sender, EventArgs e)
        {
            bntPlay.Show();                 
            bntPause.Hide();
            thamSo.checkSpace = true;   
            thamSo.checkPause = true;
            ExTime.Stop();              // Dừng timer, tạm dưng thời gian tính toán 
            Play_or_Stop();             // Kiểm tra chương trình đang chạy hay dừng
        }
        public void Pause()                 // Hàm này dùng cho Debug
        {
            if (ckDebug.Checked == true)    // Kiểm tra Debug
            {
                thamSo.checkPause = true;   // Nếu đang tích dấu vào ô Debug thì tạm dừng để quan sát
                Play_or_Stop();             // Kiểm tra lại còn dấu tích không
            }
        }
        public void Play_or_Stop()
        {
            while (thamSo.checkPause == true)
            {
                Application.DoEvents();     
            }
        }
        #endregion

        #region Debug

        private void ckDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDebug.Checked == true)
            {
                speedTrackBar.Value = speedTrackBar.Maximum - 7;
            }
            else
            {
                speedTrackBar.Value = speedTrackBar.Maximum / 2;
                thamSo.checkPause = false;
            }
        }
        private void bntDebug_Click(object sender, EventArgs e)
        {
            thamSo.checkPause = false;
        }
        #endregion

        #region Create Array
        private void bntRandom_Click(object sender, EventArgs e)
        {
            pnlChosesAlgorithms.Enabled = true;
           // grpControl.Enabled = true;
           // grpDebug.Enabled = true;
            Random r = new Random();
            for (int i = 0; i < thamSo.nOe; i++)
            {
                int rd = r.Next(0, 99);

                thamSo.arrLbl[i].Text = rd + "";
                thamSo.arrNode[i] = rd;
            }
            ShowCode();
        }

        private void bntByHand_Click(object sender, EventArgs e)
        {
            pnlChosesAlgorithms.Enabled = true;
           // grpControl.Enabled = true;
           // grpDebug.Enabled = true;
            ShowCode();
            Form1 a = new Form1();
            a.Message = numArray.Value.ToString();
            a.ShowDialog();
            for (int i = 0; i < thamSo.nOe; i++)
            {

                switch (i + 1)
                {
                    case 1: thamSo.arrLbl[i].Text = PT1; thamSo.arrNode[i] = Int32.Parse(PT1); break;
                    case 2: thamSo.arrLbl[i].Text = PT2; thamSo.arrNode[i] = Int32.Parse(PT2); break;
                    case 3: thamSo.arrLbl[i].Text = PT3; thamSo.arrNode[i] = Int32.Parse(PT3); break;
                    case 4: thamSo.arrLbl[i].Text = PT4; thamSo.arrNode[i] = Int32.Parse(PT4); break;
                    case 5: thamSo.arrLbl[i].Text = PT5; thamSo.arrNode[i] = Int32.Parse(PT5); break;
                    case 6: thamSo.arrLbl[i].Text = PT6; thamSo.arrNode[i] = Int32.Parse(PT6); break;
                    case 7: thamSo.arrLbl[i].Text = PT7; thamSo.arrNode[i] = Int32.Parse(PT7); break;
                    case 8: thamSo.arrLbl[i].Text = PT8; thamSo.arrNode[i] = Int32.Parse(PT8); break;
                    case 9: thamSo.arrLbl[i].Text = PT9; thamSo.arrNode[i] = Int32.Parse(PT9); break;
                    case 10: thamSo.arrLbl[i].Text = PT10; thamSo.arrNode[i] = Int32.Parse(PT10); break;
                    case 11: thamSo.arrLbl[i].Text = PT11; thamSo.arrNode[i] = Int32.Parse(PT11); break;
                    case 12: thamSo.arrLbl[i].Text = PT12; thamSo.arrNode[i] = Int32.Parse(PT12); break;
                    case 13: thamSo.arrLbl[i].Text = PT13; thamSo.arrNode[i] = Int32.Parse(PT13); break;
                    case 14: thamSo.arrLbl[i].Text = PT14; thamSo.arrNode[i] = Int32.Parse(PT14); break;
                    case 15: thamSo.arrLbl[i].Text = PT15; thamSo.arrNode[i] = Int32.Parse(PT15); break;
                }
            }
            pnlChosesAlgorithms.Enabled = true;
           // grpControl.Enabled = true;
        }

        private void radDecrease_CheckedChanged(object sender, EventArgs e)
        {
            thamSo.increase = false;
            ShowCode();
        }

        private void radIncrease_CheckedChanged(object sender, EventArgs e)
        {
            thamSo.increase = true;
            ShowCode();
        }
        #endregion

        #endregion

        #region bntBack_Click
        private void bntBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        #endregion
        #region bntExit_Click
        private void bntExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        int min(int a, int b)
        {
            if (a > b)
                return b;
            else
                return a;
        }
        #endregion

        #region bntSourceCode_Click
        private void bntSourceCode_Click(object sender, EventArgs e)
        {
            listCode.Show();
            listIdea.Hide();
        }
        #endregion
        #region bntIdea_Click
        private void bntIdeaAlgorithm_Click(object sender, EventArgs e)
        {
            listIdea.Show();
            listCode.Hide();
        }
        #endregion

        #region ExTime

        private void ExTime_Tick(object sender, EventArgs e)
        {
            if (int.Parse(lblSeconds.Text) == 59)
            {
                lblSeconds.Text = "00";
                lblMinutes.Text = (int.Parse(lblMinutes.Text) + 1).ToString("00");
            }
            else
            {
                lblSeconds.Text = (int.Parse(lblSeconds.Text) + 1).ToString("00");
            }
        }
        #endregion

        #region speedTrackBar_ValueChanged
        private void speedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            thamSo.speed = speedTrackBar.Maximum - speedTrackBar.Value;
        }
        #endregion

        #region rad"Sort"_CheckedChanged
        private void radQuick_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radHeap_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radBubble_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radShell_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radMerge_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radInsertion_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radInterchange_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        private void radSelection_CheckedChanged(object sender, EventArgs e)
        {
            ShowCode();
        }
        #endregion
        #endregion
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
        #region Delay
        //Hàm Delay
        public void Delay(int milisecond)
        {
            //Nếu tốc độ max thì ko sleep
            if (speedTrackBar.Value == speedTrackBar.Maximum)
            {
                Application.DoEvents();
                return;
            }
            Application.DoEvents();
            Thread.Sleep(milisecond);
        }
        #endregion
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                if (thamSo.checkSpace == true)
                    bntPlay.PerformClick();
                else
                    bntPause.PerformClick();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                bntExit.PerformClick();
                return true;
            }
            else if (keyData == Keys.T)

            {
                bntDebug.PerformClick();
                return true;
            }
            else if (keyData == Keys.X)
            {
                bntReset.PerformClick();
                return true;
            }
            else if (keyData == Keys.C)
            {
                bntCreate.PerformClick();
                return true;
            }
            else if (keyData == Keys.R)
            {
                bntRandom.PerformClick();
                return true;
            }
            else if (keyData == Keys.H)
            {
                bntByHand.PerformClick();
                return true;
            }
            else if (keyData == Keys.Up && speedTrackBar.Value < speedTrackBar.Maximum)
            {
                speedTrackBar.Value += 1;
                return true;
            }
            else if (keyData == Keys.Down && speedTrackBar.Value > speedTrackBar.Minimum)
            {
                speedTrackBar.Value -= 1;
                return true;
            }
            else if (keyData == Keys.G)
            {
                btnHelp.PerformClick();
                return true;
            }
            else if (keyData == Keys.S)
            {
                bntSourceCode.PerformClick();
                return true;
            }
            else if (keyData == Keys.I)
            {
                bntIdeaAlgorithm.PerformClick();
                return true;
            }
            else if (keyData == Keys.D)
            {
                docFILE.PerformClick();
                return true;
            }
            else if (keyData == Keys.F)
            {
                HT_File.PerformClick();
                return true;
            }
            else return false;
        }

        private void HT_File_Click(object sender, EventArgs e)
        {
            Process notePad = new Process();

            notePad.StartInfo.FileName = "notepad.exe";
            notePad.StartInfo.Arguments = Application.StartupPath + @"/TEST.txt";
            notePad.Start();

        }
    }
}

