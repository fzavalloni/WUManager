namespace WUManager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Threading;
    using WUManager.Enums;
    using WUManager.Tools;
    using System.Diagnostics;

    delegate void DataGridViewAddRowDelegate(string host);
    delegate void DataGridViewAddRowsDelegate(string[] hosts);
    delegate void DataGridViewRowDelegate(DataGridViewRow row);
    delegate void DataGridViewBatchRowDelegate(DataGridViewRow row, DateTime executionTime);

    public partial class FormMain : Form
    {
        private Dictionary<DataGridViewRow, Thread> threadList;
        private Tools.Pinger pinger;
        private Tools.OSManager osManager;
        static Semaphore semaphore;
        private bool isBatchExecution = false;

        public FormMain()
        {
            InitializeComponent();

            this.threadList = new Dictionary<DataGridViewRow, Thread>();
            this.pinger = new Tools.Pinger(this.dataGridView.DefaultCellStyle.Font);
            this.osManager = new Tools.OSManager(this.dataGridView.DefaultCellStyle.Font);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        public void DataGridViewAddRow(string host)
        {
            if (dataGridView.InvokeRequired)
            {
                // this is worker thread
                DataGridViewAddRowDelegate delegateAddRow =
                    new DataGridViewAddRowDelegate(DataGridViewAddRow);
                dataGridView.Invoke(delegateAddRow, host);
            }
            else
            {
                // this is UI thread
                // formating data
                host = host.Replace("\t", "");
                host = host.Replace("\r\n", "");
                host = host.Replace(" ", "");
                // add line.
                if (!string.IsNullOrEmpty(host))
                {
                    dataGridView.Rows.Add(host);
                }
            }
        }

        public void DataGridViewAddRow(string[] hosts)
        {
            foreach (string host in hosts)
            {
                DataGridViewAddRow(host);
            }
        }

        private void OpenFormAddHosts()
        {
            FormAddHosts f = new FormAddHosts(this);
            f.ShowDialog();
        }

        private void AddHosts_Click(object sender, EventArgs e)
        {
            this.OpenFormAddHosts();
        }

        #region Actions

        private void Act_CountUpdatesSelectedItens()
        {
            DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_CountUpdates);

            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                de.BeginInvoke(row, null, null);
            }

        }

        private void Act_CountUpdates(DataGridViewRow row)
        {
            lock (threadList)
            {
                if (threadList.ContainsKey(row))
                {
                    return;
                }
            }

            DgvUtils.SetRowValue(ref row, WUCollums.Status, "Initializing");
            Thread newThread = new Thread(Act_CountUpdatesExecutor);

            lock (threadList)
            {
                threadList.Add(row, newThread);
            }

            newThread.IsBackground = true;
            newThread.Start(row);

        }

        private void Act_InstallUpdateInSelectedItens()
        {
            DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_InstallUpdates);

            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                de.BeginInvoke(row, null, null);
            }
        }

        private void Act_InstallUpdates(DataGridViewRow row)
        {
            lock (threadList)
            {
                if (threadList.ContainsKey(row))
                {
                    return;
                }
            }

            DgvUtils.SetRowValue(ref row, WUCollums.Status, "Initializing");
            Thread newThread = new Thread(Act_InstallUpdatesExecutor);

            lock (threadList)
            {
                threadList.Add(row, newThread);
            }

            newThread.IsBackground = true;
            newThread.Start(row);
        }

        private void Act_InstallUpdatesInterpretor(ref DataGridViewRow row, string line)
        {
            string[] lineParts = line.Split(':');

            string operation = lineParts[0];

            string[] parameters = new string[] { string.Empty };
            if (lineParts.Length > 1)
            {
                parameters = lineParts[1].Split('|');
            }

            WUAOperations operations = (WUAOperations)Enum.Parse(typeof(WUAOperations), operation);

            switch (operations)
            {
                case WUAOperations.WUA_Starting:
                    {
                        //WUA_Starting

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Starting");
                        break;
                    }
                case WUAOperations.WUA_IsBusy:
                    {
                        //WUA_IsBusy

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Is Busy");
                        break;
                    }
                case WUAOperations.WUA_FindingUpdates:
                    {
                        //WUA_FindingUpdates

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Finding Updates");
                        break;
                    }
                case WUAOperations.WUA_NoApplicableUpdates:
                    {
                        //WUA_NoApplicableUpdates

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU No Applicable Updates");
                        DgvUtils.SetRowValue(ref row, WUCollums.Updates, 0);
                        break;
                    }
                case WUAOperations.WUA_UpdateItem:
                    {
                        //WUA_UpdateItem:N|Title

                        DgvUtils.SetRowValue(ref row, WUCollums.Updates, Convert.ToInt32(parameters[0]));
                        break;
                    }
                case WUAOperations.WUA_DownloadingStarted:
                    {
                        //WUA_DownloadingStarted

                        DgvUtils.SetRowProgressColor(ref row, Color.Tomato, Color.Red);
                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Downloading Started");
                        break;
                    }
                case WUAOperations.WUA_DownloadingProgress:
                    {
                        //WUA_DownloadingProgress:N|N%|T%

                        DgvUtils.SetRowValue(ref row, WUCollums.Progress, Convert.ToInt32(parameters[2]));
                        break;
                    }
                case WUAOperations.WUA_DownloadingCompleted:
                    {
                        //WUA_DownloadingCompleted:ResultCode

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Downloading Completed");
                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Downloading result: " + parameters[0]);
                        break;
                    }
                case WUAOperations.WUA_InstallationStarted:
                    {
                        //WUA_InstallationStarted

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Installation Started");
                        DgvUtils.SetRowValue(ref row, WUCollums.Progress, 0);
                        DgvUtils.SetRowProgressColor(ref row, Color.MediumSpringGreen, Color.Green);
                        break;
                    }
                case WUAOperations.WUA_InstallationProgress:
                    {
                        //WUA_InstallationProgress:N|N%|T%

                        DgvUtils.SetRowValue(ref row, WUCollums.Progress, Convert.ToInt32(parameters[2]));
                        break;
                    }
                case WUAOperations.WUA_InstallationCompleted:
                    {
                        //WUA_InstallationCompleted:ResultCode|RebootRequired

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Installation Completed");
                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Installation result: " + parameters[0]);
                        DgvUtils.SetRowValue(ref row, WUCollums.RebootRequired, Convert.ToBoolean(parameters[1]));
                        break;
                    }
                case WUAOperations.WUA_InstallationResult:
                    {
                        //WUA_InstallationResult:N|ResultCode|RebootRequired

                        break;
                    }
                case WUAOperations.WUA_Finish:
                    {
                        //WUA_Finish

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Finish");
                        break;
                    }
                case WUAOperations.WUA_InternalError:
                    {
                        //WUA_InternalError:Message

                        DgvUtils.SetRowValue(ref row, WUCollums.Status, "WU Internal Error");
                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, parameters[0]);
                        break;
                    }
                case WUAOperations.WUA_Pending:
                    {
                        DgvUtils.SetRowValue(ref row, WUCollums.Updates, lineParts[1]);
                        break;
                    }
            }
        }

        private void Act_InstallUpdatesExecutor(object rowObject)
        {
            DataGridViewRow row = (DataGridViewRow)rowObject;

            try
            {
                OperSystemUtils operSys = new OperSystemUtils();

                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 160);
                row.DefaultCellStyle.SelectionBackColor = Color.Coral;

                DgvUtils.SetRowValue(ref row, WUCollums.Status, "Starting");
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, string.Empty);
                DgvUtils.SetRowValue(ref row, WUCollums.Progress, 0);

                string hostName = row.Cells["Host"].Value.ToString();

                operSys.CopyPsExec(hostName);

                StreamReader reader = operSys.ExecWua("/install /showProgress", hostName);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Act_InstallUpdatesInterpretor(ref row, line);
                }
            }
            catch (Exception ex)
            {
                DgvUtils.SetRowValue(ref row, WUCollums.Status, "ThreadError");
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, ex.Message);
            }
            finally
            {
                this.Sys_RemoveThreadRow(ref row);
            }
        }


        private void Act_CountUpdatesExecutor(object rowObject)
        {
            DataGridViewRow row = (DataGridViewRow)rowObject;

            try
            {
                OperSystemUtils operSys = new OperSystemUtils();

                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 160);
                row.DefaultCellStyle.SelectionBackColor = Color.Coral;

                DgvUtils.SetRowValue(ref row, WUCollums.Status, "Starting");
                DgvUtils.SetRowValue(ref row, WUCollums.Updates, string.Empty);
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, string.Empty);
                DgvUtils.SetRowValue(ref row, WUCollums.Progress, 0);

                string hostName = row.Cells["Host"].Value.ToString();

                operSys.CopyPsExec(hostName);

                StreamReader reader = operSys.ExecWua("/countUpdates", hostName);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Act_InstallUpdatesInterpretor(ref row, line);
                }
            }
            catch (Exception ex)
            {
                DgvUtils.SetRowValue(ref row, WUCollums.Status, "ThreadError");
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, ex.Message);
            }
            finally
            {
                this.Sys_RemoveThreadRow(ref row);
            }
        }

        private void Sys_RemoveThreadRow(ref DataGridViewRow row)
        {
            if (!isBatchExecution)
            {
                lock (threadList)
                {
                    if (threadList.ContainsKey(row))
                    {
                        threadList.Remove(row);
                    }
                }
            }
        }

        private void Act_RemoveSelectedItens()
        {
            DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_RemoveItem);

            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                de.BeginInvoke(row, null, null);
            }
        }

        private void Act_RemoveItem(DataGridViewRow row)
        {
            if (dataGridView.InvokeRequired)
            {
                DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_RemoveItem);
                dataGridView.Invoke(de, row);
            }
            else
            {
                pinger.BeginStop(row);

                lock (row)
                {
                    lock (threadList)
                    {
                        if (threadList.ContainsKey(row))
                        {
                            threadList[row].Abort(null);
                            threadList.Remove(row);
                        }
                    }

                    dataGridView.Rows.Remove(row);
                }
            }
        }

        private void Act_Exit()
        {
            lock (threadList)
            {
                foreach (KeyValuePair<DataGridViewRow, Thread> item in threadList)
                {
                    item.Value.Abort();
                }
            }

            this.Close();
        }
        // This method was created because, by default, the method SelectedRows execute the row
        // from the botton to the top, and it fixes this to keep the execution order more
        // intuitive mainly for the Batch Executions
        private List<DataGridViewRow> InvertSelectedRowOrder(DataGridViewSelectedRowCollection selectedRows)
        {
            List<DataGridViewRow> rowList = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in selectedRows)
            {
                rowList.Add(row);
            }
            rowList.Reverse();
            return rowList;
        }

        private void Act_StartPingInSelectedItens()
        {

            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                string host = row.Cells["Host"].Value.ToString();
                pinger.BeginStart(host, row);
            }
        }

        private void Act_StartCheckRebootSelectedItens()
        {
            DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_StartCheckReboot);
            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                de.BeginInvoke(row, null, null);
            }
        }

        private void Act_StartCheckReboot(DataGridViewRow row)
        {
            try
            {
                DgvUtils.SetRowValue(ref row, WUCollums.RebootRequired, false);
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, string.Empty);

                OperSystemUtils operUtils = new OperSystemUtils();

                string host = row.Cells["Host"].Value.ToString();
                bool isRequiredBoot = operUtils.IsRebootRequired(host);

                if (isRequiredBoot)
                {
                    DgvUtils.SetRowValue(ref row, WUCollums.RebootRequired, true);
                    DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Reboot Required");
                }
                else
                {
                    DgvUtils.SetRowValue(ref row, WUCollums.RebootRequired, false);
                    DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Reboot NOT Required");
                }
            }
            catch (Exception erro)
            {
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, erro.Message);
            }
        }

        private void Act_StopPingInSelectedItens()
        {
            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                pinger.BeginStop(row);
            }
        }

        private void Act_GetReadinessInSelectedItens()
        {
            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                string host = row.Cells["Host"].Value.ToString();
                osManager.BeginHostReadiness(host, row, chkBoxClusterResources.Checked);
            }
        }

        private void Act_RebootSelectedItens()
        {
            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_StopThreadAndReboot);
                de.BeginInvoke(row, null, null);
            }
        }

        public void Act_InstallUpdateBatchInSelectedItens(DateTime executionTime)
        {
            // Add semaphore to control threads
            CreateSemaphore();

            DataGridViewBatchRowDelegate de = new DataGridViewBatchRowDelegate(Act_InstallUpdatesBatch);

            foreach (DataGridViewRow row in InvertSelectedRowOrder(dataGridView.SelectedRows))
            {
                de.BeginInvoke(row, executionTime, null, null);
            }
        }

        private void CreateSemaphore()
        {
            int threadCounter = (int)numUpDownTreads.Value == 0 ? 10000 : (int)numUpDownTreads.Value;
            if (semaphore == null)
                semaphore = new Semaphore(threadCounter, 10000);
        }

        private void Act_StopThreadAndReboot(DataGridViewRow row)
        {
            DataGridViewRowDelegate de = new DataGridViewRowDelegate(Act_StopThreadAndReboot);
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(de, row);
            }
            else
            {
                lock (row)
                {
                    string host = row.Cells["Host"].Value.ToString();

                    osManager.BeginReboot(row, host);

                    lock (threadList)
                    {
                        if (threadList.ContainsKey(row))
                        {
                            threadList[row].Abort(null);

                            Thread.Sleep(5000);
                        }
                    }

                    pinger.BeginStart(host, row);
                }
            }
        }

        #endregion

        #region Tool Strip Menu

        private void AddToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.OpenFormAddHosts();
        }

        private void InstallUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_InstallUpdateInSelectedItens();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_Exit();
        }

        private void StartPingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_StartPingInSelectedItens();
        }

        private void RtopPingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_StopPingInSelectedItens();
        }

        private void GetLastBootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_GetReadinessInSelectedItens();
        }

        private void RebootToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_RebootSelectedItens();
        }

        private void StartPingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_StartPingInSelectedItens();
        }

        private void StopPingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_StopPingInSelectedItens();
        }

        private void GetLastBootToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_GetReadinessInSelectedItens();
        }

        private void RebootToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Act_RebootSelectedItens();
        }

        private void InstallUpdatesContextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_InstallUpdateInSelectedItens();
        }

        private void RemoveItensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_RemoveSelectedItens();
        }

        private void RemoveContextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_RemoveSelectedItens();
        }

        #endregion


        private void CheckRebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_StartCheckRebootSelectedItens();
        }

        private void CountUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_CountUpdatesSelectedItens();
        }

        private void CheckRebootToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Act_StartCheckRebootSelectedItens();
        }

        private void CountUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Act_CountUpdatesSelectedItens();
        }

        private void SaveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count != 0)
            {
                this.saveFile.FileName = "List.txt";
                this.saveFile.DefaultExt = "txt";
                this.saveFile.RestoreDirectory = true;

                RichTextBox hostsList = FillTextList();

                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    hostsList.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private RichTextBox FillTextList()
        {
            RichTextBox list = new RichTextBox();

            foreach (DataGridViewRow obj in dataGridView.Rows)
            {
                string line = string.Format("{0}\r\n", obj.Cells["Host"].Value.ToString());
                list.AppendText(line);
            }
            return list;
        }

        private void InstallUpdatesBatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStartBatch form = new FormStartBatch(this);
            form.ShowDialog();
        }

        private void Act_InstallUpdatesBatch(DataGridViewRow row, DateTime executionTime)
        {
            // Waiting execution schedule
            bool isBackgroundSet = false;
            do
            {
                if (!isBackgroundSet)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;

                    DgvUtils.SetRowValue(ref row, WUCollums.BatchStep, $"Waiting");
                    DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, $"Execution Scheduled for: {executionTime.ToString("hh:mm tt - dd/MM/yy")}");
                    isBackgroundSet = true;
                }
                Thread.Sleep(30000);
            } while (executionTime >= DateTime.Now);

            DgvUtils.SetRowValue(ref row, WUCollums.BatchStep, "Waiting thread");
            semaphore.WaitOne();

            lock (threadList)
            {
                if (threadList.ContainsKey(row))
                {
                    return;
                }
            }

            Thread newThread = new Thread(Act_InstallUpdatesBatchExecutor);

            lock (threadList)
            {
                threadList.Add(row, newThread);
            }

            newThread.IsBackground = true;
            newThread.Start(row);
        }

        private void Act_InstallUpdatesBatchExecutor(object rowObject)
        {
            isBatchExecution = true;
            bool isRebootRequired = false;
            DateTime lastReboot = new DateTime();
            DataGridViewRow row = (DataGridViewRow)rowObject;
            string host = row.Cells["Host"].Value.ToString();
            string operResult = string.Empty;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                int minutesRebootLastRebootCheck = (int)numUpDownMinutesReboot.Value;
                int rebootCheckAttempts = (int)numUpDownAttemptsNumber.Value;

                // Failover Cluster Services
                if (chkBoxCluster.Checked)
                {
                    DgvUtils.SetRowValue(ref row, WUCollums.BatchStep, "Moving_ClusterResources (1/5)");
                    osManager.StartHostReadiness(host, ref row, chkBoxClusterResources.Checked);
                    bool isClustered = Convert.ToBoolean(DgvUtils.GetRowValue(ref row, WUCollums.Cluster));
                    if (isClustered)
                    {
                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Executing remote powershell to move resources...");
                        osManager.FailOverClusterNode(host);
                    }
                }

                // Install Updates
                DgvUtils.SetRowStyleForeColor(ref row, WUCollums.Status, Color.Black);
                DgvUtils.SetRowValue(ref row, WUCollums.BatchStep, "Inst_Updates (2/5)");

                Act_InstallUpdatesExecutor(row);
                //On error it stops the batch
                CheckBatchExecutionErrors(row);

                isRebootRequired = Convert.ToBoolean(DgvUtils.GetRowValue(ref row, WUCollums.RebootRequired));
                int updatesInstalled = Convert.ToInt32(DgvUtils.GetRowValue(ref row, WUCollums.Updates));

                // Reboot                
                DgvUtils.SetRowValue(ref row, WUCollums.BatchStep, "Rebooting (3/5)");
                if (isRebootRequired)
                {
                    int attempts = 0;
                    string errorRebootMessage = string.Empty;
                    osManager.StartReboot(host, ref row);
                    pinger.BeginStart(host, row);

                    // Testing server when it comes online
                    do
                    {
                        //Wait 30 seconds 
                        Thread.Sleep(30000);
                        if (attempts <= rebootCheckAttempts)
                        {
                            try
                            {
                                lastReboot = osManager.GetLastBootDateTimeObject(host, ref row);
                                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, string.Empty);
                                DgvUtils.SetRowValue(ref row, WUCollums.LastBoot, lastReboot.ToString("dd/MM/yyyy HH:mm"));
                            }
                            catch
                            {
                                // returns a generic date just to keep the execution
                                lastReboot = new DateTime(2000, 1, 1);
                            }
                        }
                        else
                        {
                            errorRebootMessage = $"Number of attempts has been reached";
                            break;
                        }

                        attempts++;

                        DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, $"Host has not completed the reboot yet...(attempt: {attempts})");

                        // Check if the last boot time attribute
                    } while ((int)(DateTime.Now - lastReboot).TotalMinutes >= minutesRebootLastRebootCheck);

                    // Stop the execution when it has reached the attempts limit 
                    if (!string.IsNullOrEmpty(errorRebootMessage))
                        throw new Exception(errorRebootMessage);
                    DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Server Online");

                    pinger.BeginStop(row);

                    osManager.StartHostReadiness(host, ref row, chkBoxClusterResources.Checked);
                }
                else
                {
                    DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, "Reboot not required");
                }

                // Count Updates
                if (updatesInstalled != 0)
                {
                    DgvUtils.SetRowValue(ref row, WUCollums.BatchStep, "Count_Updates (4/5)");
                    // Give more time to rpc services start
                    Thread.Sleep(40000);
                    Act_CountUpdatesExecutor(row);
                    //On error it stops the batch
                    CheckBatchExecutionErrors(row);
                }

                DgvUtils.SetRowValue(ref row, WUCollums.BatchStep, "Finished (5/5)");
            }
            catch (Exception ex)
            {
                DgvUtils.SetRowValue(ref row, WUCollums.Status, "ThreadError");
                DgvUtils.SetRowStyleForeColor(ref row, WUCollums.Status, Color.Red);
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults, ex.Message);
            }
            finally
            {
                isBatchExecution = false;
                sw.Stop();
                operResult = DgvUtils.GetRowValue(ref row, WUCollums.OperationResults).ToString();
                DgvUtils.SetRowValue(ref row, WUCollums.OperationResults,
                    string.Format("Duration: {0} min  {1}", (int)sw.Elapsed.Duration().TotalMinutes, operResult));
                semaphore.Release();
                this.Sys_RemoveThreadRow(ref row);
            }
        }

        private void CheckBatchExecutionErrors(DataGridViewRow row)
        {
            try
            {
                string batchStatus = DgvUtils.GetRowValue(ref row, WUCollums.Status).ToString();
                string operationResult = DgvUtils.GetRowValue(ref row, WUCollums.OperationResults).ToString();
                if (string.Equals(batchStatus, "ThreadError", StringComparison.CurrentCultureIgnoreCase))
                    throw new Exception($"BatchExecutionError: {operationResult}");
            }
            catch { }
        }
    }
}
