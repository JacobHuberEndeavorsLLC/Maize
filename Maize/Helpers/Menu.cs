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
        public Dictionary<int, string> allUtilities { get; set; }
        public int userResponseOnUtility { get; set; }
    }
    public class Menu
    {
        public static void BannerForMaize(Font font)
        //public static void BannerForMaize(Font font, List<Leaderboard>? usersTransactionsAndNftsSent)
        {
            Console.Clear();
            font.ToSecondary("= = = Welcome to = = = = = = = = = = = = = = =");
            font.ToPrimary(@"M""""""""""`'""""""`YM          oo");  
            font.ToPrimary(@"M  mm.  mm.  M                               ");  
            font.ToPrimary(@"M  MMM  MMM  M .d8888b. dP d888888b .d8888b. ");  
            font.ToPrimary(@"M  MMM  MMM  M 88'  `88 88    .d8P' 88ooood8 ");  
            font.ToPrimary(@"M  MMM  MMM  M 88.  .88 88  .Y8P    88.  ... ");  
            font.ToPrimary(@"M  MMM  MMM  M `88888P8 dP d888888P `88888P' ");
            font.SetVersionFontColor(@"MMMMMMMMM", "1.0.1","");
            font.ToSecondary("= = = Cornveniently Manage your NFTs = = = = =");
            Console.WriteLine();
            font.ToPrimary($"Good luck out there anon.");
            //font.SetBraggingFont($"Maize ", "has completed ", usersTransactionsAndNftsSent.Sum(x => x.transactionCount).ToString(), " transactions and sent ", usersTransactionsAndNftsSent.Sum(x => x.nftAmountSent).ToString(), " Nfts.");
            Console.WriteLine();
            font.ToDarkGrayInline("If you have any questions, check the Tips/FAQs in the menu or ");
            font.ToDarkYellowInline("maize");
            font.ToDarkGreenInline("helps");
            font.ToDarkGray(".art");
            font.ToDarkGrayInline("View my NFTs: ");
            font.ToWhiteInline("Loop");
            font.ToDarkRedInline("Exchange");
            font.ToDarkGray(".art/collection/maizeorigin");
            font.ToDarkGrayInline("and ");
            font.ToWhiteInline("Loop");
            font.ToDarkRedInline("Exchange");
            font.ToDarkGray(".art/collection/maizecollaboration");
            Console.WriteLine();
        }
        public static MenuAndUtility MenuForMaize(Font font, int environment)
        {
            var allUtilities = new Dictionary<int, string>()
            {
                {0, "General tips and FAQs"},
                {1, "Find NFT Data from a Wallet"},
                {2, "Find NFT Data from a Collection"},
                {3, "Find Holders from NFT Data"},
                //{4, "Find Holders from a minter"},

                //{"utilityOne", "Create a Collection"},
                //{"utilityTwo", "Batch Mint NFTs"},
                //{"utilityThree", "Mint to Sent in an Instant"},
                //{"utilityFour", "Find NFT Data for a single NFT"},
                //{"utilityFive", "Find NFT Data from NFT Id"},
                //{"utilitySeven", "Find NFT Data from a Wallet"},

                //{"utilityTen", "Find Holders who own all NFTs"},
                //{"utilityEleven", "Find Holders who own all NFTs w/min set amount"},
                //{"utilityTwelve", "Send to any users"},
                //{"utilityThirteen", "Send to any users (include amounts)"},
                //{"utilityFourteen", "Send unique NFTs to any users"},
                //{"utilityFifteen", "Send NFTs to the Dead address"},
                //{"utilitySixteen", "Send LRC to any users"},
                //{"utilitySeventeen", "Send LRC to any users (include amounts)"},
                //{"utilityEighteen", "Pay Loopring activation fee for wallets"},
                //{"utilityNineteen", "NFT Transfer Leaderboards"},
                //{"utilityTwenty", "Minted Collection Analytics"},
                //{"utilityTwentyone", "Owned Collection Analytics"},
                //{"utilityTwentyTwo", "Specific Collection Analytics"}
            };
            //font.ToPrimary(@"            ___");
            font.ToPrimary(@"       _ _  _  _     ");
            font.ToPrimary(@"= = = | | |(/_| ||_| = = = = = =");
            Console.WriteLine();
            //font.ToPrimary("      = Minting =");
            //font.ToWhite($"\t 1. {allUtilities.ElementAt(1).Value}");
            //font.ToWhite($"\t 2. {allUtilities.ElementAt(2).Value}");
            //font.ToWhite($"\t 3. {allUtilities.ElementAt(3).Value}");
            //font.ToPrimary("      = LOOKUPS =");
            //font.ToSecondary("        NFT Data                                NFT Holders");
            //font.ToWhite($"\t 4. {allUtilities.ElementAt(4).Value}\t 8. {allUtilities.ElementAt(8).Value}");
            //font.ToWhite($"\t 5. {allUtilities.ElementAt(5).Value}\t\t 9. {allUtilities.ElementAt(9).Value}");
            //font.ToWhite($"\t 6. {allUtilities.ElementAt(6).Value}\t10. {allUtilities.ElementAt(10).Value}");
            //font.ToWhite($"\t 7. {allUtilities.ElementAt(7).Value}\t        11. {allUtilities.ElementAt(11).Value}");
            font.ToPrimary("      = LOOKUPS =");

            font.ToSecondary("        NFT Data                                NFT Holders");
            //font.ToWhite($"\t 2. {allUtilities.ElementAt(2).Value}\t 4. {allUtilities.ElementAt(4).Value}");

            //font.ToSecondary("        NFT Data");
            font.ToWhite($"\t 1. {allUtilities.ElementAt(1).Value}\t\t 3. {allUtilities.ElementAt(3).Value}");
            //font.ToWhite($"\t 1. {allUtilities.ElementAt(1).Value}");
            font.ToWhite($"\t 2. {allUtilities.ElementAt(2).Value}");


            //font.ToPrimary("      = AIRDROPS =");
            //font.ToSecondary("        NFTs                                   Crypto");
            //font.ToWhite($"\t12. {allUtilities.ElementAt(12).Value}\t\t\t16. {allUtilities.ElementAt(16).Value}");
            //font.ToWhite($"\t13. {allUtilities.ElementAt(13).Value}\t17. {allUtilities.ElementAt(17).Value}");
            //font.ToWhite($"\t14. {allUtilities.ElementAt(14).Value}\t18. {allUtilities.ElementAt(18).Value}");
            //font.ToWhite($"\t15. {allUtilities.ElementAt(15).Value}");
            //font.ToPrimary("      = ANALYTICS =");
            //font.ToWhite($"\t19. {allUtilities.ElementAt(19).Value}");
            //font.ToWhite($"\t20. {allUtilities.ElementAt(20).Value}");
            //font.ToWhite($"\t21. {allUtilities.ElementAt(21).Value}");
            //font.ToWhite($"\t22. {allUtilities.ElementAt(22).Value}");
            font.ToPrimary("      = Tips/FAQs =");
            font.ToWhite($"\t 0. {allUtilities.ElementAt(0).Value}");
            Console.WriteLine();
            //font.ToTertiary("Which would you like to do?");
            var userResponseOnUtility = ApplicationUtilities.CheckUtilityNumber(allUtilities.Count() - 1, font);
            Console.WriteLine();
            return new MenuAndUtility() { allUtilities = allUtilities, userResponseOnUtility = userResponseOnUtility };

        }

        public static void FooterForMaize(Font font)
        {
            Console.WriteLine();
            font.ToPrimary("Thanks for using Cobmin's Maize.");
            font.ToSecondary("Any feedback? You can find my contact information here, https://cobmin.com.");
            font.ToPrimary("Check out my NFT collection at https://loopexchange.art/collection/maizeorigin.");
            Console.WriteLine();
            font.ToDarkGray("Need help with your drop? Let me know.");
            Console.WriteLine(); 
            font.ToDarkGray("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            font.ToDarkGray("|P|o|w|e|r| |t|o| |t|h|e| |C|r|e|a|t|o|r|s|");
            font.ToDarkGray("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
        }

        public static string EndOfMaizeFunctionality(Font font)
        {
            var userResponseReadyToMoveOn = ApplicationUtilities.CheckYesOrNo(font, "Start a new functionality");
            return userResponseReadyToMoveOn;
        }
        public static void UtilityHeader(Font font, string utilityTitle, string utilityDescription, string utilityNeeds, string? optionalInformation, bool transactionDisclaimer)
        {
            font.ToPrimary($" - {utilityTitle} -");
            font.ToSecondary(utilityDescription);
            font.ToSecondary(utilityNeeds);
            if(!string.IsNullOrEmpty(optionalInformation))
                font.ToTertiary(optionalInformation);
            if (transactionDisclaimer == true)
            {
                font.ToPrimary($"Each batch mint will cost 0.000000000000000001 LRC.");
                font.ToPrimary($"This will only occur if at least one mint was successful.");
            }
            Console.WriteLine();
            font.ToPrimary("Let's get started.");
            Console.WriteLine();
        }
        public static void MaizeLogo(Font font)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&     @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@@@@@@@");font.ToYellowInline("          &&&");font.ToGreen("          @@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@@@@@@");font.ToYellowInline("   &&&&&  &");font.ToDarkYellowInline("///");font.ToYellowInline("&   &&&&");font.ToGreen("   @@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@@@@@");font.ToDarkYellowInline("   /////   /////.  /////");font.ToGreen("   @@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@@@@@"); font.ToDarkYellowInline("   ////     ,/      ////"); font.ToGreen("    @@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@@@@@                             @@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@@");font.ToYellowInline("    &&&&&    &&&&&&&    &&&&&");font.ToGreen("    @@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@");font.ToYellowInline("    &");font.ToDarkYellowInline("/////");font.ToYellowInline("&&  &");font.ToDarkYellowInline("///////");font.ToYellowInline("&  &&");font.ToDarkYellowInline("////");font.ToYellowInline("&&");font.ToGreen("    @@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@");font.ToDarkYellowInline("    ////////  /////////  ////////");font.ToGreen("    @@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@");font.ToDarkYellowInline("     //////    ///////    //////");font.ToGreen("     @@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@                                     @@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@");font.ToYellowInline("    &&&&&&      &&&&&&&      &&&&&&/");font.ToGreen("   @@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@");font.ToYellowInline("   &");font.ToDarkYellowInline("//////");font.ToYellowInline("&&   &");font.ToDarkYellowInline("/////////");font.ToYellowInline("&   &&");font.ToDarkYellowInline("//////");font.ToYellowInline("&");font.ToGreen("   @@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@");font.ToDarkYellowInline("    /////////   ///////////   //////////");font.ToGreen("   @@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@");font.ToDarkYellowInline("    //////      /////////      //////");font.ToGreen("    @@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@                                         @@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@");font.ToYellowInline("    &&&&&&&       &&&&&&&       &&&&&&&");font.ToGreen("    @@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@");font.ToYellowInline("   &");font.ToDarkYellowInline("////////");font.ToYellowInline("&   &&&");font.ToDarkYellowInline("//////");font.ToYellowInline("#&&&   &&");font.ToDarkYellowInline("///////");font.ToYellowInline("#");font.ToGreen("   @@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@");font.ToDarkYellowInline("   //////////   /////////////    /////////   ");font.ToGreen("%@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@");font.ToDarkYellowInline("                   ///////////                   ");font.ToGreen("@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@");font.ToDarkGreenInline("        ,***********               ,***********        ");font.ToGreen("@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@");font.ToDarkGreenInline("     **********************     ***********************     ");font.ToGreen("@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@");font.ToDarkGreenInline("    *******************************************************    ");font.ToGreen("@@@@@@@@");
            font.ToGreenInline(@"@@@@@@");font.ToDarkGreenInline("    *********************************************************    ");font.ToGreen("@@@@@@@");
            font.ToGreenInline(@"@@@@@@");font.ToDarkGreenInline("    ********************************************************");font.ToDarkGreenInline(",    ");font.ToGreen("@@@@@@@");
            font.ToGreenInline(@"@@@@@@");font.ToDarkGreenInline("    ********************************************************");font.ToDarkGreenInline(",    ");font.ToGreen("@@@@@@@");
            font.ToGreenInline(@"@@@@@@");font.ToDarkGreenInline("    *******.             *************             ********");font.ToDarkGreenInline(",,    ");font.ToGreen("@@@@@@@");
            font.ToGreenInline(@"@@@@@@");font.ToDarkGreenInline("     *                ****************************        ");font.ToDarkGreenInline(",,    ");font.ToGreen("@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@");font.ToDarkGreenInline("                 **********************************");font.ToDarkGreenInline(",          ");font.ToGreen("@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@");font.ToDarkGreenInline("         ************************************");font.ToDarkGreenInline(",,    ");font.ToGreen("@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@");font.ToDarkGreenInline("      *************************************");font.ToDarkGreenInline(",,,    ");font.ToGreen("@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@");font.ToDarkGreenInline("     *************************************");font.ToDarkGreenInline(",,,    ");font.ToGreen("@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@");font.ToDarkGreenInline("    ***********************************");font.ToDarkGreenInline(",,,,    ");font.ToGreen("@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@");font.ToDarkGreenInline("     *******************************");font.ToDarkGreenInline(",,,,     ");font.ToGreen("@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@");font.ToDarkGreenInline("      ************************");font.ToDarkGreenInline(",,,,,,     ");font.ToGreen("@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@");font.ToDarkGreenInline("        ,,,,,,");font.ToDarkGreenInline("*****");font.ToDarkGreenInline(",,,,,,,,,");font.ToGreen("        @@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@@@@@                             @@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@@@@@@"); font.ToDarkYellowInline("              ///////");font.ToGreen("    @@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@@@@@@");font.ToDarkYellowInline("         ////////////");font.ToGreen("   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreenInline(@"@@@@@@@@@@@@@@@@@@@@@@@@@@");font.ToDarkYellowInline("       ////////////");font.ToGreen("    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@@@@@@@@@@                   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@      @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            font.ToGreen(@"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.SetCursorPosition(0, 0);

        }
    }
}
