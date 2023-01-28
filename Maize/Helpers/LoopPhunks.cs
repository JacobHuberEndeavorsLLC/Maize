using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maize.Helpers
{
    public class LoopPhunksInformation
    {
        public string nftName { get; set; }
        public string nftId { get; set; }
        public string nftData { get; set; }
        public string nftImage { get; set; }

    }
    public class LoopPhunksHolderAndAmount
    {
        public string owner { get; set; }
        public int amount { get; set; }

    }
    public class LoopPhunksHolderAmountAndPercentage
    {
        public string owner { get; set; }
        public int amount { get; set; }
        public decimal percentageOwned { get; set; }

    }
    public class LoopPhunksOwnerDistribution
    {
        public int amount1 { get; set; }
        public int amount2To5 { get; set; }
        public int amount6To10 { get; set; }
        public int amount11To19 { get; set; }
        public int amount20Plus { get; set; }

    }
    public class LoopPhunksHolderInformation
    {
        public LoopPhunksHolderAndAmount loopPhunksHolderAndAmount { get; set; }
        public LoopPhunksInformation loopPhunksInformation { get; set; }

    }
    public class LoopPhunks
    {
        public static List<LoopPhunksInformation> GetLoopPhunksInformation()
        {
            List<LoopPhunksInformation> loopPhunksInformation = new List<LoopPhunksInformation>();
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x25a16a752b2c73e1575d79a91615be93f2152b722f25f0696785eb9d718f7c7a", nftId = "0x4addcecbc169c95754e50037ec18607865a2921814b18a6d1efa4e8a46ada924", nftName = "LoopPhunks #741", nftImage = "ipfs://QmbCXNGW7yYXCatEp4S59BUDpisJUhLtdahrzRTV9L4mAF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x08be2bdf632d3d835e65f66c9e9c51800ec75e399044fb8067017e0c8b670763", nftId = "0x875cb581c62ed5dad56fffad421f3b554bca8437316b703ce48d038b6cd2a4b8", nftName = "LoopPhunks #740", nftImage = "ipfs://QmXpAcBTG5LkMB8U5Aed9BqvwJj8iX3HvJvN9dVm4BEiNn" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x280901b5b0d59315c210ff0e201835c05ef3d5ae3149c6ff992d892856b18b8d", nftId = "0x75060c4bb2b134522b73e21fe9c59a0fb1e2c4311fce4ba228271c302b043fbc", nftName = "LoopPhunks #739", nftImage = "ipfs://Qmd8K8N3k92aZrLJSLeRus7NYbPnwkLS4rnr48vW24rY19" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0bf611c3abadc71a430590e021f6a647e5c252ce01718c5d7421d28b1ca2d772", nftId = "0x64d93bad2fb954d5657b3e58e348f5c7c508aeb3c26cc7b9b170b54c24e4a8d9", nftName = "LoopPhunks #738", nftImage = "ipfs://QmYcqwu3JRVin3N1dxGn95v2qgT31yCBevBghSsAoVpxQ6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x176e26a7dbc7aa4c6d4fc082072010d4e9ad8975f9b1f070122b16e76547697f", nftId = "0xf3b4c985e4cf9c988513bd4401d702ec3d5f53e8f73c18f1b2a32dcb833b8e6c", nftName = "LoopPhunks #737", nftImage = "ipfs://QmTDCdsMAjakpFobnZSLPPpSxayLLpDqh9pcGjGfrvyZYu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0fb73fcc7733edc12052345f5c59f6b10f91526496eab69f4dcb09fce0eba399", nftId = "0x47d0658fcf2c4a1891380c51699a49a0ca597dcc38868dfe49186ad3599fdcaf", nftName = "LoopPhunks #736", nftImage = "ipfs://Qme2LEJ2SEWEVPij5QJ4ejz9nfNtAWH98baU2QMpmtfrnS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1517bd585039907f638c33056138ded6e07990e31395cb093642f69cb1d4a8bb", nftId = "0x7d5804ee5324ca45cff3cb01828303aacd7f6563c6f08d115b20407a79378519", nftName = "LoopPhunks #735", nftImage = "ipfs://QmRxzhP9Z9B3rgntCfW7yXegagPzKvt1DFwdFuZJJ3DLhw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24eb957e1de07f1620693488715c2c45693df7c95a0f79d1dc23fc1840256882", nftId = "0x42cf73a5aa929c021ce4b07790c935474c850289c8a12819c698915e6649d8d1", nftName = "LoopPhunks #734", nftImage = "ipfs://QmZAre35sQfohnRh5FumoLADaibj2Eq6vrdkz3sZNiCC5r" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x021c4e7fa1572d445e0955fc8753f0d008c2d3a2193f0aae34c43c40d02d8746", nftId = "0x0a46d2261404d77a51ca7a6feaa5a28660dc529452afc6ccb579d5c9b6fce71d", nftName = "LoopPhunks #733", nftImage = "ipfs://QmSgT3yVVW4eRDS8AZ7hnA75h2aJkRgcLn9G6vgV5y2jHJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ee9ae7685b74612876bd27ff52a9e8df696ca4f0201a93fe6a5ce4e6a17c773", nftId = "0x3564f85aa082397a45cfdfdeed2c48294922985ec4e1d227e9ceceb37ae6c838", nftName = "LoopPhunks #732", nftImage = "ipfs://Qma64MBjkQAGhct3rZLrknjYri3HKbBRgDwYHL6bvxFpyp" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x17570a26fa760699c6d812354702b014f490bcc0c25d8daff2c15cabd73ecf47", nftId = "0x744d15373a574d93ecf54cd3a6866b3df4992c00252f62900b4ac3e6a92f1743", nftName = "LoopPhunks #731", nftImage = "ipfs://QmSNrUr9rjTp2sKpw5cAcz1RCDXmSrUmo8SfHKWFKmptyA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0378e387f2e38f64f523c8dfbbd73128296bdd41ada477fc2b508cdddddd38f3", nftId = "0x5e11407eeb3b45938b6862626eb47c0bfa8bd3995d2e739f80d46f1321e598ec", nftName = "LoopPhunks #730", nftImage = "ipfs://QmbMMLm5fgtjQysJQDjY6Tzpsrv6pT6DqsWFMzF5Aaik7K" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24d69cf0de3909f91f5c73bd10e0b7417e8595e3da574e842268334a787a61b7", nftId = "0x7c23061e89e00425fe8603f1b4e92685e7a96c8494822aede79d465665c52612", nftName = "LoopPhunks #729", nftImage = "ipfs://QmPLVzu944wRN7g3xt4STS3htJkFWDFVVbrMQPukqJ4wRc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2391283c0a0acbb06fb9e333a5e052a19f747cbaecf14ea8ba34ed98cdac1609", nftId = "0x2f615691c2e5915861ac255c64d3b741ef1c20261b42c4de1bb2ac988bcd5bf1", nftName = "LoopPhunks #728", nftImage = "ipfs://QmUPAXPW3VMGqjY5Afk6ihrwkZrWHTTCnbNP43EchFdndL" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x20f978648d3c119ebd8406d6fdb6cc45a50a4e36c43cad175aa8b0c94b4807e3", nftId = "0xeea3aef8e889c4bd2bb998eb052ffa81c4ccf1f814df8a5f695bc6fc593f776a", nftName = "LoopPhunks #727", nftImage = "ipfs://QmXUW9oNMhB1CsSvzrbvN75fYFbVBucGTGJCDiXp9zyoHx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c5cbb1625ceee3435950a62bf5c0e04736704828f8afa456a99a5e881cbef7e", nftId = "0x55f9a4a421ac30b4d8605df34dafd0128bd6ae2f2190ff2fc8f36f352404bd69", nftName = "LoopPhunks #726", nftImage = "ipfs://QmWD8XzvdMztHkCDc5GRd6AeUavzBejFykPjprYjXZJF74" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a6355298061d9ffc02ac4bb7bf396fcbb9f3576a707df92a1ad91a3127d97d5", nftId = "0x73dd2d84a57a184875484aac45c9f3953f24a66d75999c9c6335fc3fc2beec35", nftName = "LoopPhunks #725", nftImage = "ipfs://Qmb3oKvKsMezMNdpr8GSi6fRbCfZSmaTrfzLfEKyppmxh6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0bd18e506a2207f72e78da74be39976a2568a076173620f26ca903c664f7029a", nftId = "0xd170e98ba7921c4719181509717503304a84e68b0e0413ebd3d550b05274db25", nftName = "LoopPhunks #724", nftImage = "ipfs://QmSD9sA8JYAxd2bMuD253QKhKx44kG6tLk7GcsnY9azQ5m" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0081e3a5cb009af5f08d6f8109d6369f84c9504f163805dbd92ae2089ff20c39", nftId = "0x62e0ce95f4c9fd28fecf790c454755a6b4c0a030fa97e4cef1a5367b113436ef", nftName = "LoopPhunks #723", nftImage = "ipfs://QmWtrZddQc4r6yoWNVqBMXJpowKVxG1MsCGtqrSoEouteS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18a19a5244a40a83c27ae75e236a4dedeae00e896168ebc1538cc944a13143e6", nftId = "0x50d375a7e5936b32692e838601074069fa5e52f264a66d35cbd6ec8432a25d2a", nftName = "LoopPhunks #722", nftImage = "ipfs://QmYv6EWJ8dZo4km68CWrHF7GNkr7jAYvodArmm9ybkM2Mo" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x12224c65f8813d2d80bddb351ab0099f1c29268068c1330b48a1861aee9372de", nftId = "0x82e9a2df35f09307832555a3d5bae1c35489d079f94255efccdb0934185acd74", nftName = "LoopPhunks #721", nftImage = "ipfs://QmfM2bHPwHDSU38qgn1KkwqQN2cByY3bv4dp9uxo5qKgnp" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29bda07a8f98f34dc420ad985b52550daa35a729468ce0453df4a4f50446d046", nftId = "0x63939ef4831ead29f46a107da8f0c7240b03485a57a44651655e993ed211ba9a", nftName = "LoopPhunks #720", nftImage = "ipfs://QmVzGbVEvAwbACp7mKaXybSCABjX5TjQxeVsKqEEgpExAR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0bd891bc325fd578b240a21aac39022471b7973f287eeae7c6f34e16ee31f741", nftId = "0x33fd45607aff6ef135e3ad8f900f8507b47876db615ac23b3333a22d9582268f", nftName = "LoopPhunks #719", nftImage = "ipfs://QmatRG4ikcLFA1HhKcmtVsajdmPutCQbu1PMtqq7L32rwg" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b5d21d2b31449bf44636e1716b19c19f6d3c848065da94319daf354f5dc1d6c", nftId = "0x649de9f80e12ddfe1a721b619c048e7b703b0793e726f3b2519edf5a289457e4", nftName = "LoopPhunks #718", nftImage = "ipfs://QmQuVz8sdCPyFXyzPXugmKVee2baXfinnTa24tD83gB8tP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x232a0506c39bdef7a3821fab89a083c66553e2c987cd90869b3fefaa48f42129", nftId = "0x10c370af703b88c23ca4f9303f63e50db14b284f0a16fd2a1d1d30f551bb41bb", nftName = "LoopPhunks #717", nftImage = "ipfs://Qmb5W5EPU6CdiA3n3cTh5u7LhBPapDXn93DCfqchxVdRa2" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2826f305f4fc123803b6d4e073445d620e99bbfd1dc294730cdef3e5fd0e4bbb", nftId = "0x376998574bd278c2261de45fbf00d23efcff15dd4ae86f5f9cc9192fd23cd1c0", nftName = "LoopPhunks #716", nftImage = "ipfs://QmUbfaujC4wp2HTeMjQbheDfnq6vX6JXJJXauiU7drk9qY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a673b5fda3ae73bc05e09babcf845628c0585ac03f48b6ad0003be707151072", nftId = "0xc46cb1239267389b53519e1fd1eb8d9da7662fa35f9303c45ec39bf3a2a18d69", nftName = "LoopPhunks #715", nftImage = "ipfs://QmWQxViAxawMF9rZnb7agDARXvN5DjZAwHFYUgYbZ1BXfg" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1488be5714760f667ba9fabaf2cef4d9564149b864d235f9531cf611043b85d6", nftId = "0x43108ede1179cc36e50cc44419092899bf1799477d460a7e3d20b55512e37823", nftName = "LoopPhunks #714", nftImage = "ipfs://QmP5317baHhGpHAHFABWZVTu1PBd7rWzFLLsEjeuNaazXS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e1a22d1769b8cb89c3f6a064652cf0de0aa6abf7e7177efb3027e659da1d06c", nftId = "0x21716f6e3ac2cf885d56097a112e13b21c024ce31f14a5e8ffc82e10bbbefcfd", nftName = "LoopPhunks #713", nftImage = "ipfs://QmNZXATnQD4xHSHYLBE3gSoY1YQUGNXNozS4MbH8LhuCSy" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1373569bb449119d9c6d41ec517c7cf775bd951ab1a9e0c157f88d2e34408cdf", nftId = "0xc96f7b76ba19c60c9371996170fff96be8750324736e8091df55727dacea1724", nftName = "LoopPhunks #712", nftImage = "ipfs://QmTvrq5ZhopZjDuo3uDxTkqTFtA5KTN9fxs225T5puKMcm" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x244437946c05aae2ef994772a79027f801e18f486b2ea9f933c4c3eecf333654", nftId = "0xab26e4f4f0a3c1c0d9caa76cb31776f4a365ca3135fc3985a613d2fca22efe99", nftName = "LoopPhunks #711", nftImage = "ipfs://QmSEwDnsrUDYuhkW2o7TKESZZwE8TDsCkJvtYNtorq6ACN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x276cead73a339905915a725c5bfb8ba92c582d877949ee61b1270c631c4c8282", nftId = "0x32c828e092d9ace74d52fc832f0a243848e443aeb4c7a076bb38ee5f6e6306c1", nftName = "LoopPhunks #710", nftImage = "ipfs://QmaYngad7fEAnKMDxhUf2nX7JSKKxGqAoDkE5MvL12XrMs" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1250a848f0c8724ce909bf9eb1bac6bfcf34547fdf2126c30834901ac458de83", nftId = "0xcf2dee686cc8488b501688e233e331c1df3df44b17b1eed63d92c92872bdb068", nftName = "LoopPhunks #709", nftImage = "ipfs://QmZhybqoPZzwenKFvMRLZQfZcnCTk2pethByPvvSrwixxm" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f04eb719310b177d3b39c0fb23458d4fe3d083011ddf4d218ec7e30791a7d2a", nftId = "0x1954e2d9ba6abe6779920371892e356c6a57ba2b38d636cf83396f503245951f", nftName = "LoopPhunks #708", nftImage = "ipfs://QmW2rvfeqNGuidBpNUXKnnMjHEtkpgFjVtsZwj7xYqFdci" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0e57e97b57a2b7510659ea1f5a2030c4050d5f5db20009850a757f97d557cc1c", nftId = "0x8deffa1de4437f3830ff1b03036d66dfc94628f6a7b3a9914471ea9aceccb798", nftName = "LoopPhunks #707", nftImage = "ipfs://QmVr15acC3aDpCg846BqGdcacbGcSzk28gEPXgrVkiFcGx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07d8d7dbdccc95bf57ce4ada9783d4405c342aa2e0352091b7c9eb08a6e0b7c9", nftId = "0xd681935d6e6cfac7668b68be9440736786b770fe9628f8f6768add00360fbdf3", nftName = "LoopPhunks #706", nftImage = "ipfs://QmU1F8P9BNvTyiEsrzX47UFsGMRnybdsJmkNJ39LMjP3id" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1f07fe59eae52068f000ee37533a3f25c83326cfc9a704fec2ca480c89894e78", nftId = "0xae77c1287d3f0ed62c4f307d1c7d76a8cd36fc06f641b6f218f980d673a47c93", nftName = "LoopPhunks #705", nftImage = "ipfs://QmUMo6kg2ubPs8HFHcHCvKZoHgkZMq47jJ13BydcrWBg1n" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27f4b77575062322c2c0ed34aa471c369d65b7c975ee5fff26d2f5e7b3767c97", nftId = "0x5fb619aff869bac4033fdd78743e16cf12dd27611be79c194828e2b9e6fadba7", nftName = "LoopPhunks #704", nftImage = "ipfs://QmZnWVUfcmZs6eXV6YWk2p7cpFf6Cpbwim2aUSx99UppZ9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ed8191b995f99d17c6b2437ff82bd833d0299bc6f4e185585db19c9ea799329", nftId = "0x61333d4e8a2284af6026d1aab4a1670016d86960bb8c6561474a3bbe34e6701a", nftName = "LoopPhunks #703", nftImage = "ipfs://QmUFF8Z13PgULrMdtiAPjKmaYAF2mxqvAj3rKXknB9ddUm" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1481b508496182f9398c7dd682028cf0b2ac7af61573cb9592dc7a53c91675a5", nftId = "0x2d6704b83956ed1a3d6a5f36d35fc2b0638885b9cb97068bc104ae0fe79c412e", nftName = "LoopPhunks #702", nftImage = "ipfs://QmeLmAwtxa2QXKr8bvEWhGZvcoue3UuKehVFw9EdSJsUYM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x16b1f59a5e72483a393dd95a05ffbb67c6b7c171997c9d625d39988b910c85d1", nftId = "0x7bdb16a2afb9714cb1bca51ade0a0bd53fcd499e8f1e9eea744e2bd4520c1cda", nftName = "LoopPhunks #701", nftImage = "ipfs://QmQhVigTtQeMi6WhF2VfAaGYEH1CSFVoiL2X6LzbD1VobF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1fc6c1a8621cc9c7cacc86d5dc8b2cb20962ac3b8615b1037f719dddd8896b88", nftId = "0xca72bac3cf4bbdf53d39421f516f1dc0b794cb6cda58404957d992d1888df5fd", nftName = "LoopPhunks #700", nftImage = "ipfs://QmdN7LVUrmN4jz6WfekJJXTRtH1mWUCpN8nXW3GpRyA2iF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x19177ab97ba3d473fee0194e33b8b15d719451c64f82b239b69ebd8f4b39c6a7", nftId = "0x9a22696fb6b21e279ca798840c33205a868e22f57600a5a5cd8dac44dd0b2703", nftName = "LoopPhunks #699", nftImage = "ipfs://QmYn4aB28uj4dkz1jPtkM6Brz2ciNW9RubTtfqEk1su3Tv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0fd746134c34cfdd8c6a0fd5fe4de9ea3ee1547e1bac68587b22a4ee610ff7ae", nftId = "0xf29ed3e4c035d5eee51f6c3edf61d46ad37dc9da716a0278ac07ef0bae0786b2", nftName = "LoopPhunks #698", nftImage = "ipfs://QmYk4UHjRggQ1TPepv9w376cJyfBTAJKAag6qxyqQBvBVi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x039e5848bfc2ff848fe491da41052bcdbc1629256f2a86fa31cd156aecd3cab4", nftId = "0x68d1430d18364deab854ef097bee394bc4c37facc7f6584c61390a3f0f2e58b1", nftName = "LoopPhunks #697", nftImage = "ipfs://QmdHmzWtjNvBVJA2Sg11ohqiVMPpmTkknAqWuxxjNZxdk5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00c4ef1994641a07a696156bd6d13462cab2d4e4db904e9f3a75d0c0efefbdd6", nftId = "0x0c360ba7a01696a6584e149f865a2c74ef4004619c3cbd1816c7c12ad24062d1", nftName = "LoopPhunks #696", nftImage = "ipfs://QmYuJJxeT3ugNuT9bCDdF5iMX1nTY1ZXLPxM3GLrrooWbC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2db5b1cde9142e180a8bedd77e74d2bfe7281814e0ad7ab72735f048eed22695", nftId = "0x62e6839bfae60f70d2d4b60dcdd4144aa916db42da7c4fc9b8a15abca646992e", nftName = "LoopPhunks #695", nftImage = "ipfs://QmPUW7dS6RFF1BJGbXGdxWk7PUFGeJqUjejnJwYVFERajJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x005dad9fc099a815f5ea7fb16b0cb1e1b5b42d27553d8ab32646a88c4e30399e", nftId = "0x68dfc7a980e19ec64c633a3cecc7d05b1e00ad65b92802e6c1f7d93a7da606ae", nftName = "LoopPhunks #694", nftImage = "ipfs://QmZnEBqLmrBwNGeLrpYGB3ybJurwkVkB6MmDEPm7jG3TSw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0398295c3f25f295790ceeaa3de5ec5b18dabd6c2714843c05656cc9ab9aa5a9", nftId = "0xd396b70461ec7cabfb68c5a412a48f6b64f8c26b5d6faf8ce3684ccc74a44243", nftName = "LoopPhunks #693", nftImage = "ipfs://QmQqFp97KqTxaLYe1YYjNznWc8wUHXz5yRyuwrK3swE5Gz" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x182919f92bf2459ada4c6493d6cc5508cc3dc6aa3d92c19959cd3c305b8fe76e", nftId = "0x466decd9960a2673b578de6deb21f1e0c04caa85f4c43e1aec52963f727d0d00", nftName = "LoopPhunks #692", nftImage = "ipfs://QmdV5Kt1FTMSQ26uZMiYMCCwVCbNj4SJeKPFD2Lu1jmfhW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0d74ad58579198e6a87e2bdae4cd3bd1580721f23ed89d7db239484b411013f3", nftId = "0x1b3ab4db415ecd0f982d0d95629c835c4602044e888bd100c0ae753124ea5e7a", nftName = "LoopPhunks #691", nftImage = "ipfs://QmXsJA86JGwnfDTyLo2jAtDHHSg3a94uBDRU7WzYJvaaLU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0be9bd59f245364803e8cbace12ba57fd554c76c587ba133d5af5daaf8bd27cd", nftId = "0x0c2ee0e46713b41f42a91859b246a999ac457072aabc53e5cc36be89ebd735bb", nftName = "LoopPhunks #690", nftImage = "ipfs://QmV2uuCaFsdzSNcDbmLDyzBqW77EdSAjBSPczpHb2X37KZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e1448b2544128e1f81be251e24a7315e1b6afe98a7666d75dbac0a783b1636d", nftId = "0xbc0f7828180af3f96514d9988a3df4d6d46d4537717809263a863c555636aa37", nftName = "LoopPhunks #689", nftImage = "ipfs://QmesWmAF9xjCHNYrh4SiAAh715wYi1gpafEdL7waNVPW33" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1dd226749dedcdbb94bca45613d29f71cba0ec74b4aff05ba1e0d32e1a058b3e", nftId = "0xe889fdc4453f3004ce353d5cffeecf2528b8d748276ae8ec3402683d82d03f22", nftName = "LoopPhunks #688", nftImage = "ipfs://QmVJjZpP8T3KJ9rQxCKc3ruVB6w681gu2sdMMrk191Wf4q" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0941967901d4fb5f5a60f97f436ded8296fa16cb4f8cb7769980c110c70aff1c", nftId = "0x42ac2c6ff40e594b9f33792ed5670f4fca18d9f8d0363df1a62ed87bf66d1efa", nftName = "LoopPhunks #687", nftImage = "ipfs://QmV9F6NjM43gKzLPGkjnyDfngLgNnrxGrp7GAsZekGe8GR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15ed10e28b1e4c6939a4fde2ace88b139368125092eb15bced5abf06e59fe4f1", nftId = "0x3e501df568a6706a01fb4725c66a425e82849c22081fb55686f6e65e3c0a7231", nftName = "LoopPhunks #686", nftImage = "ipfs://QmanMvCvA6ffe7QaP2pTFDNWodY5Tt4q8A8KUM69xRNsDE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1fa1ae8c890b0d03986996ab76f61fd1191dbaf98505d73de0410a3c8fe0c515", nftId = "0xae3ffb5ca0b1945da990e790af9ee71a317058917fa373c3f0fa378b558560fa", nftName = "LoopPhunks #685", nftImage = "ipfs://QmNoxARe5viJpmeRfME5vR3BHDpLYBcKx2aE3gv6Ac2smf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07cecc8f042ac36b2a55eb975dcc3af8e0419d4a107d9a3ede40bf619ad76c5c", nftId = "0xa7311937c70c80023eda19d73a43c1fb43a2971ad61ae12b1a0023e64e82a448", nftName = "LoopPhunks #684", nftImage = "ipfs://QmcJqCiMY7iMgDcT1gYJG5ZTK9NsPHJQftcfyifVAwoNLv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2d401730a74bed41ef6a43c4f940e71ba69895f86f42ab5b73bcc7f69a396e22", nftId = "0x50ea1c240574204bacb8faa3c140ccc32904e7c3c45e2f6dbd8913897ce640e3", nftName = "LoopPhunks #683", nftImage = "ipfs://Qmbk8mvN8G12Turjq8Hpzwg4jEF8ieHSc9QRAcrfGxuvdo" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x086c57d8507efb950bfdc0eedd898c0c975d3d242dd903e9ffaa39e49d24b58e", nftId = "0x77a2410c8d5813afc7d27373e9263a6e8ba72b97b3905685f219ec0022425a17", nftName = "LoopPhunks #682", nftImage = "ipfs://QmPgdai54CG75iKkg8UtP8QksGPXDs5v3Vi7ws8RWnpJVf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x212d48694b91aeff106662af8bb045abe58d13ebe189abf1bb02d41bf27c094a", nftId = "0x10f71040a4e51a8b1f6520147e0afbecfd1e84802d90befe6add10bd4af03200", nftName = "LoopPhunks #681", nftImage = "ipfs://QmdUwvqDZNdLoHjWvez9i5BschHGXp8FYm7Ly9yK9JbdRQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07bb061ec3b05c80bf9376fd06a9af358cde059fc225126a4fc9a2ca52da21b6", nftId = "0x8d27b498e4c504aebe6d184d0f6346aa7ef1a380328d5b5cf107e600813bff3d", nftName = "LoopPhunks #680", nftImage = "ipfs://Qmeb88pwTThzmm6fbm9j4VtDsXfXLj7MzL3fos7Qe1UFaJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c2919966229544409269b383e02132b2e859249ad0b6c746b3c7799719f369a", nftId = "0x816fb322f68ff397e6c3def91d3c6abe1e6e8774106bf0d200bd5a0d1ce91797", nftName = "LoopPhunks #679", nftImage = "ipfs://QmQydzsnpGrrnhgKvyRzfsDshi4g7GTxD88zkMxzA1oaHM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d5c2ef062ed218c6f207b4290e7295fe5d819253a3510764b418738d8268ccb", nftId = "0xd91ebf165c29049d7bdb210389c23907ec145dde86f0dc3cb396862e06cb6dc8", nftName = "LoopPhunks #678", nftImage = "ipfs://QmQoRnzEQr3xsqL22Uu5sNzstgnH3MXSx26c1JLFzpwkFU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24d3d3b6e12e5ba5ef920fcbce893022b3dbbaabaa84eaac1a8db75fc83c3a68", nftId = "0x3618be0cfaf4c737adf88186a4171731b706643bdd3f97a66147c23ab8f9a59c", nftName = "LoopPhunks #677", nftImage = "ipfs://QmXx9i6CFiwysdsQNtbes7K6wQmuXogEyM9Ccz7tJ5Wycj" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0fba27e7f99da732104125b8399419491c187cccbfd05a4d9b8badd093d3c40a", nftId = "0x5264f7a081088d3fbc091059faf15bcab6ed68ea9f240b0be83bff6fb516c59e", nftName = "LoopPhunks #676", nftImage = "ipfs://QmTuKaEfForrL2tFgmDB3qJ9APsZaZByAa2Ne9LTfbxvCJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18d2b61523d1da13727e4c93ca937eab4d290cbace86bfe9da18ff74be907805", nftId = "0xa45c10ded16b99fb91fa2a9b6e1fa780284b663c480303f7ef5e134ef8c6dbf5", nftName = "LoopPhunks #675", nftImage = "ipfs://QmP9bn61qCswDarjsGck9ofacFB3KoikYjC9PcRDFEfskr" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x283855d19f9b409e855f7e7743aaf6edabdae5bb1f493e9a7d8b1cd2a06c0407", nftId = "0x48942efc0dbd0880baab519aeafaa4bb6cf64b22cd483e263307e0f7daf5fa69", nftName = "LoopPhunks #674", nftImage = "ipfs://QmWSRw5omdAXMwT1qZGmb4pqvH7EbYgRrcw11KymaWbXi1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x166de35691789c03dad63d5144eb0339652bd0ed454ac197263b4cbd8a8342b9", nftId = "0xbb4e62d3b98e903f5ec6d9f3939cf39f1c603049691d11c838b07e3a63eb9de8", nftName = "LoopPhunks #673", nftImage = "ipfs://QmatgLqgcCiwwigfTkfRcHBEhFFxq36RfCeakHn9kz44B8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07a5df0c96eb98b544124bb962f9dc113bb686f013c5a50c2b7f4c9002b236c6", nftId = "0xc90c5bb68aad3b95ba1fbc16a280e5cea5d3d335237a02518dc685f9a0034dd7", nftName = "LoopPhunks #672", nftImage = "ipfs://QmXmi1KSPVxHasKG7GkVMV5Y6VEQGsBeZYXjRd4rzvdZq6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1cc2e6873c196c7e0f06d3f9b0f15e2d5c449b234b20c8dfbe44573e65c31dd7", nftId = "0x306e4956089195b6e67dabf876e0fa1801eff4938dd03bd182b1c1a43cde5f75", nftName = "LoopPhunks #671", nftImage = "ipfs://QmS99msqkjJs9Da3AWWrbR7Jbb2D5rv99bNf8qajQqYPsb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x218abddd593a9c1fc434fd739cb086a8dbaa6c9160023636b2bb1db95be81a30", nftId = "0x1684686877ff431be6e79c755eb9fc210318e049e1ff3f630a6b46f59cd779a8", nftName = "LoopPhunks #670", nftImage = "ipfs://Qmc71qJcigcgPuLt2cnZKzwmBCPtgNBfr1Uev85giZG65E" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0980e500b0e6544e73b13ab87301014c89e7f9ee07315f105900580c1130e77b", nftId = "0x6ead290054ce5ad9b8af7ed11f1ecd4b0c6ceae0146728290d14f22cf6d2c28b", nftName = "LoopPhunks #669", nftImage = "ipfs://QmdN9pcvg6sN1KqzzVdBSPz383nQ7Cdc7QiPMWiSuXFDz7" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x26dd634ca7aa24c6e6ad5d2143c6de2b42f11d7c09bb623af82f662fcf28347e", nftId = "0x847805f6e894f16c27756e9dc75ee49e218a63c6f778b0700dcc4e1d9fdf7e6a", nftName = "LoopPhunks #668", nftImage = "ipfs://QmQa8M7o5SKxLWfNFtgtyBVXpfSnfmLUmebpphUbPCkALc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2614bf79421761650bc12a7dfa57d7ddda68c01a8bb3d605fff0d275287731b6", nftId = "0xe33679984e800fe743cb7e09fcb69e6c16e7b97332f1b7e6447934ca7166b3b6", nftName = "LoopPhunks #667", nftImage = "ipfs://QmNQiCrXCgydf1BKMqhccmp8gqLyiwU6onLfVqq1Z3hge6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x051ee54cc55d2c47bf432bb58075409408931844c0271f9a8123b5a188d0bd18", nftId = "0xf258ca4106abaf117c0cddba0ff7b151513aeaf7b851aceca37863d3cf2f328e", nftName = "LoopPhunks #666", nftImage = "ipfs://QmcQVYxXLaJoAHbwqGyx6cbrGTxnCxs2NGYZ2vJB6A4FwE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1b11bbfe2ec77f8ab0c9f3f1e9ce0f29d07cd0f2470cceb057a87300978d6a29", nftId = "0x4aeb5bf3fa742cedc00c2cdf9534437df2cad8d4f36ae4ae4d296c0f1cb115cd", nftName = "LoopPhunks #665", nftImage = "ipfs://QmPsrRBgYuQeXgXh3wcQRhYbSosQs3GYagmNcnzQoRvtup" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x106bece640852dc3b7a168b964b50a9d4aaecdf1da32db2a43425dc2a83fead6", nftId = "0x4841d9af3125aa04b269480ae0a974d247b1afdb9753a35aec0d1792386d1d7a", nftName = "LoopPhunks #664", nftImage = "ipfs://QmYCeFD1gR1ccruR7JNMy8CgixhwhxaES5Jk8XLHYGwwpU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1f41ca3b72cea83958dfe2701988c60d9ad72586f5c042762a9fb47b1b693988", nftId = "0x4103b918b75cff8ac0b253f66b444d95f44cd243ef67d0f906087fa025223a58", nftName = "LoopPhunks #663", nftImage = "ipfs://QmaBq77QbYHL5qhBUSNvaBe9RQHksmV5SU9cGfSnF6VtEb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f96224b04ee19ff4bd81431e37181e63e152e8c0484c2fcbdb91ded12bf1ee1", nftId = "0x0342c1680c6773d677cc880021834c94eca1c650abae127d3d46e8cfdcec45e5", nftName = "LoopPhunks #662", nftImage = "ipfs://QmRn1yiZGtLyCJSEQ546mSXR2Enp3r9aaHSzbWEa91wbEQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28733519fb6b58148e9283f43eb6eeedabd822182f629ad160300e4be7a1b11c", nftId = "0xaa23315e8716731c95391a9ddcd89d4d8bef8603698ec239cc000d3547991386", nftName = "LoopPhunks #661", nftImage = "ipfs://QmWLr387NAU5jZsWtAibdagvWVxpxBkfbMFtzbr7yMys6c" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1a22de2c2dfc2955641f25ac32f9c9e44f1c00535a99ec33de9c7807c21a9d8d", nftId = "0xaccfc95ab3ce9c03833c8a34f60917362c8ff107addbe62d2f10935a86328be8", nftName = "LoopPhunks #660", nftImage = "ipfs://QmaDcQ9zPhXfJkE3GLHawZrHqbEDkorqfH3nd16yoBzYGL" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ada46872a7c392cdf9ff83c3fbae4f47a220dd9e1f58f11154354c6d0545491", nftId = "0xac8991c0a84c8b17a065df9e77910e58fd264063543308ad07be037e25f48763", nftName = "LoopPhunks #659", nftImage = "ipfs://QmYQEveNHZUfmeZyv2oxNXBEN6HAcUFLDskkanCKtff9nq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x03788979997063f5edac4b2592051a4c921bb5a8e35b852aee4edc683b7063df", nftId = "0xc4ca5cb87617f434660cf6cc612046a7d9c95af0672daad77bdb5dd485650cc5", nftName = "LoopPhunks #658", nftImage = "ipfs://QmYpBH3ATna2xUTAQsZZRUKLrh9GP48BekC7E23Wx6hn9b" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x23d983afda2ee37bbb37485b32de94aa7d1dc891e904841d603419e796ebcff2", nftId = "0xc179aca950e35116f6bc2a4cb44f62853b70265f9ceba44b84d1b58c413d2aae", nftName = "LoopPhunks #657", nftImage = "ipfs://QmaNjL9QMnhLuZa2ZVD4qd4Nn2nZwVoXce4ky2qZ4kB19s" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c0e6458ddf5d0f53652cc2d8af6e4e806697eef87bae1416be6a2d9ed31bb9d", nftId = "0x09d7bf17cb52be9bb4b019fdf1c64daa078cbc57ef221370c52cf5a51ff7088c", nftName = "LoopPhunks #656", nftImage = "ipfs://QmTcPQ7B4WUZsymyPTVwqxCdiTKk7sCgaJ9DUHeEfjypvZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x028c4c67522e82e87d1259efd224e22d184fedca41c3619afb02c93e108e3f0d", nftId = "0x85009c068db4f1fe1e2dcd150d4b711035b0fa07fc69a9785116c8104451c768", nftName = "LoopPhunks #655", nftImage = "ipfs://QmUMmhiRJsaUhxVYnUfhsGENxxHjtWKtbxHpegKaxASciZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14b784e11adaf17f7c89e48560db9027703f9165c66cfa7295e9606d1d496655", nftId = "0xc29530d7b5bfbf39d495573e60518a2bd4f0e6810909cf52747858670931b3f6", nftName = "LoopPhunks #654", nftImage = "ipfs://QmcAT3kyC5Hka2PDJJXobonH7tkaYHNLy8aigs2mrQNQfq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15971c43b9a19a5bdbc5f848c2acdd64ca5b55cb32ba6ca7e54f97679c666140", nftId = "0xfbc41360b2c4ee74bf2704e84be41d62636597b9a1d12e3ec1fad80b78f2db54", nftName = "LoopPhunks #653", nftImage = "ipfs://QmcCiVxJb2PhHKJ4WpmguEXZdxmRDSHS7CCtMiHUwsoqJ4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24b43a053e471e04d5a704eb890a5b6394dcfaccc87a4e8dad4b815b686327a5", nftId = "0xda5c91dca96f4e870a0f953e6d1fd51cff9f4b48ddc86ff972fecd9c9e11e1ea", nftName = "LoopPhunks #652", nftImage = "ipfs://QmYFy1Hve34ZupSXg1Rdid8PzFWcHRUouasRBWTWzRBjAU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x003f90584cf194e2573da12a06f0d2bf09956eb4f6507ccaad53572899403209", nftId = "0x39e3db3dfd14f592032e5bf3782925c2ab465078052332db6ec7010d0e36de09", nftName = "LoopPhunks #651", nftImage = "ipfs://QmZzJYeRw2tEr7DCmm1THj19Hrtk59D5DyMqC3PAT7gauV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x012d20917d64eae4e47081df4752eda80156e34088062420e6626d37aaf9a82c", nftId = "0x5b59a31056a9ea2121bd549829301fae5b4dbdd5919eccdc7514ca632f36d183", nftName = "LoopPhunks #650", nftImage = "ipfs://QmeyTcx54E4kNVA8TbXLREwgXYLw5rYjHhkDiJkaT5rPK4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1fe94a611503722e7a604aa0dde9891fe8df9c9728f9366f6c50d11076c5d4ac", nftId = "0x7b156379d3de0e9aff5aa64879fa28f38ae5827c5d38a772a75bbbeb42c6cf00", nftName = "LoopPhunks #649", nftImage = "ipfs://QmXAiUpX6iK1BWEj2FrSxuMXAF2VLu54Ly22KCdtLWz8hc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a92a8887a699ff51fe7579b346b87c18343994f100e0831060c95976043c6af", nftId = "0xb87bf96577a2735fd2faf5ab47c396a3cff6f844849494569e414ad8414c268c", nftName = "LoopPhunks #648", nftImage = "ipfs://QmP2kjVSWCqrikuL33s15EnCsFm87x2kfvFHAcHNfSVQzx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x011e8290f7a4b7497039f284ff3838b70135c3577bbf93943003720d65a3d75d", nftId = "0xcc101690cbb04d5137de2ffd1b4c0cd5422a88097c067458e1da55032e77a953", nftName = "LoopPhunks #647", nftImage = "ipfs://QmVyZNYTvDRQTYYDvnEHVygL5aYfxydP9mHk6hk3krVtHb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0dff70d4303eb7cf9d6b07aa5379d17ae46b832f63321f6f19fc33cc4d6507c5", nftId = "0x8704554f1a91350d31d4977b3b3714ea93d77b87ad9c104abfe0ca5e48f7fe7e", nftName = "LoopPhunks #646", nftImage = "ipfs://QmSRoZWd9BfvArFJrEWRVmCBXem1ptU8ZW9pyfbXx6a75U" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00d1054e7e01315973393048116fbed6c99cf6db62ab7038054a3c815c34df0f", nftId = "0x1e3a2519bd9359b02d362e661ce4bcab74d2dce404edfb05748b1d134fb1cd09", nftName = "LoopPhunks #645", nftImage = "ipfs://QmYs5azK59XxpDWB4cQgDa4VwoTjfeS9KjZxwhQoaQPqEP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1931f89714a67e8c3fb475a5fc98e8a4d58c1ee9d048e89cf03d159d91a2bc60", nftId = "0x8e751006f26235c01ba4198b4a3e21d8fd64eba7df032a44fe3699ee69d9d213", nftName = "LoopPhunks #644", nftImage = "ipfs://QmR8z8Ug9eL67smSZKJ9ucNsn7vA9F7svBSfbLmyA1RVvu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x054d84c05cc28d5b31c357a6f0a8e1fc006833ebf9ad121ace978cafed88f58c", nftId = "0x08eb16cf4761ad9533d0b58b09c839d7f04e0107d1db72a4d01dcda99e9f175b", nftName = "LoopPhunks #643", nftImage = "ipfs://QmYEd2PMJ8yGHTkydx9RxHoiUMyuEHnWZ9No7hoJGrvfs8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27c62a70a7b5a0abf150a88f544299825ff1da9de2e7ba59c8890da237daa786", nftId = "0x45f5c416d58a9f812939d3e5d00f93270fafc8096ff95a107af5c05bfbd7b375", nftName = "LoopPhunks #642", nftImage = "ipfs://QmZf7e2hDhWjNaXCLJMFBKqsQRAUXbvinikS41pLDPBfxa" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ae5bd2858569b806050ccd804b814b25636bc8e4a715646176da0f6bc5cd316", nftId = "0x4c2928416dbee2230a9f5c6cf41f6c05221101bf9846458be57321fcc05f57cf", nftName = "LoopPhunks #641", nftImage = "ipfs://QmY5uEC1AdWpM6YiwdRAh8nhTXn671o5MT4jJmzuV3DVJg" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05b000032941f8a3e438da4617d0419d9e277697ef66ee1f331e8af0d52f3938", nftId = "0x1c18a66f5128574ae86c7a9d2d09e8a358bba985a54dea405b0c7262576eeaa8", nftName = "LoopPhunks #640", nftImage = "ipfs://QmdH7SBzcVTRYDcGgAB4X8zpdFbX7C9id3jnqjp1Rdpdu7" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d8fe598f972377ef00168ec2baa452baf2d7929825ac316656f20d2c82b675d", nftId = "0x1fbdeb65921d7327fcaff9ad1356252b162c99f8913a9511afa1c39ca89d644c", nftName = "LoopPhunks #639", nftImage = "ipfs://QmU9V4MjZJZCgmVXjRgc4m179EfvHa5CssPjcZHxkMrYtS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2d05c9cc50be69a69c1bb4059e74f811b10b2f0c0163dfe7fb8bdd280925210f", nftId = "0xe6f95251817a9eb91864ab138326f446356a7fa79fdf97965b599fedb8b3188e", nftName = "LoopPhunks #638", nftImage = "ipfs://QmdAP4ohbR6NTVxBy6CSTx3hpthLLjNCr3tspgrA2qGWxQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e0a6114c68bce8c3776e4d668ece5a92fbcafdffcb7e6a55b606cac7276edf2", nftId = "0x825f5e1c7391d87d3eb00f45b1b9b35617fce0bb99fb091822a93e2a79ff5dfa", nftName = "LoopPhunks #637", nftImage = "ipfs://QmTmpR6vcbx4nQeWJ2M2XJ1YPqDCXCfAj5roN6smCpePos" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2fdf6003abba8ec27fad713f717ecaa4f262052ca6c16fbd6925fdaeaf91b4d1", nftId = "0xbfb664f6242a9de8fb7192d3145acacca05c813a3bfcaf1c42b1c8ba63d17799", nftName = "LoopPhunks #636", nftImage = "ipfs://QmStY7wiHAFducs3fGjxJ7u14sDFUtZcbKNzEP55bWNfxM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x006b70f2577f2bb851b7726ea2e6f5e319177bd817423bcafa6c13cdb668dacd", nftId = "0x2c7241a2f2607ee6ca4bffd17f25eeb9b00923f60eaab6a46099e6fe3193cae7", nftName = "LoopPhunks #635", nftImage = "ipfs://QmZ2EfdcJbWZtgg86vzkebEomvS3Q2yKU1VRAjZoEcmBnN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2314d5c3ff65661a852e573b59de0c8e7f5fa4621a43b9364a5e2a20bd80d733", nftId = "0xacf882ee92659e68b22600c1c1b7732fdff8bfe96d5b13905a1a026bf45d3388", nftName = "LoopPhunks #634", nftImage = "ipfs://QmUWwv4h73hLmQE6jZkEC4oEEi4h3ESKGNVmm8ysGTHdhX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2d1cea0576ec120d660e8f1a6ea3b05f3c68ddcc2f5af793378461ed9cd37448", nftId = "0x5b549e0a18f75266423e1135e67eba28f02d5695389381595ea7595c815f2aa7", nftName = "LoopPhunks #633", nftImage = "ipfs://QmVgQQPA7NygmNijWvFdNR6xeiLhJCbFXUb8u5yQ5VGZ4L" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2448394d41970055aa1bfcc0ea733b49ef93a72e99d3faa73f76e7dba03d12f8", nftId = "0x4ea0e382cb3923a86aac81aaba683b8dc1bdbcb8fc90f9b6e042d5a93013337c", nftName = "LoopPhunks #632", nftImage = "ipfs://QmPF28CAYuvymGKH9K9Li1VrLxBVMWrk1PnhDBArfSaafq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1481cc338a5de0cc6f3aa2b4203cc21449cc7e64c1617f96440ee8f664048deb", nftId = "0x3490f4d9280a2e0b7c3e51e5837102c1f44280430a61e8a60442fccca14e8173", nftName = "LoopPhunks #631", nftImage = "ipfs://Qmcu5FRXN66xkyvDGHqusgSXLeQgkoXcwY68zk2qTYC33k" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00cd6307320e33727cd86e82d16b098fd4528b3faece6905a65eea3c8f63c782", nftId = "0x844e5e722ca60d69446a7ba3fec74dcfa65d9339bafd6d73d612f872d4f210cf", nftName = "LoopPhunks #630", nftImage = "ipfs://QmYoBxWFi9kGoXv8dHfLCY23f7nsgjA1BUQTGzKURKbkSr" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x234941ce6483b3180944354c497ed8be3d38eeb2a00c7642567d7bfcb2d2e397", nftId = "0x9e60984ff50399ef2fd2d1c2505f103c2c6bff3f34916f5cdff8ff4e45561490", nftName = "LoopPhunks #629", nftImage = "ipfs://QmeBsK7qRCSm4CNzakQ1nDvS6Hcd2fio795pcMXNCNMEES" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15734debe6be5a7456827592e8e9555853471c39aca09e8337f0e90a0c0f7a60", nftId = "0x60eb022605b5988f194f5fce24c812415700089d31efcbe5b4047eb9f4a418b9", nftName = "LoopPhunks #628", nftImage = "ipfs://Qmb6vHk2jEmbU7jcMwHwEsPY3LynzZYStioYWmhSPgvom4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f583f4e54b167cb8c94df47900b76f997ad466864d323b3505d1ed357273e3f", nftId = "0xb49e84d86a00567019be23a5077576f516bf7130b2df961a630176030c8152f5", nftName = "LoopPhunks #627", nftImage = "ipfs://QmZhU9NsJEDrdLAhP9hM1zJauwpH7Uv2rjBV5t5JTbY2NF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x259270993efcd30119d1ff1910e7318dd4fb1c0ff10caf560240d0b815cc4bd4", nftId = "0x6ebbeac93b9213eedbbdc0692d4bc9dc20eb56d581d12c6e5b86e22b28e34fb6", nftName = "LoopPhunks #626", nftImage = "ipfs://QmSUS1yPs4SMttuS389xCRvKhnomrECSMTaCfp2Zz15yjN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f5b6ef7f5026e0fddd896a2bb290ba377b55dcf6fa9c4bba2921dfef055c970", nftId = "0x4727a8bdf8cf4bb4c7123b54ecb2704c94a5b45237030744cd4acf63066cc7b1", nftName = "LoopPhunks #625", nftImage = "ipfs://QmP3CVY9Ac3EH2uNaWSjLQZf1yMRLgJiSa5VE2KP5emNaA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x110dceb679940c567d675a797f77a0c8b6b2d2f863a12702937604683eedc9df", nftId = "0xd31b172433e52c5f4b1c09240e93da6d7f2b5f038bea9bde7a4241b3f20e4830", nftName = "LoopPhunks #624", nftImage = "ipfs://QmYnaCii8SjmuGp5hgvPtg517pvWoQpzMdWSvNVUFrxe7u" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2dba693e33f009c00bba304cd522d744decb53d7c60746fcb65a940c332281ef", nftId = "0x2a9a7cd338736ac1d59d7a9b7e08697b268f938892391b6c76a64f58c8c51d66", nftName = "LoopPhunks #623", nftImage = "ipfs://QmdvYMTwtzqs34nio17dz1BUu6n2uZnwKwrvwvAPPsrX2u" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0255149d0d67cde3a0075288e5d583b4050056f0193c7e3d66d1ee3f554d627c", nftId = "0x966c5f658a0a2d2a90ac142b3147ff92bd5526e40e631df73973533668f2f192", nftName = "LoopPhunks #622", nftImage = "ipfs://Qmf1mvCEWBUk79K6e2gY2Go2EQoRLpmw1zT4LwbpmN87k5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d1b8bb3491988ba6113dbfe2b23f6d2d4bc2aa347f053cb721ead1d481baf74", nftId = "0x470fc6f26901ca46eb6fa55a2a06875da0d944ad5a099894829cf54bd62cfa19", nftName = "LoopPhunks #621", nftImage = "ipfs://QmXF2kP1hX3TUPJ4tAJhFCkQoa2vZfVAayWuAQ8pQS6D8Y" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1c2aeaaa7c8359f67f10beca7650a01fb9e9f2ea597d82d2e4c45acda19671aa", nftId = "0x6ea83fa20ee82d4a803e989d2f07a0f0ac992b1885fef8a11564e7d5e6edbd35", nftName = "LoopPhunks #620", nftImage = "ipfs://QmV8FVFHeTt6JD5hvnfosjzZYtBAZg1oxV5uAPPb5aF7sd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2403fcf516f2b863dae8f560e9ed5286e44e2507564b1e56e9b180fcd4ff2a96", nftId = "0xe40d2b3e7d1fdbb2fd2a9ec84be8a934fb90f26e8e510dcd67fb5c4ed1cfa52a", nftName = "LoopPhunks #619", nftImage = "ipfs://QmTnzWg3UdYjBf9zMuNZKkgMcsaD4DJM1B1SevfExFF6rb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x25feb96d6c3f497e6159d03bd8f4865aa13b38f3b1313788ee819732dbebca84", nftId = "0x8d9252117e931f1b26fd2966a30ffbe47f3b36443e32b2a3cc0c6f1d2ea15d48", nftName = "LoopPhunks #618", nftImage = "ipfs://QmWG9CBFanskcsdKJuD4xHcLi56sZPTVp4DMuBPQec8wQ1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x19c4bd3b5e472f70043c87f9924050d0d95220c4855d9e020ac388f9bf5a2981", nftId = "0x0cb422311c376bcf32f4b9bb2cc5cdc872bd5b956b0fe4374e8888c3a17baf95", nftName = "LoopPhunks #617", nftImage = "ipfs://QmYFsnkx8ye8D3Y1gA2NnBkVt1aynRvDkw58z7wKKc9eL4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29884811c2ac125fb7c3bb96c345c30bc4042a3ce43026666c09e0a62347642b", nftId = "0x6a5e12083522203a26e35bb8e6f623251b6042cf462a3ad26219632a11ed5031", nftName = "LoopPhunks #616", nftImage = "ipfs://QmdQLWmGuDpaQa5T6B2DPRbbg5pM8yaZT6yhi6TdRLJJ2L" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x20e5c90da4584f1e8c8f1412051d80709e9f7c0357b4dfe727cc6a6e23e36210", nftId = "0xc4729fa9ddf52e284e810dec64bd8f4c4b2057e977db84b2a32301a601a7c1a3", nftName = "LoopPhunks #615", nftImage = "ipfs://QmYTVYVVaGTfx2sH3E5nwaSubs2FKGAAfoYPidHpgeD8uH" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1344fd0eeb3a151cf06696099a3c7126dc97b95abd149fa56f8fab45ec17ed5e", nftId = "0xc69d8a18c6b8b82b65a6e84e6bedbe4cc171390c5fa892375ba695284fe23c4f", nftName = "LoopPhunks #614", nftImage = "ipfs://QmdKQi1QKQb4GaH9yBHoWS6YPUdtGRcG9e3uP51aiQADqF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a00e0244a4fa0b0f065c33a67e42e26785bd32cb326d8fab29737cf453c442f", nftId = "0x800284f41cea4dcac7f75ee8252c2600bcf15955daf29d204fe4bbf8cd7a1d81", nftName = "LoopPhunks #613", nftImage = "ipfs://QmVNTbrRijwk86r4tjM9sxYJTmK3CJMeLCTDRMLTPPTLmQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ccd48eac0752cf52f734e59e8f731864e3482afd79356264c4f2719a06b2c7e", nftId = "0x7a91cef4a8f76d083998e7c54e037ae8ab183160c456ac5331a38843c94160c0", nftName = "LoopPhunks #612", nftImage = "ipfs://QmctuaMKVgfB4sytMcN9bjERobvJXq7hceMG1njdMwNv82" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x12ce0d9a92007c2e7e3bc48439298d0931fc630ff1e5458eb1510f46186f111d", nftId = "0xb5f32c6180c523dcd08e313dffa1dbc15c6733c702364ede303029430256a388", nftName = "LoopPhunks #611", nftImage = "ipfs://QmYEB7CxNj59ZWfgV1cYUcCccVbYtHtQQoy1YJ3AFTZo8S" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15133db6ec9be8f004377c6f859b9c8cdc0dd2080117e8323105ad6aaff4607d", nftId = "0x83b9c2086c7bb5dbbd0cc84c35c295af79ee3f65e3f37d4065f7bba108d44d7f", nftName = "LoopPhunks #610", nftImage = "ipfs://Qmab2SPPSphGwRB8knx4aDTkuiakYj9anSWKyCiN1zp2oq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x09b089051de276522a08998372f3d918634c02385b5b811771b32ee97c9a50aa", nftId = "0x08942cf67fbbbf89a91cfe843b93566697b6fb312aca5004ebaa49ed1dd9f504", nftName = "LoopPhunks #609", nftImage = "ipfs://QmZVSXaDcmQba4zdYeK8SXWqwRXdzmv8HF2uAtzW4qpA9D" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0913b1c4a0561ad2b509dc054e7d5748b2c5966c336d46af0d2054b15a0a94a7", nftId = "0xaa57e35fec365e505d36cf3f6f2ecddf03c9c150a223bb843fd600721b03db68", nftName = "LoopPhunks #608", nftImage = "ipfs://QmTrWeHcsuxjrfJAb8QjdypVkHwn7NLgWXaAh6T9CAgu9p" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1648d48a9453155877c86197e10a41ebbeed9cb1071f75eca40033319bfca772", nftId = "0xdcaed066d44332c54b7b81bc86d8638191ca02645034c38a2b9d5bbbea3420a4", nftName = "LoopPhunks #607", nftImage = "ipfs://QmPhNGW96CJxjeBhkmEZAyKxP5wdQQ1nttBJLFn4ruK1bo" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22462c26776a5e34cc023c6c6162468292c64bc87d01ea6ea479a94a3c01e1f2", nftId = "0x3b362e92e24a70c46fb4cf532f3227c4fb4da3e2c93cdca88826fb7f8d9f0dbc", nftName = "LoopPhunks #606", nftImage = "ipfs://QmbXbqTXz8ck735iDcMYQcJ3grrd5eCQTWBqWaq6Tat2J9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b6e3f368dc72530cc4228248d436c91661370443d661ad5d0e575127dff8b45", nftId = "0x1cae9c2160a922a08068aa757808125fa83d23844120142254dcee2f92f3a5b8", nftName = "LoopPhunks #605", nftImage = "ipfs://QmZoZ6KK3Y2E3LmwvbUYPqZYTGmWCurh7bgxsFBZbc38Pz" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2915edcba0ea85322d51988cb3ba0541444aa3f4f81d369dce27048f5a16d403", nftId = "0x8ea5622ec0752f47506598f5b9df8c150b897efd7b7d5d6712dba3b255f397be", nftName = "LoopPhunks #604", nftImage = "ipfs://Qmb52b6dEQWnQ9FEsHe5dX9teTt7m54sStuq8UDm91KLdB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ad31897d0fdd1f03de6f596e7219d11d8af95edf4b5c2ca7d46637e13c39e4b", nftId = "0xf31fa0ca76018337f684ebac6bfa67d7f097846604dc5ae31d2afaf1ef0111f3", nftName = "LoopPhunks #603", nftImage = "ipfs://QmafVrHU4aZyjLj6Yv8PFBR7c12sJ81x3i5ifMUdRhhpez" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13aa4100d27122b2ab4a98ebf0c8fabc357dc17674a5cab113e054f6db780baf", nftId = "0x64df754cfc34f15fbcaf8546f558772971020fc15abc4886ca31499896f5ba10", nftName = "LoopPhunks #602", nftImage = "ipfs://QmbqzcL8q8HCFBmmtQz7nNEgVZMex16o6bbRcmeRpKo6Mg" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1457501ff36c05e1e72e1f298afc958dda99dfa161f94232e7da9d5654fa9877", nftId = "0xf3743de55b45e1199fdd11f9c84e21ebfb58094e9b638f409a511d578e1c3d64", nftName = "LoopPhunks #601", nftImage = "ipfs://QmTdSPS55TLewxYpMEC44j5Yy5TgDEhXYLPP29WnoMGw9c" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e47f1647232bf3a84237aa5382a1bff1c0e25a51da942f23bb708f682e4c92c", nftId = "0xafd3a497de8e32c012f8693759c2b3bf43ebca7367ae91a9fa8dd5158f23fd59", nftName = "LoopPhunks #600", nftImage = "ipfs://QmUcqLsiS6Vhz47r3TmJStzpvHpmQU9voaKDiCdhA31D9h" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2df1d5b89f314c19ea16b8a5a94c279163250b6a3f54c7f3fed1d03de5cbea7d", nftId = "0xb39f598349b2d73f4b82a995bb672df49c0714ae6227b1e0925434f9ca06972e", nftName = "LoopPhunks #599", nftImage = "ipfs://QmPWUFSgGc6CGUMZkEqGv7sFn2WqXFspG4GGshzPqJc1Ff" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1c7ac6f44900ce8ae15ebe1d5bc096ddba71e9274b6bffc245231bdb10ce43b1", nftId = "0xf44a3e49824e487b5baf4705a653676b13a94223ac3901f4334cba029530216e", nftName = "LoopPhunks #598", nftImage = "ipfs://QmcYeGSJrGQjYYwKJcgtgqHbBjaw3jrWtcvRqwpVxNUm7L" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1e2e72b39bb6dd9a8cf86f0b2065ecbf8d5edc10c0ec3d5f7cd9ef0c462ae5ad", nftId = "0xd62c0a66f02dcd87a20038849b758f395e5cc62ab896820470c256dda68ef860", nftName = "LoopPhunks #597", nftImage = "ipfs://QmeHZuq5duPdcvsNRgKTBDUjkxExoKVZAKRt3wCu2qJmsV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x23af28423749918225efca63fadcfa33ab7b751a40f30058e6196f30a4b15dfb", nftId = "0x24431db257246c04d541a75e8b1c46df2d8ff488924cabc798aa772aa0698c8b", nftName = "LoopPhunks #596", nftImage = "ipfs://QmVbb2uuTYC84QPAWRUWPtUtJqqjjw4rcJytLUoo2qUd5V" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15dfa5872dbacd2fe3b318a2f480011bd75c0c4e4f76f36bdb84b00925382ae2", nftId = "0x9955a17dc70fd2af5752e07bf715b9f46e11a7a9f87e5bec08088e9cdc750d7b", nftName = "LoopPhunks #595", nftImage = "ipfs://QmdLyjwn2oA4xgHBHqai4pwCTXpkZa26HUtimScFSpDjaD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f572b4543af5724e1f1e4c8bd06c6b4d18fd70a649bca0e2e9baa52fa09618f", nftId = "0x9a26b3d8d307d30f5387b6291fdeca55f108669a09e15562f578d26c3dd53e5a", nftName = "LoopPhunks #594", nftImage = "ipfs://QmVWzeWD8ZWK6SR9aEzUiMZwXfNMtozib7PKUXJRm4rFBB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x140d890dc98b14c25085dbf34327efbe144cbbc8449b4ad78eeaf317c7d4b740", nftId = "0x7eeeec43c85b75c8c9f57b9145aa1ab02518138cebcbeaad3ba0d2cdfa024b39", nftName = "LoopPhunks #593", nftImage = "ipfs://QmacZMGYoVQyeMJS3VdCViF9VaKbyjFFj7hCqhVhzzCdvy" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f597207109d8f3549d714b0af68cb072837efbcf8c2e3ae27e227f958f42617", nftId = "0x3fe9fa278eb9b1e0574164a85425ae5f0249f0a4b37c4abc8d07e53008678aa0", nftName = "LoopPhunks #592", nftImage = "ipfs://QmNoCuAzYaKsSYToJ9UEKScX85y3ix8ztX4AKT2nJD3vaa" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x139185ebd499e405c318b2e4773dc2ed9e1d7e3ae77a9eba8ef9431209dca3dd", nftId = "0xe0cacd463d9fecad4ae1810b865be72556fb01ce2051a5842b0a3d8c564a14fd", nftName = "LoopPhunks #591", nftImage = "ipfs://QmS48uRXhj6oVKV6f14UkhCykTatYX2pFqmd3Bf3WAMNcS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ca61588be93e588566461d0eebd4863130c2589d91105c76d687781687d3851", nftId = "0xdc718ebde2f2611d6602b6d8b4a17368d93a3aa23caf79aed4809623165aade3", nftName = "LoopPhunks #590", nftImage = "ipfs://QmYDbRNjoTNajB936c4J2NYW9YnV6VwuY8e5W7SVa8Hiht" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29e06aaef694b6ef084e218acd343fe4f254de81c9b094f0527bb2b92612db76", nftId = "0x61ad7bc2ea757d9a6dd0886bec9caeb178e00983435a943beaf62f589a890ca2", nftName = "LoopPhunks #589", nftImage = "ipfs://QmXfD5QUdDNng8s4UzPcE1GKc4mVJ1ojzeHcjxAeF3DmP8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x273dcdcb0bf25d3e88d1e847c550f6f3eeb9399ea3bc326a1967e844036deb7d", nftId = "0x411bf514a4ae418d19864710df91eb58406486466270e6fddf16e4d95f7ed3cd", nftName = "LoopPhunks #588", nftImage = "ipfs://Qmdp9VBzhtvjkYigNXh2a9vnLeyA7Y2cG4zBrwgut4XHrV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b5393790868593134df29e8bbabfb60e49e6bb80338dfd365889ea3848ef4b4", nftId = "0x8b8555950a4eb4722630960ab0b550ad1fdd42f02cb848b84d91e8cfc1bfb816", nftName = "LoopPhunks #587", nftImage = "ipfs://QmYWkmQwLxPZ23ivK5RP2iGFkVzu1QPdijnpimtMgdyTfY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2eb40f96eccaf4435c0ce48ccad0488cb49d4245e145e4479f8177f59ebef01e", nftId = "0xb6c524cb5a9cfe3bb35ada4a2271ff530daecbfdacd50899919ac6065b981aa2", nftName = "LoopPhunks #586", nftImage = "ipfs://QmTW1jupvA4SSZfhZvBjEr2eqyyfREb8RbaUyGSun1kRNU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b8d882edda8d5da4962f15f7233e1e27959480bc41ef17fbfa52289b65e26b0", nftId = "0x0bba71360a36b6dff492e1bf348efe1e86a59331d2fba6df18300a6e3ddd04ee", nftName = "LoopPhunks #585", nftImage = "ipfs://QmfKqRQr89x7gu4bcAcpR9Za5ACnEQzHjW9AAkErJwhUoe" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2618cf4faf538af8be3355409b99c5fdda79613b9a1a90384182e6ccd2c7ffd8", nftId = "0xf511e0f32d692da5724243b2aad9dc55d04d474050e3b03cea22cdf620ff7aec", nftName = "LoopPhunks #584", nftImage = "ipfs://QmbAQCxdXBBvEzZX1tJ7Gyqmw5L9tdiAQDmg9H2wv2zWzx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1a31f492497cc01e91b61d15c6a8392f88f52f367b023f4ca2e087fd5e247fa0", nftId = "0xd6011a596e2bc6e944e48beea687e3e4a26810f491ed2967940624932a71c33d", nftName = "LoopPhunks #583", nftImage = "ipfs://QmZZs2Z6x1Tke4AypLt1VTM288cx9af7RVEYZnqbLfK2pU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1716171dce140892de3bd1e5570f9fb27143c159338c7fd6f8c41a3380941466", nftId = "0xf5232c44451cc581cc586662b9f48d8965edb76fae34f6f45fef8ea3988f9150", nftName = "LoopPhunks #582", nftImage = "ipfs://QmVJ4yrTCg9BrgZLMSNoyG4oEF4umpF9YhC12WtjZmiXSd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x03ae13811cb63a9e9ab97a74f5e3d577ada19a7e4b817ad530af0cba13877eb3", nftId = "0x0548c8a0f7aae821497efd860aa7a070ee94167786cd0685caffbc781f7aba70", nftName = "LoopPhunks #581", nftImage = "ipfs://QmWKm9SgXS5gPx1u2WG8UcuH9bzguFB7hkkkAfBrHK8m4V" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1764eecad144cd1bd41b51cc16fa8747c8f80b5027dafebc72e3fc1e53386f1a", nftId = "0x6aad4d612984dfb806bc7e667ec0bf6c1029c6ad06db489f084c9f220a8087b5", nftName = "LoopPhunks #580", nftImage = "ipfs://Qmbq8VAuTPWpVUjppm19fmSd5XeK8avQYw6yqmCBrF423t" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x20395301c2716ad0479ccd56ffc4b0e70d21871a9563438ddcfa25da77ead8ef", nftId = "0x68ba9234ab2d062f2bf9dc73166c9a838c47d4ab3ca0401f67c5ada4a04391ee", nftName = "LoopPhunks #579", nftImage = "ipfs://QmYTzmTRiugRg2UhhCr3EkWjoSQmS9Dm45urVbsjmoPpXi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c9bf610ad747fbd3ae6b36f84b251a2958a119338cf8f148ab3972eb1c947b7", nftId = "0xf34245327d1e0f2c5daf219fa8a463c644b95a9c30e6c988a01475591a81e623", nftName = "LoopPhunks #578", nftImage = "ipfs://QmbhSFVAgJ3rivKB3BwAJpAnzqEBPgXq6DfehXfAcuxsth" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f705a24cc3995d29fe605fccd726a728f9c13bb73743e378bef2ae642f5590c", nftId = "0x31fc34c751e5fecc564c48901e82ea18d608413ffe7cba82c66ed333a7e8e065", nftName = "LoopPhunks #577", nftImage = "ipfs://QmU73C16A1svvT5c9YNXNHTteYs7xw3MxCos5hvWo6UCiE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d24929714621cdcba2b33adc0ec478619235ee2a0dc5861c54f74711e8fefe9", nftId = "0x8f660198979ab97d389505f559abf666f292a3287f8c7a276b8962df5032096a", nftName = "LoopPhunks #576", nftImage = "ipfs://QmcGJWruxev3o7kFUTvrwQCxycsQq3A8LYZHrMSs3sunPc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x143d3812291aaccd6d6bed0b2c9d13e740b78c630bbb9c013fd3c2562da52034", nftId = "0x791e3cab7bd1bb9a1fa7b1ad33f65171469456396755b886db02f31f5fcd8059", nftName = "LoopPhunks #575", nftImage = "ipfs://QmaPzHWRntdJR2D9vwB59xvrektH9SPM8eB1oUWDq8zQ9W" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x284743c5fe2f62c39d8e4a9dedfc2253985add8976fdb9ede2240b323d93168e", nftId = "0x69c5aa7f83c3ecedd0be7dd99ed851d8f8295f440bbe79092cba8e58c6ebc005", nftName = "LoopPhunks #574", nftImage = "ipfs://QmZhyhg36f1zHCUCeJJHPRHjLcputbhjZfJ7cG6Pqg7c3A" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x220794d78654b415cdc7e834fc2f369d6c2287d7908215e7fcfd87645868d992", nftId = "0xca7b95f52d8f657dfbf0faab40568aa2d704f367dd5a3e4f5a874f8a48de1a35", nftName = "LoopPhunks #573", nftImage = "ipfs://Qmf8V3inPN5hqFuTVmo9NcLV4bkSdHREzCyxFz9mkaWYgz" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x03ed4efb539848bd78a4f64672b4e0fd02ddb609f8fb2693b537479c216ca441", nftId = "0xef2e69cfd901e777d0a6f6e031ba10f16f6300854a2eb911c725178fe3200786", nftName = "LoopPhunks #572", nftImage = "ipfs://QmfWQBN86DYMSBnzSGB7j6BP8b1V4yBvjyRAjo78M9VYbj" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2331c53ed6e88ea78012fbfcf8d54a12cb6cb200497bef53202fad9625ab4368", nftId = "0x5eddeba22303dab923c2ca9c47a09a055afb107ace69cca888286eaa4c159c80", nftName = "LoopPhunks #571", nftImage = "ipfs://QmausRdU6XEQikFeRsJDBrTdwh1m54Zmh2M86D3dwemVpy" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24570fcab3cc170011d74fa0fc6db4d34bc8de170e045bc53c898ebc46bfd4c1", nftId = "0x09a755b65f1ed4e58545582a5b549d4dfe9ec8728f565a330dd5614ba71246de", nftName = "LoopPhunks #570", nftImage = "ipfs://QmUCpCcXtRaVQXanrYq1LfCVQwsNQR8tZQ9seGztzDVREB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x164010ccc227e2d31a8dc7c83c242747796a33013b7266508b9414f0342fb3bd", nftId = "0xe982f4b5e7b668b0deeb9327f307848d08ff7659ac8d35c73295d864f882f450", nftName = "LoopPhunks #569", nftImage = "ipfs://Qmd3bJ6QKTtWMnLXnijsUbizFDUtB9w58MMUvKwpL76dZ2" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0e278c9d441c204882fbf8ba8bea59e279c31786dce42f2a46a917c558f06567", nftId = "0xf72ada89a82f242a314fa918b1ba7e4909104d0c5e8af34a68bf74047c70a795", nftName = "LoopPhunks #568", nftImage = "ipfs://QmbDxoch7eJocrE9pSp4r92xZPL8jYggvyNNYg2hiqa8im" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f187de609638c0c53147a30118cb11825d671a35d500fa0bd976d5c9e04b1e1", nftId = "0x95316a72a64f393836a60c9c08269cfb90b1842fd75ec93e8770ecdbce074b33", nftName = "LoopPhunks #567", nftImage = "ipfs://QmZGSd2KHZqc2nmUHbjY8B7gVxmSRsQo1vrpCRPaKKibS1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13833acd77f587120944b8ad131b69b4dbc61b9de3e91a35da8065617bc5c666", nftId = "0x9481d64de1dd19c9e5f38381c056519a28afbca9f0bcfd6db72ba42c6b2cdab4", nftName = "LoopPhunks #566", nftImage = "ipfs://QmdPY8qFnbiPhA6kP3waCzUumU9yqEcvK77AQHSG2sqJYF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2d4821f27e7d0cf88ababd404c958c8fead71f707525fb941e7854be39d20422", nftId = "0xcc6aaa7a54ab718ff4a60c8e3ec88d03457a306d3bc2a0bc2111462a80bf127f", nftName = "LoopPhunks #565", nftImage = "ipfs://QmU1C1Lv4EPBdSUCky4mAKLCXHiA3NY7HVJTedqh8QpboN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x209e585837fa9ddf21da5725fada84fca40faca9bfce06c4a10f13f7b8c89204", nftId = "0xe7abccd84d2cbbb9f8ffd606bd8ccbb001c5c45049c9673a68cddcbefea59a4e", nftName = "LoopPhunks #564", nftImage = "ipfs://QmUZSvsmZ6Jj2aWLvsDAnY9pnUXjMmEGpgHoujRj1sQvaV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1e985d8322548891f0b9199b4daac5d017c48f9a81e77f14cdb497445260cbda", nftId = "0x1f122abe2e7ae553f8d2c08b11853f202ad398276f64f2c68c9517f16486fbea", nftName = "LoopPhunks #563", nftImage = "ipfs://QmdggdUeVXAYpX4hHBDGJ1etoLf42CVcBtbbdAXgQQM64Z" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13030573f93f348d8930bb7eb3dcabb7ae47f5771353ac3e0325424d0908489b", nftId = "0x0c5c8574227f5d666cacb3f7c6b42d8b5d48d9388a9d3152540381477ef19c74", nftName = "LoopPhunks #562", nftImage = "ipfs://QmfPWYmmruoXx1T9Qp8Y8JowhigTU8CNVUxco2sMpiw72c" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1f43608d32f39da2b0414d89ee7a9121b19d05637ea3cdec0334db21e889e0cb", nftId = "0xc0bf4ffc3f3c68974921a5890571ecd5bee43df49d78652575fb20348726e32e", nftName = "LoopPhunks #561", nftImage = "ipfs://QmPsJSu2uqLr5nfkE16QZtymGNFfEuVPCxXVeFLa5YBo7g" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05a92a74a78476773f936a64f4cf2861394514241db4e6d6aa3ea960e501b4bb", nftId = "0xe1feea5d9e580452476c2e7a8fb5b2d31d52866a3131d19cae7b87865991e46c", nftName = "LoopPhunks #560", nftImage = "ipfs://QmUWKyTdpwgKF2eY8ZoBkXH6Wi1ACxUBVof8rHf4J7NoVE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x11fa8e427bab97370f1acabefa9188fb542b85ccdb0ebf209f6675161a9eb0a5", nftId = "0xb77d7711b7648e1d892c799f85a72ef6b98c88f4c285f3d25bf7e085c3a6c86e", nftName = "LoopPhunks #559", nftImage = "ipfs://Qmf6egrS5vG42Z9XT2PJ9asv3XNgQe9hYEUoYimRqjYZcF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x172f40767e63c54805f988a9ef461ea12d8ca94b5bc6b95a382e00be3efd9797", nftId = "0x988fa71c5615391d27029d592216f7d748d8a2cc040f4357597b0ac67c1a75a0", nftName = "LoopPhunks #558", nftImage = "ipfs://QmdHKna1zgdgWcW9W2xkZwh6cbnCb5NfnPFFME8QqeMyUt" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x194072c205e2df59491a0dea1e29b0484a4ebf359993495c144897e9693f8d7a", nftId = "0xdfac69a4a3f5d6ff76414250073f2994a9489f88437d238f000a0ec3ca1e8baf", nftName = "LoopPhunks #557", nftImage = "ipfs://QmTfgHPZdrSidSHkQRYG3ZghpufLRkkCrzcFAiLLmse9AL" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0137eb7a0000ef4eac3561e441aa8dff9bb1c0938c832cfa55a54da09bc57306", nftId = "0xf299bf743a49f698a56871806370b4df56f5b9c2817e519e279dc632498e6eeb", nftName = "LoopPhunks #556", nftImage = "ipfs://QmcpinapeiBneVKe5AZwJ5E9woExvYMBv5GcbEffq5UkYS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1c3c2496b830b8d52c73f8055172a22ef7a8dd4a675976d5f3be53d0c166e194", nftId = "0x7e1714511737cfd3f913f6c1d18a385e744b87578dcbc2270a81cafbce11cb1c", nftName = "LoopPhunks #555", nftImage = "ipfs://QmYeZQqocwYadXXwheV64aAuzQGYLM63HAhS8wECB72uSR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0d4c21eafcdb6045c457caabd2cff623fb5a079a1b374b9268cea88fb6c8d9bb", nftId = "0x490bc49b26355a61a548220ae125cb28ab073947185d3212f1de97869f4abb2f", nftName = "LoopPhunks #554", nftImage = "ipfs://QmUvud31YiBwt6DJw5HRbgTSafumeXuGEP8QzN3AA6NCza" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x20ee54a3b11cd13c46cf6d5150ecb9313feac99a5d5ef0610090f97807350a19", nftId = "0x7d4a10cefa1850d2a023004c9324127dec85de3f590ad1fa0f1dced9d9e28fe7", nftName = "LoopPhunks #553", nftImage = "ipfs://QmdPAV4fmT8cZQugwvYZ9UogXhs6X4cRxWTbmMzVZhLxy7" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22b462459c6c9b881022315224577a7ffbb1431b05792ee1a2469777b7e08af7", nftId = "0xc09aec65d594b9333b4cea14ac462d4c33956726f21698964320c5f62b8d0095", nftName = "LoopPhunks #552", nftImage = "ipfs://QmTPS3pc1D7pFdvpLtUowHDvsJFnAj5iGzpHKiiceCL7Eu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b3cc305cde247642b9267dc77b5b01879782b083b2908831556d5dd05bf6111", nftId = "0x909dd7ea97bc8ffa7f0759e0e25f6d75a57b3076082f17cd4d60ddf2d8072d49", nftName = "LoopPhunks #551", nftImage = "ipfs://QmeCEeL7BZnscq6e453GCPYA8mbyReLmZupVA29QT74DqC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a93a49226b7c89346501356d03cad9f148fd0a635d06b13b6cd55d6742be677", nftId = "0x89f642aa1bc021e4a286f6cdce511ad3d2f4cc90d2b8ab1be6b0328ae0c2578e", nftName = "LoopPhunks #550", nftImage = "ipfs://QmaJgiNCxtYm7TusTkn5nLjCsz7KtLmdaD9si88VKWtz2b" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ee41f92cf3b089e4eb5117197dc18ce125b86a736e8f1e7de519200358f94df", nftId = "0xe19a9d46787b6770f42363bc3efd7f6044c6732b9260542ae80dc1ae49d0074e", nftName = "LoopPhunks #549", nftImage = "ipfs://QmYnB3U5sYjHUncTsgzDfb959pRocNPpETYGjZ1pi2QisG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27137fe229205d5eb289bec588b0434d02bdf1f0b5715070dec03e34a9ad3051", nftId = "0x7c20f0f5ccb0dc31ec20f41265d3a586f32b9ca645ada8eb1ed381d5a65592de", nftName = "LoopPhunks #548", nftImage = "ipfs://QmPhtW9cG1mHJgyN9aFn5oSB787ZhyTxLzgHhtTnsTcwy4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ab677d5b0785de720ebd3570ea671f383ede79b873137a5fffeda434e571db2", nftId = "0x5342b41fa85ecb4e2aca6c3c1b831045d2128c743d95df265518c466dc593a39", nftName = "LoopPhunks #547", nftImage = "ipfs://QmV3eR3qeyBKSgr6LjDnhbfbxb8fArDrB9k1z47UscJdfM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a8cfaa267ec6c36ad0a9b329278d2d4b2fb1f2d7896838c9b8230743c218e5b", nftId = "0xf92b04affa60f6e40865ff3271e3bce2a85914d584f7442ecfdd23979025761b", nftName = "LoopPhunks #546", nftImage = "ipfs://QmZ7UwJcEF3uPLDT6tKWJgMLVCm5zDXkjWw45v56uXUHao" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x26656db40425bdbf6a3dbf24a76a0649654a0da51adb9de4e8a4407f85a4f454", nftId = "0x121c7a9462a9ce8fa6e4f62f3596f96c27eb464269cf1cc075907e28ce352d7f", nftName = "LoopPhunks #545", nftImage = "ipfs://QmW7QHUMMVuTUHHy1E5DsNkMo7RVhBDcTJ6Vk1eNEx1iFm" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05fc3260aa2d32bcf3729d1504a1e7aa72cbf73d12d47c51533ed017f038af33", nftId = "0xc6933e5cd97328423d662e6e9cef3f9e5798c4abc6becd4d3c4790de890701ea", nftName = "LoopPhunks #544", nftImage = "ipfs://QmVrDdx6mPE6Nyt4PuD4wuhgc2VSKhVyyQofAG5zK4s5HF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14d1e8fefaba26f9d8e97946142b057e92a8e0b5f38371d52c1a43e00512a6ce", nftId = "0xe8ff2759c78fc652a5d92c79404ce513309780ab84cd7a3f9023a92b82d7ecb2", nftName = "LoopPhunks #543", nftImage = "ipfs://QmciZCJj64Dhs2FfUv6DEKgni6pPRd8mLF7i6uUUqmv8aq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28a0eada533a623e33b34b43fa57400dce7235a8890232ba3e88d1c6b11a96a7", nftId = "0x9b2e145351978e079af393a421ee767cdf1a41a43fbce7796b3ca2f60ac3faa5", nftName = "LoopPhunks #542", nftImage = "ipfs://QmUkGkJ6EPxXwewbE7YtoSKciS4W4rBCpeHEs5ADHfVbQb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x106b097c66c3ac0f27e133be8e2a478b1cfbee0c64f550d2fa10c148ccc642ad", nftId = "0x5b23c83663a4fd1e75662647d7c3f3ae372e5867b6294d2555624378abfcea67", nftName = "LoopPhunks #541", nftImage = "ipfs://QmQAexoYzcE3MZJoikvkXQiu249c2CXrZyXt3qcr2Htjfe" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2af6e927a2f34412ca5bfefc51b9f2699add8b86e5770883bb06ada31412d646", nftId = "0xa4d44c7833aa13c716ceeffe4d2520ff10851b5c287e093b41ce1c349502d5d5", nftName = "LoopPhunks #540", nftImage = "ipfs://QmQa4AvJX3mgBi15PfgDY9S5EDMbpjfG4fVe7jksi1u8d6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x026dffbf469f3f5789ffb98bf19332b7da7a0a6c2737898df035c66c9894f267", nftId = "0x9648ae37b2d2393f80af6c660e2fb71b71fb34c96899005b003b0a34714b69ac", nftName = "LoopPhunks #539", nftImage = "ipfs://QmbNRVFmCR4K7tkzX1141bJHF3JPPP6ncCiGAbxALqkn8f" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ff53407f5ee2f22d4b3ceabb72c8f123b32a0cfa60bc6c3cdc4b866c9e7b822", nftId = "0xd6b49c4bcd6ad03e08c6f068f51dc5e3cb0dfa95793a7c76c77407b235d82be3", nftName = "LoopPhunks #538", nftImage = "ipfs://QmeavC7ZcHj1CNaqX4z9HeAV9ULXvvRr1QVGf9p8iPxaBg" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x031b695b65671a852cb139844944c4a4ae0dc6cb4b649c49baeed4361b50edc3", nftId = "0xbcfa118c6b67200a67c720d00b425ba008aebb6a2eead6a6955d5c73b6b72bdf", nftName = "LoopPhunks #537", nftImage = "ipfs://QmZMq2fdaorv7QGh2he4hF4WtFcfH1fx4cy9qKxgFJuNCi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02d9a27d73f927f66c13db5f6eb203ce5b5dfca4e507b74f6b7f579ffc76a5d1", nftId = "0x63a198ce258859400873adbebf1dae4d41082c4f002151a277c87b8e44436864", nftName = "LoopPhunks #536", nftImage = "ipfs://Qmaw7EPRHXm59pBC9VDNg8pnKPck2F3u7CjQoECPiSVBQb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x272c5e9c44652814f7e8bab054efdb90a0748dde479c4f55a7b6df6a02f79080", nftId = "0x048d645e4c2f86cd767acf2e4f5e9766531b358bbc058dcfde98b83840b6dedf", nftName = "LoopPhunks #535", nftImage = "ipfs://QmRm5QA3ocpx7GqqgdRd7FC1ohByuuuNF6okVpxwcDitkf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2446d3fbcc673fb32104cab3e322ff0a43b717c0c3befc8d6e8f791796f0f8ab", nftId = "0x7b1f3f76f059c824605c3e88f3e171925cf44ca4a081a228febc22fc1c7763f0", nftName = "LoopPhunks #534", nftImage = "ipfs://QmP2ky4NijrZ7fggLdcCqjoE76xRz8howRkTPkbTD4iYPq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2834bd9e6923b43718c4ecaff3877eb1fbeef69acebb6beb37c7d94cd56f798a", nftId = "0xa474aa688833d761fc59fa2ed481be84fd82cd5a786e88b1982b1d0075d278ea", nftName = "LoopPhunks #533", nftImage = "ipfs://QmNyhKoSZcy8BffDSXQEzcMNNnXdqDS2B5yhwM7zEz9PHh" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x19470c2d36eb146bbca5aebb6cad161bf6940bc5274c113d49f3c2dc0bf3351a", nftId = "0x2256d60740775d7eff7ea16479cfe34cb5977445cb037dfe0ae113c9803efa3d", nftName = "LoopPhunks #532", nftImage = "ipfs://QmRqiMTqmsCWiJ6J7SC6EcGRRmZjgdhKivfHe13AgPHhh8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x204beafda3aecf8aa14cc9de177469bae1e825730eef0502d686fcb970674e85", nftId = "0xbd7734729cc6da84cdbf144522fa3914f582d15ccf3217f98815fd92ce0ca1eb", nftName = "LoopPhunks #531", nftImage = "ipfs://QmRB1uct4cSUibACYb7FmepVHF9PaK7Xufs5F1Ni9UkLda" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e305cbbd2f050dcc6050618f8311875b3b7fc7c2a1ff7cc0b072b65c9c1261e", nftId = "0x0169c3d85625eeca84907e1891200e693ec6c348eb1fd342513dcffa86f35269", nftName = "LoopPhunks #530", nftImage = "ipfs://QmTN7ow8tj4VppoKjwJ6X6Fx8JMMVoDYkrw3AzVU2UfuUK" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18aa533667229bc0f341f85b076032b70f8627d6ece8546c6d443eecdfd12888", nftId = "0xb143470611469c7d9c4bc0347142f6546733864d341ef1d905e4080aad49b5fc", nftName = "LoopPhunks #529", nftImage = "ipfs://QmSWqVawmXif5nti4YmJLw4YQfNUWPf9erRyDkgzTxXUg1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f33f6231501ac9fb2c04cb319c223696198e4e5e57b55712b44520d790327ce", nftId = "0x536be4074fa02a757465851677ae52e7be251f7f1b7a9f94f843f993e1b18807", nftName = "LoopPhunks #528", nftImage = "ipfs://QmQFsvwJeSqdeU5y37B3tJZjt4qDaAgLrovNQnF6Dcf9h3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07af006f0ea966cdd9adf29c5174c26abde846355256b94fd97814567418d5b9", nftId = "0xb3f68e27e5418c805d5c941923f97f4ac5fb859020497f853095d8fb3dd04fb3", nftName = "LoopPhunks #527", nftImage = "ipfs://QmSnSPwB9CbXriUxg7GL5GxDfGW3bRvWNiivwYgT55LpGU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f05ce50b2aa4e9894682fa82c62cd9b2eabc9c9e5997a7914b0344cbeba6e0a", nftId = "0x787b5662b8ba46a335a0951362dee9197e28af9a3f2511c0890e45e9e4adf1db", nftName = "LoopPhunks #526", nftImage = "ipfs://QmaPk8iH2vuPTbkTcFnRpQBXh8713vVK6DrU1oXEoxJteX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x262a76fd541f5276a5893c350173f7e5e1fb73c9a85f945bf8482300a051e5c6", nftId = "0x4549b6657d91cf5014a347755de06fdb9b74af3581a6956823d23152ef75941b", nftName = "LoopPhunks #525", nftImage = "ipfs://QmXn84Jhhj1yub5zSiAAHYJfKvTsph7ggSyXdXo1PpLdh2" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x01d915436a8143293ae20f1194112e07d6e6c685055ff43c405e3612dc818e99", nftId = "0x9e62af68d313d33f1d5509fa7324b788ef19f69c56dc6773d65c8a382e166ac3", nftName = "LoopPhunks #524", nftImage = "ipfs://QmfPWfHmpkv4NmBp8XYx6aBLRiyz7A6pcg3RrpGcPfFRK9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1fb12d607ecc13b1633ddee187147df33459956b182654d6f021e393360d05f7", nftId = "0x2f80e89a73baa32c7611d3bd22af13cdbc1e30026dd6216cddf8d57d7b071b76", nftName = "LoopPhunks #523", nftImage = "ipfs://QmUauvUtaMMKfiyFQYrLJ1USTtFsYhnHV1ov8EN1hDurTE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2524941233bfd719370b501bca0f5023b6b359db71eb1ccc2b691c63b7690c68", nftId = "0xd1d4a645a67c7b5f6569f3376dc420be570f2e35be118ab1e1f8ee680339257a", nftName = "LoopPhunks #522", nftImage = "ipfs://QmbkYH3KqLuxoMVsT3ssvuWLM971dY3vAgpKFNLcnQ2VYU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x21c19768667dfff7ac8ad1c18ca22ad102f8387725c0c89f4bac1cf2fd6f1675", nftId = "0x9c8aecf416d7f8b0228b94f370e1d4e36c6ce4a7121632698346b6949946a253", nftName = "LoopPhunks #521", nftImage = "ipfs://Qmf5uicZfBMg6Q8EpdEaKSvzGp4h8DFwx5s1EkYprXtNQQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29c71da4bc48acd9746a00961d1e41314493d70d43eea114f66f6e1a0a88b5ca", nftId = "0x58385d0f7c1d443ad7087b7304c943e7c47e619c8a9f983c4dda5f4407f1f6dd", nftName = "LoopPhunks #520", nftImage = "ipfs://QmUDRU9uYAUQzX8fB1UdGknmGEj4L4JbTTLFszgGc1hWpZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x12a0a16f19d6d242f6427d06e00ea52de93336eb44bbfebf4db9bd90741927b3", nftId = "0x0ffa3fd4fad32254871a62693bdd897d1982800590accb4cd9f5457b8db3ebdf", nftName = "LoopPhunks #519", nftImage = "ipfs://QmZFUK1HMjr1mqQwq47oTtkd43J2VU7Z9xCrATo2H5aBjv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18c94dcd6e6a84b2fa3bc7353bba4a3ee47b5153608a2e66917a80bc6198628e", nftId = "0x3b711d66484bfad89588792901f0bd6b0a86557e90e49fc93171d442bf1daf93", nftName = "LoopPhunks #518", nftImage = "ipfs://QmaPKWVmBmkHEDo1BXmvoLUoB4eD1cv1qUST2ukHx611B9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02afc16572ed571e831a6b574875c5a9110775a3133d4936577d12e3a6bff831", nftId = "0x4e26b368671cb53a2dd374f6b3559941792987deeb31a5decc84dc18af901f44", nftName = "LoopPhunks #517", nftImage = "ipfs://QmVqsKWqHYu4k4mC1jfAaFcpLdrJ9ajhoeno5aCco5dfuW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1dd798bfb0b7baf4ad7a8ad826d054622c3ddbe8288781c21f8ccd98d2cdd2f7", nftId = "0xbfd30643a002a1f2e4fee03a2e0646568042c95b669f97067a542d67aea39e2b", nftName = "LoopPhunks #516", nftImage = "ipfs://QmNbFj6upft47wzCdV4gdSLBd8VGtfx63JuioLGrDQ5SPM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0fd56926af8e0e4936b20d43277e96fecfc436185db89e7e6f3847a2d12bf55d", nftId = "0x2ea40ce5820e673600a24ab07b262c0cea1cfb6e2d0bb70f5c80c27fb7302fe1", nftName = "LoopPhunks #515", nftImage = "ipfs://QmbBiXb8k7fsacZhuwQepnh1iyj7o7KpSmyHSzMk1mxYqD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x262a29bef237e6e36d27c8cb3e121ed9dfba5db5ea0792d16d32bbe62056b8cf", nftId = "0x474611bce47ef6e5945f84d7f5d0e2be5a42b0d26dcd183b67460779a4ac9b80", nftName = "LoopPhunks #514", nftImage = "ipfs://QmTsewH8RjiZqXiUL37wwzWgQKhTH1jWgG56DW7CDiVwpX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0195f86ab9dc0c12bf02a8df2a0fc14e3e401108e7727feab183df08f1a3f2fb", nftId = "0x98bef761118a6b0875ef903d0b42aa228de83b74c39dc67dd228fa0605e858a1", nftName = "LoopPhunks #513", nftImage = "ipfs://QmP1i6uQaTZQLRi273q9DwtLbAYEWyTdnNWxb485AdkGN5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a4c824660b819cc184355a2ed0ce9dad900434ceedf77972c5c0926530c02eb", nftId = "0x240146cbdfa695f46c5655f5464788b8bc7ea755994cba485b2e7654aa5b984d", nftName = "LoopPhunks #512", nftImage = "ipfs://Qmdmk2My54Eqzeq8dRzBxwc3yRwgGQy4HmPLKJywMQx8Mo" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2489504856d817399b17d167495ea786d49951a3a4b7e8ad7b001e8f5a2a1397", nftId = "0xc6bea22efca776089ca6c7fdfd28986ffc4e2b437322773b170a65fdea2f974a", nftName = "LoopPhunks #511", nftImage = "ipfs://Qmc9Vh1n6SEER5v97s9KYjyxoooYa6H4ro1fnYgeWSFKga" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x119ba588f77c7689cea30ebc771da58084d22582dc01dbf759cb30efb24479c7", nftId = "0xad52ef2ce0d31522f92afb3445ec0cf980e3788e840116d2b2a8ee87703c7bd8", nftName = "LoopPhunks #510", nftImage = "ipfs://QmahDxAzkS2mxxmT3uhwmSsZJwX4QRW8VzQjo5oxLK7Y3h" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x26d26f027ac7073b4ed1907ee191664a288757de5b21072961ca2a33cfef04f4", nftId = "0x9eabbcbfc2891ace80076207965a9edca969afc658085c125550a8f17d1d9987", nftName = "LoopPhunks #509", nftImage = "ipfs://QmRsYodDxaAv8daacS4AMhKrbCKztcux1E4PCuUyvpZd7Z" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c1965de8be057c82b5ffedc57cfc16f08a821d252551cbb529bb2fc7de2dab7", nftId = "0xdb57f448f627a5a7c15758c2172631da230a43a116bf6a7aaafebcc4fc2d8644", nftName = "LoopPhunks #508", nftImage = "ipfs://QmWVMxANNEiN6dDo4B4CtWdoSwdxjE7otnPQ7YzoxmG2gF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x11b96397f57bea62c30dd960eb75ac54989c2d0493e12ced3a2004ed619c22ec", nftId = "0x2267e5ec6790ef0e35bae01a8894c80febceaa7850c2b3b3d7d0b0677999ad01", nftName = "LoopPhunks #507", nftImage = "ipfs://QmaSfUBNJBB3ZPGhitTKZ9id1ncC3nVfmDBo3SnY1eDENH" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1b1399e6b094213f8137ad2cdf803381b0be21abc47e9c5a846a3128539e2c39", nftId = "0xa74b009c7ce530d278ef0ac35fd3def5a5590c4c0a365d4fa12516237fb7fc77", nftName = "LoopPhunks #506", nftImage = "ipfs://QmZ6Zbmuf2AC6UzT5PPJQH1hvq4r4wYGTVfR23FGh1mBcq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2fec0ddce554500dbba5371387ac3e6404d30c30e0267cae8af3a94670badc76", nftId = "0x5683a2b8aea56fd63eff07986eb7c0abf9a269f28685428f6a364832800c1e1e", nftName = "LoopPhunks #505", nftImage = "ipfs://QmfD5xRV7wWpxEQiiTi8SekbxpyLDoR3BrQrXNLkaQjYc3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b3220bbae575d26d75931af7988638d20f44bdf7ae29e8844259843e57b642c", nftId = "0x4e9b3dab9de81dcdd39328e15412117f732aea0b955779dc85e708a59dea759f", nftName = "LoopPhunks #504", nftImage = "ipfs://QmatG3AqLDeHCbmQLG5wtFgsNSHRRpQ31fL73KVkRadp1x" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0837543ab3a16ef3cf319725af53864d5b77d21788c396183a06c4d19803f05e", nftId = "0x56037fbc809ab2d4d73642fd541cd70e116f81201e11ef15c7f94cf22b0392a0", nftName = "LoopPhunks #503", nftImage = "ipfs://Qma5kfVjDKjW9g6DZmQVttBomo6V8jpPvMcf7A6rWFG5Q8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0eaa14d2eea74583cb63120a537932aeb8e9c9ee18093d516868bf4ce29bffb6", nftId = "0x73320d26b834ab54c5bc2a6fae7d1b33f3b10826ef40dca38ca028837c3d3da7", nftName = "LoopPhunks #502", nftImage = "ipfs://QmQHdYMYcQxAb5TPLeyd57xVGhGAk9BhgzShpt1dcDww5h" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x018b87c002286c7b66416982cc6ae92286dca14fedad6fcfd09d5d9402f1be7d", nftId = "0xc43d98f9d2e03ecd71aa712a71e9bc5b19aba7f66d36bdfb4c36bb8115825f5f", nftName = "LoopPhunks #501", nftImage = "ipfs://QmXmihAWSzGJ9LqaHYDvM5stzCTjuGSgSrsLSsqbZXSnju" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2df89ae1f2e9de72267b24aed193acba458041fed64b083ca263ab95ff643ef3", nftId = "0x9eda44862accae757be2a5680f791171b08b924aacd0467b673ffbd6e051f3c7", nftName = "LoopPhunks #500", nftImage = "ipfs://QmWdwx4eipkFZhjnCf6PCvdGJi1Lv67G5mDJXB93rbUscA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1b92b42dd64cf018d7a765cfdebb8415bbe6cb72ea011c510fb9c864116c6701", nftId = "0xc457d48d03fa88119c247dc2e591dc5ec3a02d8cb4c560958ba046ab6813b114", nftName = "LoopPhunks #499", nftImage = "ipfs://QmVUwEhz9YipmnqDEDkV8JcpXjEbsVHDfmPxJzwDU5Mo2d" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1314c158b9873bb85a5ab86f8c1b0224cbc9109fc0432daa601b0c30f0fed723", nftId = "0xebb813242330ca6152354ec6c89857b47b65906a07b5408f688fe893f3a72ba5", nftName = "LoopPhunks #498", nftImage = "ipfs://QmPnNhuzdXDyyDvEdCPYVKPdCZ85B69RfEAgYMcCVMNGZC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x298e00a74c4d882a960de3c6ece8a65d4fa58d5881eb9f7b78140890008bd077", nftId = "0x7ccb08413edba8906bb7127a93bebeda6e9f7386530fece9b3d37a2f6f13fddd", nftName = "LoopPhunks #497", nftImage = "ipfs://QmUu2CN6PqjpWzRGMinqYaztMEvG11jytCZwoRYYD3Djgq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13077fba8126d33a59048df1f484363e8ba273e79d1914e006aa87320b3765d2", nftId = "0xb45a5dfb34aa57b0c785d00ce4b3a1b844316f9785d208ca04290ea4b73b41a1", nftName = "LoopPhunks #496", nftImage = "ipfs://QmNk7xibadcqYyXNvsDxKqLfM9vQ7kpnK42YCxztdxsH3J" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1086c1fb395eb33fa5f8c6474649bddc3e1aa0cf8f678a36a51eacacd4de7c8d", nftId = "0xd1344165c6f99d0d14f6ecdc576dcdb90491c12175c02a1d2f05d8b6492e3466", nftName = "LoopPhunks #495", nftImage = "ipfs://QmUMDLvtJaQj3GZNDSbK3YVbb5jkq93GDukYw5LZjTWoD8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f12d2f6d7db3ec5f32db47b47e089e229089b4783e8db70ec9c3c8d96273f69", nftId = "0xea9623737c39ec07efb4b87dc449c0c1f64b09b8a2b7c249055dcb741779dc13", nftName = "LoopPhunks #494", nftImage = "ipfs://Qmegy4t27ATHtQ57v6DbU6R13RHgmEtqLeKpznRfB3naS9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0dfd7208c3d529abccd364a0fb43f07b7307c30be5245ddb5c3e5ff30988cd17", nftId = "0x77d68e702990e18c8465decf921005eaa18c6d862fbfb399e28d7bf929bb89af", nftName = "LoopPhunks #493", nftImage = "ipfs://QmadeiJVwi62C7qCiVYF5Vw8HVavR6xJEkumYLzDPTGhpB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x050f2179fb7127bed0efc719c66cdca7e1f8f86ecefb47ae71827daac17c41b5", nftId = "0xcd1c69d2e2a1526c9d31432a3d2261c66808067b4f11950c5f982c0df55fa42e", nftName = "LoopPhunks #492", nftImage = "ipfs://QmdDnr9TkD4YUNjAeJQDFT7NPKiCPy4oaD7yVJRunRXz1j" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ede846f01ccd4015460702590c5b27c6241202397fa13063347aaac216f1630", nftId = "0xe289522a62cb44e5f5fbe4d14f63b170047d1e0f664a8c8dd51b4231b13c9d24", nftName = "LoopPhunks #491", nftImage = "ipfs://Qmdxdpw55pXJ5xjmssZt5CtQmz5xG9HXgdkahYBoxmvgfa" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02c1f36bdcf061ec16ea39335da98b3e99bafa8f9ad0504a9293e96793a1d2b0", nftId = "0x21fde670b64535f5c30846f4717604696c8a22ddcd728f0e37e1cc8a1a1121ae", nftName = "LoopPhunks #490", nftImage = "ipfs://QmY7yQEEEYY5y2udYTurkj5d8pZygtzptotmJXWaHhfU5y" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e4e58518af20de09e3d20759d5edfba493a86a2e38383d94a04a759650e99df", nftId = "0x7a8aaf649c7e1e12ebc8f7ab940cda7642fd9406bae4fd5adb31d92c1abca360", nftName = "LoopPhunks #489", nftImage = "ipfs://QmdVybZXa3GQjFu2Ha4C859ESmNLcPDi8n7DZsaL69PzZN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e092275ffd27fb420fc4d3731aced9a06a0c7f41b968e83f60da29239323e76", nftId = "0x752a5332bc924d1e18f0b334ed125382cc9b97372746096edcd0e59cb3e5447e", nftName = "LoopPhunks #488", nftImage = "ipfs://Qmc7QuskhtWNUbouSWsZxRku9uzBkq8Q1azs6XCJQR8TFc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02479e35f74e6753281d2786f71cbb95915fbe718df90792169e636ff5db76dc", nftId = "0xfe361ad1aa30aa3284bfe80b7cce769b0031604504a874b31857bb41c5707e47", nftName = "LoopPhunks #487", nftImage = "ipfs://QmUafXu88bA3HvfRmntqc3Pjm4gVCtcC1qSv8e7SVSoza9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0bc420cbba154214bb639cf5b7cd34d088b64f2d7e5469c5bd0749b6c7a7481e", nftId = "0x0b142eb67cd43deb86aa08bf6be51cb264e0e10b46fb2d8c36fcbc5a34967c56", nftName = "LoopPhunks #486", nftImage = "ipfs://Qme54K4we6GeyZQALGU1MXcoTMPyJzHrRU3d3K8tAiSRUX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f805364d18c3197d99bc8f15ba7d6ae3a237d42bd249b56e93ec3caf725b388", nftId = "0xcc6a73e9442a2a8061528f8389498bdc8a803ce972ed815990708344310520e6", nftName = "LoopPhunks #485", nftImage = "ipfs://QmTLzqe4EUZoKtWfb4mDRQ1uUU2UUxx5f5jZfYLMFc1KxC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c01ebc3265d6fe949e5a1293d722a17dc93be3b465c1957a53f23e8aea8684d", nftId = "0x294823f13a479e4c464e1b5398eab3af439bc4ce3cee1a731f3537a4e781ddc1", nftName = "LoopPhunks #484", nftImage = "ipfs://QmdFazJd8VVv3SdagPokkeU2Au39eAxMUiJihywbaKSCR3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x196c4ec44891ea8aaf321dacc9a93c77f9088d38afd2c0997de4cbd13ce307da", nftId = "0xe454aab0864ab2082c74c71b060a076ef52fe9e621014eb97f314ae0bfd487c3", nftName = "LoopPhunks #483", nftImage = "ipfs://QmSGfsqqdjihgXHrDLHsoRFpcEmmWyhtPZdHGsX8XjF3rX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x21dc445ab27540da436542d7a0ea0ad3fe131d99a5532db0e9daa727a40976a5", nftId = "0xb2ee41d6ab8a841dec2767c0c8767be63dd43ad2656678c9838b6cccd95ac749", nftName = "LoopPhunks #482", nftImage = "ipfs://QmUMfRg7hhvvvDgnAf8geFiy7cbR5Z5nnQjfQUsFQvKsee" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x26894c86d1d8c90b4c89dee1adf728f320b25c3e8ea3003602e9a6e6fe43b22f", nftId = "0x1f04d96de75e20c6160b7ee94f93ee36e3d42e02ade4792e21ce9fc61fa001c5", nftName = "LoopPhunks #481", nftImage = "ipfs://QmUBtfk7kDnanCEiESwwts4QJJ4Wcmog9cb2tjC2dZo4WF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27727a4ca264b26358904c41827847af947c50765bef941ab9e9fcb29553bd44", nftId = "0xc175ce8be264fba861c306990717080b95082f3564e0697df5508b4042f5626d", nftName = "LoopPhunks #480", nftImage = "ipfs://QmTYo2T9zETnYq3JHmitrSRThE6Vfwi8XqoPETeSJ88ib5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1dc10fa0cf1affb163244bf932da498f9da03117bd20099da4649b4f3daba322", nftId = "0x7053b046772757245690955511704b80e86b00286415746d830d1bea625d7a3e", nftName = "LoopPhunks #479", nftImage = "ipfs://QmSu3aZqBRpP13ww8vrMEHpmwQucBQVZ9kkkXsAZLtq7Vr" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00d58fb4916b7e30307c424fbc7f0c628f1cd28926997526903341081468fc9d", nftId = "0xda6cae1f2c035b8d1887a32650d3f6ae1d9c11ca46b35fd146418b9930a0ac85", nftName = "LoopPhunks #478", nftImage = "ipfs://QmXMGfdUBLMSchBQXAGRWC61QiqJRFW8jEFaj7tvnccHAU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a04977a50e5e6e0b52faa9bc4bac567ed50218a2918df62302ce1f08326db4c", nftId = "0x3704f644abf59b769be722ab1e9a7cc34e136bbc8dbc9d3c628756adec14608b", nftName = "LoopPhunks #477", nftImage = "ipfs://QmUk3ru6A2nkPaQKB2Adbpz2CQd3rxEYPtuH1DaHZW4bdP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x10d29f2198a21730c51177b3b0e5ddcf4081089625c09757c42904b29972822d", nftId = "0x0cba97ee40c027af59e681551b9193599e4e4824890ad9ae08243b80a458996a", nftName = "LoopPhunks #476", nftImage = "ipfs://QmWYzD6Z35YK5v7F6rMZzdNdLFyk29gHvSJbsa2bmidAJA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x236488dfdbe65fcedc888217a40c4517e68292dc5a66e59c9f5b20fd7270bc14", nftId = "0x58206d481d756b9973ff2d54e4933ae7a224a42cd8fd33aa09572bf08f07e276", nftName = "LoopPhunks #475", nftImage = "ipfs://QmWUezjAEfzE64GtjCej2pcMTTU2yDr4bZ5tyTY5bUHm4k" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x19adabedb65ecb49674f508649c8680ff8154ebd4d84544680ace73fcfc9c87f", nftId = "0xa1efff56957464cfb53d55b86a465be4863117a13d301f48437742e2a79d7b92", nftName = "LoopPhunks #474", nftImage = "ipfs://QmdzsG4ThD3Qq8QGfEeQLDKQsZHyK2QHwxETuQ3R5vTEgx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22281a47a5a6b72ea8cb0229c8ca57331b97304f8deccad2b3bbbe22ea15e996", nftId = "0xea06bb31a8a8103d3cad55731e4a50cc15ae463f34b9e72ff0b957fa79d53282", nftName = "LoopPhunks #473", nftImage = "ipfs://QmX3StFk7u9jEFB8RB8Ncm7ExPY817kwvXZ6xKRgkoXfuw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a51a017aef7b14f7e8d2fac895caf2b08c44edeaa23944aa8704787997839b4", nftId = "0xa9e3884f9e0261b9cb79b6b90b5f2b1a8f1df3b62c2ef4d79a965a4f203d1eb1", nftName = "LoopPhunks #472", nftImage = "ipfs://Qmdd6Qw7kMyHnfRRHCJTm5d375TUVA13HNQ6kPzsvRpe5z" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b6e03c14d05e431810722211e6a25679aa49ea257ed0997804410985a409cb4", nftId = "0x4c0bf3a0d422319d77e25b1f6909c3061c7690c3e0f5181ed3f74f0227d37550", nftName = "LoopPhunks #471", nftImage = "ipfs://Qme2yLpNGtQcd444xzH9mvv46jnRk5T77NfdnwhegP7HT5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x09801c77677e202be2ecad2aa4796f4419ed4e9ac3db3a32e9c6cf41c9416773", nftId = "0x82d0ccb011ef96e0446666fb58580c8cd0af72879ed67126529454f51f83e325", nftName = "LoopPhunks #470", nftImage = "ipfs://QmdE3GPuZmseVMtujE94ZNqTYvXnz1cKTjtkdiSAsmE6jj" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27579dbaa38fbc20a6437e0b728d2d07562f69e9aedc5df048542e230930a8ca", nftId = "0xb321c884aacbbb7493b59d9c6051429fa01a052e92a2d114abd7d22066313020", nftName = "LoopPhunks #469", nftImage = "ipfs://QmSKcvSN4SfP5d2YzEqbwEPUjaL34okvEhrWHqg5KxApqc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x095ac4e3f1e48fd216e7fb64b865f86cedd39aaec9f698aad59478117643f541", nftId = "0x47c9c96df079115aca18de88eaa575b9b4559572ac4f9d49de208496066b9248", nftName = "LoopPhunks #468", nftImage = "ipfs://Qmag9eCsHgL7ZNyo9BcRPWyrms8n4goCPDg9cjw1Ckwo2p" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x165eb6cf28668a3635e7d6e3a01b7851ae2d877afc52d38fa784581803a49c1b", nftId = "0xd45d527727cba83ca34c51739b09b12c41a4c03470ddf0d180714889fe65b3c3", nftName = "LoopPhunks #467", nftImage = "ipfs://QmYjeZRcPT3n8rFTNrpRMs7SEHw81v11rZpMpM2yjoYuc8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x21891b919c66ec83f5e113c18f69d521cdbb1c48b5774db63f7f63dd68832943", nftId = "0xb602cea2038f11e2fc035e1372e2488f4923da9cd0c9acaf6eaa50654e4b13ab", nftName = "LoopPhunks #466", nftImage = "ipfs://QmbbfWtqc3YMFyYCVU4JkzX4diQGr4AEEpeeTkc4jESXG1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0eb314d5a8394664c2246d9406f40d33bc4cd3d5e207817f8561f4be6b12383e", nftId = "0xe702d34ed104548e7c753b7635182b13cf5b8cc05a541a516db2869ea7e67dc1", nftName = "LoopPhunks #465", nftImage = "ipfs://QmVBzCkxSg4P36Cvy1oQTwqkPYQY7EcwY6zAk8NdWxRLLR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b7207fa82f6568e8e4fab8dbc31036202d9573104311401c46e8c634719b1bd", nftId = "0xc3d0aa33e3588cc4ef19e4e388fe09aebe1bda442e29294f4368123e533cf43b", nftName = "LoopPhunks #464", nftImage = "ipfs://QmUwQ83HgGGtxDZy8TWnk5aShf36cYgSmBa6hVGELKTh98" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a45e844d34400cb9a42e00613726f3822d8eb293a434fc9cb26df987a6161ca", nftId = "0x88b034628e5a9ccfe13dee0f656ff02624056e5d7604696db03b887adeaad5b4", nftName = "LoopPhunks #463", nftImage = "ipfs://QmfVVLNzCEqy1jwcXBubc3s8FvroqE1c13sP7oKfkcqxci" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02420829e05039ac462a5cf7c59a6fdc6191728cda482069abfbb1c06a7284e8", nftId = "0xfda0ee787056bad9130537e0d5dd1475148c5da38e11e3fce333040f9432d3a9", nftName = "LoopPhunks #462", nftImage = "ipfs://QmTWT2rV3RdRX7WC3vHG2gnbPgQhXFbwJDn1qHgHWdQios" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28a5c191162f14026b26ecb5f2a674c8b3d4884357877ad853e7942e46d6bd16", nftId = "0xa2fa30c757ea559435dca37b4aa28b33f24ffa35593f3b2e1110e14afc202715", nftName = "LoopPhunks #461", nftImage = "ipfs://QmerGiAdb67H4VigLLP6oLmzGHuLGLqVKz4rBZPPtU4P4K" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x262b526573fedaefa0370420ba8679a9ca8e8a616206959f9dacb23d76bfa0fe", nftId = "0x99d0b83954212881f329bb9ca786671abaaa69ea43c16ebaef31435a793e798b", nftName = "LoopPhunks #460", nftImage = "ipfs://QmVWSq1kNiboSX4F3PgL9yPDVKawrxJZtHCK5VVfw5M2xF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00334c06a66a8ce8d664546a523d3d93d14fd54034c90348d92e08a4a8807050", nftId = "0x9c20792c620348486003c4a7f5221df8b0760cb29bd8f6518db0c39f82e98ec5", nftName = "LoopPhunks #459", nftImage = "ipfs://QmVCrmV8nhNFduNabhBVSyWcfqZ379qWVNbyMip5LU7uj9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28c41176909603824784b74531d0a735f5ea6184ced5951bdcaf5e114d77631e", nftId = "0x87c428d1b6051ab83d3a621a902362da1bdae084e2311f17a4877fad48d7015d", nftName = "LoopPhunks #458", nftImage = "ipfs://QmdfnAx6HKSQEPhf8pJTg3ApZqJFaFLnCNe2sV9BkDsvXu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a640d90dba1beb32d8cf22b4076150d86e438591ab6874a873db67aad73eccd", nftId = "0xc31b8c25ae7b924e20780eb50e96ac953756e15caa7520f862b88d2fb956c83c", nftName = "LoopPhunks #457", nftImage = "ipfs://QmNfvZ6UxhhmvovEdLVpEZUruoUNmifz5YuuUpTASC6ZZr" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13fe9fc9290b74fe3de2c9ae03684c20b53c74dae78d00c11b155bd96378e656", nftId = "0x5d2e20c0eeecd690850e62bdaf108c721c9270a696cae6ae2f7e8377c1287b08", nftName = "LoopPhunks #456", nftImage = "ipfs://QmeWdXbunRBLcM9oDmFuQL9Xx2YyTRaQETtxbnd4X444iC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x057f96b84dfe37870c0e0b62693c7122733d2f0b8a295dc3da6771b50f1f630f", nftId = "0xb20a76dd15c224f3e661b508266897dea497fea414e97f273722f8b1bacff8d3", nftName = "LoopPhunks #455", nftImage = "ipfs://QmZkRX1u3X2bUgvvduWQTdCsuPi6FGtsXfJ7z8UGpnoG1Y" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x013aaa6b298a27234308eb1b5ccf22c4551ec1585d8d10814fa800225334edc4", nftId = "0xb404afe12e644b6d82892b59218f5cdd78dba862af3ce8bea5d5942e16868568", nftName = "LoopPhunks #454", nftImage = "ipfs://QmNvtnFTPm1bKfKjn3P64QokkZ4otgQov1qJrL52kqqXoo" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f9d5298bd2e87b0a3d68905c28431375b8ef98752f1786025fa3e5975491574", nftId = "0x7edbcdf1a1c6f84023beba31b841301b94b79e37b31b2ec0048076bf3a028e26", nftName = "LoopPhunks #453", nftImage = "ipfs://QmPqs67bLKpFhPdPUZ2tcLQ57mF4NB8p1mSTZanHFL8c5u" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0033c73e8953c30435969f0f908d3cb30010d8275ac9190a2cfdfca4b1044a26", nftId = "0xa87e8f27b70f03291b3bbce2263305bef45deaab8ae338cca9b37a44c5c544eb", nftName = "LoopPhunks #452", nftImage = "ipfs://QmTWwU62B8xuARwU6QKHqtzqKGYkNsgmZYAYkWFDidADVe" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ef88b2f5f1465e1ae23c77dfcad7c8f277b2ce2704d823f905d730cee01b1ad", nftId = "0x0b5ecad9181924be97e0777fd448d03abdba4893571cb49601c6316f86e6e41e", nftName = "LoopPhunks #451", nftImage = "ipfs://QmWEA7bQcFDVg9h97gJUTLZmLc3zfkW7tjpAJXYXUnk3q6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13d10a7ca1ffc23aaa3571cedcae1f4fd981ee5d3fbff55c3a6ae33d8193fad2", nftId = "0x9085081acc72ea470f30318495da8cdccb4e89bc46d787ee655537be93e16010", nftName = "LoopPhunks #450", nftImage = "ipfs://QmVYe3mz8UKxTZpeBAiSNnZsthgzyK2wtDBMkMGKskUc6X" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1c272af8fcdb06d8efbccbf42d3ee538d875a088917af4daff5262aff0d9d232", nftId = "0x296639748002fd651264e46c2d050357af99671507be6c2a9d499c8a58d30546", nftName = "LoopPhunks #449", nftImage = "ipfs://QmYTWFU7WEb8CKM7cLQVBN3zAQTMj4MRgbPD5Cj6L6vfUu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29a7870097cf55d4a55226588ee1944821ed715c04b24b716800e92e489701c6", nftId = "0x72f1e7b0d3af4fa1a446147632082383daa4789ca0c80bf48030670f149cb738", nftName = "LoopPhunks #448", nftImage = "ipfs://QmVNvonsdvvhKivX4asb87upJNpoZhBQmjEHt8H2yGLosu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x16a863b42c375f57b0b624edf7f62ab7fb2bbbde240069db281cacc04f1df6f5", nftId = "0x44b043c620178cbc8a06d62c08add32762593b32b714a30342bbfaf8b491cf3a", nftName = "LoopPhunks #447", nftImage = "ipfs://QmVY6YCN2QjnLJvJLvG31zUb7ncm9nxNgTp8yRf7KMWkcQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a0e4d42e342f1aeaf0f8a34647bc19c962c40b6e984ec49e955ae801169deef", nftId = "0x9ed96364bb98305b796421e786bbea7eea3a5ad0f0e0abb11a3b03b335d7f6a2", nftName = "LoopPhunks #446", nftImage = "ipfs://QmQgMQQ3vnM8qq1VDCk3K836Xpi6bN1iXbZvsu6t13NmB5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1aa712b6b6c8dbb8ee3e4ccc6d204b3ad3afb7892c3c1ef87ee2d03dbb6bbcf8", nftId = "0xd8fa017a021630d7c749ba013e2f5d83322ea43295a02a2c81329aa17d939b0f", nftName = "LoopPhunks #445", nftImage = "ipfs://QmcPAcVmm8iuU4Bm8ZTvyQbrDPL8sKNSsHZPxuwGXay7RD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2240a25754f97a56d48dfb2c34e2699bff3fac838e701284f46dee2779c485fe", nftId = "0x2f5893765afca241b2e3d7cccb5b34ed67bedf74159430ca57dc4a7469b15a87", nftName = "LoopPhunks #444", nftImage = "ipfs://QmaPVZCpCrz8jKyuZdpu4uBzHciV6RVbSLBzK3De5TmoZC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02ed8848a1c384dee9ff34626534da90082118f3569b3456bf6a905e35629375", nftId = "0x2e6c4f9dd8221e2f0d9096ff4be607170abaa5465463d2741fb0add70e89f6a7", nftName = "LoopPhunks #443", nftImage = "ipfs://QmbMwiqc65hpWAbPjKNfYX6Yg1VDVsgNpNXN6oHvSAm9vd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22635a43ce3a395b633b26ee6d8cb9b35f5de95682ac2e1cbd4b54918fd77ff3", nftId = "0x78f80e7622bf9a21690a77135a98fe7b6ee234f709f667eb7d6310c0592b4f3a", nftName = "LoopPhunks #442", nftImage = "ipfs://QmV8xn9CFy3QmCio5NSKEZLmCWY4csYNEQovRejw8Csp7a" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x127f38105a91ce870590040e3a21b9db66f38505c7b3aacc1f7b58a3eb81627d", nftId = "0x644ab0257b52434db2f2e15e51ebec81b4424862ddd8faa3eb6223e72fdf1332", nftName = "LoopPhunks #441", nftImage = "ipfs://QmVEo8WQFUd6qBtTFBha7g6bDHZiFmymzhE5ejCtwyMZq4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b407608722378e1c90beaa34c1e6cc32d49e3b032ce6a0bb5d3ac5c63d334f0", nftId = "0x15787882199ff6c3a127f2c0c2ef51ffdbae9df0f6152fd30c31e52f50265238", nftName = "LoopPhunks #440", nftImage = "ipfs://QmWUyrq94Nustb1wB1hA9k8XCBPdTZtKUNvxAwgTWDDxGP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x146a2e0eb9f99abdbb88d126ff8eb1d309ebf37c41104279a31d33869bad5f30", nftId = "0xbbd0ff82f6e4d2de502f1a14be83d5d6d21977a36bfbc85f4ce39934ec531b6c", nftName = "LoopPhunks #439", nftImage = "ipfs://QmXW5ErT1MGudub5uU43yKQM9CUYsTQBPWkr4XKCz8g7Pc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x01363969d38655beeea901cc3d0eb49ca16f623a3f4a8545b11d64acd0cc8a66", nftId = "0xe69e425d1ef9b66e60ad39ea1a40dcf263061ed7c0858becc319e4fb94e6c574", nftName = "LoopPhunks #438", nftImage = "ipfs://QmRMCDHbpZBSmnagDd9MuFm9GYhN3Jgfv1qTiV2JFuw84y" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2838f9ad66e802ef9cbe26f8a5ffd82f70edc76a4ce9debe2bf184ee2ca392dc", nftId = "0x6548dcc06575e63c34ab477280b7b74a07e5ea38536c3fbd285b4ec7b8b35149", nftName = "LoopPhunks #437", nftImage = "ipfs://QmVJoz1LZzT4YC3UThfQFxDQjB8tVbSXmF1G2NiPrwvGkp" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1e5d3c70c31ebbd6dd9dfaa25c9dc91ed0682319c411f46b1ffb98af38ea417d", nftId = "0x6f4ca28435255b281fd50f9ce97ad99070cad37810147188b063a52dba1bbbd5", nftName = "LoopPhunks #436", nftImage = "ipfs://QmfUVZZHY4xQBKasacAt9P8Q8DTYVJEHu4nn4MiPXRyiT9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28f16e02f765cd891837efb17d7b38857ee4a5d667cab2294c634947cb4be49c", nftId = "0x0d02453cbfc4ee722e4f3106f8b0775590a8c6237659d021ba9bc314175311ca", nftName = "LoopPhunks #435", nftImage = "ipfs://QmXV5ZtmCcXrPzPSnQTdzAwg17TnvtyTPNj1kioY2X3qV3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x26adf299ac4b1694f10fa45ca3ad692ad08240036af2f2d4912e1d2ec177c37f", nftId = "0x593f4dd9ad4d53fbad576d10792a06bd50e051d2b81858673611add64964a25f", nftName = "LoopPhunks #434", nftImage = "ipfs://Qma9bC6JdyTBZ6Mp2ktfxiCjiueAb1CGcE7wmcfBC96TPY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x08c48f0a37f2bd0d4f2967b6e314d3689f0613ab6e799168c5c932bf2c569645", nftId = "0x8247eacea1dbc380c3189dc82f7c71cfdc85c12ee5f248f7123e68ee95a71eb6", nftName = "LoopPhunks #433", nftImage = "ipfs://QmW97Q19yQg5JhWpLPHGoRsLWhqGyLq4pMQF2huKG7awiV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00426dc9c103106c2c274b4bb407a60db9e421add15478f82c3b16fe8a486264", nftId = "0xd7dc7d2193bf343e6041811d6674a32609c1460c2ddd26408ec78802e94f4fab", nftName = "LoopPhunks #432", nftImage = "ipfs://QmUDLaxQtDWv1KYmrMCNWaRzuQ4qBrwPCjhxSH5hEZxLtM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a90f29e1400bb512b071045fd16caceee54eb043f5363d19868f3439974604a", nftId = "0x5296a008a502b04162e00d0165ecff7bd10a234cad23dba53ed9c7126bff1699", nftName = "LoopPhunks #431", nftImage = "ipfs://QmWWYj39ewCEZ3M5bVg1f4jcFctRmir8P7TuWfy4Pi1jTT" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x23452acc994fa16124f8e0c383af59519e164cf6700fd4f91a22f648306e81d1", nftId = "0x940c0856344a8fd23388bfe1bb420944c89f197c8d758de4a2fb4c0d1d32a00f", nftName = "LoopPhunks #430", nftImage = "ipfs://QmehrFDHEsQbWMLvyPHMKVnciC4Y2vYstsr9D44gGGaDoL" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x222c4520e7d77dea7bd7119c9dc02f000bd014ee2e97c44fbf1442c20948b7c4", nftId = "0x613d9db3b19cd52fdb076cedbc0a08ba1ae538f0f40cdd55a71311ee19e8e997", nftName = "LoopPhunks #429", nftImage = "ipfs://QmU5frTiNXCvHbqRHBkaFyjLjvRJpe6eaZ1k2HfYTEcmR4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24beb64409d3889c45ceaeac99b3d6bc564c142078491d54d0ee1df561dfcad0", nftId = "0x7e15990d2465eae652504d9c77b61f5451f5cbdd62309d8fa5cd29336e5f2922", nftName = "LoopPhunks #428", nftImage = "ipfs://QmSq1jxKa3oJqdhPqozEEkraJWqVAPCMNMVe8Qmaz8RDKd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x203a1b42dd50dd337c8b60042ac044fb91b747980d4954585e6de6e53b5d0e8f", nftId = "0x623538a157f45617e511487965d306486b41cbff7378733d23e66f24e5f8764c", nftName = "LoopPhunks #427", nftImage = "ipfs://QmcTVZasJpGyEEPyrndd431w9qLxLF3WMdbCi9mC87imkf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ab0f033d4d2c74920ca4fc344871344a66163154601e895db8b25841da05713", nftId = "0x429333797f9948ece2f340fae2bbf401b170be4179cbd6250f9980086d83bb51", nftName = "LoopPhunks #426", nftImage = "ipfs://QmX7Rzg9vuzCPqqPiWQYdnfiywF2ai6NfRJqwQeQsSviNs" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0633c89762679e2856964a0569491ea34f43a7d9582f104266238fef66477ae2", nftId = "0x0dda836a8fb5c4bca76568da3034fbea8f0d18bf5161794eb43a349561fb3f63", nftName = "LoopPhunks #425", nftImage = "ipfs://QmaNXpFQCbmcn9naDXbd2MvvPSqTkeSU52zuQCr7yzLCEb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2fc8ce9007e8dcd3723c0a6879a48c3828e391f7e4c7b633337450925c8a0fd8", nftId = "0x9f4d3ee706789a5f4e79e8507860543fa628823e23d250e967c80742e00b3ab9", nftName = "LoopPhunks #424", nftImage = "ipfs://QmR745CR7m1tLuN5x279TeU5SQjzMzTsrLoBHLvKiFdXHt" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0dd572906ad0bf81a4d1ca17ca9b98e49a93e688688d92eb3740361b1c8dd015", nftId = "0xf437da9028a5a53ba38dabbd57c2af8c6d1422d48dd79708864d730122648e03", nftName = "LoopPhunks #423", nftImage = "ipfs://QmVbr2osYJUuGTEcar9VP4cHZzG2f2radxDdh2Rdcd5ney" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15c606dd5d0a6351d3343b1c5a9080f3be6b652847a2df33b3dbde1a63f119e9", nftId = "0xd0ddc2f16929add047cb864f75d072714f58ab0eb6f4f4b1bb15ba5926248a4c", nftName = "LoopPhunks #422", nftImage = "ipfs://QmQ9LHMGm6BkhTGDFiVFEvGjeVzL7sUEyUz4Lfyc2uJb2c" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ff495b6d495fb632bd9ee0a728a3259eefb4f75cc621a7b79316b7b962ba4d4", nftId = "0x2e35a07428d6908d1b35fb2e3187c23eed20b1339d3e9337d24fcf190ff8d64c", nftName = "LoopPhunks #421", nftImage = "ipfs://QmR8MmyNHErEQKGM5ck3hc1jLJ1T8JcTnZeWjs9U9eCvHr" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x121ac8097c1405f522f9bf6662107b7639269ea05b2ad3b2deea1b3b030c8453", nftId = "0x2128dbec0b9a94dda00bbf101da7f515f308e937c7d0200105487208b3b229cc", nftName = "LoopPhunks #420", nftImage = "ipfs://QmQA5Ap8TRRmnoGg6ChRQ3BQEXkyaQ8GFKeJARvQ9DQFbf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x032dd3a2ce108aada7203b4ef0d785cdaa4543eee5ceb62f15fd4baf37629832", nftId = "0xd4d74b44dcd20edebc94ebad888133300808d2b12f98620a3af4e0a3fd1e7f36", nftName = "LoopPhunks #419", nftImage = "ipfs://QmXmtazmmB1Ey5qhCfN3ZhdiE25LeqYASdFnkTc9xHyJkY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24b92c4c96aaec4443c3c95a04b529af07581ff8db1a0f5871bbd2106e0376e3", nftId = "0xaae53d08d137031046413b10c3ac92ec7f49e94f6fc7eceab4d1b6fdef5586bd", nftName = "LoopPhunks #418", nftImage = "ipfs://QmSN5un6yEn38pXr9J2bGL2jC6u4ori3Mc6FyAECuh26RQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x072bb06053982d186d707d52c0b6d2dca43be723fffe85bb855b187e06b5d7e0", nftId = "0x0fcdfa20e7377764c65a09d79f99a53d400657e36414d83c3238dfac6684e017", nftName = "LoopPhunks #417", nftImage = "ipfs://QmPhNgr2CfwRyUiucME7zRnguK2VZa8nCNpJjm47KMygHT" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x131e37c49ccf52fadc12f1887b265dbf071e3550dc2c584537e5a9a3f09b002e", nftId = "0x54de6e83dc7fb356e26ae4886efefead859619354c5c918f4fb80e4a1c01b4d7", nftName = "LoopPhunks #416", nftImage = "ipfs://QmRzxjSsxaSE3xS1dPDRD6iA3MQXgj2pMDo21kswD9xfKp" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x06158e83aae42d864552b7b03dc680a26c403895ff7a6bfa6d893e7efb1f3a28", nftId = "0x9146f01011d69792e91cda765b264e274e1254e35fae1768eb78d1f24083d579", nftName = "LoopPhunks #415", nftImage = "ipfs://QmdbaY8nkhdxZn7txsa8ubDDG8Y8EvE4RpkN4eNVELJ9xD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15afb3e7e4dcfe5009d211c11bd45cbd39a1e92dc8be055415f739736200e5f1", nftId = "0x2b9d50e3d43103c7be6605888be8024d490553ad2172c739e2068380687cd116", nftName = "LoopPhunks #414", nftImage = "ipfs://QmYc11W566awdHQBnYQM1JLpEoJTMsebkNPXNtJ1Lo9ft6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18ff2dccefa0ef82add219d38b6e25d1b11885aed2fec5209ed19cc2539c86b8", nftId = "0xf258ae30a6c28093a5cb5b7610749a4072a96307c0b23e81d9061ccfb1aedc83", nftName = "LoopPhunks #413", nftImage = "ipfs://QmfZ5DV6KGJQZUbWKr2MwQHQshqz8sH3EeaBeeMKjsWgH6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x244d2cf27f1b1ba5414251caae7c47e6f514bbbd1681686f2e015505156d8d73", nftId = "0xb82b2ef0b4c37b6ab10edc27fb668e83e3f79e04a959ea25de7dddec1c2b9db3", nftName = "LoopPhunks #412", nftImage = "ipfs://QmVbYnfpp1yWytMGav2dJxfN9K2GjzfT3Cw44wQeqhqGhb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1fb7859b3d5c06232614b89be30dc0d5d14bebaac1432fcfaae08b747358d645", nftId = "0xe693048b3ed65f5d710876c4031c38dc71988470e55e3fb9e96e460728b750fe", nftName = "LoopPhunks #411", nftImage = "ipfs://QmeRnpaTkFyVpCcgveedeAUQK1FnqCdDcgHZ6hmzSZ7ojz" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1e7d27ef68deedaddc17c6bad7c4b809aae391e6003ea8a9beaa686cb72327e4", nftId = "0x4805fa1c90b7861efe15aefdb926be80e965600c06d738cab1ff4fe4701ef1cb", nftName = "LoopPhunks #410", nftImage = "ipfs://QmcDfggRiKpE2D49WfUWENByB2MATYvWxo9JXSL8E4oDAb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x3052549df0cb565ab97f6be98e98a4de3948429a323965094bdb4a3f9b371128", nftId = "0x64d72e95c5b7f5686efc86da8f66fc7cfe4945956ae0850c95db9e7e1a966bea", nftName = "LoopPhunks #409", nftImage = "ipfs://QmPBkKJWejfG5tZRhX51p4kgqDvcD95wbq79igTqomitcf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2fc684beb3df20d00620b9d11e64839a963848023359219caee7f886c8caedcb", nftId = "0xf2ab31f2517ddb318a3f8e45cf341ab3557c46af6cbf3d58256d8ec563a452cf", nftName = "LoopPhunks #408", nftImage = "ipfs://QmV9mJHuimnspsA3mUAV5P7HUcJMsWvLFkptTiXmLahago" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2602ba4ae92cc6564f5e50352bce84a22c1585869acdeb9fdf48fcbaa927c879", nftId = "0x00c72db925f7a76b2575b5a5bf11e6488b7ca4db8a901f42de2f35d0283fff03", nftName = "LoopPhunks #407", nftImage = "ipfs://QmdyJ4PfJFq3NPVb3Zd2Wjf4nEL2G8dxDCTFMJRDMkmZQD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e5cd60ceef77fcd735fc39c60b79e1b00d5a7f5f5aa44a25f2c8654ce84bd0d", nftId = "0x7132e34c2c6abd57e8f290e3fa1ae8b254661c2118b9604d8186995317fe2b06", nftName = "LoopPhunks #406", nftImage = "ipfs://QmSbcqHKcVF1ZXQYm3T4ZmL4wMDdetR9Q2rNqtYzgS2NSu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x12189cb22714482d7b924304885fed9144bead708419bbbd7b754047f591b476", nftId = "0x0eb3598790f2a29bfaf8add109041e1466a10b699909e4efe25a569f236f8ee7", nftName = "LoopPhunks #405", nftImage = "ipfs://QmV6U6WGwmY9YW5N6rk5pX8s2pQLx8bEia8zoBHqk3PQBR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00433dd780f5d65cf59b318e43ebbccac39bd743958d797737a3b3bfa82b1432", nftId = "0x490201d8697218e4479633effa09a489ba50e3d0645b2a9be335d3882d7d74dd", nftName = "LoopPhunks #404", nftImage = "ipfs://QmXfBCarAJuVqdwQR5ZG53AFM7bZdbdk1cMDn3ZkjtpjQ9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1df87cbdb17c4f489e71c3aa75faf008f305a89b3e4703c774363da889678491", nftId = "0x04fc41a0c07a4f7753a2a548449de44d8c1db7096ae41e71ff6e26c091b067b8", nftName = "LoopPhunks #403", nftImage = "ipfs://QmT2RBPX2jKkNzoxJA88HuWXf959pqe3jWoJdGev35hXtU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0fed5030a9214a61a28c948bdf76c51b678ed789e6f0002540e322c0aad710fb", nftId = "0x41b7f7a46159a64ec8b50c5c8bd22239caa87b869fcb50da88b845b10ea57a7c", nftName = "LoopPhunks #402", nftImage = "ipfs://QmZuny9gcA1gb1S7XnPK7dYyZAPowdvNMyfGSecW74PH36" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27c830d87dc2c9943a0749558a2b27e82501bcab36b083a14a3e5d1af445769b", nftId = "0x07984692871436df869caf783bce6c519ee0e4f2d785889fcb1b9690e42ed0d7", nftName = "LoopPhunks #401", nftImage = "ipfs://QmZ2iPcQbSxqWobZ2aMi1zhYeb9LrFiEHLyN7ESyamC9B4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x240bfeafed8f9a454f68d9dc2081b04338ccbcb482c98aa1c143a08a5bae669d", nftId = "0xc2fe1b03ebc7cd5ac645bc2ff09657423a9d82ca941373765b81b651fc8d8a27", nftName = "LoopPhunks #400", nftImage = "ipfs://QmU5GdMUu2oe8gN2SSdAW3fzrzJZ7FvVHo5RLbR3tPCQZ9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0e1a0c65cda765858ddc64b9c3a2f7eaac837694dd2f8e1965596d27ec6ebb31", nftId = "0x82d36ef76400bfdb0567b378605c2128657b967915ec3c2dce5bb4be17a5d601", nftName = "LoopPhunks #399", nftImage = "ipfs://QmYmoSqWccgPCb3RQLirJXkyUYHnzaaNFFP7hVRWKu5kQn" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29681d819aa114fa6d88e659c2f374dec7a17f119eec7d7188e44b2a87499003", nftId = "0x96ca8cdb2d7d5446f8b798860154ab38668bd122e565848c69aedba094d01ba1", nftName = "LoopPhunks #398", nftImage = "ipfs://QmVzavhg93DZjQ5BwHvdBKvo2aZgzWvBsrkLYkjaLgaiQT" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x292fa1cc2b47c4e79d697584d1f7a927dabd62f9a414d479352d49fb5d216c0b", nftId = "0x7c5aec7d99f75456e2feb0d63236cad9e7b0ae452555c8544f44ebd0d6c5a3c7", nftName = "LoopPhunks #397", nftImage = "ipfs://QmRXWCiLDjPPNaUco69NUEYxSkxvUK5L92u5XYoreTpHUa" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2bd51d53e3e9449735a41ffcb575cdae2f4aab6bc1264aba161fae813ef17e83", nftId = "0x1ac7ef3077646367d3199a5e5c6b6e304a1f2b74337aaa3df1b1c133171560f3", nftName = "LoopPhunks #396", nftImage = "ipfs://QmUMKhPm5Uk3ytMbXKdLSoSaY8pNeQs44JkecNh4UCk23G" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2eff4f9e8736e6441112d11ad9f14be5ec1750dd4e50385c1cf2c570ca2f3068", nftId = "0x674be536aa102976b2910fa77385d51c51388a9f179102e52899189044676542", nftName = "LoopPhunks #395", nftImage = "ipfs://QmdznePnkwoQUJTd2Fq6u2EdXjXi9vs2rTPF5NVXHcToGQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x106fdcd47885671b31949a96229eca9bd9e2039690e1e8eb0c7fb6b3d3beb063", nftId = "0x8279939abb00fbfa35ddd0a81f8362f3eba2aadaaa023264bdfc0b2065f26258", nftName = "LoopPhunks #394", nftImage = "ipfs://QmWR29L8dFkFG6pW38nsFbY3kU3pDEjcrfQs42BVhBA2dk" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2053dc0a25f57c8ef92a5fe582505d4f3e291ad86a9c577390dd30808a577078", nftId = "0x9006a4376ef3a826a7799deaea7cff51dfd337d2d22f5cc4b192fee9546cd77f", nftName = "LoopPhunks #393", nftImage = "ipfs://QmYHkpA2CphBHcbRpLSxj2bHyiSEWxv8zWioaJEwZzE8NZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a92079575fb0b64bd21fe47c473c2c5a8ee282a80ca47469690c99f71a83149", nftId = "0xfd8c575daf471d1e7e3cab103aacc1ab1aa6f8bcc67dff969591fe3f4ed4460f", nftName = "LoopPhunks #392", nftImage = "ipfs://QmQ1gkgXHgdcVghgozMAojW7R6Rd48QJ5DHfcstgwP7re6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02eeb6caec795137b5837a1630e0179c726530f7513062d9c1b5fe7934e4ab60", nftId = "0x1994a193771414b78e93e95ea37fa64e39059a38db4fc17c2036338edc367da8", nftName = "LoopPhunks #391", nftImage = "ipfs://QmZAa3vHZuiYBobC7xPU1AVeXW5rTLpUuk1fFE5Wgp6G4y" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0d2335358494c6075b29125df09e7790f77158d97dccb20eab0fea63bf3ea9a5", nftId = "0xb4d9548ea6842f8dcc659391f5b7019587c6b8286ee2c75b030a1bc3d2538635", nftName = "LoopPhunks #390", nftImage = "ipfs://Qmf8Rda1acBoY1L8DJrfQtQVU8woaxPZTSANt4augizDX3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x135bc67f210d5c6c5e1647fa27aa6a4b214860c4bee23f305a329fbbf0b39e37", nftId = "0xd71a5b06c838cd5eb41c22df28d9890e71ad7b2a9c80d32e2f607771eeb18117", nftName = "LoopPhunks #389", nftImage = "ipfs://QmTtpVvKWWM7exqPNNhbiybtb3ngeV9vsmqgh1dP8rYqgd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ee19ae410cdf32c055a1b5d09a62dbfd88ede9cb35913b2a489eb051e0deac6", nftId = "0x94b10728829b81054fca1a649fc7116f33e057cde62e62bf8a392d1c154b06cd", nftName = "LoopPhunks #388", nftImage = "ipfs://QmSqAqXhgssCV4H6nMnYok9QzAqTbdRSjCFQUJ7ciZHA19" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x256a236bbbab097f2e03439cf7bf57e41c3cf4b6de1095710b3490e0a35bb614", nftId = "0x2b44690bdc18aba71d001e74eaa878a8e76f39fcfbf444fe85396a2214ca935f", nftName = "LoopPhunks #387", nftImage = "ipfs://QmQvxvgC1io8PJpZeHuBzwgnvvzrB1MetrobWoVBCKrtQp" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x10e9aa10f1795ead823d1845fedd8677afa0425a09809189fd2a81d47dbe84b9", nftId = "0xbfd2337a1f6c8fd27e551f6c3064d410d1220d62806668747553930e3419eda2", nftName = "LoopPhunks #386", nftImage = "ipfs://QmbJV7m3jmAX8TD21FS5L1q75R7MCn6cZyNjoy4a8S2DRT" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x16c24d59372140f60efa0ec9ee978b0e518691315097a542083fb0a6ba93b424", nftId = "0x209035b5683bf987a4b030c88778f1b0ae9691b668363bd7a1b0a9c5c50bb367", nftName = "LoopPhunks #385", nftImage = "ipfs://QmPVdWhF9TryUdYXWRU8L1jvbgFjrhwrZjsTFX8xGK7w9Z" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1e3928b87b36cf4b5f2f7c10b5b0993e239791c3ad14e05a631a5a8f92b98e5f", nftId = "0x878d8bde16c6dea600afd5f0a5686f52a437bd377530d6fa1d372ee700f50e4a", nftName = "LoopPhunks #384", nftImage = "ipfs://QmR2WGHfQSL5nLMczP4M2934jzXhF78RPymNzqgnFZy23f" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x04ac8ed74bf328ca1c5e22518ad7b93acc3626d782e21bc73de6fa432e8b6bcc", nftId = "0xbfde3add99190fa5f0701a2ec73ecdcc8147afa8937db618bc97218e35f0a552", nftName = "LoopPhunks #383", nftImage = "ipfs://QmRFqYuMDmnMALq1Ta45835NBT8VsjXh79R15h7dF7TQYG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x20d023aaefbf51be3d409b3eee7d8682d754764465e4828df6be1a747fe2e7e8", nftId = "0x7beceb8213f6f31e9dc46a78a6ef53df5590a99feff0a0feb620d606a431a931", nftName = "LoopPhunks #382", nftImage = "ipfs://QmUZPhrn5xtXco9tk4GqnxvQXwgMVq33mZrSLcM5XvVJXc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b14a3951c47cb2ced745e9ba3fab5894562ae17c56739d623cd413451dcca86", nftId = "0x5f30bbc219e7de444f04aedb1c68efcf729214d8fc67e6da4dbdfc975e7934ba", nftName = "LoopPhunks #381", nftImage = "ipfs://QmbgoL9aMM1rkVmA5BYqpayuW4xzVwwE9b8imv3snjXCcB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x06044ec3a769356039ef2a1adc7fb6bf9773369fac51b2f23841b30c4757c295", nftId = "0x05fe94ce935f306a3b71bd063153bbe8909f51cd59b460e0fdced2b3b65c4f05", nftName = "LoopPhunks #380", nftImage = "ipfs://QmXSZLnCC3eZNCRoSKa9UzudNmhs8ZiNYe5SKrAMW2FZmx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x048c3aafc1693723c63d10cca2ccc316fc0ff95fe80d288faf8a041dfe501ce0", nftId = "0xd71a33bcce38d4e893c8946e4e0014528d3f6b1b5548c98a378dc040ce8e79ce", nftName = "LoopPhunks #379", nftImage = "ipfs://QmbZBK7okqQYprALdx4NGdypmK1Vd1Rvc7AHwWeLC5bbdK" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x08531edbfc11b8d8376474ecf9e330291ba9a4b25386db6a451c43f53f7d0bdf", nftId = "0x7bde39a58c00bf4690c1b3cb32d68017556172ff835a87befebd2340899735ee", nftName = "LoopPhunks #378", nftImage = "ipfs://QmW4edSEAKuoCRxVSvTEy4RVFjuAm1XE5bEBptcTGpNqkF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b03c10ec7bd7d5d04f8c8e1b0b3d6197f8f5aa93d18866c6e6f8c8c95d4fe9b", nftId = "0x6b660975e80ad5ff6bb81e5bd2ffd6547c32e5fc43578486b84ac948f2f2f049", nftName = "LoopPhunks #377", nftImage = "ipfs://Qmc8b5xBsG4XmFMAaDJ3DzP3m71zREXyVwZmnWmBKAzGWC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x125d97bc97f716b5973b2ce326980d75c66c992110e592d00753d907658d702e", nftId = "0x14afd692eb4f8ecbed1d91718e486f9def47b3fab2793a6b98c6e71a791d2f54", nftName = "LoopPhunks #376", nftImage = "ipfs://QmUh1pS2LpHEpYNDXZwKRXVYJdFEctSzenTKfPQhAJwVdv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x233b130b26bbc059a8d2634a825a48cb39d90f2c491fd24495aa720363aff745", nftId = "0xd7baac3f6a78b07d137613f6ed496f4248c96558c59c3ed894ec615d2e4961c3", nftName = "LoopPhunks #375", nftImage = "ipfs://QmaVU1TsFdoyQDyPDDgeojWJy15nFB7kDu9quP3jJ1MVuW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1c798023126438b433030d869481a013142dd2ac8b427b5861e8f53cb9080611", nftId = "0xca835400055d04d5e8e11a0b9f7fbf911abdedc48cd364443fee5ba705379dd3", nftName = "LoopPhunks #374", nftImage = "ipfs://QmdmgSu7cGAiHi5C7xwW3GhFchV8JEsLaSyMkVYjwMp79s" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d899beaa2d547513d905f6dff9e56a8c1e2501dd7ae83e9a60eb6c31f012941", nftId = "0xe7eb69d0d3f65bae3a518e8146afd45652a16fdcf9a1e0295a8bd2228928ec80", nftName = "LoopPhunks #373", nftImage = "ipfs://QmZuyKVpk7JJ1X6ZKQUfJnisxRRks3LRvXiF72tPRrM9Zt" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x19fe781852b7b8a03eb6b82dab505b51b8ef12f63b1f3a28a05da8e891d387a6", nftId = "0x7afadc320ed68c5adcf6cbb8d161994a2eaf6a14644897a66af92ebc47d3d3b6", nftName = "LoopPhunks #372", nftImage = "ipfs://QmPLdBm8ynY3aTCLDbnwLTMvPe8hv8377E3725yfxYgPvx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x086973dcb98441d1e978a25f47bffa1094c746d484e7e3c24d7a664ca618b7bb", nftId = "0xd594ac1aaabee746231dc3f89c182aaae1f93e415128b0b69c4a01db9e367620", nftName = "LoopPhunks #371", nftImage = "ipfs://QmWn2KznpGjZNxTvkPRZCv5xLxD1ehTy3fLhbeW5wGnx37" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ef2acaf23b70a307cfcd0f7254ace9fc92d178693369004ee372d8898b64c4d", nftId = "0xf00ce8ec82fc6e353dc16777b3e8cca25d908b015d769c0600fea17cac7edc8d", nftName = "LoopPhunks #370", nftImage = "ipfs://QmUsBfmqRz9Ah58JX3zY4EdSQHoWQ1ErpPH8PAL7c2d9eN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x131c8feafeabf2b922cc7847eeed4e0b94e93723e00ad496d583ba747270f1fc", nftId = "0x0441a566180e0ff82ac3b2c1dd0abf31966820083278fa4adca7af42fee08eb5", nftName = "LoopPhunks #369", nftImage = "ipfs://QmSSi5pVHNixMVa9zmLgQDBX9MNP12fGq4pBAuSiFFDwFA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0db641f2aeec5f433a544c6ca8b8829bdce109700267377fe9a4af811d969ed4", nftId = "0x322e2bb9e5c69cd8ea7868b46c5bac2be120e5e2bd099287ba5f9a77936b9981", nftName = "LoopPhunks #368", nftImage = "ipfs://Qmb6pb67kpR9c6ZQES1C1kx56bMhu7CkUXfDioKhSe3mdE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0e74949b083680ebf728f53c9a4f7fdf7e454acf5e4f4849dff515814e6d467b", nftId = "0x2222d25bc826fd99f700e4179a380b06d8c05ddda0c2c8a254c16f6b05853421", nftName = "LoopPhunks #367", nftImage = "ipfs://QmdRmBNq5KQ68ruoq2rqf9gjvtM768TzueYzFQaGfwLHX4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b739c49b39df04d00dc172e3e7f095c56a63ae2d912e88061450df357c91609", nftId = "0xc89280767efb75481679f4313a68e5bae035db8cd952cc87a7816619eb6c3b7d", nftName = "LoopPhunks #366", nftImage = "ipfs://QmU2dR4V7296ngMDRmjoe3MsMx41X6ofD9TptpLjYqXSPD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x183498a6ce8062613d8e3a52ab314d075f30fe04abe406c7c407a187a0537308", nftId = "0x00564f48300db8436842a6896cbde9e90bfa8b56070b85684f9b3a3208f259ee", nftName = "LoopPhunks #365", nftImage = "ipfs://QmUbUD7j1BVJtpdkTf23adE5yqrS5J5yeeLSFiZBLFWiw4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e99a5c07a992cb1e00a04d555972f489aeae7c20c78e93e46e96d8974d2425c", nftId = "0xb2c1bc42fecaf28ddd712d45052caabb2cfee8d0699c8da19cc56804a6b84a2d", nftName = "LoopPhunks #364", nftImage = "ipfs://QmTAdwS5ffwZTynbSG1uMPzrbsw9q1e16vMw7LcL8CzqAJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1296484cec4b706d8b677bbae124f15a5100279fcde49a762695b1f7a88411cd", nftId = "0xbe4ab7ad00a39d175537fee2836009f541a8ad05b6b3ce953e0e7456694227a8", nftName = "LoopPhunks #363", nftImage = "ipfs://QmSnZQZ4Vsr9HvbwEzGTx3VwoDqLihWTNowxopbLMKZcEC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2af363355fc49825010e8e9683ce8a07ae6627222e7b6e0614ff5a88ecfff52d", nftId = "0xaea7da10e072caadbe3baa65372a39e2e0193267c68ec925703b2a632536637e", nftName = "LoopPhunks #362", nftImage = "ipfs://QmQW3xPs4F1iNeqYGCf1e7g33X6mGciRju5yxNZtMTykEX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27a0a59ad7fcbabdc32f07247390064d97ace7bf66c90480a2c2e444e23bef16", nftId = "0x5c4edaccfb1b12b0caa295c7d6146bd31e8397f04dda08226340000c633a5a37", nftName = "LoopPhunks #361", nftImage = "ipfs://QmVtFb6CRGrV6CHbuWP9zGQp8KsVYfNtXjKRG5Fs8fXYiS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2345b7bdd67edf55984b58a2447a59e2dfbf360e1b800ed59f4cdfe9cfabeb09", nftId = "0xbd862c70757f18c2ab45bac0fb755726ecb4698fcbc6305406138c5d7227ebcd", nftName = "LoopPhunks #360", nftImage = "ipfs://QmSUPTVRb8QE7FmsTeda9h6nJp5eLP5dzzU3WKPqg1o11q" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x17b383fbae4be06e0a5e4a5d836f5a9d4945402d7a3fd45077225054b2d509a8", nftId = "0x90810ba5e5488bca16f668a8e333b2198f8173cd3c29b7f861c395f06b26fa59", nftName = "LoopPhunks #359", nftImage = "ipfs://QmXgj3RxmXPdopSc8k51hpBj1JDaw8Po9bCM7YvftdtApf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1214c07a95eea2b55ef98a69950c67f7927803bf44b708c1630eb89c1e071254", nftId = "0x4bc57eb9dd9c50ed64e256efd9f1d578bbc97fe5a8781650623062cbc907a172", nftName = "LoopPhunks #358", nftImage = "ipfs://QmbYjJw19tdUhYJwAWsoJCygQZgQp3YX7tigAtcXXkWbhW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a757b174e9617e33b49ce3c3307f672905ad154ad3903d9b4c7ee2bf3dccc30", nftId = "0x569ae9517ae1f06875eac049c86f1650fe5523e7849c52195aaf11285fac76af", nftName = "LoopPhunks #357", nftImage = "ipfs://QmWoio2VvFBeLNuBhdgSosMSks646pyxjEbaMBZKhG5CUx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0370cb3b0153746c79b9d5c4f925a4078e81e593eddc437029fce859442c182b", nftId = "0xcaed6269922429cc56625ca146233aa2c92dff3ac1759784ec54a290ba788a81", nftName = "LoopPhunks #356", nftImage = "ipfs://QmcY61x8dEzvxzeEV5Gtpm5jZ6PZ9bMYFn4RXYSaZMbi3a" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0bd482bc8ebac1b2005d8844b4dd8526e3c215bf066e390763d2548fd990aa86", nftId = "0x2bb274a65b84a03d83765db75662cb423c10c15d5503b33d14d7946863aa5fae", nftName = "LoopPhunks #355", nftImage = "ipfs://QmT3UAyza81zfmn43x2BHBb4xCjauY7oruc3kqgCxcDdgs" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05a738fd787e7610a6881221b7d070a883eaccd723eb7e3425543da963acbfe1", nftId = "0x74a40e8f947bf9205eaa8530a22211a5db57a2c0e7e1309c52e1fd6a6827c43a", nftName = "LoopPhunks #354", nftImage = "ipfs://QmSEG9n32PSx1GLVgKa7rvTRiyRHPnNhckvfPphGAutssx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x111b99f18bf2ab14c410c035382eed192bcc31545324b102b9d7706d918f7216", nftId = "0xf1600bfe5599a766d4bce97bd5fbdcc4aae5942bd9cc7e48197b938bf8761f82", nftName = "LoopPhunks #353", nftImage = "ipfs://QmYKfaV9wfFQeaT9CdfnDtSaiuViEVukQXFgzeqUC6YEYU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2cd28f55c864f59fad92a8ec23220fc0b584e19216daaad37bb8239cf7328ae8", nftId = "0xb373725cc122a03e4bc4826fe2c6aba4d3678937cdfbcc53e40d864bd49317a4", nftName = "LoopPhunks #352", nftImage = "ipfs://QmSnNhqwMhC9ViCKks76WSacBUBH8ifkZErGjTtPW9ZXqF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1e32851b96981008ee52ae1ceca446dd0aa8987ff8fb76e562d12c046f515687", nftId = "0x1dbe9368ff50ee4529face86f6bd108282a347a7263e5cc3def76c1eafa7966a", nftName = "LoopPhunks #351", nftImage = "ipfs://QmSMJxzUcJm7vDGUnAKnLd1xwdSovJuyp6D5497TgSNSgi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29b031f58f3bf468bf3007259bd274c8ae0c563e9bcd865178d02752a92088bd", nftId = "0xd3c4e2ba34d2824af8a30c23079c0c894baf61129c4fbb77be87430af74f71e6", nftName = "LoopPhunks #350", nftImage = "ipfs://QmXa7SgsTAsYhjSBy9zmociRhkFcYVB38YjcLWzaPVKQfR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1f3f01f2799c8f3ffcf04aadd99311795e1bab1940e823b3ea9fdd15048f23b9", nftId = "0x6abf0bc62e102e1cff8bff089b0a9d8e48692baece7115425faaec6440e1059c", nftName = "LoopPhunks #349", nftImage = "ipfs://Qmc85uFVXo6XmaxUckziDzSvfiVF1JeCsNV1Q1KiR85cuJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x270abbbd4d80c4482176ab2e6995597188028204c978eca7592af5ea4c5bd751", nftId = "0xbe5e7763c5e8919d45a3a113617aacc471715baafa742b137444aa342f757422", nftName = "LoopPhunks #348", nftImage = "ipfs://QmPcr8P6StDch9vtTLjqWTCYUPJjxKkshdb3dWE1pSvtJC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1a928bc950a187d73231324e6a8804659420e83a8ef2420437051bf54fc41291", nftId = "0xa9180ff4867bbbd867b817134691875bf572c3a4449f28d4e5fb64979495cca5", nftName = "LoopPhunks #347", nftImage = "ipfs://QmZcV9LHgfuF1nzmgMvXwVPXFLeEJFXJK9nJA4xTAV3i2C" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x021fd5795a816586c1c01c6458a893bdaba7899c4f3df50f3d1d0235e99834c0", nftId = "0x7efca879194a924607ba3d47219a2379935d843387bc7b5462a551e47f488bd0", nftName = "LoopPhunks #346", nftImage = "ipfs://QmSTgwJ2AVX1MCntSD9WcbuZ4Zanudp8f7wjL26igRGib5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x23bf542025eec995ff73f971a9ab91750470ad29ec452c8a4afd40dfc9eedb3b", nftId = "0xe6cee149069a41fc8dbd166d60cdbf85740f1accabf287be6c7b5f17b06e3a0e", nftName = "LoopPhunks #345", nftImage = "ipfs://QmSSZnD1Z9GzEPDceTyHwoBvmyLuRK4G5uzJHx57Svn4HR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1aa7d223acc0724fc797fc50bc0dea31645436bbdf120e2286ffc6a78124edf5", nftId = "0xe8ae03b4045ef6d9f9882e5da9ffa836409b8a9c21758586f1169d5797e90604", nftName = "LoopPhunks #344", nftImage = "ipfs://QmZrky5ahz9uJvzYLpyuiNArucYCrjCqcQ3FnSoYAnreei" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0334e44fc3ca165953e1dc8cb2a67c94b3d63c98d4d917390b7e6b496b9441a1", nftId = "0x067f393ae71ea191b295141ce3b6c997e915b9817016d5329a39874960059cab", nftName = "LoopPhunks #343", nftImage = "ipfs://QmdPDm3fzfde9dzb3Z8X8TterHkcKiJz9DFBp6VVMxWRaN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24486173fb05a06e59e33ad43c457ef799a141debd11c62ff9ea3a06abd6219b", nftId = "0x6593cc1d893c1b9cdd9ec43e94ae1947f2c4f780c096f728b73d7d1b5a1935de", nftName = "LoopPhunks #342", nftImage = "ipfs://QmNWzKd1rdsSiDPPjgjCVMWDtvPBMCXgZjQn2HRWZGyT5S" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x11f468c9d0c44aaed6ca593de5ac4f100a9eed9efb4411405f1fabc522d6e123", nftId = "0x4d049df8dc41a90711dd3ee84c4f1c16db22bc46219449cb3dea2be94963974b", nftName = "LoopPhunks #341", nftImage = "ipfs://QmNMuv2VnxiXSfRzXmpHKGJYL2LxQY1hh86mS7DY2pqrm9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x04317f7b16fc582c8422883fa55ee11ed7a6b1f04e6ba5c974e76f7553f7346e", nftId = "0xde4a5f0dd7e7f0f8739a2b08155994fa4e990259eb5338481386ab8bc0121791", nftName = "LoopPhunks #340", nftImage = "ipfs://QmaC6pBtJmdJCmqMhXpKMjrc3si7appn3HXt3oHxSdMBJU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0af11d9e3b4affdcc3a97b3c052457658d23c0c54a11c729ed9c6ff55f6be9d7", nftId = "0x1e56cb24e17ee44bee9ac466f488ac62c337536d9c93b34811956f048124ae03", nftName = "LoopPhunks #339", nftImage = "ipfs://QmXCDnVN7iQrihRFnLep9YMV8ta5TBBjDaYwXuKGNFhSBi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x08784f59545187f38e08f8e3bf396913d3d8dd849c00e127b0962f5ca6575292", nftId = "0x5eba55b66c5293cbdd8d7c98233e1e5163146f692907a419f153ede92b04d627", nftName = "LoopPhunks #338", nftImage = "ipfs://QmaJUEbuHoTS9FB6YUKomYLZ1XHmSYjCEBDTTcoKH6FeT1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c9cf5df1c2ea82f1951b5f69f223b30f5349d3ed2a2061f7cd7e8678613d1c4", nftId = "0xb3a4ee3fe867e284ed2d80bb05a84132ebadce2ac5f28d0bb4136689ab4a9ca5", nftName = "LoopPhunks #337", nftImage = "ipfs://QmenZvyrzW9GdbmbaHUwNY3mYQiTmneLSbmsrcYFucjPzA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ecd2a92ff6aae05b3563c9b519716a4b3bd02dd708b9f8ec424db16e43b7041", nftId = "0xa6e42f89de9fec33dfc2382538497a9d890e15ced3a00c38995ec9ff9705af06", nftName = "LoopPhunks #336", nftImage = "ipfs://QmeP7saqmPXUTkYJc94geAdbQXGuZhPVoXWPfuj8MS9oYJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x066823f9476b6cc168040c2435b2659bcd7ef14fa51727dad9f9ba5e66ee6459", nftId = "0xd2f33844ef947c2e0f079120a2ac902939415c8038b319d238e04e83e513a62b", nftName = "LoopPhunks #335", nftImage = "ipfs://QmToc8nzzXCWgGw5vHeRpYNRgKzowjvumCyF7VcJFFPRXy" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1b9e1ac5b5e820d1675b8c60cbaa24e6661c2644f7554e7127ec58e73d31d85a", nftId = "0xf502a32bac0256fd63b6c93d2dd02bfaa6703c7a715861e42d9f838942e41744", nftName = "LoopPhunks #334", nftImage = "ipfs://QmWz48D6FjbbJaaKTC67h3wrXcEBPEksLZmWUEGzYd8KTG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b4bafc47abe324f1814ec40dc146fb0109a1bb801665dd45b38fe32a807ca48", nftId = "0x50f9e961edce9017f504ff43a320bcdc5bfbdfc5fc210dcf2b2444b80e85f900", nftName = "LoopPhunks #333", nftImage = "ipfs://QmZ2Twpgv7nUufium92hha7N8wJBnmkTuoWDQW1xhDUHsa" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ad0ac28667349a3d42a59c9b0e9bb8284c6d3f605b3c2575669f19e59b7a888", nftId = "0xe64eb4afeb200445e185082d1332ced39ad971acd548d030d2cdcdb8080c1e36", nftName = "LoopPhunks #332", nftImage = "ipfs://QmPzJB7BpniYb2gPaRfB92hP6XES6iBAm5VCTUVhaLBHEh" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x09b5590017a3ae8c555f91290b25216e5505eda92ea85b642231bb34cb0c5b06", nftId = "0xb5e7fad9e178fbc37fc5c7ead943c7cd429d9102c3d6b6109ee4f955449b8187", nftName = "LoopPhunks #331", nftImage = "ipfs://Qmf3QjUSTfqHK1jXaiNfaQkzxhVpcoutzHRtiGusupvWya" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0cde8ed4df1bad266f70991135da425d4834d5dd890d56ad23ef07c8addcd75c", nftId = "0xad15688963c8c743186723701e85c67ba671a522929d365e5d34e59202a5a5b0", nftName = "LoopPhunks #330", nftImage = "ipfs://QmZaUBj3vsba5E6L1LQtXybgTm4JawVnYJEunpvKK8HTL6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22a2fd76e998bbb6cb6b116c702004bbff825aefa8e2a3a31cfc97ed1603eb33", nftId = "0xb9f7802d84d774f23f3be51d044fb84a699388185e32c2c97b2125c6737fb78a", nftName = "LoopPhunks #329", nftImage = "ipfs://QmeTEXHpDh3Vz8Z4xrPq2euP2PsCNLMDp1uDxhnvs1isUn" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1e95ba00be4fdc4d12acd87be5a0e5dc0c5bf5431443978544f07d4c42474f94", nftId = "0xc68601234f9d2631ea567edde600ea32a34a7047f9dea58d6b1ebee5c77c1d84", nftName = "LoopPhunks #328", nftImage = "ipfs://Qmdrq9a58yoqYrv6NUh3ghC1WdVeUzRvhtSyWpYPCskWrv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a5043d2ef09474a6d60bf8264300cceff3c97eef0bb52536f05dafd6ac13f87", nftId = "0xeded66c2a41405907265c7c87dd5da8289ab9210218fb3f038a4aa1a68fa28cc", nftName = "LoopPhunks #327", nftImage = "ipfs://QmaPW4dpXWT2oSdCmcZWb5u84vZwotMYPxdsUEh9DBiReq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00b66dab0068f98107cd3baf98cc5ade108af22cdc4012d79a06610aaac2b136", nftId = "0xf8b1bc2f142a1379355821cac8384fcbe0547b4ace0e0114dba01f8c97366eec", nftName = "LoopPhunks #326", nftImage = "ipfs://QmVP4ZHp6Eai7LyFNb5kpS6ngtgYQmRLbEAxMcg4us7q3c" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x20625034803fe2d387c8947ae091bfc56a426076b64c9b0db0d7ca184cc7051e", nftId = "0xa29282d4aff1011a98fbea19fa4b5a6805a80de7f3de568205d048a463086b7a", nftName = "LoopPhunks #325", nftImage = "ipfs://QmRa1TnVWc1cp8yiKP7iGSHahC9QSbjXBzYTck7hPJiY3V" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x090c62fa747495a0ea115e9530e0dfd3a485ae6ab33de8781bff1a93fbd409d2", nftId = "0x861bd852ff643260ffd8c21dc46bf66a5ee4d1a26658305d00ebaa78b9f1e6e4", nftName = "LoopPhunks #324", nftImage = "ipfs://QmS73AjjuAb3TAvMQnJ7gon1Dn8LKdRMxVPMYMvTPSXgcM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1c066e89825c5cc0a77a5bd8044ac4e34ae8a5a2c51feeade3c0a0ef8dbeb39e", nftId = "0xc62946286983530ce02da95aaa55d0d91ae1eded9d622a72a306d7a8503c9ce9", nftName = "LoopPhunks #323", nftImage = "ipfs://QmV8UHUwygNYokjyWj1J5GadC42eFBvNFTj5GSXvh4nrgh" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07bc7be6c46fff1ac98ca29d752678e5b8bde79074257e7b6a9eb9a49e5cfc21", nftId = "0x4b85fc33fce8b8575b6088c911b252c5b72789d751b6e9873b0c761f54cf9208", nftName = "LoopPhunks #322", nftImage = "ipfs://Qmcq92byXUM57tqy6oB4vpMXVkQ2vUUn4xbnbkBUG4GzBz" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x068241cbadddbbc5b78bdf8637de0781a5b4c4bdd37e594b08fab6236b4316eb", nftId = "0xbe53bd4e883d9aa2a6a34536fd83de36cafd338f51403637ded9867ca9e67ee1", nftName = "LoopPhunks #321", nftImage = "ipfs://QmYVzdj5FSfiTBX2tq1VJvACTjPz4PMjSqtoUbHYsu8Szu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x11a23d5ead4b50b79b75a885bd0e7d228ca76d4c16433383c35629c2e80c69bd", nftId = "0xc985dcb2de2f0114c55cd1323b19de996163c12158ad2082415733521bae7322", nftName = "LoopPhunks #320", nftImage = "ipfs://QmS3MHfJe3LvG5E8Wg11y2J9pFPS4bif9XnezVGoPnPwiV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28536393a79d7c1400f6adf602d7ea71152fbe56ef9d416672ab297af91aa4bf", nftId = "0xaa93b4ccd75e2d5dcc879257c4e672a7dd7e5224834a21432fe5be3546e9d36a", nftName = "LoopPhunks #319", nftImage = "ipfs://QmYbmSRKbvuVYTbtvyxDd3vBct14rzLJMe98ctS677sZzG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x197dc2d8053fb1b1055d33d3664b0452c3e1706a27c3c904a4d10e9c2754b77f", nftId = "0x595b3690e05a1bd4a25a5316cc11b1140559193e3468fb077734172442d506d4", nftName = "LoopPhunks #318", nftImage = "ipfs://QmX8fVBTccQGns4daJcxofQTDMq3ek6Y52qs7AUkqHYruZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d1edbf7658b39fc1f9869755897fb887139a09e2b8c4ab501cfb4386d66e74f", nftId = "0xcb9a15fc348ae5eb45294c419f44ee1fe5c61e9176bf4afe766dac4e32ac3ad6", nftName = "LoopPhunks #317", nftImage = "ipfs://QmRt3TaVtPfpmjkFuTgXrevjw9TTPcKzxiRXbqp5Y4ic9T" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2270b19ee35412770084047dbee469e862898286f8422e923045d95730e226a0", nftId = "0x155d61c161eb91f6a6c05e004ac6635d50bb148587f317ce8c5f7e37517c29e4", nftName = "LoopPhunks #316", nftImage = "ipfs://Qmcwf33VEQwjaaUpezriwYL7yuPLrAPNUArSMZDMjqm9M9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2618b86bcccee22ce031d35fd744479ab24f583b85b6b6502c266222e5759210", nftId = "0x241cfe18b8963c3a42b7ed8054cd418af15feabeccd6aa413bd04227e7707994", nftName = "LoopPhunks #315", nftImage = "ipfs://QmS2K4DTMqUPcsLsxkJ1oVyLDa2fDSReTzDgMhRfG9Lwbi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x164c02cded6ef1553f84da77e504254abda01706e2c8499b2661aa7a9d639b8b", nftId = "0x67f0f5b8842aa16b9d9eaf33e5c1ccf905accb3831dcb34906dbaae702984b8d", nftName = "LoopPhunks #314", nftImage = "ipfs://QmWisbBXD31vE2DjnQKnTmXtEPYmNYzh1qMNQNJDRZV98B" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05e516414f388a1db0420eda93cd153c1a5a48a38e121160c9439255d18919e7", nftId = "0xd4eccdca3fdcb53b3405fee8226082918a150c90c22f731651c48fcf6d017c8d", nftName = "LoopPhunks #313", nftImage = "ipfs://Qmb7AavFuiqDJ8i1G8KCxpdkFtoC5aVTDJWDFGrLXEcwLB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x066b627edfa9a9a84c0dfcc5beee4b5f6677dd2689c2edd2c5c8e8aa066dc701", nftId = "0xc13756ece2335661fa7080534511d6ba1868a9b891af8f7e6410c9abd7c97962", nftName = "LoopPhunks #312", nftImage = "ipfs://QmYsLJewi3KikMXCjLftg2gy8vMToU7wZYdMHisCDvFyDc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x10f9bb4f32e98162a3938594c971633c36bec6da151695e231cb393a2ceae7cb", nftId = "0xc7016b4773dffb998c9126691f878a50221d808e3147a8c698bcad8ef4f77299", nftName = "LoopPhunks #311", nftImage = "ipfs://QmdAAXkdKp9uG1uY751EPyYP93tHpQTpv4b9omFBSScZzN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x12c6d1db270629ec9e4e02277b769f62d8c548313f6c02a65781a0bcad9fc05b", nftId = "0x630415f3f587790f5ec7c7366997095961833f0626e1478f2b669a8f9dbb690c", nftName = "LoopPhunks #310", nftImage = "ipfs://QmcgP79icEvnykcxTZLgB62eSLiCkRD35SvvRSo65Aajd1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x23183fcc4a5d8e8230adeadb53bc523319aeda85b6c335d96ab5c26c6dbe8b08", nftId = "0xe65d40ecd3f7ece4eb2fedb69da9bbe2c13d4a4140686437b82b9a027ca73a3a", nftName = "LoopPhunks #309", nftImage = "ipfs://QmVh1bWzJ9vFpeXP7j3a4mMenxHi4MSC4aEZoGnzBxUdSU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02399f65312bfa89e56dfb87ea2ed030119f25cd5f9f25c703848239f026ef21", nftId = "0x5a2e1e5d02d3c5b5abb378913a16441b2208dcb7a72a835603becf9d8d1cbc0f", nftName = "LoopPhunks #308", nftImage = "ipfs://QmZiYTJQcTSPArsH2reLMBJAtDWJNuk1th4C1gcQ1wqk1w" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28423dea479c72b2c62eb650ffdf5b196f611bb4b26ff5e359448d9b0bf641d9", nftId = "0x6882d79c45338860a5d8d2020a2eda45749520d0e1f38ab8467e2466e6ba6e99", nftName = "LoopPhunks #307", nftImage = "ipfs://Qmat6E9NcjcEoxpi7RuxRZdKf1HowQXaH4Dn5Qmh6JnQ9e" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x25e5bbe2f9c8f8c47af3a251a54b63d7370171ebb4576a2a4b7ed9374d4b9108", nftId = "0x7a57d2014d6a10b9f394c9446198808b1c84f9e49ec1dc049023315f8849d064", nftName = "LoopPhunks #306", nftImage = "ipfs://Qmb6ap5TScu1yAUhZLsu3iWPMCLesmQE4iCNWgAQqDDXUs" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e5ce39b97809f59080c6c90aa278a84970295d8a52f2439090a853a3a397d08", nftId = "0xcaec78820a7d3d9dd823c3028e9d077b9ca6e1a6190c7ecd7362cee8853dd683", nftName = "LoopPhunks #305", nftImage = "ipfs://QmXF4XHuQNwdyD6d4U6Xt3pBCZvQnsqK1fWefhMBkRumsj" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2d36a709f7989b6054338eb28182a754c396b15140a3ddc22ecc5cfc2d5f2932", nftId = "0xfc5fcd50bc9c237402188999909fe92ed50f9afb5127a5ab1830c51640da88c6", nftName = "LoopPhunks #304", nftImage = "ipfs://QmahRuNdzzkESDm9AuoxWNzvJwqKhxERRzE99d8gCAk1Zw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x091e93dfdd0af5fbe9991d76cd0aec29cdb5859eb8765c66da5b520547b52c37", nftId = "0x528d97ecdf279c9d105fa77614cfb028ac11c1749840679789b12b9b17a5eee4", nftName = "LoopPhunks #303", nftImage = "ipfs://QmVD6885Ch9Ce3FA45z9DdbXghDwA4FUuEomJ5cWkisWYq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x03b421482c6a35ce442de41a63d57804ffd015baa4c32702de5944e4c7e0b067", nftId = "0xd0f8975d0093290c0cf0ce15cf0858e12f248f5dcbafbcdaa9500cdc12461c6b", nftName = "LoopPhunks #302", nftImage = "ipfs://QmRyG2k8JncYiyaiwwDjKTMd2afy5aq3NkKZPMyVLEmhew" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22d0b4d33f3c3af72dee3611ff7f61f892a386f2ebf4e79079093961f101255f", nftId = "0x6a074d191ab8b244b061988ea7b4a569f64169aad53024b67c9d0213804fea4c", nftName = "LoopPhunks #301", nftImage = "ipfs://QmY7beayY3zcHYi3JB944dknJL3VqTLRK64iuQEahbqSSb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05379c64980831123e31759c03850cb262e9a149d774c806f442bb14fcfda82d", nftId = "0xeac9302288ed9ff65852584ddc0dc2c190036c04ab92fd0da56830ac021ae8e9", nftName = "LoopPhunks #300", nftImage = "ipfs://QmSYHLR8WYdAp1RLAZ6GR7sVPRqsGm56bk83tLyRQt1Rie" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x295a5f180793202abaaeedcc0a07609784a8e2784e20a318078779082547b028", nftId = "0x749250800e4ca9c94be428fa0a68630508e4426084820a910d60d88d0157bb31", nftName = "LoopPhunks #299", nftImage = "ipfs://QmYRXX4M1Mh14xx4mSrsKHyVYpV1LsXFCoynhYDe7QQZYx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1bafcabeec35a0194f3798dbde9aea472544f4f55a521ac1537a81f1675773d8", nftId = "0x7139d0e631fc7a3067b185168fe7a3f9317e8a1c41a2d621c5493cedfced8c09", nftName = "LoopPhunks #298", nftImage = "ipfs://QmXhS5KECZ1SbK6k5x6mJaBsSjSMWkVodeqHqCg8sKJ5CM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1a69c6b0dbcc64c9b2062d8f5970cb892f110cbbac14f9734c850c089807347f", nftId = "0x055c1a2ccddd1aa5bd6ba60fceafc7b6d5b1f42f3ec45daaa927934fb97f605a", nftName = "LoopPhunks #297", nftImage = "ipfs://QmfCddJ3y7H1jE8emNMVNQyC1Z9UiKTBocYgQUG5ekRHmw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2bc131c993d0fa2a7aa482689dc0fd3aa2893f7a6cd4aca8070ffd671e47c111", nftId = "0xa171c0752a6079029d7cbb907451ba72441dfaa9d485c2d17dceba04239ebc09", nftName = "LoopPhunks #296", nftImage = "ipfs://QmS5Mfjnejm5X4jPimVaJWdDfCeuKPszbnAZyRU2sukpzw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c02eb585e14f544da4668d0f81d012b3be008027bf85661fa918b8f18142cd3", nftId = "0x93ef2c0c811ec16c69daaac026fa4927dcd697cac79caa14b974e6374ee53c83", nftName = "LoopPhunks #295", nftImage = "ipfs://QmWzyFVo4xJaYFQoACPLpvuRTS7QUQwtUgu3txogzttbvL" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a853ad3e2549ac4ed4aa416e66ffb34d776947485e74c2407be1dab7dd26231", nftId = "0x91e06addbb7a1acba73ea511b3e23e7905391b498ef6e8881119ea67b4748fe2", nftName = "LoopPhunks #294", nftImage = "ipfs://QmfLhh9dwY7G7EWniwn5tv7uQ4PeMULkT6viWdTS5kk8BA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0df2d0053e1ecc0edb378879f4099a29c7a602fcc180e9fc0cb42afafb44d08e", nftId = "0xb06e3a6380793c37a066c9dba678dda954e94d75148cff3fe736a5d22c5c1126", nftName = "LoopPhunks #293", nftImage = "ipfs://QmTRpYfBDEkE7i4LkBeg3MARfSRDFgySQMvU7aJcnZw7w8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18cd7b49b61662a96bc2db8ab0b94f450f9fbd6431b17dd42fa182cacb460665", nftId = "0x955dc6c9cffa04c806503d289f30c47b5845e51e8411286029045e95ab14da76", nftName = "LoopPhunks #292", nftImage = "ipfs://QmY2gqwW5KmJfTNkTtqnRhr8mYWUsopy6a1Q8YkTMwhCNW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x25a4d92935bbd7671478bb9aff48708c73ceba1c2d5dcb06a33c0ad56b2feaff", nftId = "0x0aad2d9c0ed48473b58a67d61a96a822c01ef0942cb5fcdbf4cec366b212743c", nftName = "LoopPhunks #291", nftImage = "ipfs://QmX6n5CXsXkcqPvTPow4rAWSGshfHQdU3ZVH5krkCgxpPD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ec6ef3296e6d8d89af5ca2268f5139b5c9405a12c564bb627b0037c3a14055f", nftId = "0xee406906283a5f8a65cec97869c43ad57d89602f63b92c9adf019fee84f90b19", nftName = "LoopPhunks #290", nftImage = "ipfs://Qmb5vvoVfa1mXPhYaWFndFRH8rc6txfeuPQYsUAMPtX157" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00c280c8b32c83a54f4e782ff9b10d438c2c71856a8d0d5aa1b114dad7b9ec1f", nftId = "0x2df34a5bc7fa92ea35aa890d54f82126e6aebb6e6314866c9fda6e168dcea9a3", nftName = "LoopPhunks #289", nftImage = "ipfs://QmeyN496m4VPXKbk7axpkX5nXBehuAkFBhwyGvNFQ1rh4z" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x21dd275d5b43453bd1aee63b3ed1ee814324603efc7080e84161b559d66bf997", nftId = "0x22143dc0cf5429001c2f477720db8a2194385cf42940af3d066359cc619936e7", nftName = "LoopPhunks #288", nftImage = "ipfs://QmcbqD8nAScAAJezx9pkGt9TH3EvpGimmsGZ8WVys6F2PS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14460d09d2a7df79d3142ba9a9e534edfe1985eecf089b40bac9fbb5507b4af6", nftId = "0xfc44b9325a2ab5817ed7eeb390fd4fe5935201805064b24330b15d4be0fecb7f", nftName = "LoopPhunks #287", nftImage = "ipfs://QmcH8ukZ7kFh6SRh5ih67EgCkEnNkZ8txpof44oNbUm1Ur" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x25a043c27f978254c2de88dc91eb96f2a0bb1fab4a9dde22eab2cc29f8555b46", nftId = "0x1ed444d590eec6b5df4e6fe8ab51c11246e91bd313befbcde44c7edb0876d9e0", nftName = "LoopPhunks #286", nftImage = "ipfs://QmTMV8ymTVvPq5pzBw6hBfmMp2iAriHvgHgujKr9jQDTLZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x176ca98cd932fb25a17a0da2ed953844a71b14b1b333ec6e8d31e98edb3fc31d", nftId = "0x41b8b36f58cabe783e82e6e74ef9fa2860ee75309441a1e38e03ce16534e9702", nftName = "LoopPhunks #285", nftImage = "ipfs://QmUecKhsATTQi3E3rDCaaCnsbnR6m87a6w8EjBsrfdNdzW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0dd6ec4a330f0f5f3a8a7acd8936ac8f1a07882d69c720238722170f2b512436", nftId = "0x01c8faff433837b90d9068604f82abf89ed2018b770ea0ed4b892ea42ac40cf2", nftName = "LoopPhunks #284", nftImage = "ipfs://QmXebovTYBALdzoFLTMwoWhJDzPTh7Jy5xZSXvhdJ9vF4D" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14e6b14dc18b932dd7777e28cb437101b38d91734d51b57352a482d45e0a648f", nftId = "0x7f06dabbdcb08f5b3d2233658c7ce14a9162ae4792f45ef083a67f7f3dfd9505", nftName = "LoopPhunks #283", nftImage = "ipfs://QmNvVdpjqHKmCp1nZHFSZPtewYBrC4UibeYS6jQtR3XrHh" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1a3c983b79c54caf8988437f02dfd1457177e6e31b0d1191826f6d70d4f638ba", nftId = "0x20ea6641da70bcee78cd52efd38ab55a9e2bfc2eb327cf77d70ac6648f36cf6a", nftName = "LoopPhunks #282", nftImage = "ipfs://QmaNKhovNniZFJjtNtwxkPogvqr3kuiPydK6dXTndABCwb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0991dea511b27cc1ea2696d748b166116ea1d64e2229cc67d8519acb05753e21", nftId = "0xe3db67b6dd3024f115cb8058f047405720d2d9c36688040caa1b80e89906f6d7", nftName = "LoopPhunks #281", nftImage = "ipfs://QmUEfVJ8ZGqXpzPCpnophpj5956jiZNPW8WrfvKHpD57Rw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d2c43688bcb37e4ae5b1f3c930093618fe4c4247f019883e650dd611a7850bc", nftId = "0x687d09508af9f9a8a294e828784581b1597cd92a5020aa7686f1c8d4d7709460", nftName = "LoopPhunks #280", nftImage = "ipfs://QmNzkdtKzXGzXs8snmU8ZA6BhedZTRSzBFpkpM4q7E826M" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13cbbc9565003c65e0758843092288e65bcec01444631e68fc25bebe63952670", nftId = "0xb0db1bc4de009a8bd77a24e9db061a122560084ea05846da834688730adfc9e5", nftName = "LoopPhunks #279", nftImage = "ipfs://QmX2xfip6854UXanpmGmqPEChZ2CFRhdGECjYsCCVbV7T8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2da9b7e3a5f8d345837c8d3c030eafe78bf86a79d8a484dbb003e39c121c719c", nftId = "0x5fc3ee36b644c321a648c7dd916b60544cdfa99d7fe0f02bb4d69ed8f0b42261", nftName = "LoopPhunks #278", nftImage = "ipfs://QmeSsGEgEe7s3RZEG6a3CsTiVDUSGZP26za3r8hY56ve8U" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f7813407e6080eda8ec8f131ba3e4402a69beae386217003774820517794a6a", nftId = "0x1123a7007810499f4d3f424ffb7bee29d13cedc3cbef4a50f32cf94659c9b273", nftName = "LoopPhunks #277", nftImage = "ipfs://QmWSkkQfSyqvo6vxKMDKghhm5pteQDNLYgjCRpkit2kBwE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0874462dcc200569500717fb6c5b49477a7cc7934cc30e1399bc2ae5df57bf72", nftId = "0x0b84ab84f38fe778101d8d66ff36773cbf35545424e0518af2d67f250aba2202", nftName = "LoopPhunks #276", nftImage = "ipfs://QmS8br1zLmyAh6SXUrN97aLq1fC7ia5PuqVNeC7VdtjDZ3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x06ca7a8e4d4b15d0e0939a73c46644383c20640d5706b57612814fc2a30cb7ac", nftId = "0xa0d030fb3a01e46f61132eaf850e74c0debef9a55d4e33ca0390acc9d94f78d5", nftName = "LoopPhunks #275", nftImage = "ipfs://QmaG1L7adsqahftpJn93btz3ffp7puPSVBbi9u8jrygcXZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27c98e7adcf92c4e9ca58a4d82dadc36115cc0510f5f76525c84f8baec69b8b0", nftId = "0xb70434823236de4daee2a9c444ddc1638fa936fee7381391959aa8e0eaa5459a", nftName = "LoopPhunks #274", nftImage = "ipfs://QmRwUTFVwGissMEK89xxxUgTE46gcFcRdA9kW3w6jGKfa8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0aeae7d4f934b980ad167eed5d06d977128e457e22540b2013369c285ca7a57d", nftId = "0xbfd57b1e6ba89b1a8484069cae364b015801d39943223584dcdb2cc96fc637a5", nftName = "LoopPhunks #273", nftImage = "ipfs://QmZksHeE4Tu9rvEYwUrapPLMK2gbbZpW487AjXgCmgk9aM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x09dcbde9f70eab92de5958f18cd1917044c5ecfcb3ec187737936cfacfc4ca26", nftId = "0xcef0e307a6cd1f294531985d97a10e7c27d6495ae7fa7bed60fde038ec5cd259", nftName = "LoopPhunks #272", nftImage = "ipfs://Qma6JT3DcQLP4PRQCQVJnFew4E4PFUriVtcbcD41zQjdxA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x273f3d344a11b95f6bbed7c10ec344cdf16882c5af1e3feb235e8a3b2190f443", nftId = "0x83855d9723ef49bbb8efb717386288c5edf52386d26156b5ebf5952955761c78", nftName = "LoopPhunks #271", nftImage = "ipfs://QmUjGvSRmBBKtVhuU61CxmiBhLnDUgH4rSJMXdcGfqtqw6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14fafdf89e088035993e9629f8e2d009182c8a01fe7725f151116bdf97446855", nftId = "0x80170a95f386caeefbaf87a65428dae730ffe280a87fb3746e7e61f61b685dd5", nftName = "LoopPhunks #270", nftImage = "ipfs://QmeWztDfPRUBDMVyjD6zqExBDcSzvTLAuaW4zXAMokiqsF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1b637f1ff30adfffd31318c48a8b05420f44fbb276233fdbcc3ea3bf20c841f3", nftId = "0x3c9d33e4114a1e85e7853a4548e4c1db30cd1b1bdae568609745e0fd61195fa0", nftName = "LoopPhunks #269", nftImage = "ipfs://QmWkhoCfmgJN5mWFkFFCfpQrRA6nBRpujxVY9Dqj6oVYqu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c11cb64402c1457275db50da8e65cdec8909bf06e4aae28555bda2ef81dd1ad", nftId = "0x798fc6870025466e0fa4ffb22e92a75ead31ba58d682746caeaa8a1c57e45742", nftName = "LoopPhunks #268", nftImage = "ipfs://Qmf91pfcbqBXAucWAHHzCXUoWYgN2UnVh1AdzR3Ksx5KT4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x19fd7aec9d444642a0dd2d23075926993e3f73643a45f0bff9d7a7df008ddaf4", nftId = "0x08bc1cb48f1c9b1e4c03e87b8c9c8df335a20cbe90828b1216c3c319486ced47", nftName = "LoopPhunks #267", nftImage = "ipfs://QmRCAxRdmdxhVnNpCr5u4RR2dzQ3GptK2Y2bCxdwSANjsb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2552b2fbc94009ec49738c7f4afae39cba333b458f44dbfc9dbf9c935b4cafaa", nftId = "0xbd6fa823f816b4f8af5d232f6047f0cf67fbbe03f51e894847255d78ed4a8dc1", nftName = "LoopPhunks #266", nftImage = "ipfs://QmbuedAGs5aevYXDVJcCQQQA59xDu5QZ4WJ55TWxPL3aMn" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x133d2781913b3f3107039240ead7f975fd960cc6f05b89aa8555cae330e280f5", nftId = "0xc8135bddd5d39ecb1cf0f4c7fcd6617184cbf8296d9404401a96ed877ca8c948", nftName = "LoopPhunks #265", nftImage = "ipfs://QmWsHns8q53Q1nHB7gAKSzkBJRWYZgR4vkoZ9aNsdzJt9F" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0071fab4640da7848e5dfb6472f6ee3f5fc5083fea8b1d9a43deb9873d4e0311", nftId = "0x39232bab1c475de7fabd35c2e9aa003fa71ab6502968c2d85a0bb0148765c897", nftName = "LoopPhunks #264", nftImage = "ipfs://QmWojn3AdZtzQWkVRsW6u49PWLohk6AVPqhUAShWdCjVKY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0820d59a54fd5ee2423f7bafc91b2ac6f2d3dcdbd5afd45a793b310b98805634", nftId = "0x018f71d4524c314ab9376147d2c865eb1b007420cf99624673446e8c1ad078c4", nftName = "LoopPhunks #263", nftImage = "ipfs://QmdHYCouKmaB9N1Wvx317nS7HAtNz1XkJkqcSnCijF9KDs" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28c34c2e539e0932ccd6b07e89a9b0a6128384ec8ffb0022455b18080e8d4c19", nftId = "0x909a4f1f83672149aff3d0003d9a9681f5cb75bc87414eec02d26c98a24130d4", nftName = "LoopPhunks #262", nftImage = "ipfs://QmNSzba8iM9EYe5s1urj2E7Zk725Zb5vSHTRzmADBTN5uA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x17cbb16d53c390c130ff9c0dc148c9dd95bae2d7aaf85edc4a1a6d7ef8c1a1e6", nftId = "0x88e2e1c470ddd35a15f627daa4db2ecb8702da356f3742c4a21d630867c0d07e", nftName = "LoopPhunks #261", nftImage = "ipfs://Qmb9nn4NeXpQ8RqR5vokgzaBXYTgsM9VsoRBjoiZF2ApPm" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27eaa9510f18c4fe061882f9775f790888ffcf9ad751d64a59336f7f778c4aa6", nftId = "0x97c1d0c2a1f763572e7de2952060105bf3f528c25220c5734d3b38d7b437d967", nftName = "LoopPhunks #260", nftImage = "ipfs://Qme1ztMNRLcHhb8bXKXwjkZRxBy9YLourLTGTrGiucN6Ub" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x025c15320215d8e310aa46a05a960e5638029bef76a4a5be693cf5b7422cf043", nftId = "0x15d105dd8bce1f456bc52e13e0bb4e1046d81e8f48002735b46a0249f1e994b8", nftName = "LoopPhunks #259", nftImage = "ipfs://QmQn4qM9anxPs7fM9ojU1wJ9NENCBKkH7zJszrXkwvK78e" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x12e863646eb0e4b39865bf98615b33fcb78e90571b267540b5f06646496104b5", nftId = "0x0dbbab6d84125911efcf792b2e632f9c5064e7be4162e29f49e531119519bd11", nftName = "LoopPhunks #258", nftImage = "ipfs://QmeBuH76eWgY5DpM1tgpL6Z5dbtqH81rAmmQsMBZ938bmJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a1da926b7391ca61acb381cc40bdcb39619aaf1c135de2cf2840069efcf80fd", nftId = "0xd63c6800832777ce7b0760471b985e326d4159f767d54062522097533d6495c3", nftName = "LoopPhunks #257", nftImage = "ipfs://QmdK8kox7PPM59gBzpcYwcs4sScBeioAjHccZ34dXwyLPk" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05842c65d807d1b12978bca3f60296037596f1d51d4a5f42c5fe54670aa9d7b9", nftId = "0xc17dae8b31768e4a003990dc83d19d72456b6a300c77079150cc54cce58234da", nftName = "LoopPhunks #256", nftImage = "ipfs://QmPbAZsPNDEjCPMTaNH6f1P7x8WwH7dywLjaPeFNuE1NBz" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1f12ebdea6350af82e4a837927e1430fe605558533e6dc7605ee18dc667cb78c", nftId = "0xfdf2a5b6964ee1c1e0a895757d21cae530d67937112bbac5d14cf8ac99226915", nftName = "LoopPhunks #255", nftImage = "ipfs://QmdkeDmw3vjzrKCdUcmA2dDZgfgEWcKeJ5pSSwGXCyxVh6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28175292034ed8f1477413a422419d83f7c073ab4b84b40383e4338ed242c96c", nftId = "0x11ade8272eb517b719ab383007736a64b4e720936ebc96a65f5111c9645ffa33", nftName = "LoopPhunks #254", nftImage = "ipfs://QmSXRrAaDK6VmGsRcMD61or7LTMDWt6Eax8XDPQqEzBHXR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0e0219d6849ab2b1bb2a26b7e535517d85b1335e09c0ac1ea38047fc54656184", nftId = "0x3e5c6c837a667c3be9a5e912250d60d9efc43e5d94816625ef7b63446ea9955c", nftName = "LoopPhunks #253", nftImage = "ipfs://QmPNHbCnEXJpumb48x7xGky2qknSLZ3hPTkL39MBsoPLS3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1f4557b1bda270022dc539c94a126fb5ddc292e37680c55975b9f7dc5be32ea9", nftId = "0x47e8f49f1fc3c09d76ee2ba713241e5cd3c4b324a08d9ada2dfa051d070083a2", nftName = "LoopPhunks #252", nftImage = "ipfs://Qme3tkPp5Pv5qa1S5ZmqRyCRY6tK6725YJTuJ98GofERku" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x21141713372002c67060e7b1f6e6b01444eb5a24230acf7f403bc844f001c724", nftId = "0x89733f88939ff089b05a8f23211a0cc559143830f3056f4989519837cd013713", nftName = "LoopPhunks #251", nftImage = "ipfs://QmSMSbb6zNTdo8v7gsFodAE6dposXAC9sD99V4JM5cCKPZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x112134ccda38c08cde58c89b28a0290bae2d0badca6623ce5dfbca7159f4df35", nftId = "0x4809b024a143faf5712a621a908f91ad4822154918bffada6602d51bcf14fe48", nftName = "LoopPhunks #250", nftImage = "ipfs://QmZtthFGtw3Vm2yzhDUJKceEUgFbws9sogENmcWmRmDSGG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f75aa2b00f2631741cb0f027d1963f41bde04a00111aa6642c352f6176571f6", nftId = "0x6ef84d7e3a1df899b4d048d929e53fa402aaa0b014aeda879f83954ff4b8bc3b", nftName = "LoopPhunks #249", nftImage = "ipfs://QmVjx7Dm2MpJbUKAQiN7UexoufazEYc2f89ZtqUSA6NzWd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1901f855ea3c245d2f37eb7a8aa334a2ae9acf30a7354e9e8893e4e351be8dc1", nftId = "0x767e89ed8a108e53b94dc78d72cac49322322f4d55b814ed147a27fbc43cfcc2", nftName = "LoopPhunks #248", nftImage = "ipfs://QmdqPifhVHfoM111KqDyqnZzVzZREixDEpJBgz5EAw3bgh" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x09f101c2e37764a03d58301d461612583a9b4c7ccc2442782a084e644bfa85cb", nftId = "0x0834f032bb29f240445f9d2dcb40bd22813fd1f114831b050553d94df90219f1", nftName = "LoopPhunks #247", nftImage = "ipfs://QmVqaRrAf6emMpnvwNHhMDAV3BaDmDph8tHNPfaeRRRejn" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c831ce02cccf83133ceab09956c6f7a8ebf6a87aaafc56756589cfe33152678", nftId = "0xd26740db74f279e9bd67572cced3f463ecea0ce88eed451ea8bf31a174b6fd7d", nftName = "LoopPhunks #246", nftImage = "ipfs://QmcdWE37ZvUnVpYHgj5U5ux3hDaE5V3khoGhacEKUm8PYF" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2481bf5ac9c440c73cfc06c54522da1a75a0b181670a3447b276408bfeb7b4e5", nftId = "0x352649d8329d97a5ece3b09804a3155ddca355c1f56a3c1bccec9b6a56ff6e92", nftName = "LoopPhunks #245", nftImage = "ipfs://QmRbreSNZnfh8HYmr8MQsWkcc6t5uapdJG7hzPg8MckRne" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22e89ca3421a250f16a374f62b1c5a08434e14dd0e91cb5c356aaafde813d44b", nftId = "0xeff3385bc987c64536272d64180a99ce1c64bc6db0f6d2ebeb58d9f5403d71fa", nftName = "LoopPhunks #244", nftImage = "ipfs://QmVg8cZhfkSVjxeNBujYRyuzjE2tA1PurRjaz2CrnwwC6z" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x303ded2a778e87028bb9232221560ae609051a6dacf6be246f5785a87c6a3b43", nftId = "0x8fb21a8920a4db28e97eca7d0b4636b93135dcd3a5ee6b8a1ec84ed92dd6f3ee", nftName = "LoopPhunks #243", nftImage = "ipfs://QmXnA2H69sWkcMTduzieHt4ctSbmEWzJaMKZFJksvLeEq1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x130f559b0656f8f651e087d2aa8e16dcbf02c94b77e0e7c34cf1bf5842fb8cfc", nftId = "0x5fe47f54d757c53547996e872f9f31c2dfe0800f6c73dba720b8e9a583bae79e", nftName = "LoopPhunks #242", nftImage = "ipfs://QmVgNK89pVdXQypgDjh1ewDi3CL1ybavfctkn2GJ3ynC1L" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x17e6f342420a44435d6b36d47afaa02997d219bc93a5c8a7e6703b7b16765a8e", nftId = "0x912d643b7d3e530930f49210029fd2a9428f648f9371ade3977bb456b9ec1aaa", nftName = "LoopPhunks #241", nftImage = "ipfs://QmR7jspMSMtfYMCrfhtBqTsJws1m7YQEJBoyA1qaGgAqeY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x223437e231194bfdba68605bd0e2eea61e1c3cf5ff7f71304bdbf9a642c0dd19", nftId = "0x81ebeb1b2841e4e48dde1d8fdd5557238bbd231ac619c8736632824eaf540203", nftName = "LoopPhunks #240", nftImage = "ipfs://QmaAumWBE1ojvJC9LBKHMY7QBsg6oA6TT5P5zgzhYyS3M7" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13e4bcb28903046d1e62e5e993f6ecc8a00a48729891392721d138027feb148e", nftId = "0x75aac3a13c67d88fcc7f25718f82cde673eb135002de94856379ad47242a1afa", nftName = "LoopPhunks #239", nftImage = "ipfs://QmQJgSgHhPKpfDAYFoA4pkgiZEVuEe26rkRcP15HCP9Lhs" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x04281dddddbf8288a072cf1eb93841c09e89b4c4bb8deb2c383f8f784aa99001", nftId = "0xe639acc0f9cf53e615a1e1bc7f89c2704dfd051145309acd0ff6927fd81e8d64", nftName = "LoopPhunks #238", nftImage = "ipfs://QmUQARXPf8w7WVidQp5kGY2pqL4tBst1FFbjQEPAZ1oEoX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e67ec78a52fdc45055c5f7942ae8bc15e3217b975c285acc0ce40d66e48eb28", nftId = "0x2b4783d8e9ee3edc4ff784dbabfb86f079c977848c624f5888123f9dc22b5111", nftName = "LoopPhunks #237", nftImage = "ipfs://QmTaQhYzkgD9qErD1FceU4uoFBHbd8vJJqqCDfikBhXWgr" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ef7f15f17be158c7bc2e05f1469dab1690c12fef564de5601c015fc400cd7a3", nftId = "0x94282f02ccad35cb6db5801898b827cd6f028612ab18562f083ba9121f2958d7", nftName = "LoopPhunks #236", nftImage = "ipfs://QmNgMWiSd6PPwnLfKnZkJHAwbbmj3VPEQVxGHB7C7UBcYT" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0afc41306b3a67c8150cc2e1400a033e7026d91f5aee8eba4926186bed75b6a5", nftId = "0xc3b8dcffd6e30831507f70eff7a0868f861d1d3347ab315d3adf22cb17785fc4", nftName = "LoopPhunks #235", nftImage = "ipfs://QmQ1ZjBtsPvL44umeBRbsBwdJ4GvTLaph3BmmoEVz19pDG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x11ccda7c83d2963712d5b61092717b72cb4e03e7fd70f4141dcd3bc15c4b184f", nftId = "0x0d2d8e8280d78e59d3e10da6f586baa242f2ab25718f015852571d44e276411b", nftName = "LoopPhunks #234", nftImage = "ipfs://Qmf5jBrJAYicW6uHvu1vFZQanmvXdqxdiChgmhwdiGh9tj" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x19bd0eb7d5f1b26015b69d25ae80a021179177edbcb66a7b6ad7f2280fc791d8", nftId = "0x223c5548b70da26a5549045ab43cec28b7e3cf57ccff5f7e238887a31f8aba97", nftName = "LoopPhunks #233", nftImage = "ipfs://QmQ1W2djGmJ58gfMz3A2VA5pXXKiETTJrq8VhdTwgobmHu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x237c0df7a55e2421fb47f65712e009050514ca277dcb2703d0333be42360b962", nftId = "0xf9bcdeb4428359b5339d8c1c440007937645a835d21cebc01bc4839df44a1b2b", nftName = "LoopPhunks #232", nftImage = "ipfs://QmWr9iLfwXNTEFbJoBWVUpL9GiTiA5d9DKPLXRfEQw78Vt" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x19c979b5ab65fd96775e754bab5c08588f6888764ee1c94e2f675eba126e1114", nftId = "0xfb546f790b6612f058783f83df6a7d138b0506065e008669be7df29f438bb764", nftName = "LoopPhunks #231", nftImage = "ipfs://QmbgjyY3726mA5fjNofqFSTJirJzKNosqjHvFfTHGxU3ot" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2d176dd11abd437cec1928092943ae15f9745873bd09ac0ce7f275d153366119", nftId = "0x6f60a2b7079ccc5c835ca0cfafa721b543a04ec0ec5f7c9ac3785ce3400cb8b7", nftName = "LoopPhunks #230", nftImage = "ipfs://Qmbp3FsGtSisfLrF12YGD7fHNzwKZuTrCbarxnmajvGarm" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2d8765fc1e520bb52f6f13ee845e40c250c90532117196407bc96d00830ea19c", nftId = "0x67c6fd58835a37fa22255ddbce96489164c87c58f67b2b1f4c2e629a8a5c21d8", nftName = "LoopPhunks #229", nftImage = "ipfs://Qmc8DaduMB7hs8jZkrSez8gSmfFnGPhofuR6jL8XpXWsu7" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1a37c5ad67b9caf93795744e18226b7f584bfb3b0691b9d652e74036351fcb50", nftId = "0x72df9965ff517f2faebebf570a03c579577b065c0785e20fd5c7e1593931f8aa", nftName = "LoopPhunks #228", nftImage = "ipfs://QmYAsTCwBLBECkbgWsZTkTMrNkYRDzrpoPqh39HBPXQcMb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b5b74bf9456071ea23c0942cfdb0f82d213bf9ff89dabfe1dae1ac5827c0b8a", nftId = "0x00a39a0a7ec3a1d4e70672eeb87f0364098d671ece6b916729e0da46818a2378", nftName = "LoopPhunks #227", nftImage = "ipfs://QmR9QTgPgsemFAkYeAQJpVUtAWqJqAEnARrR7eHV3S8rTX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14efa95730fa5248e8452855923679aa944e35dd581e2269da59c2a68f12e12d", nftId = "0x6f19eebe4f974f82f8204b9f9f32766942e19c8182dbf96e086fe36f03e92e44", nftName = "LoopPhunks #226", nftImage = "ipfs://QmdrVQDbMhgZuS54FZdVTWBUJc4jjwr5wR6nvE6BRCbqgw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27d556447834bf93860e371a4bf25509ffa9d0f0614cea07b1eb2b9b5b4a98d7", nftId = "0xa3d942761e9ad2d34811c90491a6368230ae38d657e9240876390ba86619d42f", nftName = "LoopPhunks #225", nftImage = "ipfs://QmVay8GdUQ3FDQd8VzWHiZgJxWEGR5FCYaLu96bMEsbFy3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d24d01e58d2b06863ccea7b7134bdd5fc3b0234bf9c8c4b2e630883d5eaab50", nftId = "0xe7a9f1b20228a3055fb0cd6470315c2b99e85acf9e91b6f57ce9fc60f4d302c8", nftName = "LoopPhunks #224", nftImage = "ipfs://QmYbWNtuFExYsCFMgE5zt85PXb27yPtDdU8MZzTmM3b9C5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x292bbe7b58cea1858283c33bb7b2340b2d752f673d8128762af86064c58f0779", nftId = "0xad91323aab3c5a3bafba16cb4c30a081907a7804d8f55d0927d840f57eddcd50", nftName = "LoopPhunks #223", nftImage = "ipfs://Qmc68sdon6fSAhbHCn9KdYv39QQi87RWu8xdLjdxWXbqRw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2dc552d56cd6c137d650a8ad692ec164f486bd33a9f7639ed16db7ca0d94df99", nftId = "0x52ddab419518b16bf6cae9ff7470b1fbf657e80d44f32e34f8f9a8baf4d31470", nftName = "LoopPhunks #222", nftImage = "ipfs://QmeAy9EXRSPUTjGvVboc1Za4Fy6MaZtvxqiwPsUKYnkBH8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15845277a4b0d9f4888e54d93ad7bb52c71886f37342ef789be88a4f3d7fc5e8", nftId = "0x0783f982b33929ac4ae7fcaf466611cbcad60fcb58500bcc9285b72c2c804f55", nftName = "LoopPhunks #221", nftImage = "ipfs://Qmah6suviYAPbokejnwcFpuX6zk4epoM2rkmemfo4SH1nY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x082d1888d97cc459adaa18f9444664dd2f78781346f8f4d756568874bbedf705", nftId = "0x0d7bad63f1183c1bd5d69b7a7db8fcd14e7acb1338a8559dc4678c16a6c5e1c4", nftName = "LoopPhunks #220", nftImage = "ipfs://QmdNb19GcEz2BAkq8yRjJGGFkSdBNM58UcPW9tF18wY1d9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x195072a5a50550bb6ff554684a0819367ae7a58de48add94014dcf28a26623b7", nftId = "0x36903ee3340516a80cbdf8f714d4b112fcb851179c00190cc3781e0a9090907f", nftName = "LoopPhunks #219", nftImage = "ipfs://QmY7FNJdAFM9DhbXdndJLTSvUf2thiAi7NZhfzceLaZeii" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a9f32915d6dd46a711c0bceb247d667a22d8d771d50fc8be91cdcca01f8aeb7", nftId = "0xea6c0065ed0051c1399b016f8537a1a2a1d76ff9fd21f44adfc7eb96b3900a8b", nftName = "LoopPhunks #218", nftImage = "ipfs://QmNjT9ZMKfN5CX8tazaTQaaVqxaetSVPFCUivKVjFTUn9y" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x000ab95716c97bb01efde2976e3d7e6d5127973e98d2ac7d8cf226ddfa185f13", nftId = "0x65009350e6edcf0147c7edac07aca4e15f477c52456fe4d0fb3e3ec642c8d269", nftName = "LoopPhunks #217", nftImage = "ipfs://QmWKDo3YvtGxUPZwuuYv1AVJU8aunesqqnG1Wpu7MQtp9H" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1991a4d48881daa63443a1680ab105f394908c2f6619347485e356d4780cee72", nftId = "0x17820e3fd880a126b7969a66e0b5c266fbe36d3175c8b53eacd043ac2fcffde5", nftName = "LoopPhunks #216", nftImage = "ipfs://QmchYFFVtz7DDgsmqsDzaWuM8X9BX2z3q9seRn8wkWyBf8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x230b08c26ef31922e63b1b7e96881afe0936aa26a561a0ba4c324c5b99923424", nftId = "0x1b3b74617149f289897c36ae302e9f35dbdc14793b9d1178e3929d934658aab6", nftName = "LoopPhunks #215", nftImage = "ipfs://Qmaiu7Uy1TEYup1kmwt2i7RdYQzhMqkmimnr2okg8fsUB9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x248cfe4c7ba2edc1a4db4b62dc733f926067297fc51045a1829879f12265f5fe", nftId = "0x3b77a970ec7df85948d09807f3801b243edd2b1077dad64d4f13fd66fbb04bc1", nftName = "LoopPhunks #214", nftImage = "ipfs://QmNYELHktbWxmgDJbgHwYCFmtNAQFKcZdvKVq7i4VTma8p" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0bd0d07ccdad840ab7d1da138adfa0f2ff3d182b220139bdb4432aec79886584", nftId = "0x2f74eacc87918ff120a62a38a0c17263438c9a604af02cb2cd2b06b9733d5795", nftName = "LoopPhunks #213", nftImage = "ipfs://QmQ5Ar9i1bVRcKyrMxEyLpo8CSW9hX6J2aRX4HYyq4vwbc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1203bb67d2f4754df1ff2a2db2c83fe7cd1748ab5468ef186ed99595f367971f", nftId = "0xac56c151989dad283a19a958383a9fb7ed0f42616eaf3bb9da480cc9ff2d4e79", nftName = "LoopPhunks #212", nftImage = "ipfs://QmXUhKfUjGSfwPMjE4QLtLwm2R4q8Y7JS3vbMw4FUEY78X" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22b50db96e85488449e7adf7eb25ef7a54062cb1449027ce5bdcf8fd225253f4", nftId = "0x95523f20d45efcefbbfd0b661285befe7fb7e4e428fdb16eb9d4cfce14ebdac2", nftName = "LoopPhunks #211", nftImage = "ipfs://QmTp4zeXNevhKdcu4tsmc6puqftT2CvWa85KSpx6AgLVKf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f15f3f78faafda8859e7abea6a8fd7fefb2b800c57d9d6feee842aa8b1d9871", nftId = "0xf61a35323a9985796859c9a285141f1b67186afb71cb357d56ea4543f67ba2d2", nftName = "LoopPhunks #210", nftImage = "ipfs://QmWPgz1LubE8Zogiga428fawpjpC8GZNp7Ea3q6z77uLDX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0290bc5003769fe9637a07869f86ac764bc730635beadc2ba330353afd9a9145", nftId = "0x960efb38d6a3eea6a58babecbc69eba271392bab57317c2cf4a64a1e979a8fc2", nftName = "LoopPhunks #209", nftImage = "ipfs://QmQmBQxLMbQi885bn99MDmYK2L1iN8QtEDHUNdYNbRwA3Z" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a381b1bcf0400f65734d987ee19c9c56507646fdce6e256396dd1fec519f482", nftId = "0xb8735e6b1df23cc67d5b361bf1a9c194e9293ba8689b9b8f1c44fa4a45ae7633", nftName = "LoopPhunks #208", nftImage = "ipfs://QmeusxAKm1FSzKdsxWgMjHrHxQv83QHPsxTH8ivMu4pm6W" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1945bcd39aba0f764bebadf0b85a9a37e741b5ebe5e1d9399ea32a42483e3e20", nftId = "0x316ad84e48ca2dbe38fce3ce9d807b421cf876d5edecd537bd159ed01f46c3a3", nftName = "LoopPhunks #207", nftImage = "ipfs://QmR8La5NiPiUshN8DDGBDbTUhb3aWpgADYEXirgQw1Z8VZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x032e6a2dc3bca9708eaa739c4c8aeedb6121546e37398eee15ff208c0ad9deb1", nftId = "0x4b5fe98fcf98d6efc8e4202973e1eb1c18c6efc60b0ce5391606905a88a44d25", nftName = "LoopPhunks #206", nftImage = "ipfs://QmS2aKY3mmfFaeiGFucbyheuWFbGngzFs69exMzfned2Gc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0beeddd36d9790992e6875b86e28669207c1fc655bf41e36b74a4dd44de17fc5", nftId = "0xddb8fcb79c8ba8a9cb80bb19beedca34360efbbee51be9c023cb3063c7927b85", nftName = "LoopPhunks #205", nftImage = "ipfs://QmNTrA31NcPm7B1XtZ3ePxmiHBpGPF2XKGFGaeZbHQfKC5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x23abec321d3fcb144e9ffa768d8683a8c33ac6742f987d92f747fa4831a712a4", nftId = "0x76c94e1f33d4c569cf07bbea56d4a9b83a7476a6f6fb0987ee5e92a827eefc70", nftName = "LoopPhunks #204", nftImage = "ipfs://QmZyk46PviSMD67HtLtH13TzUGmA4bNuwngmwZqzTtXkYB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x241f8bb3e8f567f931779e8e69d4bccaa6c836dde563c4c63e25c18e118e1881", nftId = "0x99972a1a6b98961f10a7eceaefb67bab1b2c298883d2e6fce4941da787d1dd62", nftName = "LoopPhunks #203", nftImage = "ipfs://QmYKeZVFAprYjEnYrCC4kEKv2Zp1CCVpuXL2rPy8gPSmrd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x16b6f59f60b51a4d7d4a35f11561f8fb1b8f8c709f96b29637b57bc39d66b0f5", nftId = "0x126abb5af41cf777c2e9256f6f5ee2a3d124f7c6de8fe1aa3da7e9d0a097a664", nftName = "LoopPhunks #202", nftImage = "ipfs://QmY81ukVisXNu2mCh7RgvAG9WyojCcLRjDYSpzgct1MgNe" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b54986b0fa566d801c32c88e2d082cd47f39f01be9448d647e45c1175b44ac1", nftId = "0x1f976534f8db847197591ad23e4db9751a24725abf59b171d28aa57746757eeb", nftName = "LoopPhunks #201", nftImage = "ipfs://QmQxhkgYhHkzTG4117YKv4ToRAdGeeq6h7cM45UbA3xnVi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x275a922e5ab634769258b9ea3cfd39e92a6974d77a54da1c1386ca7fcce3f394", nftId = "0x251cf9df245fc8dfa70318b2063f9c61776cbe4aa0d998d1a9632a61a2cdafa9", nftName = "LoopPhunks #200", nftImage = "ipfs://Qme5fd13UrvcJUY41mRSDLuFdnwEwgu5Xsdu6VtcunVvB4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f27319046ddbd8c9b11792801109d2eb7b47421f052d6e1c520d4a0b4b75cb4", nftId = "0x6aae639706ffaa24c7f04579fe1c74daad3c3ff1c7e82021b48f11484e2945c1", nftName = "LoopPhunks #199", nftImage = "ipfs://Qmdh2AFRuYeLQ7mLYQfDczmgz5EUyzTsAwSLZ8kXmjYFb8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24978ea3844a5246616be4d1bca246cca563c57ac90a479b534c9379f19274aa", nftId = "0xec2b803e08f34ac43e22ecc21acda90f4d828ac052e34ef47e8b281ec6e57a2b", nftName = "LoopPhunks #198", nftImage = "ipfs://QmcfP24zGZK93jJeSARnrZeaAQVUSDpc8YNEe3qbhMJMcr" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x264fd2585786122b1cea93eefb632717212a9809a59aa2f21159bf17506c3a5b", nftId = "0xc69282e8128e3ffad78fa87930320bfb55f994f569b74db6dec2a8f5c7744b54", nftName = "LoopPhunks #197", nftImage = "ipfs://QmR9v2Dv9TjvmF94vSBeQpBYX5EP3pTbcNxWE1o2QjqQ89" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x237ee63befca8d1c04a49862ce6f81eaf471160f3039f704417beec515710d84", nftId = "0xe9ac0a72d4cee01a90d4daa5f28002eb6e46a8538a1862c970d48202828833a1", nftName = "LoopPhunks #196", nftImage = "ipfs://QmcUAA7bQYQx1Zg4ZKRjNkSWe1GvdpHRf8ZzFAz6SK2hzW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ece9a388e3bca19e58622d0992effed773905d66672b947bf8243d4ec3beeca", nftId = "0x7f5c10a1d7c8e929e98395de33612ea1f6dfd74cb3155d6dfb38c0820167a7b5", nftName = "LoopPhunks #195", nftImage = "ipfs://QmZqgonPzAt8Nu3TSF6mJYkAMDhvaWKwgdMQbE6tYdwu6d" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ea08ba84fc7d4cecaf01eae7c410f9d44723a1b35d3909863b8b1a72f0d8591", nftId = "0x1445adcd35a65070bd49319d3cbaec9c9513e1507dd80e1ab06b4df340c62133", nftName = "LoopPhunks #194", nftImage = "ipfs://Qmd36vdQyCtFmu9cALyRWyNPUokQmhaZvT2Ys6qEAknZcA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x195fdf01534c0dff7871dc9483c44bf058e9e144b29d8be7e1cab14c5fdf67fc", nftId = "0x4bba03ef73530f76648f6946ac3565cffab6b1a4f7ff6247413df2c052598067", nftName = "LoopPhunks #193", nftImage = "ipfs://QmSraDy3FSZ29azf3zkjdxVUVAG6uAvPrmb7oc9vSXKtQP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15526fbc27a5e8ae716bfaf12bc34f4190a97b47b834d76d4314b8cfd4058e77", nftId = "0xdc97f4b271f059e7654dc4e9b8381a450ab5058b39309d52b965cda8033e6c5b", nftName = "LoopPhunks #192", nftImage = "ipfs://QmbM7DRhvRVkBGWdpH1h7obAcQ2ZSoSC5xAdPREVcAamNz" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2692b2b2251bae1089eabf57038d9263f2622f3629a2f85b2ec33f9fa5e90dab", nftId = "0xba6b98885d78502b4cfef47361a5fa01d0aa57bf2a7a64690260df4d3d663722", nftName = "LoopPhunks #191", nftImage = "ipfs://QmSDwM539XPE8EkATo8bAzzMLsyuAkYLcWvC36G2iQEKHH" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x123fe5ac7db8ea7fdf44d112a11be9aa8a0de0699db17ca03250a2bd33765ace", nftId = "0x58d76c9bed22a06ed4eb2c795a88b14875540c1dfebf14aa96b0f543bf74b875", nftName = "LoopPhunks #190", nftImage = "ipfs://QmcukwCcLCkREg8X5Ys7Vmw6iDL7fE5g45E29va4XSw4oP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14d0328691c0cfdc057535951cc40016a96a658fdb9ca65cd3f8a88c503649c1", nftId = "0xeaded17ba0390feb0ee3fcc98a1a6514e3b1e1099450b2b2ba3065d1e53f93c6", nftName = "LoopPhunks #189", nftImage = "ipfs://QmYqcCALosfgxqoLFQCLaJCTZDJ9GnCCLpZ9HCyjPrXq2m" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x146e0986295b614df1123d578e81650dc33a02ce24c488a6de78b9e8ce64124c", nftId = "0x99caa7721fc4f279603805d0c95bb76abc43d6e578a3b572beb87e288cb1d12c", nftName = "LoopPhunks #188", nftImage = "ipfs://QmZkgqUarMeLSGUpiDvU1UnoU49A2jwKnWXZWbSs4uzeak" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b1781029e049da6b080a3eadadba3752356e5509b52ce3ab49334ffd38941f0", nftId = "0x4c34d705f7dee8b4607e963dfe1826a8cca36fe3ee58709be53842bbab3bcf4e", nftName = "LoopPhunks #187", nftImage = "ipfs://QmZYzJJWKVZes11A7Kz52bRyqrwsPyiXUVGF3he6S8jfv6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c2483e4100cce0d68592333942ff9de3bf225e12ffd7a1d8d8b6fb2faed6e86", nftId = "0x47abfe0c3c23bc4135fc36c98f1bc0f181d8f5dca094c761fc2e52f007841bec", nftName = "LoopPhunks #186", nftImage = "ipfs://QmVvLvxoSz4i7UcoFXWh7kmymTvEAseWXopwPHGcxda9nj" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00f943e91f54bb23d3509480ac864a6ba8608b87236bb5879ed16efd47c4f862", nftId = "0x2af3253790172b4b624a822268ec01ca3b7c07eca72990bd0622efe110342a97", nftName = "LoopPhunks #185", nftImage = "ipfs://QmdAJxwke9xJCQHQaqE218wT3JFbeHsnPMi5Np1J4qUQqQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0dde2dd4b686b7a9c1105232671e4f3d43af69a3ce191a8d5723ca3f6ad897c5", nftId = "0x7142bf5422002c99d8100b7cd93138d119d302f867e103fd0ffb3c51db21efa7", nftName = "LoopPhunks #184", nftImage = "ipfs://QmXda8JhQj8bRcVaA9rxJkcPpW3VTUGLnQMwxsgxyqs8j7" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x143360076096e4156a0287138650fe0b1fc7eb7bd364cacddc74c80c5b73c935", nftId = "0x96bc0d56774edcb044e1be91c194cb5a37dea45c55fea8eef01c42b76c9f80b2", nftName = "LoopPhunks #183", nftImage = "ipfs://Qmao9LBBPVTrJr5jpNoKrFW5PyVagNCUKoEa7QA3QJpvEt" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1236173234479f669ad31126f75be84801c61028ed89f10e0e8bce23c397b5c6", nftId = "0x9b3c87334f44d0a5a2fe70706afb5d0e630988af433e0129e38099396b22c0f3", nftName = "LoopPhunks #182", nftImage = "ipfs://QmZVudXAMXvX6cu4Q3F7e5FMu2t2LV3nAgymnLgzxV6STt" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x27af75edeed20472b0dfe1399291a063c3d59cb11f101957ab5470ff0e8354f1", nftId = "0xe3a3b63a6d1ba1a4ebe5e99b46bd2c80646942f0dc2c7805faacd6285f0ba700", nftName = "LoopPhunks #181", nftImage = "ipfs://QmbBam351T67vrwMuMZvTcUSwyUV5jai12m3FEjZcNzp4V" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x04b6505e8f850d29f3b203530226c273b71561624ca958c508ee44ef36c56c7c", nftId = "0x974a2c2e7c8f0dcbf77a2b2ddf1d6248db4bf9ce1b31584f37235e1184185439", nftName = "LoopPhunks #180", nftImage = "ipfs://QmdeaZEQFSdjpU5KDZERvYeWSAE2zbbUCWHuPmYN716fpM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x08b1b30a28113a158476b6f71a44ba33acb5e87112b3e5fa68f80eaf16802732", nftId = "0x7f913639713f3fd3a9cd854ea80f78a296f96bbaec26b0fc9e52de74e2958e08", nftName = "LoopPhunks #179", nftImage = "ipfs://QmbyxXe2rF7xBmaCSc8u6BteFExNF6HPZv6K7jZzWHWKGD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x06262075eae27fed1b05e6227f60b85528b9aa7519619a70b6c91a7ddb2526b7", nftId = "0xe0e3ddee19429a3e1b7578ebe6d3a3dbd556176e301f46af9b00e43e94f207c9", nftName = "LoopPhunks #178", nftImage = "ipfs://QmcEJpKRbwB3Q1HEUYJUqbcNSgL6p4B4Dqy24tWCA1HHwK" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ae12c8d21f86c89c332f459fe4919e0368108c38b91e75f01e7d298cb153c7e", nftId = "0x43ab467dc1f5da6887dcf18039a987428ae7d5221e887844fff991fb49aeee45", nftName = "LoopPhunks #177", nftImage = "ipfs://QmcRTqw19V3wFZCHn2fNdZyHNs4eugnUELqMf8RGP4uBoA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e56ad0626a64762444aab84578893c81a368c4e92158ea6d3dc0ea2b3556835", nftId = "0xdbb6b5a142390d639cf6d252d703964beef9afe3f3e4b75c68f465e5a2426ab0", nftName = "LoopPhunks #176", nftImage = "ipfs://QmYouQaAbbDcVfUgew9SSPF78nFEZAtgUUWa4QwvTeFmUd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x16771da8c876b31f3b94ea2b00913ad3b89b16a155da01e8f874079d1b942783", nftId = "0xd8ef882c4baba840adc1c14ba1da4cd903eaccff8aa94ac569ba518aa0a5f75a", nftName = "LoopPhunks #175", nftImage = "ipfs://QmcA3SyAz3DTehpfbFidkvYzswyYRgRNNy7DoUMRAzKYTi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x11d6f58041ec1dd9f6e3336a9e978e3588c8913d33fd902e321573190bf31086", nftId = "0x4df5611b45ea95d81f3509e1c53db3b301ee3d58356cee3d35e240bc508255e1", nftName = "LoopPhunks #174", nftImage = "ipfs://QmQB128n4i4xdCHvws9DYQK67L2wQCt9VXLqhjWQpMzWaN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22b62933cdd1501b74543c9786df541016f57acc1a35c59b0940db27f8affcbe", nftId = "0xbbd48f77d040ab9b6c51018b2c1cab9df4554ff5874528f7f3be8fb88817c668", nftName = "LoopPhunks #173", nftImage = "ipfs://QmYMP47mhnHx3HfTUr1zqiiXPVjMVxWVsFLRLNfBzpPFK4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x159423bedd357b3a3b500dca770a23c37bcec76f3aebea921761350c78201ecd", nftId = "0x82d984fcde4747fe312e1b625bdf9f8eca31f09c3771bee315d948c5721129ba", nftName = "LoopPhunks #172", nftImage = "ipfs://QmQLyRYhHsNtRNvrxh6AUZzJam5MvyuqDp5Gmgkwud1aLy" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ea898f0c61c6acd2fe3bd9c6c6c4e512897450d4b4143e54cd55482f429b36b", nftId = "0xb8c7028e48893d672c6371c06130f07791db519c28a31666c23b062df5f3349b", nftName = "LoopPhunks #171", nftImage = "ipfs://QmaEn2RuTepH6mHQkoqpbBmHwnfinhwHNmd2XXwLBqnumo" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c4c6c8539df24c7dd88e717696bb5d97dd9f7aa00e5ae3093a7bf89c6e91d3e", nftId = "0x04da9f3edbdd080cba280d82fe9946955068240b6e375245a920efe452877ec0", nftName = "LoopPhunks #170", nftImage = "ipfs://Qme5baUJNEt9nwdsxVNVmgZjY6bLNQfWFRuNnEZeZ2o5d4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2be9c185811eee1ee53ecdd03d0021bf77d7f36e1f4990bda6dedc0e4bb1556e", nftId = "0xe5c0d8cc5aaad3b286a06b64a8be2e5148bf6c4ca843ff9613d711397ee70e2e", nftName = "LoopPhunks #169", nftImage = "ipfs://QmVj8vfmWAPUJYnhaaiB3qSaZ7PqYzLPzUM9ZMiwqdhTus" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15a0f83917c27e20dbb5a4c080f1fef55fe2a9a4b7278d82a778e93f90b5c99a", nftId = "0xaa173268ea37bbe38554b694faabe9b6c5f321507a13d7a8d5ad03384062a748", nftName = "LoopPhunks #168", nftImage = "ipfs://QmeAcpKmituHkn75NQvA9wSZ8JeQEVhAeWQvw2AjC2JEjx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05dd3ad460016eccc28db356018492f576d9128f2f8f331470e2307b757ce08c", nftId = "0xd0d2aeb8e7f7628bb15a964c54b5d957515f46ad7802c48c160991c912aad154", nftName = "LoopPhunks #167", nftImage = "ipfs://QmZvsLrMF9KJQ96qsWyi1SP6RzoXMUTVRcb1q5pxTLa73b" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x154c7a9dc34f35b987b56ab557358bccabfcedcd7de06df63a284f9438c1d048", nftId = "0x87a42ea5a01fe848f114aa825e32a7c277631caee58f68d6a969fe1aaf8d5913", nftName = "LoopPhunks #166", nftImage = "ipfs://QmceY97tGAh5iXYPYfKpQKs5gfFZmkJ2b2qWs35Q3ZJS8a" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0842101ed2e78fdea4ef597d7f13a20614869d997456ec6e7af32f397dffd4ad", nftId = "0x203233574bd3697150275a7521db2a29638d075b9f27075dc93514bd3e73c208", nftName = "LoopPhunks #165", nftImage = "ipfs://QmRn4fvP6dG8DxE9gQP3aEqMuQvUVQ4Qb7cimpTskC9DK3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ddbf29f72278191980b709adfbff5b187465beee9ef8b85480d67fed338a10f", nftId = "0x4f4386f9536d10aaf4e89b44e14e6d85ae855f8ff1180157452d923a6b83db43", nftName = "LoopPhunks #164", nftImage = "ipfs://QmW7Dtu1nMy2xUoAU6YGgh6fgKutpAWiww4Qk9JGJ5DtTn" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18c6d3de1c3e793fc31e58e0cfd9658e43aedfeb3feafa986fe08f93faedd5d6", nftId = "0x1e8cc2ba7bfa80badab496f724140c10570657ccd93c558c0a8a35b552b61b34", nftName = "LoopPhunks #163", nftImage = "ipfs://QmTD1Qb968gchXZydttSGAz2ecVDgvVnscouwcprZhTztA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ae014aeb04ee5454b5538c45ca281a13a5574bc9ecbb32ec8929a7a2d548e0c", nftId = "0x5c6fc448f76dba85ad36adb44e30a8b52132919df068caae5a78f827af8701f8", nftName = "LoopPhunks #162", nftImage = "ipfs://QmPbhCPSSL1ojSCjEXxtDyEiY2wNsS9WMQQ4N2RvtUJ5vP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2949b26c083e46a297f206a4af7af771774c179aa0576d158c1d80054179161e", nftId = "0xf3ab71c45c05d37cc72393ea17fe5e9dc515e9bb1b11fd6eac28a32b803d2ac3", nftName = "LoopPhunks #161", nftImage = "ipfs://QmXcArtLisgki8CatkMvhrM5WJgPZ6EDQWG6NPs1SFcujm" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x04cd45805d4baa0c815c733912716776834374f1e2f7bca933d2df7174022065", nftId = "0xe59acd3f3c44f767a6b247b92ace0cd144e505f3120eac5f71f7791cc70fd4df", nftName = "LoopPhunks #160", nftImage = "ipfs://QmaEK8vsEv47E2RXozDJ72Ui1F3qjAxpEGMx5Se9GpUJs6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ac64e075107cd4870e75383a2237c1a80d2b2d59c73a61705ff879215898758", nftId = "0xd0b725affa429610f188c4f943c3d845228794c2bb84e15202934bf77824e0b6", nftName = "LoopPhunks #159", nftImage = "ipfs://QmcAkyudphqQ5NszzR3vyGLV1ndK2BsTAXsBUZEx3PM2it" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f80a99c8ad463c52665de572653d7240467b2890cec4e6364ffaf6f3dc4b396", nftId = "0xabf2d9c0d80b41595f8dd7f40f472dfcd9580f61b582c46e146f35d65b854190", nftName = "LoopPhunks #158", nftImage = "ipfs://QmR1UwuBdUdXMRLvVDBoJVbxayqmrBuvZtm4pSx7n3hXTU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x12a4dac61c7ac01fca87448ff557c60e6c3cdf7e6c82e8d337a544f55c9c388f", nftId = "0x59d0577bf3b00736f19fa86136959f59e7b71d44c6e452543535efb6ecfaf744", nftName = "LoopPhunks #157", nftImage = "ipfs://Qmden6CdpezxjmuXEFk1KWDqX1nhXkioqpCXMFZGXcfLhP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29997ab02100fa4a995140c14398a509ba8baf38a85eec9b86835573f71d5e83", nftId = "0x32d337a4284da2d9a83be838b33e77e15c0325dcf6c636948ac5e7e12f388d21", nftName = "LoopPhunks #156", nftImage = "ipfs://QmVstdLuYzKRQsfcBVwNb5jQXCdRs2FiSe2Sam2p6NMMWW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a199ce41796e5bbadfd030f778f309e27c563fef7cc4a776a00777685194495", nftId = "0x9cbbbb910b51e92e41e6901cab01142ff861dabdf1af7a084184116dc48ace15", nftName = "LoopPhunks #155", nftImage = "ipfs://QmXnBwF4NVCv6NQvfnwuqNnf9jH3qJfqjGxQrr7bKjCJi1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x202f8b3c77dc71825996acdb59babec6665e8b45473bc86f4911ea4914e989d6", nftId = "0x439ff2c002c30961c8f341e752feb6df14f3a00db6692a3b1ccf97c039700d82", nftName = "LoopPhunks #154", nftImage = "ipfs://QmXcSUPyTwDJNy1J3tBFV6s3zJAxk4WwX8R1ysoDJ9ZH9o" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2725c0235736beb0cc3c13b085b7c5ef25c16374bd009f0e0451d08d5da35022", nftId = "0x61ae45c8be9b6cd78a9253880ea09670ee5ff8fc033bac5b048715579187687a", nftName = "LoopPhunks #153", nftImage = "ipfs://QmdpjHNwWw8x2jQtZnvAmwbGofEqgZVt8AAxXdjj7YcwfU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x187611df3751949020952b22783d9c2de8bedbd18d7677732f12bec3b0586c3c", nftId = "0xb676ee9e153be138836a6a62ee41110e33d021ae15a94fe3b496d2122ada961e", nftName = "LoopPhunks #152", nftImage = "ipfs://QmdVrkzWc2DN56aBAViS5YTeVrsAoajbrQrgtncYtFNCe3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c8472c5ece0a8825f30edb220b310adf38eb6d78551a4964244c59e70f3e90e", nftId = "0x80ea02538a02e978c01016263e066f02fa5ab085f8720a2e31f663a441764bf5", nftName = "LoopPhunks #151", nftImage = "ipfs://QmaHiNVsQm81sx58qpdWXp3jYfTvD1GHDkeuBXoxDoY4HS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x007172beabb3c9ced3f9bf2200f2f03d824df1381d9ae9ac6281ef2eb8cd14c2", nftId = "0xf048db99a566c8061b0341a69e2c0ad2d8ccfb99f56ace5fcc804c19407a92fd", nftName = "LoopPhunks #150", nftImage = "ipfs://QmSA4M8QUnsDrFjHYEA2ZCMM7jVBmJkbemVoBfnSvs7KAM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1a62da515c59baebfafb8127d599640337be8f99588cdb5f6f51acb79c1d8dc9", nftId = "0xb455bf3114b03681212963383531e1d2a9ee84253456609ca20ee174e39387e0", nftName = "LoopPhunks #149", nftImage = "ipfs://QmNVf1kgWrNeeQvczJmYqpXxCk7YPTAXdQT21fGu6GALyM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x21c71aebf4da17618fd0a2377955bf58cad6eadeaa130660a9d97569460012a9", nftId = "0xbdd2f746315a5e4e385fd0bc43680ce19bdc128a4478d79891f3bdce222de715", nftName = "LoopPhunks #148", nftImage = "ipfs://Qmc69wtwwLCFibpcvmPGEPmsv8EReuu8PTdkNS4BcUSBPb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f911af7b493b77f692edf8631d3cfcc27f6319f92589cf747194628add0a4da", nftId = "0xf547f105e91aad455bcdccbab4c488558c828b35a5012019429e63936e6296eb", nftName = "LoopPhunks #147", nftImage = "ipfs://QmYu11Cuhhn7s3jWK1dd2XiRtazhYiLTVtQmyVLKvCtsKR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ea889a683387b2fd69c6ae47e588b43c65ad128d56b3bff2b8d006b006d858a", nftId = "0x96ff605b6b545cb2fdb82e8b887eab0ea1da1ec25e1b676bc7867ce2f8641bef", nftName = "LoopPhunks #146", nftImage = "ipfs://QmevXLRorTqBucE7jwtxk4jr5ECDjUZEGErXD69euBGUEc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07987ef1a627934f29ed5cbe99b5accfb91056bb56a9ab3fc4c5a806b079024c", nftId = "0x7ba5d64312b5ce4588b47786cccbb7611c4b751b7d64c5cc471d98a88b4371cf", nftName = "LoopPhunks #145", nftImage = "ipfs://QmccV7gYQcgMPfNLKRZeESJQTfwURSSWyAXn8s97mtxked" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1a7b1db81fc79561622b7cc143861372c0fd985a7a21ed949159e6e52450c343", nftId = "0x1eba9c06ac7d234e3b422f1b6bdd1813e4c0e41bd2ed1cc4fbad9ff1258fb7de", nftName = "LoopPhunks #144", nftImage = "ipfs://QmbMUMGtfzUmPUks5XDG3XYYieUPjfoGhfoJ5Ngha5bG2x" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x157c9b305533801f117718a5ab23fd99c861428069a8a3d9877c861f559a1650", nftId = "0x1cbd6c15becb78de025da54754a4a11054f334e8bdeb3798abf215cff09c4b24", nftName = "LoopPhunks #143", nftImage = "ipfs://QmNR6ZuRSghEcRrZ5hBh1FSAAnbqb4htLwuks1gkWvxPJe" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2fc950cb3bbfc36bc44c00f9f0ad798c21983146517e7e52fecc353209cd90c7", nftId = "0xfd0af14abcaa5c334d2c87ff890f82fca2719e2211a2734b20921605e14bfa4e", nftName = "LoopPhunks #142", nftImage = "ipfs://QmPP3ChHDZq6DRo6S5vzsBFPzP1wBvLL9SXYtDsLVGvFRW" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b0aa9a86cce583d2017872f71d75c837122f0be1cab0ee2e189db3cdcba4678", nftId = "0x68575659e4085b9b3275076b96c3cd4a03339a940ffbc7b62ceb9adbe1036960", nftName = "LoopPhunks #141", nftImage = "ipfs://QmZpznbETs1ZGSfWx1jwzjxWNksR2MZawqvFwotJhjwbyd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c7a1ee6be75d41dde320c269bda9fae554d5b4c9692ce3baa47dd826bb0ab88", nftId = "0x88828a3350cf65912292ab637cb1e8270513768c8468ed896d38cbdd7d23896e", nftName = "LoopPhunks #140", nftImage = "ipfs://QmehdxXREQNacvwdyvhf2XtrXpvRztMztKuw3eVt363sCd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x23c71460f577368ea7cdaf2a2288b6af71b4dc83cd5a2b2a19741dcd282eb85d", nftId = "0xe8f3066dde7f22b86e7117e96052aa4639d53ac567d4963271a70e9772cad56c", nftName = "LoopPhunks #139", nftImage = "ipfs://Qmc6WqTWnFTvHnPLqY4hJwsTgj8gWCGvWbBd6P5ccyXbdv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x09aea549eebc1f41019585df3d261c631cbd9469baf194248a1f8b8791f41002", nftId = "0xbf06adef332bb5fbb0c9e74a0f3496be6c0df0a0a28188b291055b43d475915d", nftName = "LoopPhunks #138", nftImage = "ipfs://QmazSUh7qwz3vWUsyHNhQpuQa728T7ZZBsdVaPqGjik5P4" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22ee94dca78348d2b45d0408f7187a3a2527e0dac62af07692808d6af1778002", nftId = "0x76a0eac100014a51ea7d7353c9152e165aea6f01e575c6edc2ad5db6016def73", nftName = "LoopPhunks #137", nftImage = "ipfs://Qmcncc9jnzvbNEeWkbFmBQ1bpDhLeeTKamFN5mwhBS5Mnu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x182fc5ecefcc1d97d4a87f35c95a4dc5c0bd6ae74175d736fb8de901c2e0f293", nftId = "0xaec3e9b7d2bee1247bf7f487fe81148a2788867408c2a98093702d24940877f6", nftName = "LoopPhunks #136", nftImage = "ipfs://QmS5xfGBYEHFkAHzBF3h3TQSjnZXT6mEk4Cckd3SeXxuKt" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x15b49057e0f0d118c6a3541e0db6d20ff25bac4c449ce664e6d9a32c49c92fe8", nftId = "0xf9913d85ab29042e03cca0e6c6f18e700ee29650d175786ffa7b76e4ff8a32da", nftName = "LoopPhunks #135", nftImage = "ipfs://QmQpsj6AjfweCKVoR9HHXYuz59xtCEiT6KFpzjdviSm9Ee" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2bf8a0116b328684297f2c97e4db6afdf15287d5519193a8af41810b06d21e38", nftId = "0x44ab03348a611c25df728e5e2c06daa004a8e44c9c465733d555db23e00e8ba4", nftName = "LoopPhunks #134", nftImage = "ipfs://QmfBqnUEQom8n4gTXE8zsaD6MGnodJ8kJEpJ9CceRcA15K" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x128dd249c2f8297509a508aaf1abda4d05bcf17b5273c97626d7c7b9545da373", nftId = "0xd2b1a701b3e6675d2d8f1922741304b28ee1e1c06415d46b4116b789c87cd27d", nftName = "LoopPhunks #133", nftImage = "ipfs://QmSeom85LV8ucr9KQCWi79hWFaqKnHVijJ52pxqLs19knD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2830ebe40a812fff609ede5827b68a8588a6b2d5987d9a602597583d5bf012f7", nftId = "0x99d28f640118ffaafc870d6192141f8a0c456d812a806b4d08bd4efc6795c23f", nftName = "LoopPhunks #132", nftImage = "ipfs://QmcL98qeZaiW4sUHViG31XYE1icXmgXeV2b1fiKq75Yjad" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x188aa2ad3cf70dce0fabc0359c08f12463d18c58dad71316b4c4c46b5809caa8", nftId = "0x7c9c1ed81d600dcd3f68b3118b10d4d9809c1fb1ce174a76b90358996e6c5d4a", nftName = "LoopPhunks #131", nftImage = "ipfs://QmautW2Qs38mUVu6cW1xwgBC2h1f5xSBrUA3JXNJFtAXMd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0de38ad44c640d35340c4c30519b03f24dd996bb3f32e749310901e5ae9b222a", nftId = "0x09c774070dddf1d578ecd2c8a569502699456578ff21818c1f22525f3ff6fb92", nftName = "LoopPhunks #130", nftImage = "ipfs://QmVuJ51SDCCsdhT9xzjEuVb9kGxYXzwxLjBWsMucGZ431E" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1aa88420e757a709f5a1c877f4fe1518c14004ce27a1b0d916f6ae62583ab5d2", nftId = "0xe3b16642c3f0e07650d54cba535695923af3245d9775766a54fdfdec9c85b409", nftName = "LoopPhunks #129", nftImage = "ipfs://Qmd6cmgVsq2bdyeayYJvgusGjB9jFdDAg6wTbGKLAnAtJV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2439ed0aa855d8be97f859ae58c576f681a70ebde924936a4b263a49b2f873bd", nftId = "0x15fa8723b39bf6774ab40b2f1776ade328c7666014f21b5ab4487be978c9a62b", nftName = "LoopPhunks #128", nftImage = "ipfs://QmaXeQopEbWTqpGwDkDykrqLmF4HgjJy52FF67Qq955FGn" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x038bfbd9765267953e4b94f270118964fe57c23ef8f83225ea41f310809c0123", nftId = "0x8132cf67fee7caa4001f13e08c29ea0d2177cb83b3a8bbc6dd8588c77a8b8a92", nftName = "LoopPhunks #127", nftImage = "ipfs://QmP3kYfeMQ9CrrRjEGdxgA3u1kKEQFWEKchRVenyCHffqm" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ace6e3d484e33f3c3e82e8c4c84481f4646f4f0d2dedb35a25367a6565495d9", nftId = "0x4f963455d09560ea0507c478c6abacea49afdae0b6cec804aed075c7d9c20644", nftName = "LoopPhunks #126", nftImage = "ipfs://QmTd8QDJfnNRaa99S6d6V8qWi1o12ciADEGanwLKgASGhb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b73da4c2f136ba92077ff70fc3d9a4c6792c8fd42d0c546ba2319f22eee109c", nftId = "0x395ad0b36659a94a056a4b307bc29ba4e6d950ea2d9d2b8f603b00eee427c137", nftName = "LoopPhunks #125", nftImage = "ipfs://QmTQzQpUF18AbXy151CffGsecjgmvGwiPksadShhr2DzbB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x101a1541803a0d09db776bef6d39c8f7d115990fbba1ee181acd97a0226da8bc", nftId = "0x63bf085b6c4377b0032860d15bf7e115e30c1c68225461261dcb64c030a5505a", nftName = "LoopPhunks #124", nftImage = "ipfs://QmeabsZdWTSPW8YtYDvqEwXVLHfe7Cs2VpJDWawitjMQQQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f3430f179930f630aaa2d77b518700effd510ffa73307f0dca1785a9ee811e9", nftId = "0x48ea006276fc47d05adc32a6fe389949d23d121e00b49cfabbefb6d6e1d63396", nftName = "LoopPhunks #123", nftImage = "ipfs://QmWEvnaSaRGkRFNZDbZsNHC1zQZ3urtxDpkqrYbQHRK4m3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2da1e7f85e0be7966bdeb3721add82dabb85a6e4271b2d037f394feb1a104894", nftId = "0x4fe087b3aab22632b6fb545687da8543f584c00d64c07ce486a17c5fc28d1860", nftName = "LoopPhunks #122", nftImage = "ipfs://QmbG9mVMsTP2xNqqAnLKW391uabHFDn4xFHvtZZMjSLUMd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ec3103308bc2f2d9db2d7e8084747bbd45af273d2f74890709252eba04fc04c", nftId = "0xc1e673d9d1a1f650f17e419e4e1c34f1ab00c58b512250b2d7c76acb6b140874", nftName = "LoopPhunks #121", nftImage = "ipfs://QmPPBV3DXZBT9d55JezzdruJDSW7wzYHvEZjzySYHEghY7" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a9cfda8b79165916c5a8eb10497e54683c72418bfb9b89cefe75660c2dd6473", nftId = "0xb9402610faec21fb022fd37f177a8ec65405cd7aef32011c99f3873e0457b5a6", nftName = "LoopPhunks #120", nftImage = "ipfs://QmYB33Py7oQ6fgL1fq4TuCdXVBeGtUMN3vVr3s4qUVvgEE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x081b81da92c65b9c1ed71e62334b6a79b98a158d8ffa2087ce7b5900230ad482", nftId = "0xaf278a26030ab01e9689dcd1c0ee22b046f43bee24bdb8e1f21e0b825d1ed59d", nftName = "LoopPhunks #119", nftImage = "ipfs://QmX22nedu6CEhDJAvAMBn4qeZb5Av9Hxeh7SwjwAhokm4U" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x25f09a08b756d73a1e98edfabbc1994dbc106ab7b14a697d27c753571ff882ed", nftId = "0x8d73eb54e1be0e2fa3d49deb0ce3bbaaacb899e18585d48e8f47a6531f8ec65c", nftName = "LoopPhunks #118", nftImage = "ipfs://QmfEYu1RDdUWbA3rwmbAoqTqZR3opwQHworChHgrK3cGsA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13650072eaab4eaedeacc4b2a94584880a4b7e10777bc16a38c743cd1d6a6a07", nftId = "0xcb6042626c52176ec79c7bdcaaa10142d4022ac95a10a38480588196620cffae", nftName = "LoopPhunks #117", nftImage = "ipfs://QmRSYKMUpDaRspaPNgQBVEW9x3kqkQk1ZrNywBdxTrq9aV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14eae1b16664704e4b9882802c1db310a60cf618eeaf36342b105f9830fe85b6", nftId = "0x73ecd4704659bce7c66071cf26b388bcbe663cb82abe59c77267c8a37b88b079", nftName = "LoopPhunks #116", nftImage = "ipfs://QmTiHpTJGNASxztg1EofdQU7rttDKLR1RD9QRYXGUygioR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e08cd9c4ab971e78bfbf7ad51c7bad30ac2f2aed8a94d82984e6603f1c27cda", nftId = "0x11e5ba12d04f02a0e17cfa259e8be725c0a1e4371ff0c2dbaa28d12ed64e4ee7", nftName = "LoopPhunks #115", nftImage = "ipfs://QmRdyaVZc3GVctjyUSH6eLTkXkPkWZGPEFKkjJCY86j1WJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ab2f64029eca8f2645064950c24666f5c3b61c31ddaf0248b63876e974d375b", nftId = "0x88eeac974318da5b7de430afd88cc03fa1b44785bfc27fdeef54d24248b2e711", nftName = "LoopPhunks #114", nftImage = "ipfs://QmQUGqMnqCmk99yg7N1zfFaTN49y5aTNqtG4Tedhat1Rok" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f2a61faad3e1e4bff442b64fb3d8ea75b45050512800179e670044102aab243", nftId = "0x9fe8efe9bcc72a9c0d25a4fe0a3f09ccc426753eda562e8193eb14bd0602587e", nftName = "LoopPhunks #113", nftImage = "ipfs://QmRZypmB4yop3XkbisYawEzHo3FHZn8BThKs4HmYCwTfvM" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x300ad9118d2b2a818bce7422ca26b07396c50787292a43ee97e9689b754d15b6", nftId = "0x64054a41535f0c84cb104451c099bf2e8617bbf3273f77e63e0eda3e4b650e68", nftName = "LoopPhunks #112", nftImage = "ipfs://Qmf1N63gAcrZQemXZrszgtFVkxggi95Wy5JEfTgA2vADVP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2731df3ca2f4bdbade5e9790f098a93036fe975c38943b1bdb177e08cb841f2f", nftId = "0x8ea3d00342025c69f05b05e9a27e31518ec240465a7dbc2ed485795225cab7c1", nftName = "LoopPhunks #111", nftImage = "ipfs://Qmci4JeU7rk16qEL86ETz335uWeQr2LDEhHrDkEZnLyDUe" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1db681cc1443c68f0f6c49632b701655b597e7fa0a2a4fb427ea03b77fd7491c", nftId = "0xa46aa1ec64409a0250abe49a69445f5497574cb2fb10eba289c0c176651a65e6", nftName = "LoopPhunks #110", nftImage = "ipfs://QmVVnV5Am6ccmVfgF5CK99L2LYB5rzU4WawSXxGvb2VSh3" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1fa74909992fa5c4ee5947d9c3a573f345e5af2c6913553dcac4abd0bea1c175", nftId = "0xa24da11cd3944c554923337f9f14251c478adf21ffb6dcd5a82bc9caed6712f0", nftName = "LoopPhunks #109", nftImage = "ipfs://QmNqVqu5v8NR3V3qFSXEEtwKUCFAwd2UcmoeK51p8xhWva" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x04cf5598372791626c064fc6751b7fa11ac06cb3fd03ced55d1871f259354447", nftId = "0x620968d103b3573f465d03d22c4a54ebb52c8fe3d33f6a6264a3977b3a99de30", nftName = "LoopPhunks #108", nftImage = "ipfs://QmaDzs7d7t9WVqr3c8eCsePMe8XRa96yAcgaAGRCFS9vas" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1cbca00e7b9ef6aeee36595a847a283a5cb4f6385a36a32997a4acf41eafa226", nftId = "0xdeb038ba581a1be4ada2c2468d939edb01e0983fbcc4ab6b7aa0c38534f0e51c", nftName = "LoopPhunks #107", nftImage = "ipfs://Qmf1H9if3GEBMSyyTdPLkCy4RGKn3HuzF2xaiZpivLjhEv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x017a080a3999bb23eb73f01fa7506d946075e67537784c507a51a2a78ab2208f", nftId = "0x1d7aa91286c8c3782bcd15477e6df4ac51622b69858a6b376256bb2910958297", nftName = "LoopPhunks #106", nftImage = "ipfs://QmZMvq5z3f9LneQ2uYMQLsAYu1hLo7BqxJNXgFcoVsETLB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x03f05570cc003ff4f8fd92eaa8172f46fb924a916b2eae99f4a07667edca753a", nftId = "0x6a86a1fa6afe02ccb93acf3bfa9d9bc276db55c374b926eed94f94b389fd424e", nftName = "LoopPhunks #105", nftImage = "ipfs://QmTkFdYRFcidSpyV5opNq5a8xfG1pMpNHDBTy93hL4atPf" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x02379a2aa16f3f052f4766b0c6b2642ddb4525d72319c179ca39e4807786b091", nftId = "0x0e8a73097004b573394636391a2c525695b6f63f0cf3fafa825b252e6d29fb89", nftName = "LoopPhunks #104", nftImage = "ipfs://QmRDkfGw69p9ke7BjxsWMGmeavaK32a3RZvX1qQt8jxMxw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2816ca8c5f26805c1ad4e3c01b3d20b266fe82453a2ff5626953b358c79fedda", nftId = "0x2beca2f1bbf8380e1e9ab62df651edb9c4ba9fdc2ecc4b509fc71dc8a0d18512", nftName = "LoopPhunks #103", nftImage = "ipfs://QmRMrLe93D96SyjagHGgME3zWzE6NacsephzsqRC1ZRex5" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2356086e9b466cba3c594227fb03d42530bf54ea17888555c83d62a55f09b3aa", nftId = "0xdb127e2380289d5159b4ba2427fc454a264ba96a9e749b393aa40d47cccb9d0b", nftName = "LoopPhunks #102", nftImage = "ipfs://Qmey39JkGtbxJM5AVaP7kqGo2SBXoyjpZDWxeJzNQt4do6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x16546ae4c211744e5cf927a0631f774f7661936f67d8c32bd7614fb1c62fcf41", nftId = "0xdb3085093837cfaf5cea910ec088f19c80d8864d25dbb0896cf405bc4d8cf9a2", nftName = "LoopPhunks #101", nftImage = "ipfs://QmQPQExjaLUPhSv9kCd6XFmXzk6hfGhEi9tq97xMsfbKzK" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x028f23a66d197396609e928982030b7f61fbec552c9dabf83bf312109cd07be5", nftId = "0x6b9a1aa0a8667e96a8a77783b28a5ae0ac27c813ac23e149341d069c4d1ad9bb", nftName = "LoopPhunks #100", nftImage = "ipfs://QmYsRXuYDUsN515KUnpPFeTSWSAfV9DW2fVhDpL4F8dMkB" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x086c6ae077bf9b4b946deaeca25db188676e89d5f1644a439ff4f1eed263cece", nftId = "0x37ca9d44b388a107a76ab75f19a4e26920e901506762a5773f6b2da09f3b36cf", nftName = "LoopPhunks #099", nftImage = "ipfs://QmbE65ppBBRbBS8P2hvTRcV3sG6aumeeDyB5SmkUNe2sJG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e60ad795bb9fa7918865ded5443c57560e6be81745ffaef6423848744aa8178", nftId = "0xd8c796ed2b86e64a15f0a5c7328091ef7269a82d8ef8b08434c5488e87526075", nftName = "LoopPhunks #098", nftImage = "ipfs://QmYNZHGcSwRYsu243v7wFVreZJLoHnGc3DD88HJXDrHiyX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07126aa38ed24191b6ca386567d0071a3231fd1bc675ede06c03819326d8e9fb", nftId = "0x143938bd421815f11bfd7c14930d0f58ce722726b538837bb4965e36e175faf5", nftName = "LoopPhunks #097", nftImage = "ipfs://QmVQzhHovVzDA8rtCpWzWN5BwuShrWBYyJXtG5mCXpQ8oc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2b01cd7d7b4db25419eaf69267078711572469c1fa01a2425465a8622df1b10d", nftId = "0x9245e93810dc93aebca23262bd21e964b0e3df59f28fa4d76ee892d933b654bc", nftName = "LoopPhunks #096", nftImage = "ipfs://QmTcmQzZYichYYbNce9KZdDTXQfPoqTnWfZLAUJSkGk5dR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x04f324ad84231d26e024b418f467d504c5bebf3577487ccebb242a46f0372095", nftId = "0x8a2507003f5b13150eb36b32d464a6c0be3739d632caccdccc95ecb76fd71939", nftName = "LoopPhunks #095", nftImage = "ipfs://QmXD58FFEbMbo99M2n2vtzwaUnSKshM4dzmKo3WxyLpW7M" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13b90afc78f25a6a852dacb5fd7dce6aceb6081fbca94348b860b7dd651867da", nftId = "0x423611cfa3b8ce0cc0eb43258a49656719170ce2c81ff96e0c62c89675331631", nftName = "LoopPhunks #094", nftImage = "ipfs://QmZQNnmTxmpxV5d9CbqqQvssHqLJcH4Gn5WXkigsvCkPzY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x08b161952cd11819ed894e7714a502697aeecae7fee7d6a4f1c99d7b747b43b2", nftId = "0x52fdb70bdb2ebecd0bee85e8d3bf4fbb701a95c81f6994e8080a71561e6e2d9f", nftName = "LoopPhunks #093", nftImage = "ipfs://QmcDKSGWKisFowyAPX7LrHJLNMMG2Z9ze5bubAAtPAEFoZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0898ca8ef24627bc47e2ab27658a6645bc7814811df682c6bf4cc2d0f7beeb6e", nftId = "0x53bc1fab8d68ca405ba8c75590c7f89c2d21d9779aff906052c5b57d5d802150", nftName = "LoopPhunks #092", nftImage = "ipfs://QmezLb2Bh2c91kgtB5BpeiffgTYkzpghwPzt4S9r6nqsn2" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2c161b66f097a2f8489c5a60e7e1120c9f243c71da4c42613f1ba8df12d4a53e", nftId = "0x03e4a3f588c7e56d152c95b5c58cda27f1a2632ff305cee96ddc9799f750b1e2", nftName = "LoopPhunks #091", nftImage = "ipfs://QmcSsLrkMmAoJkj8WKTT8Gdv5SArAdGwMHobH9Z87m89LG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0369595d95c0305784656b15bc9fa70c0927b7ed0bcb3c0f448801583c56b6e3", nftId = "0x4b5c89220ee95447e4473435ded600a1adebdff71811d323d5e1a8df37adbd2f", nftName = "LoopPhunks #090", nftImage = "ipfs://QmSUTrXk5SP7dv2CBQzFXkjnMHfM7zy5AeANUHok38GWSN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x09b38a6104d359d17c2858bb68636126579f2e48fa0be469292274a54e4aaf53", nftId = "0x420c06602befed06e7a2bb04a173c7be8b4e3860f8481446fdd4b2e1e7e8b73f", nftName = "LoopPhunks #089", nftImage = "ipfs://QmYgN46Mq8hEzBjxL7eEUxAY7gRmPQngAE8byDsM9xikLb" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a37c7ec13b76d175a92edb636e16397b36923f5893c74bd56d76ffa9633e21a", nftId = "0xdf4312d35fce62f6e63b36c37fa3bee1046a63e45710dd4b5a990ccc095a8f77", nftName = "LoopPhunks #088", nftImage = "ipfs://QmTy7RhGo41MQXmdetwtQEDPHT2bn3WgbZT59yWcEqa3s2" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ecf2ef06aee9483f670504d979b2af7e09d95f20df8e97971aa1c4d8a34ad19", nftId = "0x786e317c1d7c432cddf339bbe30e6e1f9fe6e86a89503937b0a1cd929bf42bf8", nftName = "LoopPhunks #087", nftImage = "ipfs://QmU8eno4t84785C5i7F64BNkT3S1cVaQLSvkmbesfVaFVR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0378b1c4fb472b153f2140337279597a4fec5e6627996fdad39f55901566bb99", nftId = "0x61a4e831e1833a8ba1bb61401fa3492fca54bf870ccd05f74b9a260bdafb3bac", nftName = "LoopPhunks #086", nftImage = "ipfs://QmRmXWfDk5YYViFzy5djrWdVh9XQ4MXZbWkYWejAAkFsEw" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0db552ac319cf3ed46ffb2dc82d411c445a8ea7cb8707e78ac2c162aabb41928", nftId = "0xcbc1b5bb1965a339b206e10ddbd5bcb298ccd530f4a36d0caa1593037ef6ff99", nftName = "LoopPhunks #085", nftImage = "ipfs://QmWocJjxrXYGRAGzJNJmaDhKp8PLAdQuhtytSWKBjtEjvQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x16ae49306b012135ac14a35b2d32f8a5f084029f5bd051b7ab32c3178061f2a0", nftId = "0x3739657132baf91d305c075e2ae7c0464caa4e64fc540b48a9b3c3086dfff0a2", nftName = "LoopPhunks #084", nftImage = "ipfs://QmcshygAoihEPCHXSAsjTjsGbEgJLg1LUMoGXsUZaro2Sd" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x14f3ae3cb41aa66992b2ba196a8a42a7d36af40d02e9ed96531ef3da7e89fc51", nftId = "0xa91c7adf0591b9b09fbce86cd110c083316f93e5866c92faca645b585b63539d", nftName = "LoopPhunks #083", nftImage = "ipfs://QmTe1bYHjnWQ2jNTbftL4NRpUzcjaw9Q2gtg9SzUSbRG6x" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0f9ddfbf4d50b93fc5e2145c85c7fbcd68f76c82810ead49370a13d5997aca70", nftId = "0x43ba15d93d8abc352911d14730013e599fb3b4817de6a87bd786cbc7970d9e41", nftName = "LoopPhunks #082", nftImage = "ipfs://QmPwzgUW1aYBBKZeZcdC1yo9KWShDyCEAKh6Z3yLCTVdmZ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1af06eacaf7b26209fbf8f3a88b4b4fe719f7bdeaf9caf31b3e469ebc2747d30", nftId = "0xdba682d2276aaebbcdf44147114d3b979ee8ffe0676e9c31abe8bea58da80455", nftName = "LoopPhunks #081", nftImage = "ipfs://QmdN77mVRqgpmyKNLskyy9ShmNEH2juFuzRZF7prTxttug" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x280752c2cdebd4562c7ef73d9243b1b12a5f4436a89a9bac5cc23da9ff6a1ae9", nftId = "0xe379f7f58e85ee07343191443a724cc2a9ed0b480ff9f74abca2e533d1f520ff", nftName = "LoopPhunks #080", nftImage = "ipfs://QmVt7dmHGo6UWiZmkoKUKWnEqNhmV5KYbhRft6MYarJheS" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c8ebe533ca56939bc59053083846cee20ef7d8f6438a61a67336c3dcfe987bd", nftId = "0x5fb48f5ca3aaf1ab1583500d58e4dfa883cc2af72e9a0bcf11e904d06fa3892f", nftName = "LoopPhunks #079", nftImage = "ipfs://QmP35uBMS5FUvib52Vne2AQfd1dDEgWDYPpMjdegEXaXM2" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1f1d25007265b7af48a0c61d4cbccbd5f54a1d877cb9ba2553acdf9d32f22b0b", nftId = "0x31452d5e2f0d58b0e6e91f4f3f971b3f361d2926615d226d674c0850a3545664", nftName = "LoopPhunks #078", nftImage = "ipfs://QmXpuk7srxKh4S13pmWEgL9jM6WVbWbFEhDb9RfYHcdprU" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13efbfb2a97b8d519f3db7d214af25d60faf97cdceb08acb3ac24803ec78806a", nftId = "0x8d310a54804ceac2f45bcc48343b564ed8d60f96f8787319a74490279208be2c", nftName = "LoopPhunks #077", nftImage = "ipfs://QmdzqojHeYPp9phYrUyJGcYxARvs3D9ZytNBBPaaQa6ecD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ea4da4cdf8fe3538629f7c76800287a9f7e6e4870af16f54dca57c0ac337f36", nftId = "0x22bccb3c6f42f01d7019eb1ef9012228971da43ea299e9ca1997e9b2b0ce8037", nftName = "LoopPhunks #076", nftImage = "ipfs://QmVGkLZeXxmxTPsABiCm8wyC89qVs9K7FnxTbn6uhhrj5j" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x20e57a3c918beae9ddb4271181592385bea434c67b0ef3adae8150ec4b16907e", nftId = "0x40148e9acbfea9c1fc25da96cde5e5ef0e34837fe192bbf5215eaf7c03e942a3", nftName = "LoopPhunks #075", nftImage = "ipfs://QmYPFebRXmZmbg3XaPYwRM9JjBrLprz1wsRbDxMyTAEmPi" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x20273799d2f3ea9ccf20af71dd13445341466a5d11109495df8804b2ce61bc25", nftId = "0x6c491461ec28c1113fda8d8594e2a4e556a86452194648a77dcc455803ad22f9", nftName = "LoopPhunks #074", nftImage = "ipfs://QmSPXkoj3wpaFfkcpzGvk9tcN1BjPUNp9u9qTKwRzd8dXP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x012f1781a38d14fd10e9e48ff9ee15f0ee493bdd42f637b3f10a3a403fe42734", nftId = "0x5821cabb9a3088735b3733b229e5453cfdee963234a017c24a46a45179d60fde", nftName = "LoopPhunks #073", nftImage = "ipfs://QmZXcDD6gatnQwzz5tqXgn4rW8aVeLry5jboGDr7SxoCJa" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x23d7f4e8b7e9527028de732b9a93d5f1c6fe87038329392e9d68b8a245dd14f2", nftId = "0x80826d64b353f4f362eb567a68c3ec42c6cfe209b2546d61d54b2fc5003b1b11", nftName = "LoopPhunks #072", nftImage = "ipfs://QmPSzdhVj1Y45Ut5SHjadPr7raPZHR5SZj6Q5zugEvdLRT" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0553e92cb3b6e7f463c81dc07f3ed5b953426ed42fa34561fc7c0f4e1fd72ea9", nftId = "0x045c92ac105e2e5cb31236f0da5002bb126c0071febff476301686908adb7b33", nftName = "LoopPhunks #071", nftImage = "ipfs://QmYPuf1yGyhL4VTHLRQ2FGq68HqsXLKy9rTEZ4nHCW1XZr" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07c843511b4feb60f57553b213b79f32dcbacbf50e0d4ae0a810492257ccfcf1", nftId = "0x461fdbc4250998d9f24acc6cdeb9bf9dc0bd0aa5446391899f400254a74564d5", nftName = "LoopPhunks #070", nftImage = "ipfs://QmZvzq6tJyPrkSjpHQnnYiFhTf5xoRruvLPXYgFo4T3okx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a55a355a2d7127305a83e807dd79ff0f4d2d54023abae7df1a4b4a704715641", nftId = "0xd868e7e4d8a251ae9bc3baa02d6584f8bb1f1a998a4fd657dbfff73746290e0d", nftName = "LoopPhunks #069", nftImage = "ipfs://QmXXfJhYhreqbrc2rVLTNcYJRjzcdp5T8EdJStQJMCe1PK" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13af22b4ba4472100e3473a288eae91cf767c42c3408d7af03c7a5ad0e3f790d", nftId = "0x31a6bc284d5318e9f52a8c73895a3ff69d145d4bc0f7ee2e61238c59b0041b7f", nftName = "LoopPhunks #068", nftImage = "ipfs://QmQFHFY9vBFN5dZsLLNvXgvgRs3q8WBHxtuVenAciJ6s27" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x015efab30ddcabe38f3f70669689c761127e0559b7149d750119a3e188abaf48", nftId = "0x823a28fdb537d1daf7458a8c8b71f718bc7e95bdcfa0bd09a7b9f6b48c342aa3", nftName = "LoopPhunks #067", nftImage = "ipfs://Qmf7Dgitk42foEmduQwasvC1r9DULKYUUDshwXGz3F5SCR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a87611762c8206d18b4931bfd0092eb821d6dc441db6ea55de2d0a9645626a4", nftId = "0x4a3b86298ebf604b5a6a1658f156747373b77c32edb5fd6bf8b06564e03e7f38", nftName = "LoopPhunks #066", nftImage = "ipfs://QmVNXTYM4UaKFvDYKbuPx7tVxSyRaEEoKPqPScCnkRhaFQ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18c70ef19429ac8ce90f358972257fa7156bf8b64e940d699858f4462729b752", nftId = "0x5ecf7d4fab301f0bb70e015a1e7eb2da013c93367dc778fdd9ae1ff614900163", nftName = "LoopPhunks #065", nftImage = "ipfs://QmThNjH8mAbsBn6rutP42wY72kb5WbCPRBtnwKNsEqMPzL" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x06c19e710e2fe90d1c73e8e477a693f39d83d3f52eb14bded547de8d4d632427", nftId = "0xd502161fb8131a9b9a8ea1ccdbefbc6c91bf2b82f47c1009be2e84b6d926e1e4", nftName = "LoopPhunks #064", nftImage = "ipfs://QmTsgkVmkEdxFiAoUoCwo8ga4GsYE3fMUX76p5HK2VyXBC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13bbf434b244ff7cbba762de2fd60572ca24e03c641e171a5fcc7e63b163c8f8", nftId = "0xd53c5b7b395f6959cb365e0312f340019278ec3c7a4fd229f524ed0dc932c087", nftName = "LoopPhunks #063", nftImage = "ipfs://QmPbVW1akgSysBqBgJ1w8fotj3THTmiD5Xr6BMAs9quYWP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2e187b4a8232c5e0f3e8cb7f939ff15a611cea5279d8b0516455deaa9fbb580d", nftId = "0x0a951abdedde6a69765a0f69a11d3ce3f2f53e2aca0bb55d379d9b0a2b3a2fb5", nftName = "LoopPhunks #062", nftImage = "ipfs://QmW9UN2bZcMtT8EPgoDKJNZFkMQcD8aEqWQBND4K8JW3EG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2be940944f1a5723ad9fa9ac96b925b20444ca07299180874a2f489bbe014a1c", nftId = "0x8043896d67080cb5d5141cd4f93177a1629aa7856bcd3f89ea58602fca5ab383", nftName = "LoopPhunks #061", nftImage = "ipfs://QmYfhbNiPu1psjHKt4xGLRxqtaZoMd7gS6q4YswoaumhNa" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x254ef4912fb7a3fd0090a3232e2aa522dbc1962fc005f1c4f965986fd045bdcf", nftId = "0xfd1403bb7d1cc61d491b12682d1dfb9aa31c4c4ef86b4b7240a93dabc5af2885", nftName = "LoopPhunks #060", nftImage = "ipfs://QmUADEYsQNc7LU2Zkh43zwzLtW6cojJHDwEmzAB5kYH4HA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d5d797143b0c0ae4d468c18bd1a7c8920a2c4cf979c05a059d822502b6e95f9", nftId = "0xaf3e121373efc3674e48db467e4ce9b367c4568327fb4a1cd797c33eca73ad68", nftName = "LoopPhunks #059", nftImage = "ipfs://QmeNdvLCVe5f8EdsFDZs1g6dPNnyZKQAtPT1MEbKTnp7ph" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x236ca39141127c4be1209ba7313b8ddf7283c81ecac12319c455fb254a0f9baf", nftId = "0x3b7da399cbce8df26439ffe552c55555100a69982666e7e97c61d748715cc79d", nftName = "LoopPhunks #058", nftImage = "ipfs://Qmep6aDEE6oNmJdcyqATY8HRadx8w8Rudcc2L5WNtXsfho" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x066e3f2d49852e4bf2502167f082aa63f26a0206f1167ffea3d560965efd63f8", nftId = "0x8de5dd518232da2aeca86bb57ddf1f217e9294dcee8a7bc64313f6b0e1ac8973", nftName = "LoopPhunks #057", nftImage = "ipfs://QmbmH2h5BEoFpwFejQiKSmHVSf5wDhu9B1neN3amQsCUbC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c16bb879f86eaf941228e497a56a8e77633b2a21ca1c36fcefaf3a75e1dd545", nftId = "0x85611c38049e07183fcba5bea128539f743c24c1a7a683a2d02faa2d0fd4dbd8", nftName = "LoopPhunks #056", nftImage = "ipfs://Qmbia3osnFohngNWPUdkvmvMrTVAZ7DTVR6Gic8WkoWZhP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x08fc9611bc9038a89cc7c6713675f887be739bfc5693d0c1b100af26e5e8b959", nftId = "0x8288bea14d9da6902b0494588e6cebbdb344b05463270699f610e5192cdf8daa", nftName = "LoopPhunks #055", nftImage = "ipfs://QmTaMikDAnENzaTJT8oSz8t1Vha4GatGuKab6fGefrf6xv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x18becec879807f6e048af7e79d6401debe86c05c4f6c865daa356dd5955ebe35", nftId = "0x6ce126da7e135ee3aef2664d1e329ee32d7f248ebb9fbc758dc19014ff42c823", nftName = "LoopPhunks #054", nftImage = "ipfs://QmSR6wd1iDUE51BvhVbW3W2nQZUnQ6npaXdAMnoEWC4XKJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x113cda8a48bae0cc8ec87f8de1ea7d2d941f45b8492727d1fa9676a2fda7a4ac", nftId = "0xdbd887ae12edfb7ecd7b452c486cbce260d7f791388ea767b04990eda39a3749", nftName = "LoopPhunks #053", nftImage = "ipfs://Qmc1YYVtKYTv4FYW3f6vkv5bTxqLHevtsFi8eVEGhXnepN" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1add7bd2ed32af775628d8a55b5999545ccaeab7a2d0c195d09bf636ddc9ec17", nftId = "0x13253adcda25cc3bc081de425f6ec56047dc54458a1ce3c39c70bc7e6ed358ac", nftName = "LoopPhunks #052", nftImage = "ipfs://QmfYettjnRMY4Vx32KiQWcdzYojMkvRUtpNtc8ifMf69Cz" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0ae98f722ae62869ab8b08833f49b8dc807a5f90c4af5e55ede9af0ccb33f048", nftId = "0x05064a13c6eaee3d04f3bf50227b21e58f084ccb8731057ed930c0d9c85e6a8b", nftName = "LoopPhunks #051", nftImage = "ipfs://QmSbPxKAScxvB8Q1QQCsLmRHQ4Xofq62Jb7W5mG32JpqmE" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ed5b72270679f7a32d1ca7ae28c8ab7718ff54f1dac682903aa93b853c51daf", nftId = "0x4c8ba0279eef6e2eaa37165b484e58f4197958bd922b221a85cea2cc86898e66", nftName = "LoopPhunks #050", nftImage = "ipfs://QmdsLpAvQ8s8C4DzMYezibEjC1qYwQZtVSaHAKJ3xZQHCu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1cc6bebb8a901dfc78729489cb54ae01edb7bf674617d64a48f05ffc500577de", nftId = "0x9c219d2dc4181f3fa5417e730ca506004177b7bbea784fa3ce12477b467fd84f", nftName = "LoopPhunks #049", nftImage = "ipfs://QmVjD25SsA8Hh9fVHLA2QumVCCvg1fKwga3yk8rhcAcXKC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x062ccaa3ad0d099ac2e3a3ddaed818bd8e2493972d72a79e86a1944fc0173028", nftId = "0x3caaf1dd2887414075429df3330004d81b9fe29858fde93e6ed91e57e996be3b", nftName = "LoopPhunks #048", nftImage = "ipfs://QmXiKayQDPQZpKhy2SZRCpZhDUfPEz81XjQCif6ph613YV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1bf2064f4f868827499b97130abbf5c6951f836612f6ddb702d0ae09a2f6683f", nftId = "0xd366cde59ad43fc02b8b6a9e40f2c3aa42c0337c23f169c75e39b0f1927c9430", nftName = "LoopPhunks #047", nftImage = "ipfs://QmRPcCta36BMqS4wtu1aptVsTkZVepRfCiXUmvZtN14aQx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1ed35deaab057fee79cc6002a61b096fab1ffbb10107303b3741bca60007d2d3", nftId = "0x6d314e382adf4974385ff008f5f363d8a846b09bc2f34d7674e52edc0096ba12", nftName = "LoopPhunks #046", nftImage = "ipfs://QmYoqZo7DuR2Mgv1UaPyaBZhaK3eBf16DbseqzwKsqyrya" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x10a6fc46a20bc7d310af67cb45b38bfc8af29f7ffbede7c3377d78988bbb5efe", nftId = "0xeb2ef9f3d5fa87c6624b24d71a9ddae507072c4fe03db17ccc65373ea2046a0d", nftName = "LoopPhunks #045", nftImage = "ipfs://QmZeC355rjPxbXo6ZYuGpn35Lu9m7P6vxJjbSv1FFinwjq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x26fed08660a84cb5228600905aba62736e9a4ce98733e518b8bddd92b2acca1c", nftId = "0x080be1d58727f68628b1494fe6142bd3c69e40c17e1a01ad893843102fe88bf2", nftName = "LoopPhunks #044", nftImage = "ipfs://QmcyXHBtTPj7fNFLAaNbsK4MNkhZMVrDWnV4LtGMhHXuf1" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24639edf3685e7780060b97247a234741662b44490ea56e32d129d3e6f0b91ea", nftId = "0x8e0413ad514960b6d62f47158e3faa5da93f904aa1980114189e484b2714e60f", nftName = "LoopPhunks #043", nftImage = "ipfs://QmRKKav7ug4BoxxxKivzYPuxUGegmmo8egAapGwNjvcuvV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0438e39ff86e1fd533fc0316a060b8f9f6678d836610fc18a0d40216616f7495", nftId = "0x114e004296f11fe27156b5dcdbb22a8d7b616e25cf24c35b4b6689dc799d7cb9", nftName = "LoopPhunks #042", nftImage = "ipfs://QmUVVogk6PcQ6cbpgVRTrb7iLZWGUGYWY1Rx1MzBUPWJrX" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x13f96d49fe7486a6c281fececaf0fade120df8bf789ed178235e201792f19942", nftId = "0x0c5c064391f3e5a856e0e10c58ab7976e4be4c092cdfde56b5707bbddf68976a", nftName = "LoopPhunks #041", nftImage = "ipfs://Qmb1GJTeYHQA8ueTAoVY9G2KNY6T2sqFaCTSgSUY7GjSLv" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2da4c1e3fd25a33383c3a8386b2155c472e196e8cb0cf3eecba794606ec7207a", nftId = "0x078164767a382fc58ab6673b5cd1cd429c0a22679a8772bcdbebcc6ccd94272b", nftName = "LoopPhunks #040", nftImage = "ipfs://Qmcb7ixMACUuF5bAj3jan3CAcGeRLvEfu1cHNyhuNBrqP9" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00403b1e4b5e7d0109987f227f92a7a3c943996e919cffb873d5970fed94cfd0", nftId = "0xf4611d3d0e7030722428348c165ae02e6b04dd26c4a1cd96631e5a2de5e014af", nftName = "LoopPhunks #039", nftImage = "ipfs://Qmdx3nXemWHdMq92CqdPdU4JJrqgo7fJ75ak2nmpLVWAZ6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0e79ca58ba2fcdc2dcf1758aec6195fe6d01daf255ee7df0aba80705c51288c2", nftId = "0x9df06a360bb2f1d33584fdbd841ed46697f13228ecbb1db6a1b33c2019edf08d", nftName = "LoopPhunks #038", nftImage = "ipfs://QmZun6XMWLfSYp3LpXYgNy3yNyh7mNFajw8HfZ6qtPb1z8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x28c4be6a4848f8c09147e914c1f4ee31f13529782c419dcffdbf4e568a6e0fa2", nftId = "0xd5196590d9e0bac438de61889a3ba3893884b624e9f375d0211885e25d2f6219", nftName = "LoopPhunks #037", nftImage = "ipfs://QmP6K4VkoQxCtVyw5FbwyVmYZwGbenkpTVHateiM5Aoh41" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x151ce02219219ae6431c45c59a9a0fa359bb9cb947c2e83638034951391c6d84", nftId = "0xbf9c9e5693233155ea4ae59f216e7420bf1416ec99e831fc0b8cc4fdc0bd659b", nftName = "LoopPhunks #036", nftImage = "ipfs://QmUc3tnQQChHL5xWte8vMADDX9L5H7NTpZ8V1CzdYfw6hJ" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x05f5dc67c71895f72e2e37ba4833dd517f4b490c7591a4443dc4ed3367d0e838", nftId = "0x26391ef42c7ac8a6134f8c87db191647bb833360d638f7009679b2836b2bbd74", nftName = "LoopPhunks #035", nftImage = "ipfs://Qmb47aZMQhqbU9HDTMxwPv1X9mfibm6FrXXUyudj3wKWz7" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x09f88f076951629689f9a7b3a88612abc713d856d27837eeae889fa141264c48", nftId = "0xd48704b25b752f8eae2e3e8b28706d091938729ec47f674ba7e4cef27c24b171", nftName = "LoopPhunks #034", nftImage = "ipfs://QmTL2kARv9N4ckmBDmvu9LyDmYrZvqJvogcu15kcJkaetY" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x04ebaf299919d1aca331987d20f7d0b485b939f7851941d3c7780f792c5c1af6", nftId = "0x1902b0f806f88419633612ead09476a11e0e5c5f5eed829298902a351aa073b7", nftName = "LoopPhunks #033", nftImage = "ipfs://QmeJmZidubLit3gL2RMwNAwh9tiCPi9eio8bQ7jBNJaaRT" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1185141816c3fdde466a49e4d18141ef42a14c5643b0e3fb8090e8296bdd04a9", nftId = "0x5254bb098116bb920777a47bf84bd706db008d6ef4fb9130899ca5b6251db58a", nftName = "LoopPhunks #032", nftImage = "ipfs://QmSXxc4Ga1pyEhohmHuXXQTXN6t1daqb3QS8ECkHTMVJNx" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1213fd1490e1a14c3e8c7ecd2a7ac95d129d90c07447512773985d2e6084a6d3", nftId = "0xe51c80545c35c5f4cfbb446210c5a32cab2d247de6f788cb04622bc7ca1f4f79", nftName = "LoopPhunks #031", nftImage = "ipfs://Qmf566huutTngssurJxgA13Jdrp24uKGwkSvuKx7jV6QyD" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1218b8ceabc66e815ebd05833715605aeb67f099995d7d429dea8bcf0ad78069", nftId = "0x63b1e184cc5662a1abcbc19792a82b3a2613d583c3eca5f646c7fae9fb0f81ad", nftName = "LoopPhunks #030", nftImage = "ipfs://QmeHyXrVUy6SPTyhigkmwJc7DSkb9Cpqw6eJoET1HP35Nu" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0404c126eecc17a848f504b2df0239e87db160e928a9b89d677b4ebe603392b3", nftId = "0x1cab428931c5aede7e8d399bd79dd38e8e42f9b61ac64f6e78b37132cab68959", nftName = "LoopPhunks #029", nftImage = "ipfs://QmQBSjsUWGQzAXBVo6rLbss4GYFA8teXQcuWsXJRxaXGDR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x11a2b15e4afa9785e6ebddc974390d3419acdb30a60e2571be023259b8ae8d17", nftId = "0x4765931db01b203c6c8a5cdd8d0257d887174d3122ba2077e84fd124d8415de2", nftName = "LoopPhunks #028", nftImage = "ipfs://QmVi73PAcVJe74LXhJvgXn34fmydPUSLTj3sK4PSRBFiT6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0e1610cb6461886c5ef76e828bc0e1ce69537342fbf15d71d7f0f526e8dc336e", nftId = "0x863b3acc619f01a92bc44a06151665ad47ec192d4b05eea116d94c03ed9ad822", nftName = "LoopPhunks #027", nftImage = "ipfs://QmTbhbebpim2yXjJhRTCYMqNg6mxFAXcrqwPeDV8MNVjKc" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0b22a4c20c391e4029a9df9e83b71384729b772d43d2e87da61b088ed4a01f5c", nftId = "0xb90254ac268fd083883e0fa50a88409779a3ed515afc33da2f08f5213a15dc5d", nftName = "LoopPhunks #026", nftImage = "ipfs://QmXcEbivuviNVUrT5ya3z3DBLV8scXUsXymjjXc9GThKGR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x01f693f192f3411e1bfc55fe0f67e0d523698e9e7e16b55a8a35dd5ee7022e02", nftId = "0xda875c28d88746a3ccba7b7a3d0dcbd96d09142218b8a363bcbbb3c4a38882f8", nftName = "LoopPhunks #025", nftImage = "ipfs://QmUJFB1HyiNkmpecXHg5Vc9RP64Hkp4xPBtyzD1r3svBzV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2f3486a0570e9b35c0ac0a4c317b29e9c01a04798c1a117cb7a8c88c1ca8fa1a", nftId = "0x934f263ae584f2da07637238493cf6a40989c1cb39ea8f9849213faa1046116a", nftName = "LoopPhunks #024", nftImage = "ipfs://QmSb81U3iJACudazUtnhM7JcdPvNZvB4LY1GS6PHbnrA2a" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x29e1b7d7e76010fb5bf4375a2fa78580a3296e281d5a2d148481b522c936c5b0", nftId = "0xd7f8d45e759619c6bcb50a237daf619b84084edea5ac6252f9b9fee07123dc4e", nftName = "LoopPhunks #023", nftImage = "ipfs://QmefUeEFmornPaeCwK6Fz3fLMAT2SX2jVegAKgbXJnVGf6" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x24ad4a7dbe50fe11620c1aa92484eae60c2468f52e234939d445e3289d14b383", nftId = "0x9b095d5e9c522cf6034865ef5f66c1b82d0369c877766a6b9edf26680aa40241", nftName = "LoopPhunks #022", nftImage = "ipfs://QmbZ63R8JjyjQBDPmysjDt4nYb2sgDaYRoFRnQHeszW75G" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x07780e9babbab6c8b5af6daa9d84159038d4e370f8264755bc8bb9a648405e58", nftId = "0xed1bff33cfc7f34158b1a7c691e5ccf875c0aa40fd7a54e7e4e94c34a84ad5da", nftName = "LoopPhunks #021", nftImage = "ipfs://QmRXjof3txL44m6VypeP4yg8WkovWrvwUHNu1NZkNPJ2GP" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0081ca9ec08245408e5b4b0315f3d23104eff2e13162f9cb828f2a8d6859d2ce", nftId = "0x26e25a06ce479c782b60ce65cad33618e23a3e23e9489fd5120eeebce1d51615", nftName = "LoopPhunks #020", nftImage = "ipfs://QmWZ1pmUkFLPUCYZo7psjaCgogKYuGmnoBXFtnLcPhVgiA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x26491253381324988cd475a12c91d87dce4ec181e73fdaef101db16e5b1616ff", nftId = "0xf714907b9e45ac0f83875c18283c286ab1b81185ef1c9606cb88c64639f08872", nftName = "LoopPhunks #019", nftImage = "ipfs://QmdEYkZiUByHFppg6ctk86ZE8XvdD57M2V5yzxAL9qngx8" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00ffd5f1415045a417931e6d39f160da2add9a1e0240d23615565a6e73229e22", nftId = "0x722cfe33f191343badcc37486fcff3a1d0b0ed8519c3c95399ac788f8ef9b88b", nftName = "LoopPhunks #018", nftImage = "ipfs://QmazKWQ1A1FCeKhNaNryay89kZHwxCxr4AtwCZfS7ogTky" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x00d57844ff48e5024dd5b5e95d8e96f8667acb4489ad2f29a79fa5c91188982e", nftId = "0x759cac07fd64e4f854e622c6584c13c83144005b4e33386b4499bdeeff371938", nftName = "LoopPhunks #016", nftImage = "ipfs://QmWQyLsj3DPMswjk1TvHEknYS7mR1CkDuUyYYmE5yfRkBV" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x21a5f50c5eb301740796b499bb639faf888c909c75170104f9cbf330364238eb", nftId = "0x81d769622e354440218249bb3903f0bd199ea000cecf370eb8c938f639e09bd0", nftName = "LoopPhunks #015", nftImage = "ipfs://Qmd1tLVZX7BdfYJ6bpAQkfvxWpuW6Fi4n13ezphWaCJa6M" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0fd2739b3619af33441fde5f2499bd2a8925486241dc0f2f1c22e39c50c40a34", nftId = "0x75d9b877d4a1b8e58d0dc4969c879907b9659e7ec5fd84e66c22d0463ad1d9a3", nftName = "LoopPhunks #014", nftImage = "ipfs://QmTScQAjQwNoqbRFgQH3KYsi5xSdqmrzW7AMEUQ8ewaebj" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0a29bf08cd2082c7179c54ba7f60b1fe26e1f238c33b28599298e42e2788a30c", nftId = "0x58ec01327c65a75d5f08b0fb1654015edab5bab975870c68c673d8aaf41e44b9", nftName = "LoopPhunks #013", nftImage = "ipfs://QmS3YnSCJFuqTpSYfgjqXQHWvL7ioEyGXWngQT6WtP2iHj" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22b3698ce4efdc3a4003f48e3dac5cfa91e143251c2779e2ab7dd4727fb7424d", nftId = "0x52033a7a9b6c4e6879570f65776960610f70e71d6960493225550777e543dc31", nftName = "LoopPhunks #012", nftImage = "ipfs://QmeQcivNnsSZ5uKmU5HtY53wEE5UUew9q3PBbVD87kfEYC" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0bc357cf1da11a5ec841a02ce52bd6f263e8316bf432843da6bf28c4f00726f3", nftId = "0x2706941f11b3ea5d6b5f09726e510ed4c764b93faf5fe76c32b74ce22be3bc0d", nftName = "LoopPhunks #011", nftImage = "ipfs://QmNm5TfH6NszatneeeQ8JfspdQPczrzA8LNPhcYQoqgUWa" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2d3b2bfac6278154fcfbcb95dafdb9f6115e48dd3c5309a43ec403a03d1bd5b8", nftId = "0xff810a065749d8d38d10407dfc4d9e8d3d088daea60fd65fa39b95ce293105c3", nftName = "LoopPhunks #010", nftImage = "ipfs://QmUMhZX28vwCYxkinuuHJBdZjWgumt6VEM7Pm6L8dVYNJA" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1d97b6dbb65828818065043c510b1982b9249227c320362b5a27e3db700006bd", nftId = "0x923912d62c9cb423493bf06ffba49084ebbc28c37e5e73160fbbb835cf15acc9", nftName = "LoopPhunks #009", nftImage = "ipfs://QmbryziYz9HAW3zxdtZqBipE4J4NFHhBv6Q9Xc9rTg4ria" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2a877622f52f4a2b4dd51757c33c64e44d07066dc588ca5fb284febd0be66930", nftId = "0x678efd2e200f93f3942e5900b79092d14cb82282c3a86cbb91530910a1f8cd75", nftName = "LoopPhunks #008", nftImage = "ipfs://QmW8j9KtprFpwbpRNvnENkY1RqwQoLx2tQEQSZ9XZEtuBq" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0c488fefd72b105b356a679cea8685b2f6d0e1dc775db1724e83f6074c4880ea", nftId = "0x88aed924b1f58de01f561450929917c34c891dcf97529ab1f94a7ece78524381", nftName = "LoopPhunks #007", nftImage = "ipfs://QmUFXAywD7qbw34VYn5P2UnoVwMXhA1Ymzh6Zq4H35qgbT" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2ce5f4ab0c681f9fc33adfad69b890771fa748886922628f7a596e4b8a12c509", nftId = "0xfa949d6b4fa0209bb363ea025f9ee36a0bf6ad921afa8cf9d55f8a6c7535f303", nftName = "LoopPhunks #006", nftImage = "ipfs://QmQU1R4eCfn3FLmLktB81maLdqpwB7f99idrERaqg6ApPR" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x22846520544259570e80833b90c9bc2ef53b32745ecf75cafbccc5625965f773", nftId = "0x4392b34fa75f55d96753dcb4d872d3242883665cece0e205e228477aaa0abd75", nftName = "LoopPhunks #005", nftImage = "ipfs://QmNvw4dDay74HZWQEX12P5X8Ctr6AuNU7LJB4GzUWmh9fp" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x0cb2aa94e5f4bf7d1514bfe3b6822799fb1b21a0597413013e6639c4d9781eaf", nftId = "0xa00cb7309ee6365c887afb44b5ad786fff736eaebcff633f8b9955b726d5e8e6", nftName = "LoopPhunks #004", nftImage = "ipfs://QmbjjtfhixDXQP7Ergj8mHsvD7Z25SEUTo9u6hUDonormG" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x1bae06787efa0a4713019276e8bd415dec1c5e5efd00aeaf3770ca793d97c161", nftId = "0x314aaf3bd4d1abb4062f47fc4001121dc5c34bf92871ebead8771463f861d2a6", nftName = "LoopPhunks #003", nftImage = "ipfs://QmdVS3w3uy1T3AneiW2Bnpz7fDCurkCm8W7SAU8g7jCh4Q" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x06afb46dd6968b14ed3bda429065dd0a4a34fce0765425f9d6d917d4815bd682", nftId = "0xf2b3aff6ad35e6e9c2cb383a2d0de12180524df6cc304b1df057358d81ffd7c2", nftName = "LoopPhunks #002", nftImage = "ipfs://Qmetg2RSaoTbHxZ8UFvfrDbkbaWJqoSd2eKiWwK1rJVaxs" });
            loopPhunksInformation.Add(new LoopPhunksInformation() { nftData = "0x2364efd141c329297a8a7ab0152fecf4090f6819c303945bc59fc94afd3c22c4", nftId = "0xd7c5954abbe2611e497dcb67476b96fd14912ace44a6ef461560fb079de73418", nftName = "LoopPhunks #001", nftImage = "ipfs://QmQfCMywCSHXdcgAsDcjahGrXY6pVfj6JnRjsWKZzZh8nB" });
            return loopPhunksInformation;
        }
    }
}





































































































































































































































































































































































































































































































































































































































































































































































