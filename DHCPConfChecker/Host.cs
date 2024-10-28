namespace DHCPConfChecker
{
    class Host
    {
        private string name = "";
        private string mac = "";
        private string ip = "";

        public Host()
        {

        }

        public Host(string v)
        {
            string trg = v.Trim();

            if (trg.IndexOf("host") >= 0)
            {
                this.SetAsConf(trg);
            }
            else
            {
                this.SetAsLdif(trg);
            }
        }

        private void SetAsConf(string trg)
        {
            // host
            int idxH = trg.IndexOf("host");
            int idxB = trg.IndexOf("{");

            if (idxH < 0 || idxB < 0)
            {
                return;
            }

            this.name = trg.Substring(idxH + 4, idxB - idxH - 4).Trim();

            // mac
            trg = trg.Substring(idxB + 1);

            int idxE = trg.IndexOf("hardware ethernet");
            int idxS = trg.IndexOf(";");

            if (idxE < 0 || idxS < 0)
            {
                return;
            }

            int x = (idxS - idxE - 17);

            this.mac = trg.Substring(idxE + 17, idxS - idxE - 17).Trim().ToUpper();

            // ip
            trg = trg.Substring(idxS + 1);

            int idxF = trg.IndexOf("fixed-address");
            idxS = trg.IndexOf(";");

            if (idxF < 0 || idxS < 0)
            {
                return;
            }

            this.ip = trg.Substring(idxF + 13, idxS - idxE - 13).Trim();
        }

        private void SetAsLdif(string trg)
        {
            int idxCn = trg.IndexOf("cn:");
            if (idxCn < 0)
            {
                return;
            }

            int idxEnd = trg.IndexOf("\r\n", idxCn);

            this.name = trg.Substring(idxCn + 3, idxEnd - idxCn - 3).Trim();

            trg = trg.Substring(idxEnd + 2);

            int idxMac = trg.IndexOf("dhcpHWAddress: ethernet");
            if (idxMac < 0)
            {
                return;
            }

            idxEnd = trg.IndexOf("\r\n", idxMac);

            this.mac = trg.Substring(idxMac + 23, idxEnd - idxMac - 23);

            trg = trg.Substring(idxEnd + 2);

            int idxIP = trg.IndexOf("dhcpStatements: fixed-address");
            if (idxIP < 0)
            {
                return;
            }

            idxEnd = trg.IndexOf("\r\n", idxIP);
            if (idxEnd < 0)
            {
                this.ip = trg.Substring(idxIP + 29).Trim();
            }
            else
            {
                this.ip = trg.Substring(idxIP + 29, idxEnd - idxIP - 29).Trim();
            }
        }

        public Host(string name, string mac, string ip)
        {
            this.name = name;
            this.mac = mac;
            this.ip = ip;
        }

        public Host(Host ho)
        {
            this.name = ho.name;
            this.mac = ho.mac;
            this.ip = ho.ip;
        }

        public bool IsSameHostName(Host trg)
        {
            return (this.name == trg.name);
        }

        public bool IsSameMac(Host trg)
        {
            return (this.mac == trg.mac);
        }

        public bool IsSameIP(Host trg)
        {
            return (this.ip == trg.ip);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Mac
        {
            get
            {
                return this.mac;
            }
        }

        public string IP
        {
            get
            {
                return this.ip;
            }
        }
    }
}
