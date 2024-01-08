using System;
using System.Collections.Generic;
using System.Text;

namespace ARMS_BLL.Functions
{
    public class DateFunctions
    {
        public static bool IsDate(string vDate)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(vDate);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string PadZero(int iValue)
        {
            if (iValue < 10)
            {
                return "0" + Convert.ToString(iValue);
            }
            else
            {
                return Convert.ToString(iValue);
            }

        }

        public static string FormatDateDDMMYYYY(string vDate)
        {
            string bMonth, bDay, bYear;
            string rValue = "";
            DateTime bDate;
            if (IsDate(vDate) == true)
            {
                bDate = Convert.ToDateTime(vDate);
                bMonth = PadZero(bDate.Month);
                bDay = PadZero(bDate.Day);
                bYear = PadZero(bDate.Year);
                rValue = bDay + "/" + bMonth + "/" + bYear;
            }
            return rValue;
        }
        public static string FormatDateMMDDYYYY(string vDate)
        {
            string bMonth, bDay, bYear;
            string rValue = "";
            DateTime bDate;
            if (IsDate(vDate) == true)
            {
                bDate = Convert.ToDateTime(vDate);
                bMonth = PadZero(bDate.Month);
                bDay = PadZero(bDate.Day);
                bYear = PadZero(bDate.Year);
                rValue = bMonth + "/" + bDay + "/" + bYear;
            }
            return rValue;
        }
        public static string FormatDateDDMMMYYYY(string vDate)
        {
            string bMonth, bDay, bYear;
            string rValue = "";
            DateTime bDate;
            if (IsDate(vDate) == true)
            {
                bDate = Convert.ToDateTime(vDate);
                bMonth = GetMonthName(Convert.ToInt32(bDate.Month));
                bDay = PadZero(bDate.Day);
                bYear = PadZero(bDate.Year);
                rValue = bDay + "/" + bMonth + "/" + bYear;
            }
            return rValue;
        }
        private static string GetMonthName(int iMonth)
        {
            string sMonth = "";
            switch (iMonth)
            {
                case 1:
                    sMonth = "Jan";
                    break;
                case 2:
                    sMonth = "Feb";
                    break;
                case 3:
                    sMonth = "Mar";
                    break;
                case 4:
                    sMonth = "Apr";
                    break;
                case 5:
                    sMonth = "May";
                    break;
                case 6:
                    sMonth = "Jun";
                    break;
                case 7:
                    sMonth = "Jul";
                    break;
                case 8:
                    sMonth = "Aug";
                    break;
                case 9:
                    sMonth = "Sep";
                    break;
                case 10:
                    sMonth = "Oct";
                    break;
                case 11:
                    sMonth = "Nov";
                    break;
                case 12:
                    sMonth = "Dec";
                    break;


            }
            return sMonth;
        }
        //public static string FormatDateDDMMYYYY(string vDate)
        //{
        //    string bMonth, bDay, bYear;
        //    string rValue = "";
        //    DateTime bDate;
        //    if (IsDate(vDate) == true)
        //    {
        //        bDate = Convert.ToDateTime(vDate);
        //        bMonth = Convert.ToString(bDate.Month);
        //        bDay = Convert.ToString(bDate.Day);
        //        bYear = Convert.ToString(bDate.Year);
        //        rValue = bDay + "/" + bMonth + "/" + bYear;
        //    }
        //    return rValue;
        //}

        //public static string FormatDateMMDDYYYY(string vDate)
        //{
        //    string bMonth, bDay, bYear;
        //    string rValue = "";
        //    DateTime bDate;
        //    if (IsDate(vDate) == true)
        //    {
        //        bDate = Convert.ToDateTime(vDate);
        //        bMonth = Convert.ToString(bDate.Month);
        //        bDay = Convert.ToString(bDate.Day);
        //        bYear = Convert.ToString(bDate.Year);
        //        rValue = bMonth + "/" + bDay + "/" + bYear;
        //    }
        //    return rValue;
        //}

        public static string SetDateFormatForDB(DateTime dtDate)
        {
            string sDay, sMonth, sYear;
            string rValue = "";
            sDay = PadZero(dtDate.Day);
            sMonth = PadZero(dtDate.Month);
            sYear = PadZero(dtDate.Year);
            rValue = sYear + "-" + sMonth + "-" + sDay;
            return rValue;

        }
        //Convert.ToDateTime(hs["ComplaintDate"]).Day+" "+Convert.ToDateTime(hs["ComplaintDate"]).ToString("MMM")+" "+Convert.ToDateTime(hs["ComplaintDate"]).Year
        public static string GetDateFormatForApplication(DateTime dtDate)
        {
            string sDay, sMonthName, sYear;
            string rValue = "";
            sDay = PadZero(dtDate.Day);
            sMonthName = dtDate.ToString("MMM");
            sYear = PadZero(dtDate.Year);
            rValue = sDay + " " + sMonthName + " " + sYear;
            return rValue;

        }
        public static string DisplayFormatToDB(string vDate)
        {
            string DisplayFormat;
            if (vDate.Length != 10)
            {
                return "DBNull.Value";
            }
            DisplayFormat = GetDisplayFormat();

            if (DisplayFormat == "DD/MM/YYYY")
            {
                //return vDate.Substring(3, 2) + "/" + vDate.Substring(0, 2) + "/" + vDate.Substring(6, 4);
                return vDate.Substring(6, 4) + "-" + vDate.Substring(3, 2) + "-" + vDate.Substring(0, 2);
            }
            if (DisplayFormat == "MM/DD/YYYY")
            {
                return vDate.Substring(6, 4) + "-" + vDate.Substring(0, 2) + "-" + vDate.Substring(3, 2);
            }
            if (DisplayFormat == "YYYY/MM/DD")
            {
                return vDate.Substring(0, 4) + "-" + vDate.Substring(6, 2) + "-" + vDate.Substring(8, 2);
            }
            return "DBNull.Value";
        }
        public static string DisplayFormatFromDB(string vDate)
        {
            string DisplayFormat;
            if (vDate.Length != 10)
            {
                return "DBNull.Value";
            }
            DisplayFormat = GetDisplayFormat();

            if (DisplayFormat == "DD/MM/YYYY")
            {
                return vDate.Substring(3, 2) + "/" + vDate.Substring(0, 2) + "/" + vDate.Substring(6, 4);
                //return vDate.Substring(6, 4) + "-" + vDate.Substring(3, 2) + "-" + vDate.Substring(0, 2);
            }
            if (DisplayFormat == "MM/DD/YYYY")
            {
                return vDate.Substring(6, 4) + "-" + vDate.Substring(0, 2) + "-" + vDate.Substring(3, 2);
            }
            if (DisplayFormat == "YYYY/MM/DD")
            {
                return vDate.Substring(0, 4) + "-" + vDate.Substring(6, 2) + "-" + vDate.Substring(8, 2);
            }
            return "DBNull.Value";
        }
        public static string GetDisplayFormat()
        {
            return "DD/MM/YYYY"; 
            //Configuration.AppSettings("DateDisplayFormat");
        }

        public static bool ValidDisplayFormat(String vDate)
        {
            string DisplayFormat, DisplayFormatToDB = "";
            if (vDate.Length != 10)
            {
                return false;
            }
            DisplayFormat = GetDisplayFormat();

            if (DisplayFormat == "DD/MM/YYYY")
            {
                DisplayFormatToDB = vDate.Substring(6, 4) + "-" + vDate.Substring(3, 2) + "-" + vDate.Substring(0, 2);
            }
            if (DisplayFormat == "MM/DD/YYYY")
            {
                DisplayFormatToDB = vDate.Substring(6, 4) + "-" + vDate.Substring(0, 2) + "-" + vDate.Substring(3, 2);
            }
            if (DisplayFormat == "YYYY/MM/DD")
            {
                DisplayFormatToDB = vDate.Substring(0, 4) + "-" + vDate.Substring(6, 2) + "-" + vDate.Substring(8, 2);
            }
            if (IsDate(DisplayFormatToDB))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getDatetypefrom(string dtvalue)
        {
            //string type : dd/mm/yyyy
            string result = "";
            result = dtvalue.Substring(6, 4) + "-" + dtvalue.Substring(3, 2) + "-" + dtvalue.Substring(0, 2);
            return result;
        }

    }
}
