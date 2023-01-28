using Maize.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.Text;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;


namespace Maize.Helpers
{
    public class ExcelFile
    {
        public static async Task CreateExcelFile(Font font, List<OwnerAndTotal> ownerAndTotal, List<OwnerAndAmount> ownerAndAmount, Collection userCollection, 
            CollectionInformation userCollectionInformation, List<NftHolder> collectionNftHolders,
            StringBuilder collectionNftInformation, string excelFileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var fileNameLocation = new FileInfo($@".\OutputFiles\{excelFileName}");

            await SaveExcelFile(userCollection, ownerAndTotal, ownerAndAmount, userCollectionInformation, collectionNftHolders, collectionNftInformation, fileNameLocation);

        }
        private static async Task SaveExcelFile(Collection userCollection, List<OwnerAndTotal> ownerAndTotal, List<OwnerAndAmount> ownerAndAmount, CollectionInformation userCollectionInformation, 
            List<NftHolder> collectionNftHolders, StringBuilder collectionNftInformation, FileInfo file)
        {
            DeleteIfExists(file);

            using (var package = new ExcelPackage(file))
            {
                var format = new ExcelTextFormat();
                format.Delimiter = '~';
                var ws = package.Workbook.Worksheets.Add($"- {userCollection.name} -");
                CreateHeader(ws, userCollection, userCollectionInformation, collectionNftHolders, ownerAndTotal, ownerAndAmount);

                var range = ws.Cells["A6"].LoadFromText(collectionNftInformation.ToString(), format, TableStyles.Medium1, true);

                ws.Cells.AutoFitColumns();
                ws.Column(2).Width = 35;

                // =========================================================================================
                var amountChart = new AmountChart();
                foreach (var data in ownerAndTotal)
                {
                    if (data.total == 1)
                    {
                        amountChart.amount1++;
                    }
                    else if (data.total >= 2 && data.total <= 5)
                    {
                        amountChart.amount2To5++;
                    }
                    else if (data.total >= 6 && data.total <= 10)
                    {
                        amountChart.amount6To10++;
                    }
                    else if (data.total >= 11 && data.total <= 19)
                    {
                        amountChart.amount11To19++;
                    }
                    else if (data.total >= 20)
                    {
                        amountChart.amount20Plus++;
                    }
                }

                var ws2 = package.Workbook.Worksheets.Add("Analytics");
                CreateHeader(ws2, userCollection, userCollectionInformation, collectionNftHolders, ownerAndTotal, ownerAndAmount);
                range = ws2.Cells["A6"].LoadFromCollection(ownerAndTotal.OrderByDescending(x => x.total), true, TableStyles.Medium1);
                ws2.Cells["E6"].Value = $"Owner Distribution [{ownerAndTotal.Count()}]";
                ws2.Cells["E7"].Value = "1 item";
                ws2.Cells["E8"].Value = "2-5 items";
                ws2.Cells["E9"].Value = "6-10 items";
                ws2.Cells["E10"].Value = "11-19 items";
                ws2.Cells["E11"].Value = "20+ items";
                ws2.Cells["F7"].Value = amountChart.amount1;
                ws2.Cells["F8"].Value = amountChart.amount2To5;
                ws2.Cells["F9"].Value = amountChart.amount6To10;
                ws2.Cells["F10"].Value = amountChart.amount11To19;
                ws2.Cells["F11"].Value = amountChart.amount20Plus;
                ws2.Cells["G7"].Value = $"{(Convert.ToDecimal(amountChart.amount1) / Convert.ToDecimal(ownerAndTotal.Count()) * 100).ToString("0.00")}%";
                ws2.Cells["G8"].Value = $"{(Convert.ToDecimal(amountChart.amount2To5) / Convert.ToDecimal(ownerAndTotal.Count()) * 100).ToString("0.00")}%";
                ws2.Cells["G9"].Value = $"{(Convert.ToDecimal(amountChart.amount6To10) / Convert.ToDecimal(ownerAndTotal.Count()) * 100).ToString("0.00")}%";
                ws2.Cells["G10"].Value = $"{(Convert.ToDecimal(amountChart.amount11To19) / Convert.ToDecimal(ownerAndTotal.Count()) * 100).ToString("0.00")}%";
                ws2.Cells["G11"].Value = $"{(Convert.ToDecimal(amountChart.amount20Plus) / Convert.ToDecimal(ownerAndTotal.Count()) * 100).ToString("0.00")}%";

                ws2.Cells.AutoFitColumns();
                ws.Column(2).Width = 35;

                // ============================================================================================
                var nftsDistinct = ownerAndAmount.DistinctBy(x => x.nftName);
                var counter = 0;
                foreach (var item in nftsDistinct)
                {
                    if (item.nftName != null)
                    {
                        if (ownerAndAmount.Where(x=>x.nftName == item.nftName).Count() > 1)
                        {
                            item.nftName += counter;
                            counter++;
                        }
                        ws = package.Workbook.Worksheets.Add($"{item.nftName.Replace(" ","")}");
                        CreateHeader(ws, userCollection, userCollectionInformation, collectionNftHolders, ownerAndTotal, ownerAndAmount);
                        range = ws.Cells["A6"].LoadFromCollection(ownerAndAmount.Where(x => x.nftName == item.nftName).OrderByDescending(x => x.ownerAmountOwned), true, TableStyles.Medium1);
                        ws.Cells.AutoFitColumns();
                        ws.Column(2).Width = 35;
                    }
                }

                await package.SaveAsync();
            }
        }
        private static void CreateHeader(ExcelWorksheet ws, Collection userCollection, CollectionInformation userCollectionInformation, List<NftHolder> collectionNftHolders, List<OwnerAndTotal> ownerAndTotal, List<OwnerAndAmount> ownerAndAmount)
        {
            //var pic = ws.Drawings.AddPicture("MyPhoto", new FileInfo("C:\\Code\\JokerBurnMeme.jpg"));
            //pic.SetPosition(2, 0, 1, 0);
            ws.Cells["A1"].Value = userCollection.name;
            ws.Row(1).Style.Font.Size = 24;
            ws.Row(1).Style.Font.Bold = true;

            ExcelRange inLine = ws.Cells["A2"];
            inLine.IsRichText = true;
            ExcelRichText text1 = inLine.RichText.Add("By ");
            ExcelRichText text2 = inLine.RichText.Add(userCollection.owner);
            text2.Bold = true;
            ws.Row(2).Style.Font.Size = 16;

            inLine = ws.Cells["A3"];
            inLine.IsRichText = true;
            text1 = inLine.RichText.Add("Items ");
            text2 = inLine.RichText.Add(ownerAndAmount.DistinctBy(x=>x.nftData).Count().ToString());
            text2.Bold = true;
            ExcelRichText text3 = inLine.RichText.Add(" · ");
            text1 = inLine.RichText.Add("Nfts ");
            text1.Bold = false;
            text2 = inLine.RichText.Add(ownerAndTotal.Sum(x=>x.total).ToString());
            text2.Bold = true;
            text3 = inLine.RichText.Add(" · ");
            text1 = inLine.RichText.Add("Created ");
            text1.Bold = false;
            text2 = inLine.RichText.Add(Utils.GetUnixTime(long.Parse(userCollection.times.createdAt.ToString())).ToShortDateString().ToString());
            text2.Bold = true;
            //text3 = inLine.RichText.Add(" · ");
            //text1 = inLine.RichText.Add("Creator Fee ");
            //text1.Bold = false;
            //text2 = inLine.RichText.Add($"{userCollectionInformation.nftTokenInfos.First().royaltyPercentage}%");
            //text2.Bold = true;

            ws.Cells["A4"].Value = $"{userCollection.description}";

            inLine = ws.Cells["A5"];
            inLine.IsRichText = true;
            //text1 = inLine.RichText.Add($"{Decimal.Round(1000 / 1000000000000000000000m)}K LRC ");
            //text1.Bold = true;
            //text2 = inLine.RichText.Add("total volume · ");
            //text2.Bold = false;
            //text1 = inLine.RichText.Add($"{1000 / 1000000000000000000m} LRC ");
            //text1.Bold = true;
            //text2 = inLine.RichText.Add("floor price · ");
            //text2.Bold = false;
            text1 = inLine.RichText.Add($"{ownerAndTotal.Count()} ");
            text1.Bold = true;
            text2 = inLine.RichText.Add("owners · ");
            text2.Bold = false;
            text1 = inLine.RichText.Add($"{((Convert.ToDecimal(ownerAndTotal.Count()) / Convert.ToDecimal(ownerAndTotal.Sum(x=>x.total))) * 100).ToString("0.00")}% ");
            text1.Bold = true;
            text2 = inLine.RichText.Add("unique owners");
            text2.Bold = false;

            ws.Cells["A1:C1"].Merge = true;
            ws.Cells["A2:B2"].Merge = true;
            ws.Cells["A3:E3"].Merge = true;
            ws.Cells["A4:N4"].Merge = true;
            ws.Cells["A5:G5"].Merge = true;
        }

        private static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
