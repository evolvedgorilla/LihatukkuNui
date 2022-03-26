using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace LihatukkuNui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        lihanTiedot[] lihaTiedot = new lihanTiedot[50];
        int lihanInd = 0;
        struct lihanTiedot
        {
            public string nimi;
            public string tyyppi;
            public string maa;
            public string marmori;
            public string luomu;
            public string kuvaNimi;
            public string lippu;
            public string myyjä;
        }
        public MainWindow()
        {

            InitializeComponent();


            XmlReader lukija = XmlReader.Create("meats.xml");
            string lihanID = "";
            lukija.MoveToContent();

            while (lukija.Read())
            {
                if (lukija.NodeType == XmlNodeType.Element
                    && lukija.Name == "MEAT")
                {
                    if (lukija.HasAttributes)
                    {
                        lihanID = lukija.GetAttribute("ID");
                        lstLihojenID.Items.Add(lihanID);
                    }
                }
                if (lukija.NodeType == XmlNodeType.Element
                    && lukija.Name == "NAME")
                {
                    lukija.Read();
                    lihaTiedot[lihanInd].nimi = (lukija.Value);

                }
                if (lukija.NodeType == XmlNodeType.Element
                    && lukija.Name == "TYPE")
                {
                    lukija.Read();
                    lihaTiedot[lihanInd].tyyppi = (lukija.Value);

                }
                if (lukija.NodeType == XmlNodeType.Element
                     && lukija.Name == "ORIGIN")
                {
                    lukija.Read();
                    lihaTiedot[lihanInd].maa = (lukija.Value);

                }
                if (lukija.NodeType == XmlNodeType.Element
                     && lukija.Name == "MARBLING")
                {
                    lukija.Read();
                    lihaTiedot[lihanInd].marmori = (lukija.Value);

                }
                if (lukija.NodeType == XmlNodeType.Element
                      && lukija.Name == "ORGANIC")
                {
                    lukija.Read();
                    lihaTiedot[lihanInd].luomu = (lukija.Value);

                }
                if (lukija.NodeType == XmlNodeType.Element
                      && lukija.Name == "PICTURE")
                {
                    lukija.Read();
                    lihaTiedot[lihanInd].kuvaNimi = (lukija.Value);

                }
                if (lukija.NodeType == XmlNodeType.Element
                     && lukija.Name == "FLAG")
                {
                    lukija.Read();
                    lihaTiedot[lihanInd].lippu = (lukija.Value);

                }
                if (lukija.NodeType == XmlNodeType.Element
                      && lukija.Name == "SELLER")
                {
                    lukija.Read();
                    lihaTiedot[lihanInd].myyjä = (lukija.Value);
                    lihanInd++;
                }

            }
        }


        private void lstLihojenID_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int haettavanIndeksi = lstLihojenID.SelectedIndex;
            lblNimi.Content = lihaTiedot[haettavanIndeksi].nimi;
            lblTyyppi.Content = lihaTiedot[haettavanIndeksi].tyyppi;
            lblMaa.Content = lihaTiedot[haettavanIndeksi].maa;
            lblMarmori.Content = lihaTiedot[haettavanIndeksi].marmori;
            lblMyyjä.Content = lihaTiedot[haettavanIndeksi].myyjä;

            if (lihaTiedot[haettavanIndeksi].luomu == "yes")
            {
                rdbLuomu.IsChecked = true;
            }
            if (lihaTiedot[haettavanIndeksi].luomu == "no")
            {
                rdbEiLuomu.IsChecked = true;
            }

            string LihaKuva = @"C:\Kuvat\" + lihaTiedot[haettavanIndeksi].kuvaNimi;
            ImageSource imageSource = new BitmapImage(new Uri(LihaKuva));
            imgLiha.Source = imageSource;

            string LippuKuva = @"C:\liput\" + lihaTiedot[haettavanIndeksi].lippu;
            ImageSource imageSource1 = new BitmapImage(new Uri(LippuKuva));
            imgLippu.Source = imageSource1;




        }
    }
}
