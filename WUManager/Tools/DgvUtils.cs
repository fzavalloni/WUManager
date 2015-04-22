namespace WUManager.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    using WUManager.Enums;

    internal class DgvUtils
    {
        internal static void SetRowStyleFont(ref DataGridViewRow row, WUCollums wuCollum, Font font)
        {
            try
            {
                row.Cells[wuCollum.ToString()].Style.Font = font;
            }
            catch { }
        }

        internal static void SetRowStyleForeColor(ref DataGridViewRow row, WUCollums wuCollum, Color color)
        {
            try
            {
                row.Cells[wuCollum.ToString()].Style.ForeColor = color;
            }
            catch { }
        }

        internal static void SetRowProgressColor(ref DataGridViewRow row, Color startColor, Color endColor)
        {
            try
            {
                ((ProgBar.DataGridViewProgressCell)row.Cells["Progress"]).SetStartColor(startColor);
                ((ProgBar.DataGridViewProgressCell)row.Cells["Progress"]).SetEndColor(endColor);
            }
            catch { }
        }

        internal static void SetRowValue(ref DataGridViewRow row, WUCollums wuCollum, Object obj)
        {
            try
            {
                row.Cells[wuCollum.ToString()].Value = obj;
            }
            catch { }
        }        
    }
}
