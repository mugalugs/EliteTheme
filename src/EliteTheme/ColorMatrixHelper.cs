using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTheme
{
    public static class ColorMatrixHelper
    {
        //http://graficaobscura.com/matrix/index.html
        //Paul Haeberli - 1993
        //Adapted to .NET - 2018

        public const float RED_LUMINANCE = 0.3086f;
        public const float GREEN_LUMINANCE = 0.6094f;
        public const float BLUE_LUMINANCE = 0.0820f;

        public static void Multiply(float[][] a, float[][] b, ref float[][] multiplied)
        {
            float[][] tmp = CreateIdentity();

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    tmp[y][x] = b[y][0] * a[0][x]
                       + b[y][1] * a[1][x]
                       + b[y][2] * a[2][x]
                       + b[y][3] * a[3][x];
                }
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    multiplied[y][x] = tmp[y][x];
                }
            }
        }
        
        public static float[] TransformPoint(float[][] matrix, float x, float y, float z)
        {
            float[] t = new float[3];
            t[0] = x * matrix[0][0] + y * matrix[1][0] + z * matrix[2][0] + matrix[3][0];
            t[1] = x * matrix[0][1] + y * matrix[1][1] + z * matrix[2][1] + matrix[3][1];
            t[2] = x * matrix[0][2] + y * matrix[1][2] + z * matrix[2][2] + matrix[3][2];
            return t;
        }

        public static void Scale(ref float[][] matrix, float r, float g, float b)
        {
            float[][] tmp = CreateIdentity();

            tmp[0][0] = r;
            tmp[0][1] = 0.0f;
            tmp[0][2] = 0.0f;
            tmp[0][3] = 0.0f;

            tmp[1][0] = 0.0f;
            tmp[1][1] = g;
            tmp[1][2] = 0.0f;
            tmp[1][3] = 0.0f;

            tmp[2][0] = 0.0f;
            tmp[2][1] = 0.0f;
            tmp[2][2] = b;
            tmp[2][3] = 0.0f;

            tmp[3][0] = 0.0f;
            tmp[3][1] = 0.0f;
            tmp[3][2] = 0.0f;
            tmp[3][3] = 1.0f;

            Multiply(tmp, matrix, ref matrix);
        }

        public static void Saturation(ref float[][] matrix, float saturation)
        {
            float[][] tmp = CreateIdentity();

            tmp[0][0] = (1.0f - saturation) * RED_LUMINANCE + saturation;
            tmp[0][1] = (1.0f - saturation) * RED_LUMINANCE;
            tmp[0][2] = (1.0f - saturation) * RED_LUMINANCE;
            tmp[0][3] = 0.0f;

            tmp[1][0] = (1.0f - saturation) * GREEN_LUMINANCE;
            tmp[1][1] = (1.0f - saturation) * GREEN_LUMINANCE + saturation;
            tmp[1][2] = (1.0f - saturation) * GREEN_LUMINANCE;
            tmp[1][3] = 0.0f;

            tmp[2][0] = (1.0f - saturation) * BLUE_LUMINANCE;
            tmp[2][1] = (1.0f - saturation) * BLUE_LUMINANCE;
            tmp[2][2] = (1.0f - saturation) * BLUE_LUMINANCE + saturation;
            tmp[2][3] = 0.0f;

            tmp[3][0] = 0.0f;
            tmp[3][1] = 0.0f;
            tmp[3][2] = 0.0f;
            tmp[3][3] = 1.0f;

            Multiply(tmp, matrix, ref matrix);
        }
        
        public static void Luminance(ref float[][] matrix)
        {
            float[][] lum = new float[][] {
                new float[] { RED_LUMINANCE, RED_LUMINANCE, RED_LUMINANCE, 0 },
                new float[] { GREEN_LUMINANCE, GREEN_LUMINANCE, GREEN_LUMINANCE, 0 },
                new float[] { BLUE_LUMINANCE, BLUE_LUMINANCE, BLUE_LUMINANCE, 0 },
                new float[] { 0, 0, 0, 1 }
            };

            Multiply(lum, matrix, ref matrix);
        }

        public static void Offset(ref float[][] matrix, float r, float g, float b)
        {
            float[][] tmp = CreateIdentity();

            tmp[3][0] = r;
            tmp[3][1] = g;
            tmp[3][2] = b;
            tmp[3][3] = 1.0f;

            Multiply(tmp, matrix, ref matrix);
        }

        public static void RotateX(ref float[][] matrix, float a, float b)
        {
            float[][] tmp = CreateIdentity();

            tmp[1][0] = 0.0f;
            tmp[1][1] = b;
            tmp[1][2] = a;
            tmp[1][3] = 0.0f;

            tmp[2][0] = 0.0f;
            tmp[2][1] = -a;
            tmp[2][2] = b;
            tmp[2][3] = 0.0f;

            Multiply(tmp, matrix, ref matrix);
        }

        public static void RotateY(ref float[][] matrix, float a, float b)
        {
            float[][] tmp = CreateIdentity();

            tmp[0][0] = b;
            tmp[0][1] = 0.0f;
            tmp[0][2] = -a;
            tmp[0][3] = 0.0f;

            tmp[2][0] = a;
            tmp[2][1] = 0.0f;
            tmp[2][2] = b;
            tmp[2][3] = 0.0f;

            Multiply(tmp, matrix, ref matrix);
        }

        public static void RotateZ(ref float[][] matrix, float a, float b)
        {
            float[][] tmp = CreateIdentity();

            tmp[0][0] = b;
            tmp[0][1] = a;
            tmp[0][2] = 0.0f;
            tmp[0][3] = 0.0f;

            tmp[1][0] = -a;
            tmp[1][1] = b;
            tmp[1][2] = 0.0f;
            tmp[1][3] = 0.0f;

            Multiply(tmp, matrix, ref matrix);
        }

        public static void ShearZ(ref float[][] matrix, float x, float y)
        {
            float[][] tmp = CreateIdentity();

            tmp[0][0] = 1.0f;
            tmp[0][1] = 0.0f;
            tmp[0][2] = x;
            tmp[0][3] = 0.0f;

            tmp[1][0] = 0.0f;
            tmp[1][1] = 1.0f;
            tmp[1][2] = y;
            tmp[1][3] = 0.0f;

            Multiply(tmp, matrix, ref matrix);
        }

        public static void HueRotate(ref float[][] matrix, float degrees)
        {
            float[][] tmp = CreateIdentity();
            float mag = (float)Math.Sqrt(2.0);
            float[] t;
            float xrs, xrc;
            float yrs, yrc;
            float zrs, zrc;
            float zsx, zsy;

            /* rotate the grey vector into positive Z */
            xrs = 1.0f / mag;
            xrc = 1.0f / mag;
            RotateX(ref tmp, xrs, xrc);

            mag = (float)Math.Sqrt(3.0);
            yrs = -1.0f / mag;
            yrc = (float)Math.Sqrt(2.0) / mag;
            RotateY(ref tmp, yrs, yrc);

            /* shear the space to make the luminance plane horizontal */
            t = TransformPoint(tmp, RED_LUMINANCE, GREEN_LUMINANCE, BLUE_LUMINANCE);
            zsx = t[0] / t[2];
            zsy = t[1] / t[2];
            ShearZ(ref tmp, zsx, zsy);

            /* rotate the hue */
            zrs = (float)Math.Sin(degrees * Math.PI / 180.0);
            zrc = (float)Math.Cos(degrees * Math.PI / 180.0);
            RotateZ(ref tmp, zrs, zrc);

            /* unshear the space to put the luminance plane back */
            ShearZ(ref tmp, -zsx, -zsy);

            /* rotate the grey vector back into place */
            RotateY(ref tmp, -yrs, -yrc);
            RotateX(ref tmp, -xrs, -xrc);

            Multiply(tmp, matrix, ref matrix);
        }

        public static float[][] CreateIdentity()
        {
            return new float[][] {
                new float[] { 1, 0, 0, 0 },
                new float[] { 0, 1, 0, 0 },
                new float[] { 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 1 }
            };
        }

        //4x4 to 5x5
        public static float[][] Compat(float[][] matrix)
        {
            float[][] tmp = new float[][] {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            };

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    tmp[y][x] = matrix[y][x];
                }
            }

            return tmp;
        }
    }
}
