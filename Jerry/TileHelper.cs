using System;
using System.Globalization;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Jerry
{
    public class TileHelper
    {
        public static void UpdateTile(string ip)
        {
            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueue(true);
            
            var dateString = DateTime.Now.ToString(new CultureInfo("sv-se"));

            var squareTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareText04);
            XmlNodeList tileTextAttributes = squareTileXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = string.Format("{0}{1}{2}", 
                ip, Environment.NewLine, dateString);

            var tileNotification = new TileNotification(squareTileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);


            var wideTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideText01);
            tileTextAttributes = wideTileXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = ip;
            tileTextAttributes[1].InnerText = dateString;

            var wideNotification = new TileNotification(wideTileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(wideNotification);
        }
    }
}