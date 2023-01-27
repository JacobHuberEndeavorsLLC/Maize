# Maize
![](https://user-images.githubusercontent.com/97369738/205774544-2b875df8-fa70-4a44-8184-50bd55af25d7.png)

## Analytics and Airdrops for your Crypto and Nfts on Loopring

In order to use Maize, you will need to own a 'Maize Origin Logo'. One can be purchased at https://loopexchange.art/collection/maizeorigin.

<img src="https://user-images.githubusercontent.com/97369738/206356200-491b3771-61f2-41c8-af85-3f2c308f0aaa.png" width="100" height="100" />

You do not need 'Maize Origin Logo' to use Maize on the testnet goerli.

## Current Functionality 
![image](https://user-images.githubusercontent.com/97369738/215150788-2a28058d-1b45-486d-83d7-4c6857bf23ab.png)

## Setup

Download one of the compiled releases in the [Releases](https://github.com/cobmin/maize/releases) section and unzip it into a location of your choice. You will need to edit the included appsettings.json file with your own wallet details. 

Here is a video going over the setup: https://youtu.be/00TY9aHTUuE.

This application uses a ***MetaMask/GameStop*** private key to sign the transfers. You will need to export that out from your metamask/gamestop Wallet. You can export the Loopring related account details from the "Security" tab while logged into https://loopring.io. Make sure these details are from the same Wallet. *Note* that you cannot perform transfers with a Loopring wallet

macOS users: You also need to run the following command in the unzipped folder of LoopDropSharp to turn it into an executable to run it. You may also need to add it as a trusted application if it gets blocked from running (Settings > Security & Privacy).

```
chmod +x Maize
```
DO NOT SHARE ANY API OR PRIVATE KEYS with anyone else!!!!!!! 

You will need to change the both the main and test appsettings.json" file in the project directory with the necessary information. The video above covers this. 

```json
{ // this is the mainnet setup
    "Settings": {
      "LoopringApiKey": "asdfasdfasdfasdfasdfasdf", //Your loopring api key.  DO NOT SHARE THIS AT ALL. FLOWERS INFORMATION
      "LoopringPrivateKey": "0xasdfasdfasdfasdfasdfasdf", //Your loopring private key.  DO NOT SHARE THIS AT ALL.
      "MMorGMEPrivateKey": "asdfasdfasdfasdfasdfasdf", //Private key from metamask. DO NOT SHARE THIS AT ALL.: null,
      "LoopringAddress": "0xasdfasdfasdfasdf", //Your loopring address
      "LoopringAccountId": 1234, //Your loopring account id
      "ValidUntil": 1700000000, //How long this transfer should be valid for. Shouldn't have to change this value
      "Environment": 1 // 1 = mainnet or 5 = Goerli
}
}

{ // this is the goerli setup (note that these values may differ from mainnet)
  "Settings": {
    "LoopringApiKey": "asdfasdfasdfasdfasdfasdf", //Your loopring api key.  DO NOT SHARE THIS AT ALL. FLOWERS INFORMATION
    "LoopringPrivateKey": "0xasdfasdfasdfasdfasdfasdf", //Your loopring private key.  DO NOT SHARE THIS AT ALL.
    "MMorGMEPrivateKey": "asdfasdfasdfasdfasdfasdf", //Private key from metamask. DO NOT SHARE THIS AT ALL.: null,
    "LoopringAddress": "0xasdfasdfasdfasdf", //Your loopring address
    "LoopringAccountId": 1234, //Your loopring account id
    "ValidUntil": 1700000000, //How long this transfer should be valid for. Shouldn't have to change this value
    "Environment": 5 // 1 = mainnet or 5 = Goerli
  }
}
```
After setting up the appsettings.json, launch Maize and get started.

### Only LRC can be used with Maize

## Input.txt setup

### 2. Find Nft Datas from Nft Ids.
In the Input.txt located in the project directory add Nft Ids. You will have one Nft Id per line.

### 5. Find Nft Holders from Nft Data.
In the Input.txt located in the project directory add an Nft Data. You will have one Nft Data per line.

### 7. Find Nft Holders who own all Nfts
In the Input.txt located in the project directory add an Nft Data. You will have one Nft Data per line.

### 8. Find Holders who own specific Nfts with a minimum set amount
In the Input.txt located in the project directory add an Nft Data. You will have one Nft Data per line.

### 9. Airdrop the same NFT to any users.
In the Input.txt located in the project directory add a wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.

### 10. Airdrop the same NFT to any users with different amounts.
In the Input.txt located in the project directory add a wallet address a comma and then the amount you want to send (example: 0x4a71e0267207cec67c78df8857d81c508d43b00d,2). You will have one wallet address and one amount per line. Each wallet address will be one transfer. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.

### 11. Airdrop unique NFTs to any users
In the Input.txt located in the project directory add a wallet address a comma and then the nft data (example: 0x4a71e0267207cec67c78df8857d81c508d43b00d,0x103cb20d3b310873f711d25758d57f18ba77a6b7842ae605d662e0ddd908ed5a). You will have one wallet address and nft data per line. Each wallet address will be one transfer. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.

### 13. Airdrop LRC/ETH to any users.
In the Input.txt located in the project directory add a wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer of LRC/ETH. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.

### 14. Airdrop LRC/ETH to any users with different amounts
In the Input.txt located in the project directory add a wallet address a comma and then the amount of LRC/ETH to send (example: 0x4a71e0267207cec67c78df8857d81c508d43b00d,50.25). You will have one wallet address and one amount per line. Each wallet address will be one transfer. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.

### 15. Pay Loopring activation fee for wallets
In the Input.txt located in the project directory add a wallet addresses. You will have one wallet address per line. Each wallet address will be one transfer of LRC/ETH. Be sure to have enough LRC/ETH for each transfer. You can add a long wallet address or the ENS.

## Banish.txt setup
In the Banish.txt located in the project directory add wallet addresses that you do not want to send to. If you have a wallet address that you never want to airdrop an Nft to or send crypto to then you can place them on this list. The application checks this list before sending Nfts or crypto. You can add a long wallet address or the ENS.

### 12. Send all Nfts owned by banished addresses to the dead address
In the Banish.txt located in the project directory add the minter wallet address whose Nfts you want to remove from your wallet. You will have one wallet address per line and you can add a long wallet address or the ENS.

### Predecessor
Maize is the successor to LoopDropSharp, https://github.com/cobmin/LoopDropSharp. 

If you have used LDS then you will love Maize. It has all the same functionality and more. Improved error handling, faster performance, intuitive interface, and yes, all data is logged to a csv file to use in notepad or excel.
