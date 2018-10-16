using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTheme
{
    public static class PresetThemes
    {
        public static Theme[] List()
        {
            List<Theme> list = new List<Theme>();

            list.Add(new Theme("Original", new float[][] {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            // Tri Color

            list.Add(new Theme("Snakeyesx21 - 2", new float[][] {
                new float[] { 0, 0, 0.5f, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0.5f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 7", new float[][] {
                new float[] { 0, 0.5f, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0.1f, 0.1f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 14", new float[][] {
                new float[] { 0.5f, 0, 0.5f, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 17", new float[][] {
                new float[] { 0.3f, 0.3f, 1, 0, 0 },
                new float[] { 1, 1, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - Black UI", new float[][] {
                new float[] { 0.15f, 0, 0, 0, 0 },
                new float[] { 0, 1, 1, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - mitzt", new float[][] {
                new float[] { -0.2f, 1, 0.5f, 0, 0 },
                new float[] { 0.2f, -0.1f, 1, 0, 0 },
                new float[] { 1, 0.1f, -0.5f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - Rustiest_Venture - Green", new float[][] {
                new float[] { -0.25f, 0.5f, -0.25f, 0, 0 },
                new float[] { 2, 2, 2, 0, 0 },
                new float[] { 1.5f, -1.5f, -1.5f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - BlueRedYellow", new float[][] {
                new float[] { -1, 0.5f, 1, 0, 0 },
                new float[] { 1, -1, -0.25f, 0, 0 },
                new float[] { 1, 0.3f, -1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - BluePurple", new float[][] {
                new float[] { 0, 0.1f, 1, 0, 0 },
                new float[] { 0.4f, 1.25f, 0.2f, 0, 0 },
                new float[] { 1, -1.25f, 0.3f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - Cool Blue", new float[][] {
                new float[] { 0.2f, 0.3f, 0.9f, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - 80's Revival Purple", new float[][] {
                new float[] { 0.3f, 0.3f, 1, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - WhiteBlue", new float[][] {
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { -1, -1, 1, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - Beige", new float[][] {
                new float[] { 0.3f, 0.1f, 0, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - Nightvision", new float[][] {
                new float[] { 0.3f, 0.75f, 0.1f, 0, 0 },
                new float[] { 0.5f, 0.5f, 1, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - Bakayarou - BlueWhite", new float[][] {
                new float[] { 0.2f, 0.3f, 0.9f, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - fenrishunter500 - Phantom Green", new float[][] {
                new float[] { 0, 0.6f, 1, 0, 0 },
                new float[] { 1, 0.8f, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - D3V0M4N - Blue Stahli", new float[][] {
                new float[] { 0.15f, 0.25f, 0.9f, 0, 0 },
                new float[] { 0.6f, 1, 0.3f, 0, 0 },
                new float[] { 0.5f, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - DaveInc - Gameboy 1989", new float[][] {
                new float[] { 0.25f, 0.45f, 0, 0, 0 },
                new float[] { 1, 0.1f, 0.35f, 0, 0 },
                new float[] { 0, 0.1f, 0.35f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - Sushiki - Dream of night", new float[][] {
                new float[] { 1, 0.15f, 0, 0, 0 },
                new float[] { 0, 0.15f, 1, 0, 0 },
                new float[] { 0, 1, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            //Preset from https://www.reddit.com/r/EliteDangerous/comments/31vuk8/perfect_blue_color_scheme_all_radar_targets_are

            list.Add(new Theme("Reddit - Sammyhain - WhiteYellow", new float[][] {
                new float[] { 0.11f, 0.26f, 1, 0, 0 },
                new float[] { 1, 1, -0.45f, 0, 0 },
                new float[] { 0.18f, -0.26f, -0.21f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - SirBaron - Blue", new float[][] {
                new float[] { 0, 0.35f, 0.75f, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Kirisute - Green Venom", new float[][] {
                new float[] { 0, 0.3f, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0.3f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Kirisute - Purple Haze", new float[][] {
                new float[] { 0, 0, 0.5f, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0.5f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Mulbin - 1980's Spaceship", new float[][] {
                new float[] { 0.3f, 0.3f, 1, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Alatar - BlueRed", new float[][] {
                new float[] { 0, 0.33f, 0.75f, 0, 0 },
                new float[] { 0.6f, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Arkku - BluePurple", new float[][] {
                new float[] { 0.05f, 0.1f, 1, 0, 0 },
                new float[] { 0.4f, 1.25f, 0.2f, 0, 0 },
                new float[] { 1, -1.25f, 0.3f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - MadEye - Shine", new float[][] {
                new float[] { 0.3f, 0.3f, 0.4f, 0, 0 },
                new float[] { 0.2f, 0.6f, 0.1f, 0, 0 },
                new float[] { 0.9f, 0.1f, 0.1f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Uncertain - Deus Ex Mint-Mocha", new float[][] {
                new float[] { 0.7f, 0.1f, -0.1f, 0, 0 },
                new float[] { 0, 1, 1, 0, 0 },
                new float[] { 0.15f, -0.15f, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("EliteTheme - Random - RedBlue", new float[][] {
                new float[] { 0, 0.3f, 0.35f, 0, 0 },
                new float[] { 0.6f, 0, 0, 0, 0 },
                new float[] { 0.6f, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("EliteTheme - Random - PurpleYellow", new float[][] {
                new float[] { 0.05f, 0.25f, 0.5f, 0, 0 },
                new float[] { 0.9f, 0, 0, 0, 0 },
                new float[] { 0.9f, 0.85f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("EliteTheme - Random - TealOrange", new float[][] {
                new float[] { 0, 0.35f, 0.75f, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 1, -0.3f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            //Preset from http://steamcommunity.com/app/359320/discussions/0/483367798509363817/

            list.Add(new Theme("Steam - Draco25240 - BlueOrange", new float[][] {
                new float[] { 0.1f, 0, 0, 0, 0 },
                new float[] { -1, 1, 2, 0, 0 },
                new float[] { 2, 0, -1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            // Oculus

            list.Add(new Theme("Reddit - [deleted] - TealTri-Color *Oculus*", new float[][] {
                new float[] { 0, 0.9f, 0.6f, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - GreenBlue *Oculus*", new float[][] {
                new float[] { 0, 0.5f, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0.1f, 0.1f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Quietman - Green *Oculus*", new float[][] {
                new float[] { 0, 0.4f, 0, 0, 0 },
                new float[] { 0, 0.2f, 0, 0, 0 },
                new float[] { 0, 0.8f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Quietman - BlueYellow *Oculus*", new float[][] {
                new float[] { 0, 0.25f, 0.75f, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            //Presets from http://imgur.com/gallery/GB7Dd

            list.Add(new Theme("Snakeyesx21 - 1", new float[][] {
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));
            
            list.Add(new Theme("Snakeyesx21 - 3", new float[][] {
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 4", new float[][] {
                new float[] { 0, 1, 1, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 5", new float[][] {
                new float[] { 0, 0.3f, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0.3f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 6", new float[][] {
                new float[] { 0, 0.4f, 0.7f, 0, 0 },
                new float[] { -1, -1, -1, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));
            
            list.Add(new Theme("Snakeyesx21 - 8", new float[][] {
                new float[] { 0, 0.5f, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0.5f, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 9", new float[][] {
                new float[] { 0, 0.5f, 1, 0, 0 },
                new float[] { 0, 0.5f, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 10", new float[][] {
                new float[] { 0, 0.33f, 0.75f, 0, 0 },
                new float[] { 0.6f, 0, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 11", new float[][] {
                new float[] { 0, 0.66f, 1, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 12", new float[][] {
                new float[] { 0.2f, 1, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 13", new float[][] {
                new float[] { 0.3f, 0.03f, 1, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 15", new float[][] {
                new float[] { 0.5f, 0, 0.5f, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Snakeyesx21 - 16", new float[][] {
                new float[] { 0.33f, 0.11f, 0, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            // Presets from https://www.reddit.com/r/EliteDangerous/comments/41oiq1/i_made_a_thing_called_elitetheme/

            list.Add(new Theme("Reddit - Dakro_6577 - Blue", new float[][] {
                new float[] { 0, 0.2f, 1, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            //Presets from https://www.reddit.com/r/EliteDangerous/comments/2sqg81/10_more_ui_themes_with_a_focus_on_readability/

            list.Add(new Theme("Reddit - thapol - Ice", new float[][] {
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { -2, 1, 1, 0, 0 },
                new float[] { -2, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - thapol - TealPurple", new float[][] {
                new float[] { 0, 1, 1, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 1, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - thapol - TealYellow", new float[][] {
                new float[] { -1, 1, 1, 0, 0 },
                new float[] { 1.5f, 1.5f, 2, 0, 0 },
                new float[] { 0.5f, 0.5f, -1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - Rustiest_Venture - Green", new float[][] {
                new float[] { -0.25f, 0.5f, -0.25f, 0, 0 },
                new float[] { 2, 2, 2, 0, 0 },
                new float[] { 1.5f, -1.5f, -1.5f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - NoShftShck16 - WhiteOrange", new float[][] {
                new float[] { 2, 2, 2, 0, 0 },
                new float[] { 2, -2, -2, 0, 0 },
                new float[] { 2, 1, 2, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - thapol - WhiteBlue", new float[][] {
                new float[] { 2, 2, 2, 0, 0 },
                new float[] { 0, 0, 2, 0, 0 },
                new float[] { -2, 1, 2, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - ExplosionSanta - Hotline Miami", new float[][] {
                new float[] { 1, -1, 0.5f, 0, 0 },
                new float[] { 1, 0.8f, 0, 0, 0 },
                new float[] { -1, 1, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            //Presets from https://www.reddit.com/r/EliteDangerous/comments/2p3784/you_can_manually_customize_the_gui_colors

            list.Add(new Theme("Reddit - megazen - LightBlueWhite", new float[][] {
                new float[] { 0, 0.4f, 0.7f, 0, 0 },
                new float[] { -1, -1, -1, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - Retro Gamer", new float[][] {
                new float[] { 0.2f, 1, 0, 0, 0 },
                new float[] { 0.5f, 0, 0, 0, 0 },
                new float[] { 0.5f, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - GreenPink", new float[][] {
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0.5f, 0, 0, 0, 0 },
                new float[] { 0.5f, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - Red", new float[][] {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - Ghost", new float[][] {
                new float[] { 0, 0.3f, 0.5f, 0, 0 },
                new float[] { 0, 0, 0.2f, 0, 0 },
                new float[] { 0.2f, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - Fade to Grey", new float[][] {
                new float[] { 0.2f, 0.2f, 0.5f, 0, 0 },
                new float[] { 0.4f, 0.2f, 0.3f, 0, 0 },
                new float[] { 0.4f, 0.2f, 0.3f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - megazen - Jaded", new float[][] {
                new float[] { 0.2f, 0.5f, 0.2f, 0, 0 },
                new float[] { 0.3f, 0.2f, 0.4f, 0, 0 },
                new float[] { 0.3f, 0.2f, 0.4f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - b1llyb0nes - PurpleGreen", new float[][] {
                new float[] { 0.3f, 0, 1, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0.15f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - cyb0rgmous3 - Raspberry Slush", new float[][] {
                new float[] { 0.2f, 0.4f, 0.65f, 0, 0 },
                new float[] { 0, 0.15f, 0.3f, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - cyb0rgmous3 - Strawberry", new float[][] {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0.15f, 0.3f, 0, 0 },
                new float[] { 0.65f, 0.4f, 0.2f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - cyb0rgmous3 - Lime", new float[][] {
                new float[] { 0, 0.95f, 0, 0, 0 },
                new float[] { 0.3f, 0, 0.15f, 0, 0 },
                new float[] { 0.65f, 0.5f, 0.35f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - cyb0rgmous3 - Neon Lights / For the Ladies", new float[][] {
                new float[] { 0.45f, 0, 0.45f, 0, 0 },
                new float[] { 0, 0.35f, 0, 0, 0 },
                new float[] { 0, 1, 0.55f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - cyb0rgmous3 - Teal Plum", new float[][] {
                new float[] { 0, 0.55f, 0.5f, 0, 0 },
                new float[] { 0.3f, 0.3f, 0.55f, 0, 0 },
                new float[] { 0.75f, 0, 0.75f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - cyb0rgmous3 - Baby Blue Gold", new float[][] {
                new float[] { 0.1f, 0.55f, 1, 0, 0 },
                new float[] { 0.45f, 0, 0, 0, 0 },
                new float[] { 0.95f, 0.8f, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - lun471k - BlueOrangeWhite", new float[][] {
                new float[] { -1, 0.45f, 1, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 1, -0.35f, -1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("Reddit - kithsakhai - Homeworld2", new float[][] {
                new float[] { 0.2f, 0.4f, 1, 0, 0 },
                new float[] { 0.1f, 0.1f, 0.1f, 0, 0 },
                new float[] { 1, 0.2f, 0.2f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            //Presets from https://forums.frontier.co.uk/showthread.php?t=73419

            list.Add(new Theme("FDF - Uncertain - Hot Pink", new float[][] {
                new float[] { 1, 0, 0.35f, 0, 0 },
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 0.35f, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Kirisute - Sunset Blast", new float[][] {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0.5f, 0.7f, 0, 0, 0 },
                new float[] { 0, 0, 0.1f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - hobblygobbly - Green", new float[][] {
                new float[] { 0.7f, 1, 0.15f, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 0.15f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Mulbin - Retro Gamer", new float[][] {
                new float[] { 0.2f, 1, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Uncertain - Thargoid", new float[][] {
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0.5f, 0, 0, 0, 0 },
                new float[] { 0.5f, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Uncertain - GoldPurple", new float[][] {
                new float[] { 1, 1, 0, 0, 0 },
                new float[] { 1, 0, 0.9f, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));
            
            list.Add(new Theme("FDF - Highrisedrifter - Blood", new float[][] {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Uncertain - Shark", new float[][] {
                new float[] { 0.25f, 0.2f, 0.5f, 0, 0 },
                new float[] { 0, 0.5f, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - DhuAlan - I'm All White Jack", new float[][] {
                new float[] { 0.4f, 0.4f, 0.4f, 0, 0 },
                new float[] { 0.85f, 0.85f, 0.85f, 0, 0 },
                new float[] { 0.2f, 0.2f, 0.2f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Oddball_E8 - GrayRed", new float[][] {
                new float[] { 0.35f, 0.35f, 0.35f, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Blake_Dragon - Empire Red", new float[][] {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0.15f, 0, 0, 0 },
                new float[] { 0, 0.75f, 0.7f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - DhuAlan - Greydient", new float[][] {
                new float[] { 0.6f, 0.6f, 0.6f, 0, 0 },
                new float[] { 0.1f, 0.1f, 0.1f, 0, 0 },
                new float[] { 0.3f, 0.3f, 0.3f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Maver - Trooper", new float[][] {
                new float[] { 1, 1, 1, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Arkku - PurpleRed", new float[][] {
                new float[] { 0.35f, 0.15f, 3.5f, 0, 0 },
                new float[] { -0.5f, 2, -1.25f, 0, 0 },
                new float[] { 1.75f, -1, -0.4f, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - bliss - TurquoiseOrange", new float[][] {
                new float[] { 0, 0.5f, 0.2f, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));

            list.Add(new Theme("FDF - Roughrider - GAHAODNBTIVG", new float[][] {
                new float[] { -0.5f, 0.2f, 1, 0, 0 },
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0.8f, 1, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            }));
            
            return list.ToArray();
        }
    }
}
