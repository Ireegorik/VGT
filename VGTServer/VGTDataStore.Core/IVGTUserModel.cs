using System;
using System.Collections.Generic;
using System.Text;

namespace VGTDataStore.Core
{
    public interface IVGTUserModel
    {
        string Login { get; set; }

        string Email { get; set; }
    }
}
