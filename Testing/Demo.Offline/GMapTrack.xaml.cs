using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GMap.NET;
using GMap.NET.MapProviders;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using UserControl = System.Windows.Controls.UserControl;

namespace Demo.Offline
{
    /// <summary>
    /// UserControl.xaml 的交互逻辑
    /// </summary>
    public partial class GMapTrack : UserControl
    {
        public GMapTrack()
        {
            InitializeComponent();
            this.MainMap.MouseEnter += MainMap_MouseEnter;
            this.MainMap.OnTileLoadStart += MainMap_OnTileLoadStart;
            this.MainMap.OnTileLoadComplete += MainMap_OnTileLoadComplete;
            this.MainMap.Loaded += MainMap_Loaded; 
        }

        private void MainMap_Loaded(object sender, RoutedEventArgs e)
        {
            double lat = double.Parse(ConfigurationManager.AppSettings["defaultLat"]);
            double lng = double.Parse(ConfigurationManager.AppSettings["defaultLng"]);
            this.MainMap.Position = new PointLatLng(lat,lng);

           // this.MainMap.MapProvider.Area = new RectLatLng(30.981178, 105.351914, 2.765142, 4.120995);
            this.MainMap.BoundsOfMap = new RectLatLng(lat+2, lng+2, 2.765142, 4.120995);
            this.MainMap.Manager.Mode = AccessMode.ServerOnly;
            this.MainMap.MapProvider = GMapProviders.BaiduMap;
            this.MainMap.DragButton = MouseButton.Left;
            this.MainMap.Zoom = 13;
            this.MainMap.MinZoom = 8;
            this.MainMap.MaxZoom = 24;

            //MapManagerLoader.Instance.Load(ConfigurationManager.AppSettings["mapName"]);
        }

        private void MainMap_OnTileLoadComplete(long elapsedmilliseconds)
        {
            MethodInvoker m = delegate()
            {
                progressBar.Visibility = Visibility.Hidden;
            };

            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Loaded, m);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.Message);
            }
        }

        private void MainMap_OnTileLoadStart()
        {
            MethodInvoker m = delegate()
            {
                progressBar.Visibility = Visibility.Visible;
            };

            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Loaded, m);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.Message);
            }
        }

        private void MainMap_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MainMap.Focus();
        }
    }
}
