using Maize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Helpers
{
    public class UtilsLoopring
    {
        public static MinterAndCollection GetMinterAndCollection(Font font)
        {
            var result = new MinterAndCollection();
            font.ToTertiary("Enter the Minter");
            string minter = Utils.ReadLineWarningNoNulls("Enter the Minter", font);
            font.ToTertiary("Enter the Token/Collection Address");
            string TokenId = Utils.ReadLineWarningNoNulls("Enter the TokenId/Collection Address", font);
            result.minter = minter;
            result.TokenId = TokenId;
            return result;

        }
        public static void CheckIpfsForbidden(Font font, NftMetadata nftMetadata)
        {
            if (nftMetadata == null)
            {
                Utils.ClearLine();
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 5 min.");
                Thread.Sleep(60000);
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 4 min.");
                Thread.Sleep(60000);
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 3 min.");
                Thread.Sleep(60000);
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 2 min.");
                Thread.Sleep(60000);
                font.ToTertiaryInline($"\rIPFS timeout issue...I sleep for 1 min.");
                Thread.Sleep(60000);
            }

        }

        public static string CheckMemoLimit(Font font)
        {
            font.ToTertiary("Enter Memo for transfer. (optional)");
            string transferMemo;
            var counter = 0;
            do
            {
                if (counter > 0)
                {
                    font.ToYellow("Enter a Memo with 120 characters or less.");
                }
                transferMemo = Console.ReadLine()?.Trim();
                counter++;
            } while (transferMemo.Length > 120);

            return transferMemo;
        }

    }

    public class MinterAndCollection
    {
        public string minter { get; set; }
        public string TokenId { get; set; }
    }
}
