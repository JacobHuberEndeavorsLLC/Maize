using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maize.Models;
using static Maize.Services.NftStorageService;

namespace Maize.Services
{
    public interface INftStorageService
    {
        Task<PinataResponseData?> SubmitPin(string nftStorageApiKey, byte[] fileBytes, string fileName);
        Task<NFTStorageUploadResponse> UploadDataFromFile(Font font, string path, string jwt);
    }
}
