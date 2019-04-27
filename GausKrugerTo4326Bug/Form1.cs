using GausKrugerTo4326Bug.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GausKrugerTo4326Bug
{
    public partial class Form1 : Form
    {
        private const string Proj4_4326 = "+proj=longlat +ellps=WGS84 +datum=WGS84 +no_defs ";
        private const string Proj4_31462 = "+proj=tmerc +lat_0=0 +lon_0=6 +k=1 +x_0=2500000 +y_0=0 +ellps=bessel +datum=potsdam +units=m +no_defs ";

        public Form1()
        {
            InitializeComponent();

            //SourceWktTextBox.Text = "LINESTRING(12.317 47.89,12.302 47.81,12.306 47.84)";
            SourceWktTextBox.Text = "POINT(12.317 47.89,12.302 47.81,12.306 47.84)";


        }

        private void ReprojectButton_Click(object sender, EventArgs e)
        {
            var geometryConverter = new GeometryConverter();

            var sourceWkt = SourceWktTextBox.Text;
            //var reprojectedWkt = geometryConverter.ReprojectGeometry(sourceWkt, 4326, 31462);
            var reprojectedWkt = geometryConverter.ReprojectGeometry(
                sourceWkt,
                Proj4_4326,
                Proj4_31462);
            DestinationWktTextBox.Text = reprojectedWkt;
        }
    }
}
