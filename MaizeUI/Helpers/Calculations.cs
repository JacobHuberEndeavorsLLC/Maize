using Maize;
using Maize.Models;
using Maize.Models.ApplicationSpecific;
using Nethereum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaizeUI.Helpers
{
    public class Calculations
    {
        public static async Task<decimal> CalculateMaizeFee(ILoopringService LoopringService, decimal totalTransactions, string MaizeFeeSelectedOption)
        {
            return Math.Round((await CurrentTokenPriceInUsd(LoopringService, MaizeFeeSelectedOption)) * (totalTransactions * Constants.LcrTransactionFee), 14);
        }
        public static async Task<decimal> CurrentTokenPriceInUsd(ILoopringService LoopringService, string maizeFee)
        {
            var varHexAddress = await LoopringService.GetTokens();
            var currentFeePrice = (await LoopringService.GetTokenPrice()).data.Where(x => x.token == varHexAddress.FirstOrDefault(x => x.symbol == maizeFee).address).FirstOrDefault().price;
            var convertToOneUsd = 1 / decimal.Parse(currentFeePrice);

            return convertToOneUsd;
        }
        public static async Task<(bool, decimal userEth, decimal userLrc, decimal userPepe)> CanUserAfford(ILoopringService LoopringService, Settings settings, 
            string MaizeFeeSelectedOption, string LoopringFeeSelectedOption, decimal maizeFee, decimal loopringFee)
        {

            var userAssets = await LoopringService.GetUserAssetsForFees(settings.LoopringApiKey, settings.LoopringAccountId);
            var eth = userAssets.FirstOrDefault(asset => asset.tokenId == 0);
            var lrc = userAssets.FirstOrDefault(asset => asset.tokenId == 1);
            var pepe = userAssets.FirstOrDefault(asset => asset.tokenId == 272);
            decimal userLrc = 0;
            decimal userEth = 0;
            decimal userPepe = 0;
            if (lrc != null)
                userLrc = decimal.Parse(lrc.total) / 1000000000000000000;
            if (eth != null)
                userEth = decimal.Parse(eth.total) / 1000000000000000000;
            if (pepe != null)
                userPepe = decimal.Parse(pepe.total) / 1000000000000000000;

            var canAfford = true;
            switch (MaizeFeeSelectedOption)
            {
                case "ETH":
                    if (LoopringFeeSelectedOption == "ETH")
                    {
                        if (userEth < (loopringFee + maizeFee))
                        {
                            canAfford = false;
                            return (canAfford, userEth, userLrc, userPepe);
                        }
                    }
                    else
                    {
                        if ((userEth < maizeFee) || loopringFee > userLrc)
                        {
                            canAfford = false;
                            return (canAfford, userEth, userLrc, userPepe);
                        }
                    }
                    break;

                case "LRC":
                    if (LoopringFeeSelectedOption == "LRC")
                    {
                        if (userLrc < (loopringFee + maizeFee))
                        {
                            canAfford = false;
                            return (canAfford, userEth, userLrc, userPepe);
                        }
                    }
                    else
                    {
                        if (userLrc < maizeFee || loopringFee > userEth)
                        {
                            canAfford = false;
                            return (canAfford, userEth, userLrc, userPepe);
                        }
                    }
                    break;

                case "PEPE":
                    if (LoopringFeeSelectedOption == "ETH")
                    {
                        if (userPepe < maizeFee || loopringFee > userEth)
                        {
                            canAfford = false;
                            return (canAfford, userEth, userLrc, userPepe);
                        }
                    }
                    else
                    {
                        if (userPepe < maizeFee || loopringFee > userLrc)
                        {
                            canAfford = false;
                            return (canAfford, userEth, userLrc, userPepe);
                        }
                    }
                    break;

            
            }
            return (canAfford, userEth, userLrc, userPepe);
        }
    }
}
