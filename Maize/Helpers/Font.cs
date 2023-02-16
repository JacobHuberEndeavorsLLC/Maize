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
        public void ToPrimary(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorPrimary;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToPrimaryInline(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorPrimary;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToSecondary(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorSecondary;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToSecondaryInline(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorSecondary;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToTertiary(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorTertiary;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToTertiaryInline(string str)
        {
            Console.ForegroundColor = _consoleForegroundColorTertiary;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void SetVersionFontColor(string beginning, string readMe, string end)
        {

            ToPrimaryInline(beginning);
            Console.ForegroundColor = _consoleForegroundColorSecondary;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            ToPrimary(end);
        }
        public void SetBraggingFont(string maize, string beginning, string transactionAmount, string middle, string nftAmount, string end)
        {
            ToPrimaryInline(maize);
            ToSecondaryInline(beginning);
            ToPrimaryInline(transactionAmount);
            ToSecondaryInline(middle);
            ToPrimaryInline(nftAmount);
            ToSecondary(end);
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
            ToPurpleInline(beginning);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            ToPurple(end);
        }
        public  void SetREADMEFontColorYellow(string beginning, string readMe, string end)
        {
            ToYellowInline(beginning);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            ToYellow(end);
        }
        public void SetREADMEFontColorDarkGray(string beginning, string readMe, string end)
        {
            ToDarkGrayInline(beginning);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{readMe}", Console.ForegroundColor);
            Console.ResetColor();
            ToDarkGray(end);
        }
        public  void ToBlue(string str) {
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
        public void ToBlueInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void ToYellow(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkYellow(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToYellowInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkYellowInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void ToRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToRedInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkRedInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToGreenInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkGreenInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToPurple(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void ToPurpleInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void ToDarkPurple(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }

        public void ToGray(string str)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToGrayInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkGray(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToDarkGrayInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToWhite(string str)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void ToWhiteInline(string str)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{str}", Console.ForegroundColor);
            Console.ResetColor();
        }
        public void PowerToTheCreators(Font font)
        {
            font.ToRedInline("+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+");
            font.ToRedInline("|P|o|w|e|r| |t|o| |t|h");
            Console.WriteLine("|e| |C|r|e|a|t|o|r|s|");
            font.ToRedInline("+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+");
        }
    }
}
