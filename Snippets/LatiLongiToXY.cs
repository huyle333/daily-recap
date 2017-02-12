using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatLonToXY
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hoi this is for demonstrating the use of position to x and y ...");
            int x = 0;
            int y = 0;
            calculateLatLonToXY(37.787123, -122.395324, ref x, ref y);
            Console.WriteLine("This is x:" + x + ", y:" + y);
            Console.ReadKey();
        }

        static bool calculateLatLonToXY(double longitude, double latitude, ref int outX, ref int outY)
        {

            double longitudeLeftTop = 37.789325;
            double latitudeLEftTop = -122.399772;
            //lt
            double longitudeBR = 37.785832;
            double latitudeLBR = -122.393944;
            double width = 1417;
            double height = 864;

            //Source: https://en.wikipedia.org/wiki/Latitude
            // straight forward this will be 69.1 because it is straight forward
            double stdLat = 69.1; //miles
                                  // Source: http://gis.stackexchange.com/questions/142326/calculating-longitude-length-in-miles
                                  // As this is ther longitude it is an approximitation towards the real distance in 
            double stdLong = 55.24; //miles
            // calculate the relative longitude of the complete map
            double dlon = Math.Abs(longitudeLeftTop - longitudeBR);
            // calculate the relative latitude of the complete map
            double dlat = Math.Abs(latitudeLEftTop - latitudeLBR);
            // calc in miles
            double widthmiles = dlat * stdLat;
            // calc in miles
            double heightmiles = dlon * stdLong;
            // now calc towards pixel/mile
            double mppCols = width / widthmiles;
            // now calc towards pixel/mile.
            double mppRows = height / heightmiles;
            //relative longitude of the point of interest on the map
            double dlon2 = Math.Abs(longitudeLeftTop - longitude);
            //relative latitude of the point of interest on the map
            double dlat2 = Math.Abs(latitudeLEftTop - latitude);
            // calc in miles
            double xmiles = dlat2 * stdLat;
            // calc in miles
            double ymiles = dlon2 * stdLong;
            //calculate X and Y image position of given position in Angle.
            outX = (int)Math.Floor(xmiles * mppCols);
            outY = (int)Math.Floor(ymiles * mppRows);
            // return success
            return true;

        }
    }
}
