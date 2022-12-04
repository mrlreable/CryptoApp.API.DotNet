using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Common
{
    public enum UserAssetState
    {
        NotEnoughBalance,
        WalletNotExist,
        StockNotExist,
        Ok,
        InvalidAmount,
        UserAssetNotExist,
        Error
    }
}
