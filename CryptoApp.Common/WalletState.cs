using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Common
{
    public enum WalletState
    {
        CurrencyNotExist,
        WalletExists,
        WalletNotExist,
        Ok,
        Error
    }
}
