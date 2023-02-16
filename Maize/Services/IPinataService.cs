using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maize.Models;

namespace Maize.Services
{
    public interface IPinataService
    {
        Task<PinataResponseData?> SubmitPin(string jwt, byte[] fileBytes, string fileName, bool wrapDirectory = false, string pinataMetadata = null);
        Task<string> TestAuthentication(string jwt);
    }
}
