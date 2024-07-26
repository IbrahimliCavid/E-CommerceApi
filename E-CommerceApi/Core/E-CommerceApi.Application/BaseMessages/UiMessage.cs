using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Infrastructure.BaseMessages
{
    public static class UiMessage
    {
        public static string SuccessAddedMessage(string propName = "Məlumat")
        {
            return $"{propName} uğurla əlavə olundu.";
        }

        public static string SuccessUpdatedMessage(string propName = "Məlumat")
        {
            return $"{propName} uğurla redaktə olundu.";
        }

        public static string SuccessDeletedMessage(string propName = "Məlumat")
        {
            return $"{propName} uğurla silindi.";
        }

        public static string ErrorAddedMessage(string propName = "Məlumat")
        {
            return $"{propName} əlavə olunmadı!";
        }

        public static string ErrorUpdatedMessage(string propName = "Məlumat")
        {
            return $"{propName} redaktə olunmadı!";
        }

        public static string ErrorDeletedMessage(string propName = "Məlumat")
        {
            return $"{propName} silinmədi!";
        }


        public static string MinLengthMessage(string propName, int count)
        {
            return $"{propName} {count} simvoldan kiçik ola bilməz!";
        }

        public static string MaxLengthMessage(string propName, int count)
        {
            return $"{propName} {count} simvoldan böyük ola bilməz!";
        }

        public static string NotEmptyMessage(string propName)
        {
            return $"{propName} boş ola bilməz!";
        }

        public static string MaxValueMessage(string propName, int count)
        {
            return $"{propName} {count} dəyərindən böyük ola bilməz!";
        } 

        public static string MinValueMessage(string propName, int count)
        {
            return $"{propName} {count} dəyərində kiçik ola bilməz!";
        }


    }
}
