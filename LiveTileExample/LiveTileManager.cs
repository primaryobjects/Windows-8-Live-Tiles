using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace LiveTileExample
{
    /// <summary>
    /// LiveTileManager helper class for creating Windows 8 live tile notifications.
    /// Written by Kory Becker http://www.primaryobjects.com
    /// </summary>
    public static class LiveTileManager
    {
        public static void SetLiveTile(string title, string body, int seconds)
        {
            SetLiveTile(TileTemplateType.TileSquareBlock, seconds, (XmlDocument tileXml) =>
            {
                // Set notification text.
                XmlNodeList nodes = tileXml.GetElementsByTagName("text");
                nodes[0].InnerText = title;
                nodes[1].InnerText = body;
            });
        }

        public static void SetLiveTile(string imageFileName, int seconds)
        {
            SetLiveTile(TileTemplateType.TileSquareImage, seconds, (XmlDocument tileXml) =>
            {
                // Set notification image.
                XmlNodeList nodes = tileXml.GetElementsByTagName("image");
                nodes[0].Attributes[1].NodeValue = "ms-appx:///Assets/" + imageFileName;
            });
        }

        public static void SetLiveTileAnimated(string imageFileName, string text, int seconds)
        {
            SetLiveTile(TileTemplateType.TileSquarePeekImageAndText04, seconds, (XmlDocument tileXml) =>
            {
                // Set notification image and text.
                XmlNodeList nodes = tileXml.GetElementsByTagName("image");
                nodes[0].Attributes[1].NodeValue = "ms-appx:///Assets/" + imageFileName;
                nodes = tileXml.GetElementsByTagName("text");
                nodes[0].InnerText = text;
            });
        }

        /// <summary>
        /// Displays a Windows 8 Live Tile notification.
        /// </summary>
        /// <param name="tileTemplateType">TileTemplateType. See hxxp://msdn.microsoft.com/en-us/library/windows/apps/hh761491.aspx</param>
        /// <param name="seconds">Number of seconds to display tile notification</param>
        /// <param name="customizeMethod">Method to set the XML text or image properties for the tile notification. The method receives an XmlDocument as a parameter, to modify the contents.</param>
        private static void SetLiveTile(TileTemplateType tileTemplateType, int seconds, Action<XmlDocument> customizeMethod)
        {
            // Get tile template.
            var tileTemplate = tileTemplateType;
            var tileXml = TileUpdateManager.GetTemplateContent(tileTemplate);

            // Create notification.
            var notification = new TileNotification(tileXml);
            notification.ExpirationTime = DateTime.Now + TimeSpan.FromSeconds(seconds);

            // Set notification options.
            customizeMethod(tileXml);

            // Update Live Tile.
            var upd = TileUpdateManager.CreateTileUpdaterForApplication();
            upd.Update(notification);
        }
    }
}
