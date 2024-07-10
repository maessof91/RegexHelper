using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexHelper;

public class Colors
{
   public static Color[] groupColors = new Color[] {
             Color.Yellow,                  //0 
             Color.Green,                   //1 
             Color.Teal,                    //2 
             Color.Cyan,                    //3 
             Color.Cornsilk,                //4 
             Color.Gray,                    //5 
             Color.Lavender,                //6 
             Color.Pink,                    //7 
             Color.HotPink,                 //8 
             Color.Azure,                   //9 
             Color.LemonChiffon,            //10
             Color.SpringGreen,             //11
             Color.LightSeaGreen,           //12
             Color.Turquoise,               //13
             Color.LightCyan,               //14
             Color.MediumVioletRed,         //15
             Color.Fuchsia,                 //16
             Color.LightSkyBlue,            //17
             Color.SandyBrown,              //18
             Color.LightSalmon,             //19
             Color.LightGreen,              //20
             Color.PowderBlue,              //21
             Color.MediumTurquoise,         //22
             Color.LavenderBlush,           //23
             Color.LightGoldenrodYellow,    //24
             Color.PaleTurquoise,           //25
             Color.LightSteelBlue,          //26
             Color.Plum,                    //27
             Color.MediumPurple,            //28
             Color.PaleVioletRed,           //29
             Color.SkyBlue,                 //30
             Color.LightSlateGray,          //31
             Color.LightGray,               //32
             Color.LightYellow,             //33
             Color.Honeydew,                //34
             Color.AliceBlue,               //35
             Color.MistyRose,               //36
             Color.SeaShell,                //37
             Color.PaleGoldenrod,           //38
             Color.OldLace,                 //39
             Color.PaleGreen,              //40
             Color.PeachPuff,               //41
             Color.MintCream,               //42
             Color.LightBlue,               //43
             Color.LightPink,               //44
             Color.Azure,                   //45
             Color.LightCoral,              //46
             Color.Chocolate ,              //47
             Color.Goldenrod ,              //48
        };

    public static Color[] groupColorsContrasted = new Color[] {
        Color.Purple,                   //0 - Contrasts with Yellow
        Color.Red,                      //1 - Contrasts with Green
        Color.Orange,                   //2 - Contrasts with Teal
        Color.Magenta,                  //3 - Contrasts with Cyan
        Color.DarkSlateGray,            //4 - Contrasts with Cornsilk
        Color.White,                    //5 - Contrasts with Gray
        Color.DarkSlateBlue,            //6 - Contrasts with Lavender
        Color.DarkGreen,                //7 - Contrasts with Pink
        Color.Teal,                     //8 - Contrasts with HotPink
        Color.OrangeRed,                //9 - Contrasts with Azure
        Color.DarkBlue,                 //10 - Contrasts with LemonChiffon
        Color.DarkMagenta,              //11 - Contrasts with SpringGreen
        Color.Maroon,                   //12 - Contrasts with LightSeaGreen
        Color.Crimson,                  //13 - Contrasts with Turquoise
        Color.Navy,                     //14 - Contrasts with LightCyan
        Color.Yellow,                   //15 - Contrasts with MediumVioletRed
        Color.LimeGreen,                //16 - Contrasts with Fuchsia
        Color.DarkOrange,               //17 - Contrasts with LightSkyBlue
        Color.MidnightBlue,             //18 - Contrasts with SandyBrown
        Color.Sienna,                   //19 - Contrasts with LightSalmon
        Color.DarkRed,                  //20 - Contrasts with LightGreen
        Color.CadetBlue,                //21 - Contrasts with PowderBlue
        Color.Firebrick,                //22 - Contrasts with MediumTurquoise
        Color.Indigo,                   //23 - Contrasts with LavenderBlush
        Color.Goldenrod,                //24 - Contrasts with LightGoldenrodYellow
        Color.DarkTurquoise,            //25 - Contrasts with PaleTurquoise
        Color.SteelBlue,                //26 - Contrasts with LightSteelBlue
        Color.DarkOrchid,               //27 - Contrasts with Plum
        Color.Gold,                     //28 - Contrasts with MediumPurple
        Color.DarkOliveGreen,           //29 - Contrasts with PaleVioletRed
        Color.Orange,                   //30 - Contrasts with SkyBlue
        Color.DarkGray,                 //31 - Contrasts with LightSlateGray
        Color.Black,                    //32 - Contrasts with LightGray
        Color.DarkGoldenrod,            //33 - Contrasts with LightYellow
        Color.MediumSeaGreen,           //34 - Contrasts with Honeydew
        Color.CornflowerBlue,           //35 - Contrasts with AliceBlue
        Color.IndianRed,                //36 - Contrasts with MistyRose
        Color.SaddleBrown,              //37 - Contrasts with SeaShell
        Color.DarkKhaki,                //38 - Contrasts with PaleGoldenrod
        Color.Peru,                     //39 - Contrasts with OldLace
        Color.SeaGreen,                 //40 - Contrasts with PaleGreen
        Color.DarkSalmon,               //41 - Contrasts with PeachPuff
        Color.SeaShell,                 //42 - Contrasts with MintCream
        Color.DarkSlateBlue,            //43 - Contrasts with LightBlue
        Color.DeepPink,                 //44 - Contrasts with LightPink
        Color.DodgerBlue,               //45 - Contrasts with Azure
        Color.RosyBrown,                //46 - Contrasts with LightCoral
        Color.DarkOrange,               //47 - Contrasts with Chocolate
        Color.PaleVioletRed,            //48 - Contrasts with Goldenrod
    };
}

