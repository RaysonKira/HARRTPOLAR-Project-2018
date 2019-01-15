 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for placesDetail
/// </summary>
public class placesDetail
{
    public placesDetail(string FormattedAddressClass, string PhoneNumberClass, string PhotoClass, string PhotoCreditClass, string WebsiteClass)
    {
        FormattedAddress = FormattedAddressClass;
        PhoneNumber = PhoneNumberClass;
        Photo = PhotoClass;
        PhotoCredit = PhotoCreditClass;
        Website = WebsiteClass;
    }

    public string FormattedAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Photo { get; set; }
    public string PhotoCredit { get; set; }
    public string Website { get; set; }
}