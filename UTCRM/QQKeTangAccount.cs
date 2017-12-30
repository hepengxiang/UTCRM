using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UTCRM
{
    public partial class QQKeTangAccount : Form
    {
        public QQKeTangAccount()
        {
            InitializeComponent();
        }

        keqq kq = new keqq();
        qqApp qqapp = new qqApp();
        private void QQKeTangAccount_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);
            this.dataGridView1.DataSource = kq.GetKeQQPlan(frmMain.CurQQ, qqapp.get_bkn());
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush((sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor);
            try
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), (sender as DataGridView).DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
            catch { }
        }
    }
}
