using System.Collections.Generic;
using System.Security.Cryptography;

namespace LoopringSharp
{
    public static class Constants
    {
        public static Dictionary<string, int> TokenIDMapper = new Dictionary<string, int>();        

        public static string OffchainFeeUrl = "api/v3/user/offchainFee";
        public static string CreateInfoUrl = "api/v3/user/createInfo";
        public static string UpdateInfoUrl = "api/v3/user/updateInfo";
        public static string BalancesUrl = "api/v3/user/balances";
        public static string DepositsUrl = "/api/v3/user/deposits";
        public static string WithdrawlsUrl = "/api/v3/user/withdrawals";
        public static string TransfersUrl = "/api/v3/user/transfers";
        public static string TradeHistoryUrl = "api/v3/user/trades";
        public static string OrderFeeUrl = "api/v3/user/orderFee";
        public static string OrderUserRateAmountUrl = "api/v3/user/orderUserRateAmount";
        public static string StorageIdUrl = "api/v3/storageId";
        public static string TickerUrl = "api/v3/ticker";
        public static string TimestampUrl = "api/v3/timestamp";
        public static string TransferUrl = "api/v3/transfer";
        public static string ApiKeyUrl = "api/v3/apiKey";
        
        public static string OrderUrl = "api/v3/order";
        public static string OrdersUrl = "api/v3/orders";
        public static string AccountUrl = "api/v3/account";
        public static string MarketsUrl = "api/v3/exchange/markets";
        public static string TokensUrl = "api/v3/exchange/tokens";
        public static string InfoUrl = "api/v3/exchange/info";
        public static string DepthUrl = "api/v3/depth";
        public static string DepthMixUrl = "api/v3/mix/depth";
        public static string CandlestickUrl = "api/v3/candlestick";
        public static string PriceUrl = "api/v3/price";
        public static string TradeUrl = "api/v3/trade";

        public static string L2BlockInfoUrl = "api/v3/block/getBlock";
        public static string PendingRequestsUrl = "api/v3/block/getPendingRequests";

        public static string AmmPoolTradesUrl = "api/v3/amm/trades";
        public static string AmmJoinExitTransactionsUrl = "/api/v3/amm/user/transactions";
        public static string AmmPoolConfigurationUrl = "api/v3/amm/pools";
        public static string AmmPoolBalanceUrl = "api/v3/amm/balance";

        public static string EIP721DomainName = "Loopring Protocol";
        public static string EIP721DomainVersion = "3.6.0";

        public static string HttpHeaderAPIKeyName = "X-API-KEY";
        public static string HttpHeaderAPISigName = "X-API-SIG";

       

        public static string WalletConnectHTML = @"<!DOCTYPE html>
            <html>
            <head>
            <title>WalletConnect Details</title>            
            </head>

            <body>   
            <h1>For wallet connect, scan this CR code or paste the bellow code into your wallet</h1>
            <img src=""|----|""/></br>
            <p>|--|--|</p>
            </body>

            </html>";
    }
}
