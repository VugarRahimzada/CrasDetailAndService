using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BaseMessage
{
    public class ValidationBaseMessage
    {
        public const string NOT_EMPTY ="Boş buraxıla bilməz!";
        public const string MIN_LENGHT = "Minimum 3 simvol tələb olunur!";
        public const string MAX_LENGHT_50 = "Maximum 50 simvol tələb olunur!";
        public const string MAX_LENGHT_200 = "Maximum 200 simvol tələb olunur!";
        public const string MAX_LENGHT_1000 = "Maximum 1000 simvol tələb olunur!";
        public const string EMAIL = "Düzgün email daxil edin!";
        public const string PHONE_NUMBER = "Düzgün Telefon Nömrəsi daxil edin!";
        public const string NEGATİVE = "0 dan Az Ola Bilməz!";
    }
}
