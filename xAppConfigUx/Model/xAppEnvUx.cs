using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using xAppConfigMx;

namespace xAppConfigUx.Model
{
    public class xAppEnvUx : IxAppEnvUx
    {
        private readonly string _xmlFilePath;

        private xAppEnv _env = new xAppEnv();

        public xAppEnvUx(string fullPath)
        {
            _xmlFilePath = fullPath;

            if (!File.Exists(_xmlFilePath))
                CreateAppXmlStub();

            XmlSerializer serializer = new XmlSerializer(typeof(xAppEnv));

            StreamReader reader = new StreamReader(_xmlFilePath, Encoding.UTF8);
            _env = (xAppEnv)serializer.Deserialize(reader);
            reader.Close();
            return;

/*
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(_xmlFilePath);
            }
            catch (Exception)
            {
                return;
            }

            XmlNode node = doc.SelectSingleNode("KxIx/DataBaseType");
            if (node != null)
            {
                try
                {
                    _env.DatabaseType = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/MDataBase/IP");
            if (node != null)
            {
                try
                {
                    _env._host.ip = node.InnerText;
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/MDataBase/PORT");
            if (node != null)
            {
                try
                {
                    _env._host.port = node.InnerText;
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/DataBase/Run");
            if (node != null)
            {
                try
                {
                    _env._liteDBPath.Run.path = node["Path"].InnerText;
                    _env._liteDBPath.Run.name = node["Name"].InnerText;
                }
                catch (System.Exception ex)
                {
                    string ss = ex.Message.ToString();
                }
            }

            node = doc.SelectSingleNode("KxIx/DataBase/Item");
            if (node != null)
            {
                try
                {
                    _env._liteDBPath.Item.path = node["Path"].InnerText;
                    _env._liteDBPath.Item.name = node["Name"].InnerText;
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/DataBase/Review");
            if (node != null)
            {
                try
                {
                    _env._liteDBPath.Review.path = node["Path"].InnerText;
                    _env._liteDBPath.Review.name = node["Name"].InnerText;
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/DataBase/Partnerzone");
            if (node != null)
            {
                try
                {
                    _env._liteDBPath.Partnerzone.path = node["Path"].InnerText;
                    _env._liteDBPath.Partnerzone.name = node["Name"].InnerText;
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/DataBase/Ranking");
            if (node != null)
            {
                try
                {
                    _env._liteDBPath.Ranking.path = node["Path"].InnerText;
                    _env._liteDBPath.Ranking.name = node["Name"].InnerText;
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/DataBase/Device");
            if (node != null)
            {
                try
                {
                    _env._liteDBPath.Device.path = node["Path"].InnerText;
                    _env._liteDBPath.Device.name = node["Name"].InnerText;
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/OPTION/UseWebItemTitle");
            if (node != null)
            {
                try
                {
                    _env.UseWebItemTitle = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/OPTION/UseDBItemChk");
            if (node != null)
            {
                try
                {
                    _env.UseDBItemChk = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/HISTORY");
            if (node != null)
            {
                try
                {
                    _env.HistoryPath = node["PATH"].InnerText;
                }
                catch (Exception)
                {
                }
            }

            XmlNode nodeSMSUse = doc.SelectSingleNode("KxIx/SMS_ALIMI/USE");
            if (nodeSMSUse != null)
            {
                _env._SMS.use = Int32.Parse(nodeSMSUse.InnerText);
            }

            _env._SMS.phoneNumbers.Clear();
            XmlNodeList nodeSMSPhone = doc.SelectNodes("KxIx/SMS_ALIMI/PHONE_NUMBERS/PHONE");
            if (nodeSMSPhone != null)
            {
                foreach (XmlNode xn in nodeSMSPhone)
                {
                    _env._SMS.phoneNumbers.Add(xn.InnerText);
                }
            }

            node = doc.SelectSingleNode("KxIx/Review/Use");
            if (node != null)
            {
                try
                {
                    _env._review.use = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Review/UseServerControl");
            if (node != null)
            {
                try
                {
                    _env._review.useServerControl = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Review/UseFavorite");
            if (node != null)
            {
                try
                {
                    _env._review.useFavorite = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                 }
            }

            node = doc.SelectSingleNode("KxIx/Review/PeriodMIN");
            if (node != null)
            {
                try
                {
                    _env._review.periodMin = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Review/StartHour");
            if (node != null)
            {
                try
                {
                    _env._review.startHour = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Review/EndHour");
            if (node != null)
            {
                try
                {
                    _env._review.endHour = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Purchases/Use");
            if (node != null)
            {
                try
                {
                    _env._purchase.use = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Purchases/UseServerControl");
            if (node != null)
            {
                try
                {
                    _env._purchase.useServerControl = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Purchases/MusicPath");
            if (node != null)
            {
                try
                {
                    _env._purchase.musicPath = node.InnerText;
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Purchases/PeriodMIN");
            if (node != null)
            {
                try
                {
                    _env._purchase.periodMin = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Purchases/StartHour");
            if (node != null)
            {
                try
                {
                    _env._purchase.startHour = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }

            node = doc.SelectSingleNode("KxIx/Purchases/EndHour");
            if (node != null)
            {
                try
                {
                    _env._purchase.endHour = Int32.Parse(node.InnerText);
                }
                catch (Exception)
                {
                }
            }
*/
        }

        public xAppEnv Get()
        {
            return _env;
        }

        private void CreateAppXmlStub()
        {
            xAppEnv env = new xAppEnv();
            _SaveEnv(env);
        }

        private void _SaveEnv(xAppEnv env)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(xAppEnv));
            XmlTextWriter tw = new XmlTextWriter(_xmlFilePath, Encoding.UTF8);
            tw.Formatting = Formatting.Indented;
            _serializer.Serialize(tw, _env);
            tw.Close();
            return;
/*
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclare = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.AppendChild(xmlDeclare);

            XmlNode xRoot           = doc.CreateElement("KxIx");

            XmlNode xDataBaseType   = doc.CreateElement("DataBaseType");
            xDataBaseType.InnerText = _env.DatabaseType.ToString();

            XmlNode xMDataBase          = doc.CreateElement("MDataBase");
            XmlNode xMDataBase_ip       = doc.CreateElement("IP");              xMDataBase_ip.InnerText = _env._host.ip;
            XmlNode xMDataBase_port     = doc.CreateElement("PORT");            xMDataBase_port.InnerText = _env._host.port;
            xMDataBase.AppendChild(xMDataBase_ip);
            xMDataBase.AppendChild(xMDataBase_port);

            XmlNode xDataBase           = doc.CreateElement("DataBase");
            XmlNode xDataBase_item      = doc.CreateElement("Item");
            XmlNode xDataBase_item_path = doc.CreateElement("Path");            xDataBase_item_path.InnerText = _env._liteDBPath.Item.path;
            XmlNode xDataBase_item_name = doc.CreateElement("Name");            xDataBase_item_name.InnerText = _env._liteDBPath.Item.name;
            xDataBase_item.AppendChild(xDataBase_item_path);
            xDataBase_item.AppendChild(xDataBase_item_name);
            XmlNode xDataBase_run      = doc.CreateElement("Item");
            XmlNode xDataBase_run_path = doc.CreateElement("Path");             xDataBase_run_path.InnerText = _env._liteDBPath.Run.path;
            XmlNode xDataBase_run_name = doc.CreateElement("Name");             xDataBase_run_name.InnerText = _env._liteDBPath.Run.name;
            xDataBase_run.AppendChild(xDataBase_run_path);
            xDataBase_run.AppendChild(xDataBase_run_name);
            XmlNode xDataBase_review      = doc.CreateElement("Review");
            XmlNode xDataBase_review_path = doc.CreateElement("Path");          xDataBase_review_path.InnerText = _env._liteDBPath.Review.path;
            XmlNode xDataBase_review_name = doc.CreateElement("Name");          xDataBase_review_name.InnerText = _env._liteDBPath.Review.name;
            xDataBase_review.AppendChild(xDataBase_review_path);
            xDataBase_review.AppendChild(xDataBase_review_name);
            XmlNode xDataBase_device      = doc.CreateElement("Device");
            XmlNode xDataBase_device_path = doc.CreateElement("Path");          xDataBase_device_path.InnerText = _env._liteDBPath.Device.path;
            XmlNode xDataBase_device_name = doc.CreateElement("Name");          xDataBase_device_name.InnerText = _env._liteDBPath.Device.name;
            xDataBase_device.AppendChild(xDataBase_device_path);
            xDataBase_device.AppendChild(xDataBase_device_name);
            XmlNode xDataBase_partnerzone      = doc.CreateElement("Partnerzone");
            XmlNode xDataBase_partnerzone_path = doc.CreateElement("Path");     xDataBase_partnerzone_path.InnerText = _env._liteDBPath.Partnerzone.path;
            XmlNode xDataBase_partnerzone_name = doc.CreateElement("Name");     xDataBase_partnerzone_name.InnerText = _env._liteDBPath.Partnerzone.name;
            xDataBase_partnerzone.AppendChild(xDataBase_partnerzone_path);
            xDataBase_partnerzone.AppendChild(xDataBase_partnerzone_name);
            XmlNode xDataBase_ranking      = doc.CreateElement("Ranking");
            XmlNode xDataBase_ranking_path = doc.CreateElement("Path");         xDataBase_ranking_path.InnerText = _env._liteDBPath.Ranking.path;
            XmlNode xDataBase_ranking_name = doc.CreateElement("Name");         xDataBase_ranking_name.InnerText = _env._liteDBPath.Ranking.name;
            xDataBase_ranking.AppendChild(xDataBase_ranking_path);
            xDataBase_ranking.AppendChild(xDataBase_ranking_name);

            xDataBase.AppendChild(xDataBase_item);
            xDataBase.AppendChild(xDataBase_run);
            xDataBase.AppendChild(xDataBase_review);
            xDataBase.AppendChild(xDataBase_device);
            xDataBase.AppendChild(xDataBase_partnerzone);
            xDataBase.AppendChild(xDataBase_ranking);

            XmlNode xOption             = doc.CreateElement("OPTION");
            XmlNode xUseDBItemChk       = doc.CreateElement("UseDBItemChk");    xUseDBItemChk.InnerText = _env.UseDBItemChk.ToString();
            XmlNode xUseWebItemTitle    = doc.CreateElement("UseWebItemTitle"); xUseWebItemTitle.InnerText = _env.UseWebItemTitle.ToString();
            xOption.AppendChild(xUseDBItemChk);
            xOption.AppendChild(xUseWebItemTitle);

            XmlNode xHistory            = doc.CreateElement("HISTORY");
            XmlNode xHistoryPath        = doc.CreateElement("PATH");            xHistoryPath.InnerText = _env.HistoryPath;
            xHistory.AppendChild(xHistoryPath);

            XmlNode xSMS                = doc.CreateElement("SMS_ALIMI");
            XmlNode xSMS_use            = doc.CreateElement("USE");             xSMS_use.InnerText = _env._SMS.use.ToString();
            XmlNode xSMS_phones         = doc.CreateElement("PHONE_NUMBERS");
            foreach (string s in _env._SMS.phoneNumbers)
            {
                XmlNode xSMS_phones_phone = doc.CreateElement("PHONE");         xSMS_phones_phone.InnerText = s;
                xSMS_phones.AppendChild(xSMS_phones_phone);
            }
            xSMS.AppendChild(xSMS_use);
            xSMS.AppendChild(xSMS_phones);

            XmlNode xReview = doc.CreateElement("Review");
            XmlNode xReview_use = doc.CreateElement("Use");                     xReview_use.InnerText       = _env._review.use.ToString();
            XmlNode xReview_useServer = doc.CreateElement("UseServerControl");  xReview_useServer.InnerText = _env._review.useServerControl.ToString();
            XmlNode xReview_useFavor = doc.CreateElement("UseFavorite");        xReview_useFavor.InnerText  = _env._review.useFavorite.ToString();
            XmlNode xReview_periodMin = doc.CreateElement("PeriodMIN");         xReview_periodMin.InnerText = _env._review.periodMin.ToString();
            XmlNode xReview_startHour = doc.CreateElement("StartHour");         xReview_startHour.InnerText = _env._review.startHour.ToString();
            XmlNode xReview_endHour = doc.CreateElement("EndHour");             xReview_endHour.InnerText   = _env._review.endHour.ToString();
            xReview.AppendChild(xReview_use);
            xReview.AppendChild(xReview_useServer);
            xReview.AppendChild(xReview_useFavor);
            xReview.AppendChild(xReview_periodMin);
            xReview.AppendChild(xReview_startHour);
            xReview.AppendChild(xReview_endHour);

            XmlNode xPurchase = doc.CreateElement("Purchases");
            XmlNode xPurchase_use = doc.CreateElement("Use");                     xPurchase_use.InnerText       = _env._purchase.use.ToString();
            XmlNode xPurchase_musicpath = doc.CreateElement("MusicPath");         xPurchase_musicpath.InnerText = _env._purchase.musicPath;
            XmlNode xPurchase_periodMin = doc.CreateElement("PeriodMIN");         xPurchase_periodMin.InnerText = _env._purchase.periodMin.ToString();
            XmlNode xPurchase_startHour = doc.CreateElement("StartHour");         xPurchase_startHour.InnerText = _env._purchase.startHour.ToString();
            XmlNode xPurchase_endHour = doc.CreateElement("EndHour");             xPurchase_endHour.InnerText   = _env._purchase.endHour.ToString();
            xPurchase.AppendChild(xPurchase_use);
            xPurchase.AppendChild(xPurchase_musicpath);
            xPurchase.AppendChild(xPurchase_periodMin);
            xPurchase.AppendChild(xPurchase_startHour);
            xPurchase.AppendChild(xPurchase_endHour);

            xRoot.AppendChild(xDataBaseType);
            xRoot.AppendChild(xMDataBase);
            xRoot.AppendChild(xDataBase);
            xRoot.AppendChild(xHistory);
            xRoot.AppendChild(xOption);
//            xRoot.AppendChild(xSMS);
            xRoot.AppendChild(xReview);
            xRoot.AppendChild(xPurchase);
            doc.AppendChild(xRoot);
            doc.Save(_xmlFilePath);
*/
        }

        public void Save(xAppEnv env)
        {
            _env = env;
            _SaveEnv(env);
        }
    }
}
