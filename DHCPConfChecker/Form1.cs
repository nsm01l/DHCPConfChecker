using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DHCPConfChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMessage.Text = "run.\r\n";
        }

        private void btnISCConfOpen_Click(object sender, EventArgs e)
        {
            btnISCConfOpen.Enabled = false;

            if (openConfDialog.ShowDialog() == DialogResult.OK)
            {
                string fText = OpenAndFormatConf(openConfDialog.FileName);
                List<Host> hostList = GetHostsFromISCConf(fText);
                CheckDup(hostList);
            }

            btnISCConfOpen.Enabled = true;
        }

        private void btnISCLdifOpen_Click(object sender, EventArgs e)
        {
            btnISCLdifOpen.Enabled = false;

            if (openLdifDialog.ShowDialog() == DialogResult.OK)
            {
                string fText = "";
                using (StreamReader st = new StreamReader(openLdifDialog.FileName))
                {
                    fText = st.ReadToEnd();
                }
                List<Host> hostList = GetHostsFromISCLdif(fText);
                CheckDup(hostList);
            }

            btnISCLdifOpen.Enabled = true;
        }

        private void btnKeaConfOpen_Click(object sender, EventArgs e)
        {
            btnKeaConfOpen.Enabled = false;

            if (openConfDialog.ShowDialog() == DialogResult.OK)
            {
                string fText = "";
                using (StreamReader st = new StreamReader(openConfDialog.FileName))
                {
                    fText = st.ReadToEnd();
                }
                List<Host> hostList = GetHostsFromKeaConf(fText);
                CheckDup(hostList);
            }

            btnKeaConfOpen.Enabled = true;
        }

        private void btnISCConfExport_Click(object sender, EventArgs e)
        {
            btnISCConfExport.Enabled = false;
            if (openConfDialog.ShowDialog() == DialogResult.OK)
            {
                string fText = OpenAndFormatConf(openConfDialog.FileName);
                List<Host> hostList = GetHostsFromISCConf(fText);

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ExportHosts(hostList, saveFileDialog1.FileName);
                }
            }
            btnISCConfExport.Enabled = true;
        }

        private void btnISCLdifExport_Click(object sender, EventArgs e)
        {
            btnISCLdifExport.Enabled = false;
            if (openLdifDialog.ShowDialog() == DialogResult.OK)
            {
                string fText = "";
                using (StreamReader st = new StreamReader(openLdifDialog.FileName))
                {
                    fText = st.ReadToEnd();
                }
                List<Host> hostList = GetHostsFromISCLdif(fText);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ExportHosts(hostList, saveFileDialog1.FileName);
                }
            }
        }


        private void btnKeaConfExport_Click(object sender, EventArgs e)
        {
            btnKeaConfExport.Enabled = false;
            if (openConfDialog.ShowDialog() == DialogResult.OK)
            {
                string fText = OpenAndFormatConf(openConfDialog.FileName);
                List<Host> hostList = GetHostsFromKeaConf(fText);

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ExportHosts(hostList, saveFileDialog1.FileName);
                }
            }
            btnKeaConfExport.Enabled = true;
        }

        /// <summary>
        /// conf ファイルを開く
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        private string OpenAndFormatConf(string fn)
        {
            txtMessage.Text += "Open " + fn + " .\r\n";
            string fileText = "";
            using (StreamReader st = new StreamReader(@fn))
            {
                fileText = st.ReadToEnd();
            }

            string[] spt = fileText.Split('\n');
            txtMessage.Text += "Start parse " + spt.Length + " lines.\r\n";

            string noCommentFileText = "";
            foreach (string t in spt)
            {
                string u = t.Trim();
                if ((u.StartsWith("#"))) {
                    continue;
                }
                if (u.Length == 0)
                {
                    continue;
                }
                noCommentFileText += u + "\r\n";
            }

            txtMessage.Text += "Finish parse.\r\n";

            return noCommentFileText;
        }

        /// <summary>
        /// conf ファイルのホストを抽出する
        /// </summary>
        /// <param name="fText"></param>
        /// <returns></returns>
        private List<Host> GetHostsFromISCConf(string fText)
        {
            List<Host> ho = new List<Host>();

            string trg = fText.Trim();

            int idxH = trg.IndexOf("host");
            trg = trg.Substring(idxH);

            idxH = trg.IndexOf("host");
            while (idxH >= 0)
            {

                int fin = trg.IndexOf("}");
                if (fin >= 0)
                {
                    ho.Add(new Host(trg.Substring(idxH, fin - idxH)));
                }
                else
                {
                    txtMessage.Text += "conf error } does not exists. near " + trg.Substring(0, 20) + " \n";
                    break;
                }

                trg = trg.Substring(fin + 1);
                idxH = trg.IndexOf("host");
            }

            txtMessage.Text += "get " + ho.Count + " hosts.\r\n";

            return ho;
        }

        /// <summary>
        /// LDIF ファイルからホストを抽出する
        /// </summary>
        /// <param name="fText"></param>
        /// <returns></returns>
        private List<Host> GetHostsFromISCLdif(string fText)
        {
            List<Host> ho = new List<Host>();

            string trg = fText.Trim();

            var lines = trg.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int start = 0;
            int index = 0;
            while (index < lines.Length)
            {
                while ((index < lines.Length) && (lines[index].Length != 0))
                {
                    index++;
                }

                if (index >= lines.Length)
                {
                    index = lines.Length - 1;
                }

                string t = lines[start];
                while (++start <= index)
                {
                    t += Environment.NewLine + lines[start];
                }
                ho.Add(new Host(t));

                start = index + 1;
                index++;
            }

            txtMessage.Text += "get " + ho.Count + " hosts.\r\n";

            return ho;
        }

        private List<Host> GetHostsFromKeaConf(string fText)
        {
            List<Host> ret = new List<Host>();

            try
            {
                JObject root = JObject.Parse(fText);

                JArray reserves = (JArray)root.SelectToken("$..reservations");

                foreach(JObject item in reserves)
                {
                    string host = item["hostname"].ToString();
                    string mac = item["hw-address"].ToString();
                    string ip = item["ip-address"].ToString();
                    ret.Add(new Host(host, mac, ip));
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Error: " + ex.Message;
            }

            return ret;
        }

        /// <summary>
        /// 重複がないか調べる
        /// </summary>
        /// <param name="hosts"></param>
        private void CheckDup(List<Host> hosts)
        {
            txtMessage.Text += "check dup.\r\n";
            string resText = "";

            int count = hosts.Count;

            bool[] passCheck = new bool[count];

            for (int i = 0; i < count; i++)
            {
                passCheck[i] = false;
            }

            int errorCount = 0;
            bool noError = true;

            // check host-name
            for (int i = 0; i < count - 1; i++)
            {
                int num = 0;
                for (int j = i + 1; j < count; j++)
                {
                    if (passCheck[j])
                    {
                        continue;
                    }

                    if (hosts[i].IsSameHostName(hosts[j]))
                    {
                        num++;
                        passCheck[j] = true;
                    }
                }
                if (num > 0)
                {
                    resText += "Host dup name : " + hosts[i].Name + "\r\n";
                    errorCount++;
                }
            }

            if (errorCount > 0)
            {
                noError = false;
            }
            txtMessage.Text += "host check finished. " + errorCount + " dup.\r\n";

            errorCount = 0;
            for (int i = 0; i < count; i++)
            {
                passCheck[i] = false;
            }

            // check Mac
            for (int i = 0; i < count - 1; i++)
            {
                int num = 0;
                for (int j = i + 1; j < count; j++)
                {
                    if (passCheck[j])
                    {
                        continue;
                    }

                    if (hosts[i].IsSameMac(hosts[j]))
                    {
                        num++;
                        passCheck[j] = true;
                    }
                }
                if (num > 0)
                {
                    resText += "MAC dup address : " + hosts[i].Mac + "\r\n";
                    errorCount++;
                }
            }

            if (errorCount > 0)
            {
                noError = false;
            }
            txtMessage.Text += "MAC check finished. " + errorCount + " dup.\r\n";

            errorCount = 0;

            for (int i = 0; i < count; i++)
            {
                passCheck[i] = false;
            }

            // check IP
            for (int i = 0; i < count - 1; i++)
            {
                int num = 0;
                for (int j = i + 1; j < count; j++)
                {
                    if (passCheck[j])
                    {
                        continue;
                    }

                    if (hosts[i].IsSameIP(hosts[j]))
                    {
                        num++;
                        passCheck[j] = true;
                    }
                }
                if (num > 0)
                {
                    resText += "IP dup address : " + hosts[i].IP + "\r\n";
                    errorCount++;
                }
            }

            if (errorCount > 0)
            {
                noError = false;
            }
            txtMessage.Text += "IP check finished. " + errorCount + " dup.\r\n";

            if (noError)
            {
                txtResult.Text = "no error.";
            }
            else
            {
                txtResult.Text = resText;
            }

            txtMessage.Text += "finish check.\r\n";
            txtMessage.SelectionStart = txtMessage.Text.Length;
            txtMessage.Focus();
            txtMessage.ScrollToCaret();
        }

        /// <summary>
        /// ホストの情報を出力する
        /// </summary>
        /// <param name="hosts"></param>
        /// <param name="fileName"></param>
        private void ExportHosts(List<Host> hosts, string fileName)
        {
            string export = "Host,MAC,IP\r\n";
            foreach(Host h in hosts)
            {
                export += h.Name + "," + h.Mac + "," + h.IP + "\r\n";
            }
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(export.Trim());
                sw.Close();
            }
        }
    }
}
