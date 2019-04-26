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
        public Form1()
        {
            InitializeComponent();

            SourceWktTextBox.Text = "POLYGON((12.312196686994866 47.87511651751136,12.292970612776116 47.86221904662349,12.332109406721429 47.851622294448454,12.349275544416741 47.86267972585108,12.336229279768304 47.87143185333576,12.312196686994866 47.87511651751136))";
        
        }

        private void ReprojectButton_Click(object sender, EventArgs e)
        {
            var geometryConverter = new GeometryConverter();

            var sourceWkt = SourceWktTextBox.Text;
            //var reprojectedWkt = geometryConverter.ReprojectGeometry(sourceWkt, 4326, 31462);
            var reprojectedWkt = geometryConverter.ReprojectGeometry(
                sourceWkt,
                // 4326
                "+proj=longlat +ellps=WGS84 +datum=WGS84 +no_defs ",
                // 31462
                "+proj=tmerc +lat_0=0 +lon_0=6 +k=1 +x_0=2500000 +y_0=0 +ellps=bessel +datum=potsdam +units=m +no_defs ");
            DestinationWktTextBox.Text = reprojectedWkt;
        }
    }
}
