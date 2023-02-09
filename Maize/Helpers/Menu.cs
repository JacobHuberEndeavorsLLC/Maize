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
            font.SetTextToSecondary("= = = |W|e|l|c|o|m|e| |t|o| = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            font.SetTextToPrimary(@"          MMMMMMMM               MMMMMMMM                    iiii                                       ");  
            font.SetTextToPrimary(@"          M:::::::M             M:::::::M                   i::::i                                      ");  
            font.SetTextToPrimary(@"          M::::::::M           M::::::::M                    iiii                                       ");  
            font.SetTextToPrimary(@"          M:::::::::M         M:::::::::M                                                               ");  
            font.SetTextToPrimary(@"          M::::::::::M       M::::::::::M  aaaaaaaaaaaaa   iiiiiii zzzzzzzzzzzzzzzzz    eeeeeeeeeeee    ");  
            font.SetTextToPrimary(@"          M:::::::::::M     M:::::::::::M  a::::::::::::a  i:::::i z:::::::::::::::z  ee::::::::::::ee  ");  
            font.SetTextToPrimary(@"          M:::::::M::::M   M::::M:::::::M  aaaaaaaaa:::::a  i::::i z::::::::::::::z  e::::::eeeee:::::ee");  
            font.SetTextToPrimary(@"          M::::::M M::::M M::::M M::::::M           a::::a  i::::i zzzzzzzz::::::z  e::::::e     e:::::e");  
            font.SetTextToPrimary(@"          M::::::M  M::::M::::M  M::::::M    aaaaaaa:::::a  i::::i       z::::::z   e:::::::eeeee::::::e");
            font.SetTextToPrimary(@"          M::::::M   M:::::::M   M::::::M  aa::::::::::::a  i::::i      z::::::z    e:::::::::::::::::e ");
            font.SetTextToPrimary(@"          M::::::M    M:::::M    M::::::M a::::aaaa::::::a  i::::i     z::::::z     e::::::eeeeeeeeeee  ");
            font.SetTextToPrimary(@"          M::::::M     MMMMM     M::::::Ma::::a    a:::::a  i::::i    z::::::z      e:::::::e           ");
            font.SetTextToPrimary(@"          M::::::M               M::::::Ma::::a    a:::::a i::::::i  z::::::zzzzzzzze::::::::e          ");
            font.SetTextToPrimary(@"          M::::::M               M::::::Ma:::::aaaa::::::a i::::::i z::::::::::::::z e::::::::eeeeeeee  ");
            font.SetTextToPrimary(@"          M::::::M               M::::::M a::::::::::aa:::ai::::::iz:::::::::::::::z  ee:::::::::::::e  ");
            font.SetVersionFontColor(@"          MMMMMMMM","       v0.1.0"," MMMMMMMM  aaaaaaaaaa  aaaaiiiiiiiizzzzzzzzzzzzzzzzz    eeeeeeeeeeeeee  ");
            font.SetTextToSecondary("= = = Analytics and Airdrops for your Crypto and Nfts = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine();
            font.SetBraggingFont($"Maize ", "has completed ", usersTransactionsAndNftsSent.Sum(x => x.transactionCount).ToString(), " transactions and sent ", usersTransactionsAndNftsSent.Sum(x => x.nftAmountSent).ToString(), " Nfts.");
            Console.WriteLine();
            font.SetTextToDarkGray("If you have any questions, check the Tips/FAQs in the menu or https://cobmin.io/posts/Maize");
            font.SetTextToDarkGray("Check out my nfts here, https://loopexchange.art/collection/maizeorigin");
            font.SetTextToDarkGray("and https://loopexchange.art/collection/maizecollaboration");
            Console.WriteLine();
        }
        public static MenuAndUtility MenuForMaize(Font font, int environment)
        {
            var allUtilities = new Dictionary<string, string>()
            {
                {"utilityZero", "General tips and FAQs"},
                {"utilityOne", "Create a Collection"},
                {"utilityTwo", "Mint Nfts"},
                {"utilityThree", "Find Nft Data for a single Nft"},
                {"utilityFour", "Find Nft Data from Nft Id"},
                {"utilityFive", "Find Nft Data from a Collection"},
                {"utilitySix", "Find Nft Data from a Wallet"},
                {"utilitySeven", "Find Holders from Nft Data"},
                {"utilityEight", "Find Holders from a minter"},
                {"utilityNine", "Find Holders who own all Nfts"},
                {"utilityTen", "Find Holders who own all Nfts w/min set amount"},
                {"utilityEleven", "Send to any users"},
                {"utilityTwelve", "Send to any users (include amounts)"},
                {"utilityThirteen", "Send unique NFTs to any users"},
                {"utilityFourteen", "Send Nfts to the Dead address"},
                {"utilityFifteen", "Send LRC to any users"},
                {"utilitySixteen", "Send LRC to any users with different amounts"},
                {"utilitySeventeen", "Pay Loopring activation fee for wallets"},
                {"utilityEighteen", "Nft Transfer Leaderboards"},
                {"utilityNineteen", "Minted Collection Analytics"},
                {"utilityTwenty", "Owned Collection Analytics"},
                {"utilityTwentyone", "Specific Collection Analytics"},
            };
            font.SetTextToPrimary(@"          ___");
            font.SetTextToPrimary(@"= = |\/| |___ |\ | |  | = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            font.SetTextToPrimary(@"= = |  | |___ | \| |__| = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine();
            font.SetTextToPrimary("      = Minting =");
            font.SetTextToWhite($"\t 1. {allUtilities.ElementAt(1).Value}");
            font.SetTextToWhite($"\t 2. {allUtilities.ElementAt(2).Value}");
            font.SetTextToPrimary("      = LOOKUPS =");
            font.SetTextToSecondary("        Nft Data                                Nft Holders");
            font.SetTextToWhite($"\t 3. {allUtilities.ElementAt(3).Value}\t 7. {allUtilities.ElementAt(7).Value}");
            font.SetTextToWhite($"\t 4. {allUtilities.ElementAt(4).Value}\t\t 8. {allUtilities.ElementAt(8).Value}");
            font.SetTextToWhite($"\t 5. {allUtilities.ElementAt(5).Value}\t 9. {allUtilities.ElementAt(9).Value}");
            font.SetTextToWhite($"\t 6. {allUtilities.ElementAt(6).Value}\t        10. {allUtilities.ElementAt(10).Value}");
            font.SetTextToPrimary("      = AIRDROPS =");
            font.SetTextToSecondary("        Nfts                                   Crypto");
            font.SetTextToWhite($"\t11. {allUtilities.ElementAt(11).Value}\t\t\t15. {allUtilities.ElementAt(15).Value}");
            font.SetTextToWhite($"\t12. {allUtilities.ElementAt(12).Value}\t16. {allUtilities.ElementAt(16).Value}");
            font.SetTextToWhite($"\t13. {allUtilities.ElementAt(13).Value}\t17. {allUtilities.ElementAt(17).Value}");
            font.SetTextToWhite($"\t14. {allUtilities.ElementAt(14).Value}");
            font.SetTextToPrimary("      = ANALYTICS =");
            font.SetTextToWhite($"\t18. {allUtilities.ElementAt(18).Value}");
            font.SetTextToWhite($"\t19. {allUtilities.ElementAt(19).Value}");
            font.SetTextToWhite($"\t20. {allUtilities.ElementAt(20).Value}");
            font.SetTextToWhite($"\t21. {allUtilities.ElementAt(21).Value}");
            font.SetTextToPrimary("      = Tips/FAQs =");
            font.SetTextToWhite($"\t 0. {allUtilities.ElementAt(0).Value}");
            Console.WriteLine();
            font.SetTextToTertiary("Which would you like to do?");
            var userResponseOnUtility = Utils.CheckUtilityNumber(allUtilities.Count() - 1, font);
            //var userResponseOnUtility = "16";
            Console.WriteLine();
            var menuAndUtility = new MenuAndUtility() { allUtilities = allUtilities , userResponseOnUtility = userResponseOnUtility };
            return menuAndUtility;

        }

        public static void FooterForMaize(Font font)
        {
            Console.WriteLine();
            font.SetTextToPurple("Thanks for using Cobmin's Maize.");
            font.SetTextToSecondary("Any feedback? You can find my contact information here, https://cobmin.io/.");
            font.SetTextToPurple("Check out my Nft collection at https://loopexchange.art/collection/maizeorigin.");
            font.SetTextToGray("Need help with your drop? Let him know.");
            Console.WriteLine(); 
            font.SetTextToDarkGray("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            font.SetTextToDarkGray("|P|o|w|e|r| |t|o| |t|h|e| |C|r|e|a|t|o|r|s|");
            font.SetTextToDarkGray("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
        }

        public static string EndOfMaizeFunctionality(Font font)
        {
            font.SetTextToTertiary("Start a new functionality?");
            var userResponseReadyToMoveOn = Utils.CheckYesOrNo(font);
            return userResponseReadyToMoveOn;
        }
        public static void UtilityHeader(Font font, string utilityTitle, string utilityDescription, string utilityNeeds, string? optionalInformation, bool transactionDisclaimer)
        {
            font.SetTextToPrimary($" - {utilityTitle} -");
            font.SetTextToSecondary(utilityDescription);
            font.SetTextToSecondary(utilityNeeds);
            if(optionalInformation != null)
                font.SetTextToSecondary(optionalInformation);
            if (transactionDisclaimer == true)
            {
                font.SetTextToPrimary($"Each batch mint will cost 0.000000000000000001 LRC.");
                font.SetTextToPrimary($"This will only occur if at least one mint was successful.");
            }
            Console.WriteLine();
            font.SetTextToPrimary("Let's get started.");
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
