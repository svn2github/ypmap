using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using NUnit.Framework;

namespace UnitTet
{
    [TestFixture]
    public class GMapProviderTester: GMapProvider
    {
        [Test]
        public void should_pass_sogou_image_file()
        {
            //Assert.IsNotNull(this.GetTileImageUsingHttp("http://q6.baidu.com/it/u=x=5;y=0;z=4;v=014;type=web&fm=44"));
            //Assert.IsNotNull(this.GetTileImageUsingHttp("http://p1.go2map.com/seamless1/0/174/723/0/0/10_2.png"));

        }

        [Test]
        public void should_get_geo_info()
        {
            GeocodingProvider gp = GMapProviders.BaiduMap;

            GeoCoderStatusCode status;
            PointLatLng? point = gp.GetPoint("重庆市国际社区", out status);
        }

        public override Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public override string Name
        {
            get { return string.Empty; }
        }

        public override PureProjection Projection
        {
            get { return new LKS92Projection(); }
        }

        public override GMapProvider[] Overlays
        {
            get { throw new NotImplementedException(); }
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            return null;
        }
    }
}
