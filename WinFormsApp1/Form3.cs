using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private int nborderGap = 10;

        private int m_nMaxTop = 0;
        private int m_nMaxLeft = 0;

        private int nWidth = 60;//40;
        private int nHeight = 48;//32;

        private int nTotalCount = 500;
        private int nDiv = 12;

        private int nMarginleft = 10;
        private int nMarginRight = 10;
        private int nMarginTop = 10;
        private int nMarginBottom = 10;
        private int nGap = 3;

        private Controls.clsPanelList list = new Controls.clsPanelList();

        private Controls.TablePanel tablePanel;

        public Form3()
        {
            InitializeComponent();
        }

        private void InitBorderPanel()
        {
            borderPanel1.Location = new Point(nborderGap, nborderGap);
            borderPanel1.Height = (ClientRectangle.Height - (nborderGap * 6));
            borderPanel1.Width = (ClientRectangle.Width - (nborderGap * 2));
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InitBorderPanel();

            initControl();

            setTablePanelItem();

            textBox1.Text = String.Format("{0}", nWidth);
            textBox2.Text = String.Format("{0}", nHeight);
        }

        private void initControl()
        {
            m_nMaxTop = 0;
            m_nMaxLeft = 0;

            int nScrW = borderPanel1.Width - (nGap * 2);
            int nScrH = borderPanel1.Height - (nGap * 2);

            //스크롤
            this.xtraScrollableControl1.BackColor = Color.FromArgb(40, 40, 40);
            this.xtraScrollableControl1.Dock = DockStyle.None;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(nGap, nGap);
            this.xtraScrollableControl1.Size = new System.Drawing.Size(nScrW, nScrH);
            this.xtraScrollableControl1.VerticalScroll.Value = 0;
            this.xtraScrollableControl1.HorizontalScroll.Value = 0;

            //메인 패널
            pnlMain.Location = new Point(0, 0);
            pnlMain.Size = xtraScrollableControl1.Size;
            pnlMain.AllowDrop = true;

            //스크롤 넓이에 따른 가로 개수 정의
            nDiv = ((xtraScrollableControl1.Width - nWidth - (nMarginRight * 2)) / nWidth);

            //string sMsg = string.Format("nScrW {0} nScrH {1} nDiv {2}", nScrW, nScrH, nDiv);
            //Console.WriteLine(sMsg);
        }
        
        private void setTablePanelItem()
        {
            TablePanel_Clear();

            TablePanel_Display();

            TablePanel_Resize();

            Init_TablePanelPosition();

            TablePanelMaxLocation();

            this.xtraScrollableControl1.Visible = true;
        }

        public void TablePanel_Clear()
        {
            try
            {
                if (list.Count > 0)
                {
                    for (int i = 0; i < nTotalCount; i++)
                    {
                        list[i].Visible = false;
                        list[i].Dispose();
                    }
                    pnlMain.Refresh();

                    list.Clear();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void TablePanel_Resize()
        {
            try
            {
                for (int i = 0; i < nTotalCount; i++)
                {
                    list[i].ReSize(nWidth, nHeight);
                    list[i].Refresh();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void TablePanel_Display()
        {
            for (int i = 0; i < nTotalCount; i++)
            {
                tablePanel = new Controls.TablePanel();

                try
                {
                    tablePanel.Parent = pnlMain;
                    tablePanel.TabIndex = i;
                    tablePanel.Tag = string.Format("{0}", i + 1);
                    tablePanel.delMouseDown += new Controls.TablePanel_MouseDown(func_MouseDown);
                    tablePanel.delMouseMove += new Controls.TablePanel_MouseMove(func_MouseMove);
                    tablePanel.delMouseUp += new Controls.TablePanel_MouseUp(func_MouseUp);
                    tablePanel.delMouseEnter += new Controls.TablePanel_MouseEnter(func_MouseEnter);
                    tablePanel.delMouseLeave += new Controls.TablePanel_MouseLeave(func_MouseLeave);

                    tablePanel.AllowDrop = true;
                    tablePanel.Enabled = true;
                    tablePanel.Visible = true;

                    list.Add(i, tablePanel);
                    list[i].BringToFront();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        public void Init_TablePanelPosition()
        {
            for (int i = 0; i < nTotalCount; i++)
            {
                list[i].ReSize(nWidth, nHeight);

                if (i == 0) //첫번째 데이터
                {
                    list[i].Left = nMarginleft;
                    list[i].Top = nMarginTop;
                }
                else
                {
                    int nGapHeight = i / nDiv;              //간격 높이
                    int nGapWidth = i % nDiv;              // 간격 넓이 
                    int nLeft = nGapWidth * nWidth;
                    int nTop = nGapHeight * nHeight;
                    list[i].Left = nLeft + nMarginleft;
                    list[i].Top = nTop + nMarginTop;
                }

                m_nMaxTop = (m_nMaxTop > list[i].Top) ? m_nMaxTop : list[i].Top;
                m_nMaxLeft = (m_nMaxLeft > list[i].Left) ? m_nMaxLeft : list[i].Left;
            }
        }

        public void TablePanelMaxLocation()
        {
            //아래쪽도 마진을 맞추기 위해 전체 높이를 마진만큼 증가
            pnlMain.Height = m_nMaxTop + list[1].Height + nMarginBottom;

            //오른쪽도 마진을 맞추기 위해 전체 넓이를 마진만큼 증가
            pnlMain.Width = m_nMaxLeft + list[1].Width + nMarginRight;

            pnlMain.Location = new Point(0, 0);
        }

        private void func_MouseDown(int nIndex, MouseEventArgs e)
        {
            string sMsg = string.Format("func_MouseDown [{0}] tag {1} point({2},{3})", nIndex, list[nIndex].Tag, list[nIndex].Location.X, list[nIndex].Location.Y);
            //Console.WriteLine(sMsg);
        }

        private void func_MouseUp(int nIndex, MouseEventArgs e)
        {
            string sMsg = string.Format("func_MouseUp [{0}] tag {1} point({2},{3})", nIndex, list[nIndex].Tag, list[nIndex].Location.X, list[nIndex].Location.Y);
            //Console.WriteLine(sMsg);
        }

        private void func_MouseMove(int nIndex, MouseEventArgs e)
        {
            string sMsg = string.Format("func_MouseMove [{0}] tag {1} point({2},{3})", nIndex, list[nIndex].Tag, list[nIndex].Location.X, list[nIndex].Location.Y);
            //Console.WriteLine(sMsg);
        }
        private void func_MouseEnter(int nIndex, EventArgs e)
        {
            string sMsg = string.Format("func_MouseEnter [{0}] tag {1} point({2},{3})", nIndex, list[nIndex].Tag, list[nIndex].Location.X, list[nIndex].Location.Y);
            Console.WriteLine(sMsg);
        }

        private void func_MouseLeave(int nIndex, EventArgs e)
        {
            string sMsg = string.Format("func_MouseLeave [{0}] tag {1} point({2},{3})", nIndex, list[nIndex].Tag, list[nIndex].Location.X, list[nIndex].Location.Y);
            Console.WriteLine(sMsg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nWidth = Convert.ToInt32(textBox1.Text);
            nHeight = Convert.ToInt32(textBox2.Text);

            initControl();
                        
            setTablePanelItem();
        }
    }
}
