using DotSpatial.Projections;
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
        private Geometry ReprojectGeometry(Geometry geometry, ProjectionInfo sourceProjectionInfo, ProjectionInfo targetProjectionInfo)
        {
            var cloneGeometry = geometry.Copy();
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

            // Workaround because Reproject.ReprojectPoints cannot dealt with multiple points for some projections 
            // Example: 4326 to 31462
            double[] tmpCoordinates = new double[2];
            for (int i = 0; i < pointArray.Length; i += 2)
            {
                tmpCoordinates[0] = pointArray[i];
                tmpCoordinates[1] = pointArray[i + 1];
                Reproject.ReprojectPoints(tmpCoordinates, new double[] { 0 }, sourceProjectionInfo, targetProjectionInfo, 0, 1);
                pointArray[i] = tmpCoordinates[0];
                pointArray[i + 1] = tmpCoordinates[1];
            }

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

        public Geometry ReprojectGeometry(Geometry geometry, int sourceEpsgCode, int targetEpsgCode)
        {
            var sourceProjection = ProjectionInfo.FromEpsgCode(sourceEpsgCode);
            var targetProjection = ProjectionInfo.FromEpsgCode(targetEpsgCode);

            return ReprojectGeometry(geometry, sourceProjection, targetProjection);
        }

        public Geometry ReprojectGeometry(Geometry geometry, string sourceEpsgCode, string targetEpsgCode)
        {
            var sourceProjection = ProjectionInfo.FromProj4String(sourceEpsgCode);
            var targetProjection = ProjectionInfo.FromProj4String(targetEpsgCode);

            return ReprojectGeometry(geometry, sourceProjection, targetProjection);
        }


        public string ReprojectGeometry(string wkt, int sourceEpsgCode, int targetEpsgCode)
        {
            var geometry = Wkt2Geometry(wkt);

            var reprojectedGeometry = ReprojectGeometry(geometry, sourceEpsgCode, targetEpsgCode);
            var reprojectedWkt = Geometry2Wkt(reprojectedGeometry);

            return reprojectedWkt;
        }

        public string ReprojectGeometry(string wkt, string sourceEpsgCode, string targetEpsgCode)
        {
            var geometry = Wkt2Geometry(wkt);

            var reprojectedGeometry = ReprojectGeometry(geometry, sourceEpsgCode, targetEpsgCode);
            var reprojectedWkt = Geometry2Wkt(reprojectedGeometry);

            return reprojectedWkt;
        }
    }
}
