using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GausKrugerTo4326Bug.Utils
{
    public class GeometryConverter
    {

        public Geometry Wkt2Geometry(string wkt)
        {
            WKTReader reader = new WKTReader();
            Geometry geom = (Geometry)reader.Read(wkt);

            return geom;
        }

                public string Geometry2Wkt(Geometry geometry)
        {
            var writer = new WKTWriter();

            var wkt = writer.Write(geometry);
            return wkt;
        }

        // Source: https://gis.stackexchange.com/questions/127374/coordinate-transformation-reprojection-using-dotspatial
        public Geometry ReprojectGeometry(Geometry geometry, int sourceEpsgCode, int targetEpsgCode)
        {
            var cloneGeometry = geometry.Copy();
            var sourceProjection = DotSpatial.Projections.ProjectionInfo.FromEpsgCode(sourceEpsgCode);
            var targetProjection = DotSpatial.Projections.ProjectionInfo.FromEpsgCode(targetEpsgCode);
            double[] pointArray = new double[cloneGeometry.Coordinates.Count() * 2];
            double[] zArray = new double[] { 1 };

            int counterX = 0;
            int counterY = 1;
            foreach (var coordinate in cloneGeometry.Coordinates)
            {
                pointArray[counterX] = coordinate.X;
                pointArray[counterY] = coordinate.Y;

                counterX = counterX + 2;
                counterY = counterY + 2;
            }

            DotSpatial.Projections.Reproject.ReprojectPoints(pointArray, zArray, sourceProjection, targetProjection, 0, (pointArray.Length / 2));

            counterX = 0;
            counterY = 1;
            foreach (var coordinate in cloneGeometry.Coordinates)
            {
                coordinate.X = pointArray[counterX];
                coordinate.Y = pointArray[counterY];

                counterX = counterX + 2;
                counterY = counterY + 2;
            }

            return cloneGeometry as Geometry;
        }


        public string ReprojectGeometry(string wkt, int sourceEpsgCode, int targetEpsgCode)
        {
            var geometry = Wkt2Geometry(wkt);

            var reprojectedGeometry = ReprojectGeometry(geometry, sourceEpsgCode, targetEpsgCode);
            var reprojectedWkt = Geometry2Wkt(reprojectedGeometry);

            return reprojectedWkt;
        }
    }
}
