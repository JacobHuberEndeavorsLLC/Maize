using Maize.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Helpers
{
    public class MenuAndUtility
    {
        public Dictionary<string, string> allUtilities { get; set; }
        public string userResponseOnUtility { get; set; }
    }
    public class Menu
    {
        public static void BannerForMaize(Font font, List<Leaderboard>? usersTransactionsAndNftsSent)
        {
            font.ToSecondary("= = = |W|e|l|c|o|m|e| |t|o| = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            font.ToPrimary(@"          MMMMMMMM               MMMMMMMM                    iiii                                       ");  
            font.ToPrimary(@"          M:::::::M             M:::::::M                   i::::i                                      ");  
            font.ToPrimary(@"          M::::::::M           M::::::::M                    iiii                                       ");  
            font.ToPrimary(@"          M:::::::::M         M:::::::::M                                                               ");  
            font.ToPrimary(@"          M::::::::::M       M::::::::::M  aaaaaaaaaaaaa   iiiiiii zzzzzzzzzzzzzzzzz    eeeeeeeeeeee    ");  
            font.ToPrimary(@"          M:::::::::::M     M:::::::::::M  a::::::::::::a  i:::::i z:::::::::::::::z  ee::::::::::::ee  ");  
            font.ToPrimary(@"          M:::::::M::::M   M::::M:::::::M  aaaaaaaaa:::::a  i::::i z::::::::::::::z  e::::::eeeee:::::ee");  
            font.ToPrimary(@"          M::::::M M::::M M::::M M::::::M           a::::a  i::::i zzzzzzzz::::::z  e::::::e     e:::::e");  
            font.ToPrimary(@"          M::::::M  M::::M::::M  M::::::M    aaaaaaa:::::a  i::::i       z::::::z   e:::::::eeeee::::::e");
            font.ToPrimary(@"          M::::::M   M:::::::M   M::::::M  aa::::::::::::a  i::::i      z::::::z    e:::::::::::::::::e ");
            font.ToPrimary(@"          M::::::M    M:::::M    M::::::M a::::aaaa::::::a  i::::i     z::::::z     e::::::eeeeeeeeeee  ");
            font.ToPrimary(@"          M::::::M     MMMMM     M::::::Ma::::a    a:::::a  i::::i    z::::::z      e:::::::e           ");
            font.ToPrimary(@"          M::::::M               M::::::Ma::::a    a:::::a i::::::i  z::::::zzzzzzzze::::::::e          ");
            font.ToPrimary(@"          M::::::M               M::::::Ma:::::aaaa::::::a i::::::i z::::::::::::::z e::::::::eeeeeeee  ");
            font.ToPrimary(@"          M::::::M               M::::::M a::::::::::aa:::ai::::::iz:::::::::::::::z  ee:::::::::::::e  ");
            font.SetVersionFontColor(@"          MMMMMMMM","       v0.3.0","  MMMMMMMM  aaaaaaaaaa  aaaaiiiiiiiizzzzzzzzzzzzzzzzz    eeeeeeeeeeeeee  ");
            font.ToSecondary("= = = Analytics and Airdrops for your Crypto and Nfts = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine();
            font.SetBraggingFont($"Maize ", "has completed ", usersTransactionsAndNftsSent.Sum(x => x.transactionCount).ToString(), " transactions and sent ", usersTransactionsAndNftsSent.Sum(x => x.nftAmountSent).ToString(), " Nfts.");
            Console.WriteLine();
            font.ToDarkGrayInline("If you have any questions, check the Tips/FAQs in the menu or ");
            font.ToDarkYellowInline("maize");
            font.ToDarkGreenInline("helps");
            font.ToGray(".art");
            font.ToDarkGrayInline("Check out my nfts here: ");
            font.ToWhiteInline("Loop");
            font.ToDarkRedInline("Exchange");
            font.ToGray(".art/collection/maizeorigin");
            font.ToDarkGrayInline("and ");
            font.ToWhiteInline("Loop");
            font.ToDarkRedInline("Exchange");
            font.ToGray(".art/collection/maizecollaboration");
            Console.WriteLine();
        }
        public static MenuAndUtility MenuForMaize(Font font, int environment)
        {
            var allUtilities = new Dictionary<string, string>()
            {
                {"utilityZero", "General tips and FAQs"},
                {"utilityOne", "Create a Collection"},
                {"utilityTwo", "Batch Mint Nfts"},
                {"utilityThree", "Mint to Sent in an Instant"},
                {"utilityFour", "Find Nft Data for a single Nft"},
                {"utilityFive", "Find Nft Data from Nft Id"},
                {"utilitySix", "Find Nft Data from a Collection"},
                {"utilitySeven", "Find Nft Data from a Wallet"},
                {"utilityEight", "Find Holders from Nft Data"},
                {"utilityNine", "Find Holders from a minter"},
                {"utilityTen", "Find Holders who own all Nfts"},
                {"utilityEleven", "Find Holders who own all Nfts w/min set amount"},
                {"utilityTwelve", "Send to any users"},
                {"utilityThirteen", "Send to any users (include amounts)"},
                {"utilityFourteen", "Send unique NFTs to any users"},
                {"utilityFifteen", "Send Nfts to the Dead address"},
                {"utilitySixteen", "Send LRC to any users"},
                {"utilitySeventeen", "Send LRC to any users (include amounts)"},
                {"utilityEighteen", "Pay Loopring activation fee for wallets"},
                {"utilityNineteen", "Nft Transfer Leaderboards"},
                {"utilityTwenty", "Minted Collection Analytics"},
                {"utilityTwentyone", "Owned Collection Analytics"},
                {"utilityTwentyTwo", "Specific Collection Analytics"}
            };
            font.ToPrimary(@"          ___");
            font.ToPrimary(@"= = |\/| |___ |\ | |  | = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            font.ToPrimary(@"= = |  | |___ | \| |__| = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine();
            font.ToPrimary("      = Minting =");
            font.ToWhite($"\t 1. {allUtilities.ElementAt(1).Value}");
            font.ToWhite($"\t 2. {allUtilities.ElementAt(2).Value}");
            font.ToWhite($"\t 3. {allUtilities.ElementAt(3).Value}");
            font.ToPrimary("      = LOOKUPS =");
            font.ToSecondary("        Nft Data                                Nft Holders");
            font.ToWhite($"\t 4. {allUtilities.ElementAt(4).Value}\t 8. {allUtilities.ElementAt(8).Value}");
            font.ToWhite($"\t 5. {allUtilities.ElementAt(5).Value}\t\t 9. {allUtilities.ElementAt(9).Value}");
            font.ToWhite($"\t 6. {allUtilities.ElementAt(6).Value}\t10. {allUtilities.ElementAt(10).Value}");
            font.ToWhite($"\t 7. {allUtilities.ElementAt(7).Value}\t        11. {allUtilities.ElementAt(11).Value}");
            font.ToPrimary("      = AIRDROPS =");
            font.ToSecondary("        Nfts                                   Crypto");
            font.ToWhite($"\t12. {allUtilities.ElementAt(12).Value}\t\t\t16. {allUtilities.ElementAt(16).Value}");
            font.ToWhite($"\t13. {allUtilities.ElementAt(13).Value}\t17. {allUtilities.ElementAt(17).Value}");
            font.ToWhite($"\t14. {allUtilities.ElementAt(14).Value}\t18. {allUtilities.ElementAt(18).Value}");
            font.ToWhite($"\t15. {allUtilities.ElementAt(15).Value}");
            font.ToPrimary("      = ANALYTICS =");
            font.ToWhite($"\t19. {allUtilities.ElementAt(19).Value}");
            font.ToWhite($"\t20. {allUtilities.ElementAt(20).Value}");
            font.ToWhite($"\t21. {allUtilities.ElementAt(21).Value}");
            font.ToWhite($"\t22. {allUtilities.ElementAt(22).Value}");
            font.ToPrimary("      = Tips/FAQs =");
            font.ToWhite($"\t 0. {allUtilities.ElementAt(0).Value}");
            Console.WriteLine();
            font.ToTertiary("Which would you like to do?");
            var userResponseOnUtility = Utils.CheckUtilityNumber(allUtilities.Count() - 1, font);
            //var userResponseOnUtility = "16";
            Console.WriteLine();
            var menuAndUtility = new MenuAndUtility() { allUtilities = allUtilities , userResponseOnUtility = userResponseOnUtility };
            return menuAndUtility;

        }

        public static void FooterForMaize(Font font)
        {
            Console.WriteLine();
            font.ToPurple("Thanks for using Cobmin's Maize.");
            font.ToSecondary("Any feedback? You can find my contact information here, https://cobmin.io/.");
            font.ToPurple("Check out my Nft collection at https://loopexchange.art/collection/maizeorigin.");
            font.ToGray("Need help with your drop? Let him know.");
            Console.WriteLine(); 
            font.ToDarkGray("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            font.ToDarkGray("|P|o|w|e|r| |t|o| |t|h|e| |C|r|e|a|t|o|r|s|");
            font.ToDarkGray("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
        }

        public static string EndOfMaizeFunctionality(Font font)
        {
            font.ToTertiary("Start a new functionality?");
            var userResponseReadyToMoveOn = Utils.CheckYesOrNo(font);
            return userResponseReadyToMoveOn;
        }
        public static void UtilityHeader(Font font, string utilityTitle, string utilityDescription, string utilityNeeds, string? optionalInformation, bool transactionDisclaimer)
        {
            font.ToPrimary($" - {utilityTitle} -");
            font.ToSecondary(utilityDescription);
            font.ToSecondary(utilityNeeds);
            if(optionalInformation != null)
                font.ToSecondary(optionalInformation);
            if (transactionDisclaimer == true)
            {
                font.ToPrimary($"Each batch mint will cost 0.000000000000000001 LRC.");
                font.ToPrimary($"This will only occur if at least one mint was successful.");
            }
            Console.WriteLine();
            font.ToPrimary("Let's get started.");
            Console.WriteLine();
        }

        //public static void ColorfulAnimation()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        for (int j = 0; j < 30; j++)
        //        {
        //            Console.Clear();

        //            // steam
        //            Console.Write("       . . . . o o o o o o", Color.LightGray);
        //            for (int s = 0; s < j / 2; s++)
        //            {
        //                Console.Write(" o", Color.LightGray);
        //            }
        //            Console.WriteLine();

        //            var margin = "".PadLeft(j);
        //            Console.WriteLine(margin + "                _____      o", Color.LightGray);
        //            Console.WriteLine(margin + "       ____====  ]OO|_n_n__][.", Color.DeepSkyBlue);
        //            Console.WriteLine(margin + "      [________]_|__|________)< ", Color.DeepSkyBlue);
        //            Console.WriteLine(margin + "       oo    oo  'oo OOOO-| oo\\_", Color.Blue);
        //            Console.WriteLine("   +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+", Color.Silver);

        //            Thread.Sleep(200);
        //        }
        //    }
        //}
    }
}
