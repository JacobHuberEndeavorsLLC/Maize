using Maize.Models;
using Nethereum.RLP;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Helpers
{
    public class Leaderboards
    {
        public static void DisplayLeaderboardBanner(Font font)
        {
            font.SetTextToPrimary(@".     ___  __  ___   ___  ___  __   __   __   ___ ___   __ ");
            font.SetTextToPrimary(@"|    |___ |__| |  \ |___ |__/ |__] |  | |__| |__/ |  \ [__  ");
            font.SetTextToPrimary(@"|___ |___ |  | |__/ |___ |  \ |__] |__| |  | |  \ |__/ ___] ");
            Console.WriteLine();
        }
        public static List<Leaderboard> GetLeaderBoardContestants(List<Transaction> nftTransfers)
        {
            var leaderBoardContestants = new List<Leaderboard>();
            foreach (var item in nftTransfers.DistinctBy(x => x.senderAddress))
            {
                var itemAll = nftTransfers.Where(x => x.senderAddress == item.senderAddress).ToList();
                // issues with the first two transactions. removing them and manually adding them
                if (itemAll.Where(x => x.amount == "79681000000000000").Count() > 0)
                {
                    var itemToRemove = itemAll.Single(r => r.amount == "79681000000000000");
                    if (itemToRemove != null)
                        itemAll.Remove(itemToRemove);

                    itemToRemove = itemAll.Single(r => r.amount == "79051000000000000");
                    if (itemToRemove != null)
                        itemAll.Remove(itemToRemove);

                    leaderBoardContestants.Add(new Leaderboard
                    {
                        owner = item.senderAddress,
                        transactionCount = (itemAll.Sum(x => Convert.ToInt32(x.amount)) + 20),
                        nftAmountSent = (itemAll.Sum(x => Convert.ToInt32(x.memo.Remove(0, 9))) + 20)
                    });
                }
                else
                {
                    leaderBoardContestants.Add(new Leaderboard
                    {
                        owner = item.senderAddress,
                        transactionCount = itemAll.Sum(x => Convert.ToInt32(x.amount)),
                        nftAmountSent = itemAll.Sum(x => Convert.ToInt32(x.memo.Remove(0, 9)))
                    });
                }
            }
            return leaderBoardContestants;
        }

        public static void DisplayContestants(Font font, List<Leaderboard> leaderBoardContestants, IEnumerable<Leaderboard> userInformation, string fromAddress, string leaderboardHeader)
        {
            font.SetTextToPrimary(String.Format($" - {leaderboardHeader} - "));
            font.SetTextToTertiary($"{leaderBoardContestants.Count()} wallets counted with {leaderBoardContestants.Sum(x=>x.transactionCount)} transactions and {leaderBoardContestants.Sum(x => x.nftAmountSent)} Nfts sent.");
            font.SetTextToPrimary(String.Format("|{0,42}|{1,12}|{2,10}|", "User", "Transactions", "Nfts Sent"));
            var counter = 0;
            foreach (var item in leaderBoardContestants.OrderByDescending(x => x.transactionCount).Take(10))
            {
                if (++counter <= 3 && leaderboardHeader != "Last 7 Days (Top 10)")
                {
                    font.SetTextToTertiary(String.Format("|{0,42}|{1,12}|{2,10}|", item.owner, item.transactionCount, item.nftAmountSent));
                }
                else
                {
                    font.SetTextToWhite(String.Format("|{0,42}|{1,12}|{2,10}|", item.owner, item.transactionCount, item.nftAmountSent));
                }
            }
            if (userInformation.Count() > 0 && leaderBoardContestants.OrderByDescending(x => x.transactionCount).Take(10).ToList().Where(x => x.owner.ToLower() == fromAddress.ToLower()).Count() == 0)
            {
                font.SetTextToPrimary("Your Score: ");
                font.SetTextToWhite(String.Format("|{0,42}|{1,12}|{2,10}|", userInformation.First().owner, userInformation.First().transactionCount, userInformation.First().nftAmountSent));
            }
            Console.WriteLine();
            //foreach (var item in leaderBoardContestants)
            //{
            //    Console.WriteLine(item.owner);
            //}
        }
    }
}
