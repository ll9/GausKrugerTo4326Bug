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
        }

        private void ReprojectButton_Click(object sender, EventArgs e)
        {
            var geometryConverter = new GeometryConverter();

            var sourceWkt = SourceWktTextBox.Text;
            var reprojectedWkt = geometryConverter.ReprojectGeometry(sourceWkt, 4326, 3857);
            DestinationWktTextBox.Text = reprojectedWkt;
        }
    }
}
