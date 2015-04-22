namespace WUManager.ProgBar
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    using System.ComponentModel;

    public class DataGridViewProgressCell : DataGridViewImageCell
    {
        const int minVal = 0;
        const int maxVal = 100;
        const int margin = 3;

        private WUManager.Controls.ProgressBar pb = new WUManager.Controls.ProgressBar();
        private Label lbl = new Label();
        private Color endColor;
        private Color startColor;

        static DataGridViewProgressCell()
        {
        }

        public DataGridViewProgressCell()
        {
            this.ValueType = typeof(int);

            pb.MinValue = minVal;
            pb.MaxValue = maxVal;
            pb.Value = minVal;

            this.endColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(163)), ((System.Byte)(211)));
            this.startColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(211)), ((System.Byte)(40)));
        }

        protected override object GetFormattedValue(object value,
            int rowIndex, ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            if (value == null)
                value = 0;

            int progressVal = (int)value;

            if (progressVal > maxVal)
                progressVal = maxVal;
            if (progressVal < minVal)
                progressVal = minVal;

            Bitmap bmp = new Bitmap(OwningColumn.Width - margin, OwningRow.Height - margin);
            Bitmap bmptxt = new Bitmap(OwningColumn.Width, OwningRow.Height);

            pb.Height = bmp.Height;
            pb.Width = bmp.Width;

            pb.BackColor = System.Drawing.Color.Transparent;
            pb.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(100)), ((System.Byte)(201)), ((System.Byte)(201)), ((System.Byte)(201)));
            pb.StartColor = this.startColor;
            pb.EndColor = this.endColor;
            //pb.HighlightColor = System.Drawing.Color.Orange;
            pb.TabIndex = 0;

            pb.Value = progressVal;
            pb.Update();
            pb.Invalidate();

            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Height = bmptxt.Height;
            lbl.Width = bmptxt.Width;

            if (!this.Selected)
            {
                lbl.ForeColor = cellStyle.ForeColor;
                lbl.BackColor = cellStyle.BackColor;
            }
            else
            {
                lbl.ForeColor = cellStyle.SelectionForeColor;
                lbl.BackColor = cellStyle.SelectionBackColor;
            }            

            pb.DrawToBitmap(bmp, pb.ClientRectangle);
            
            lbl.Text = String.Format("{0}%", progressVal);
            lbl.Image = bmp;
            lbl.ImageAlign = ContentAlignment.MiddleCenter;
            lbl.DrawToBitmap(bmptxt, lbl.ClientRectangle);

            return bmptxt;
        }

        public void SetStartColor(Color color)
        {
            this.startColor = color;
        }

        public void SetEndColor(Color color)
        {
            this.endColor = color;
        }
    }
}
