using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EliteTheme
{
    public class Theme : IXmlSerializable
    {
        public float[][] Matrix { get; set; }
        public string Name { get; set; }
        
        public bool Altered { get; set; }
        public bool Custom { get; set; }
        public bool Preset { get; set; }

        public Theme()
        {
            Name = "Original";
            Matrix = new float[][] {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            };

            Preset = false;
            Custom = false;
            Altered = false;
        }

        public Theme(string name, float[][] matrix)
        {
            Name = name;
            Matrix = matrix;

            Preset = true;
            Custom = false;
            Altered = false;
        }

        public override string ToString()
        {
            return Name;
        }

        public Theme Clone()
        {
            Theme clone = new Theme();
            clone.Name = Name.ToString();
            clone.Preset = Preset;
            clone.Custom = Custom;
            clone.Altered = Altered;
            clone.Matrix[0][0] = Matrix[0][0];
            clone.Matrix[0][1] = Matrix[0][1];
            clone.Matrix[0][2] = Matrix[0][2];
            clone.Matrix[1][0] = Matrix[1][0];
            clone.Matrix[1][1] = Matrix[1][1];
            clone.Matrix[1][2] = Matrix[1][2];
            clone.Matrix[2][0] = Matrix[2][0];
            clone.Matrix[2][1] = Matrix[2][1];
            clone.Matrix[2][2] = Matrix[2][2];
            return clone;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();
            Name = reader.GetAttribute("Name");
            Boolean isEmptyElement = reader.IsEmptyElement; // (1)
            reader.ReadStartElement();
            if (!isEmptyElement) // (1)
            {
                string matrixRed = reader.ReadElementString("MatrixRed");
                string matrixGreen = reader.ReadElementString("MatrixGreen");
                string matrixBlue = reader.ReadElementString("MatrixBlue");
                reader.ReadEndElement();

                string[] redParts = matrixRed.Split(',');
                Matrix[0][0] = float.Parse(redParts[0].Trim());
                Matrix[0][1] = float.Parse(redParts[1].Trim());
                Matrix[0][2] = float.Parse(redParts[2].Trim());

                string[] greenParts = matrixGreen.Split(',');
                Matrix[1][0] = float.Parse(greenParts[0].Trim());
                Matrix[1][1] = float.Parse(greenParts[1].Trim());
                Matrix[1][2] = float.Parse(greenParts[2].Trim());

                string[] blueParts = matrixBlue.Split(',');
                Matrix[2][0] = float.Parse(blueParts[0].Trim());
                Matrix[2][1] = float.Parse(blueParts[1].Trim());
                Matrix[2][2] = float.Parse(blueParts[2].Trim());
            }

            Custom = true;
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
            writer.WriteElementString("MatrixRed", Matrix[0][0] + ", " + Matrix[0][1] + ", " + Matrix[0][2]);
            writer.WriteElementString("MatrixGreen", Matrix[1][0] + ", " + Matrix[1][1] + ", " + Matrix[1][2]);
            writer.WriteElementString("MatrixBlue", Matrix[1][0] + ", " + Matrix[2][1] + ", " + Matrix[2][2]);
        }
    }
}
