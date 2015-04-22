namespace WUManager.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net.NetworkInformation;
    using System.Windows.Forms;
    using System.Threading;
    using System.Net.Sockets;
    using System.Drawing;

    internal class Pinger
    {
        private delegate void BeginStartDelegate(string host, ref DataGridViewRow row);
        private Ping pingSender;
        private PingOptions options;
        private byte[] buffer;
        private int timeout;
        private List<DataGridViewRow> listRow;
        private Font defaultCellStyle;

        public Pinger(Font defaultCellStyle)
        {
            this.pingSender = new Ping();
            this.options = new PingOptions();
            this.listRow = new List<DataGridViewRow>();
            this.defaultCellStyle = defaultCellStyle;

            // Use the default Ttl value which is 128, but change the fragmentation behavior.
            options.DontFragment = false;

            // Create a buffer of 1 byte of data to be transmitted.
            this.buffer = new byte[] { 1 };
            this.timeout = 1000;
        }

        public void BeginStart(string host, DataGridViewRow row)
        {
            lock (listRow)
            {
                if (!listRow.Contains(row))
                {
                    SetRowStyleFont(ref row, new Font(defaultCellStyle, FontStyle.Regular));
                    SetRowStyleForeColor(ref row, Color.Black);

                    listRow.Add(row);

                    BeginStartDelegate de = new BeginStartDelegate(Start);
                    de.BeginInvoke(host, ref row, null, null);
                }
            }
        }

        public void BeginStop(DataGridViewRow row)
        {
            lock (listRow)
            {
                listRow.Remove(row);

                SetRowStyleFont(ref row, new Font(defaultCellStyle, FontStyle.Italic | FontStyle.Strikeout));
                SetRowStyleForeColor(ref row, Color.Silver);
            }
        }

        private bool IsPinging(ref DataGridViewRow row)
        {
            lock (listRow)
            {
                return listRow.Contains(row);
            }
        }

        private void Start(string host, ref DataGridViewRow row)
        {
            int n = 0;
            string rep = string.Empty;
            while (this.IsPinging(ref row))
            {
                try
                {
                    PingReply reply = pingSender.Send(host, this.timeout, this.buffer, this.options);

                    if (reply.Status == IPStatus.Success)
                    {
                        rep = string.Format("{0} {1} Time {2}",
                            ++n, reply.Address, reply.RoundtripTime);

                        SetRowStyleForeColor(ref row, Color.Black);
                    }
                    else
                    {
                        rep = string.Format("{0} {1}",
                            ++n, reply.Status);

                        SetRowStyleForeColor(ref row, Color.Red);
                    }                    
                }
                catch (Exception ex)
                {
                    rep = string.Format("{0} {1}",
                        ++n, ex.GetBaseException().Message);

                    SetRowStyleForeColor(ref row, Color.Red);
                }

                try
                {
                    SetRowValue(ref row, rep);
                }
                catch
                {
                    this.BeginStop(row);
                    return;
                }

                Thread.Sleep(2000);
            }
        }

        private void SetRowStyleFont(ref DataGridViewRow row, Font font)
        {
            try
            {
                row.Cells["PingReply"].Style.Font = font;
            }
            catch { }
        }

        private void SetRowStyleForeColor(ref DataGridViewRow row, Color color)
        {
            try
            {
                row.Cells["PingReply"].Style.ForeColor = color;
            }
            catch { }
        }

        private void SetRowValue(ref DataGridViewRow row, Object obj)
        {
            try
            {
                row.Cells["PingReply"].Value = obj;
            }
            catch { }
        }
    }
}
