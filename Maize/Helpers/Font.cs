using Nethereum.JsonRpc.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize
{
    public class Font
    {
        readonly ConsoleColor _consoleForegroundColorPrimary;
        readonly ConsoleColor _consoleForegroundColorSecondary;
        readonly ConsoleColor _consoleForegroundColorTertiary;
        public Font(ConsoleColor consoleForegroundColorPrimary, ConsoleColor consoleForegroundColorSecondary, 
            ConsoleColor consoleForegroundColorTertiary)
        {
            _consoleForegroundColorPrimary = consoleForegroundColorPrimary;
            _consoleForegroundColorSecondary = consoleForegroundColorSecondary;
            _consoleForegroundColorTertiary = consoleForegroundColorTertiary;
        }
        public void SetTextToPrimary(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorPrimary;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToPrimaryInline(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorPrimary;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToSecondary(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorSecondary;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToSecondaryInline(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorSecondary;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToTertiary(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorTertiary;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToTertiaryInline(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorTertiary;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetVersionFontColor(string beginning, string readMe, string end)
        {

            SetTextToPrimaryInline(beginning);
            Console.ForegroundColor = _consoleForegroundColorSecondary;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            SetTextToPrimary(end);
        }
        public void SetBraggingFont(string maize, string beginning, string transactionAmount, string middle, string nftAmount, string end)
        {
            SetTextToPrimaryInline(maize);
            SetTextToSecondaryInline(beginning);
            SetTextToPrimaryInline(transactionAmount);
            SetTextToSecondaryInline(middle);
            SetTextToPrimaryInline(nftAmount);
            SetTextToSecondary(end);
        }
        public void SetREADMEFontColor(string beginning, string readMe, string end)
        {
            Console.Write(beginning);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            Console.WriteLine(end);
        }

        public void SetREADMEFontColorPurple(string beginning, string readMe, string end)
        {
            SetTextToPurpleInline(beginning);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            SetTextToPurple(end);
        }
        public  void SetREADMEFontColorYellow(string beginning, string readMe, string end)
        {
            SetTextToYellowInline(beginning);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            SetTextToYellow(end);
        }
        public void SetREADMEFontColorDarkGray(string beginning, string readMe, string end)
        {
            SetTextToDarkGrayInline(beginning);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            SetTextToDarkGray(end);
        }
        public  void SetTextToBlue(string str) {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{str}", Console.ForegroundColor);
                Console.ResetColor();
            }
            catch (Exception)
            {
                Console.WriteLine(str);
            }

        }
        public void SetTextToBlueInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToDarkBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void SetTextToYellow(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToDarkYellow(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToYellowInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToDarkYellowInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void SetTextToRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToRedInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToGreenInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToDarkGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToDarkGreenInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToPurple(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void SetTextToPurpleInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void SetTextToDarkPurple(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void SetTextToGray(string str)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToDarkGray(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToDarkGrayInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToWhite(string str)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetTextToWhiteInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void PowerToTheCreators(Font font)
        {
            font.SetTextToRedInline("+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+");
            font.SetTextToRedInline("|P|o|w|e|r| |t|o| |t|h");
            Console.WriteLine("|e| |C|r|e|a|t|o|r|s|");
            font.SetTextToRedInline("+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+");
        }
    }
}
