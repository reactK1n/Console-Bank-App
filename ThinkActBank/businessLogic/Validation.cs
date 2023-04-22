using System;
using System.Globalization;
using System.Linq;
using ThinkActBank.businessLogic;

namespace ThinkActBank
{
    public class Validation
    {
        public static bool IsNullOrEmptyOrWhiteSpace(string info)
        {
            return string.IsNullOrEmpty(info.Trim());
        }
        public static bool IsLessThanOneAndGreaterThanEleven(string info)
        {
            int infoLength = info.Length;
            return infoLength <= 0 || infoLength >= 11 ? true : false;
        }   
        public static bool IsBtwOneAndSix(string info)
        {
            return info == "1" || info == "2" || info == "3" || info == "4" || info == "5" || info == "6" ? true : false;
        }

        public static bool IsLessThanOneAndGreaterThanTwenty(string info)
        {
            int infoLength = info.Length;
            return infoLength <= 0 || infoLength >= 21 ? true : false;
        }
        public static bool IsOneOrTwoOrThree(string info)
        {
            
            return info == "1" || info == "2" || info == "3" ? true : false;
        }     
        public static bool IsOneOrTwo(string info)
        {
            
            return info == "1" || info == "2" ? true : false;
        }     
        
        public static bool NotGreaterThanTen(string info)
        {
            int infoLength = info.Length;

            return infoLength <= 10 ? true : false;
        }
        public static bool NotGreaterThanFive(string info)
        {
            int infoLength = info.Length;

            return infoLength <= 5 ? true : false;
        }
        public static bool IncludeAlphabeth(string info)
        {
            bool itContains = true;
            string alphabeth = "abcdefghijklmnopqrstuvwxyz";
            char[] beth = alphabeth.ToCharArray();

            foreach (var letter in info)
            {
                itContains = beth.Contains(letter);
                if (itContains == true)
                {
                    break;
                }
            }

            return itContains ? true : false;
        }
        public static bool IncludeNumber(string info)
        {
            bool itContains = true;
            string alphabeth = "1234567890";
            char[] beth = alphabeth.ToCharArray();

            foreach (var letter in info)
            {
                itContains = beth.Contains(letter);
                if (itContains == true)
                {
                    break;
                }
            }

            return itContains ? true : false;
        }
        public static bool IncludeSign(string info)
        {
            bool itContains = true;
            string alphabeth = "@#!&$*_-";
            char[] beth = alphabeth.ToCharArray();

            foreach (var letter in info)
            {
                itContains = beth.Contains(letter);
                if (itContains == true)
                {
                    break;
                }
            }

            return itContains ? true : false;
        }
        public static bool IncludeCapitalLetter(string info)
        {
            bool itContains = true;
            string alphabeth = "abcdefghijklmnopqrstuvwxyz";
            char[] beth = alphabeth.ToUpper().ToCharArray();

            foreach (var letter in info)
            {
                itContains = beth.Contains(letter);
                if (itContains == true)
                {
                    break;
                }
            }

            return itContains ? true : false;
        }

        public static bool IsStrong(string info)
        {

            return IncludeNumber(info) == true
                   && IncludeAlphabeth(info) == true
                   && IncludeCapitalLetter(info) == true
                   && IncludeSign(info) == true ? true : false;
        }


        public static bool EndWithAtGmailDotCom(string info)
        {
            int infoLength = info.Length;
            string lastinfo = info.Substring(infoLength - 10);
            return lastinfo.ToLower().ToString() == "@gmail.com" ? true : false;
        }

        public static bool IsExist(string info)
        {
            bool userName = true;
            var accountInfo = Authentication.Users;
            foreach (var acc in accountInfo)
            {
                userName = acc.Username.Equals(info);
                if (userName == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool MoreThanTwenty(string info)
        {
            return info.Length >= 21 ? true : false;
        }

        public static string ChangeFirstLetterToUpper(string info)
        {
            string myInfo = info.Replace(info[0].ToString(), info[0].ToString().ToUpper());
            return myInfo;

        }

        public static string ChangeTheRestLetterToLower(string info)
        {
            string myInfo = info.Replace(info.Substring(1), info.Substring(1).ToLower());
            return myInfo;
        }

        public static bool TransactionIndexOutOfRange(string index)
        {
            TransactionLogic.cloneList();
            TransactionLogic.IdIsNotCurrent();
            return Int32.Parse(index) >= 1 || Int32.Parse(index) <= TransactionLogic.DisplayCurrentUserList.Count ? false : true;
        }

        public static bool ANumber(string index)
        {
            bool checker = int.TryParse(index, out int result);
            return checker;
        }

        public static bool TransactionLogicCheckingIsNotCorrect(string index)
        {
            return IsNullOrEmptyOrWhiteSpace(index) || !ANumber(index) || TransactionIndexOutOfRange(index);
        }
        public static bool ChooseIsInvalid(string index)
        {
            return IsNullOrEmptyOrWhiteSpace(index) || !ANumber(index) || TransactionIndexOutOfRange(index);
        }

        public static bool FullNameIsInValid(string info)
        {
            return IsNullOrEmptyOrWhiteSpace(info) || IsLessThanOneAndGreaterThanTwenty(info) || ANumber(info)
                ? true
                : false;
        }


        public static bool UserNameExistOrIsInvalid(string info)
        {
            return IsNullOrEmptyOrWhiteSpace(info) || IsLessThanOneAndGreaterThanEleven(info) || IsExist(info) ? true : false;
        }
               
        public static bool PasswordIsNotStrong(string info)
        {
            return IsNullOrEmptyOrWhiteSpace(info) || NotGreaterThanFive(info) || !IsStrong(info) ? true : false;
        }

        public static string GenerateAccountNumber()
        {
            Random getNumber = new Random();
            var getAccountNumber1 = getNumber.Next(128, 993);
            var getAccountNumber2 = getNumber.Next(114, 979);
            return $"02{getAccountNumber1}{getAccountNumber2}30";
        }

    }

}
