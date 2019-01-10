function NoAccessAction() {
    alert('Sorry,You do not have access to this module.');
    window.location.href = '../Admin/DashboardNew.aspx';
}

function alertwithRedirct(msg, url) {
    alert(msg);
    window.location.href = url;
}

function Convdate(curdate) {
    var splitdate = [];
    splitdate = curdate.split('/');
    var dd, mm, yy;
    mm = parseInt(splitdate[0]);
    dd = parseInt(splitdate[1]);
    yy = parseInt(splitdate[2]);
    return new Date(yy, mm - 1, dd);
}

function fnTime(inputText) {
    var strTime = /([01][0-9]|2[0-3]):[0-5][0-9]/g;
    if (inputText.value.match(strTime)) {
        return true;
    }
    else {
        alert("Please enter time in the following format 24 hh:mm.");
        return false;
    }
}

function CheckValidateEmail(element) {
    var email = element.value;
    if (email != "") {
        if (email.search(/^[a-zA-Z]+([_\.-]?[a-zA-Z0-9]+)*@[a-zA-Z0-9]+([\.-]?[a-zA-Z0-9]+)*(\.[a-zA-Z]{2,4})+$/) == -1) {
            element.value = "";
            alert("Please enter a valid email address.");
        }
    }
}

function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
}

function AlphabetsWithSpace(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode==32)
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}

function AlphabetsWithSpaceHyphen(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32 || charCode == 45)
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function NumberandAlpha(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode > 47 && charCode < 58))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }

//function ValidateEmail(inputText) {
//            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
//            if (inputText.value.match(mailformat)) {
//                document.frm1.txtEmail.focus();
//                return true;
//            }
//            else {
//                alert("You have entered an invalid email address!");
//                document.frm1.txtMail.focus();
//                return false;
//            }
//}

        function ValidateEmail(inputText, ID) {
            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if (inputText.value.match(mailformat)) {
              //  document.frm1.txtEmail.focus();
                return true;
            }
            else {
                $("#" + ID).css('border', '1px solid red');
                $("#" + ID).val("");
                //alert("You have entered an invalid email address!");
                //document.frm1.txtMail.focus();
                return false;
            }
        }
function phonenumber(inputText) {
    var phoneno = /^\d{10}$/;
    if (inputtxt.value.match(phoneno)) {
        return true;
    }
    else {
        alert("Not a valid Phone Number");
        return false;
    }
}
function checkdateformat(element, chkfuture, chkpast) {

    //validatefromdate();
    var chkformat = element.value;
    var currentyear = parseInt(new Date().getFullYear() + 35);

    if (chkformat != "") {

        var parts = chkformat.split("/");
        var day = parseInt(parts[1], 10);
        var month = parseInt(parts[0], 10);
        var year = parseInt(parts[2], 10);

        var monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

        // Adjust for leap years
        if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
            monthLength[1] = 29;

        if (!/^\d{1,2}\/\d{1,2}\/\d{4}$/.test(chkformat)) {
            alert("Please enter date in the format mm/dd/yyyy.");
            element.value = "";
        }
        else if (year < 1000 || year > currentyear || month <= 0 || month > 12 || day <= 0 || day >= monthLength[month - 1]) {
            // alert("Year should be greater than 1000 and less than 3000 digit");
            alert("Please enter date in the format mm/dd/yyyy.");
            element.value = "";
        }

        var today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()).getTime();
        var selected = new Date(chkformat).getTime();

        if (chkfuture == 'future') {
            if (today < selected) {
                alert("This is a future date. If this is not correct, please change the date you have entered.");
            }
        }

        if (chkpast == 'past') {
            if (today > selected) {
                alert("This date has passed. If this is not correct, please change the date you have entered.");
            }
        }
    }
}

function SetTarget() {
    document.forms[0].target = "_blank";
}

function isValidDate(dateString) {
    // First check for the pattern
    if (!/^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString))
        alert("Please enter date in the format mm/dd/yyyy.");
    return false;

    // Parse the date parts to integers
    var parts = dateString.split("/");
    var day = parseInt(parts[1], 10);
    var month = parseInt(parts[0], 10);
    var year = parseInt(parts[2], 10);

    // Check the ranges of month and year
    if (year < 1000 || year > 3000 || month == 0 || month > 12) {
        if (month <= 0 || month > 12) {
            alert("Month should be greater than 0 and less than 12 digit");
            return false;
        }
        if (year < 1000 || year > 3000) {
            alert("Year should be greater than 1000 and less than 3000 digit");
            return false;
        }
    }
    var monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    // Adjust for leap years
    if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
        monthLength[1] = 29;

    if (day <= 0 || day >= monthLength[month - 1]) {
        alert("Digit for day should not exceed " + monthLength[month - 1])
        return false;
    }

    // Check the range of the day
    return day > 0 && day <= monthLength[month - 1];
};

function validatefromdate() {
    var no = isValidDate('11/5/2015');
}


//function FormatPhoneNumber_old(element) {
//    number = element.value;
//    if (number.length >= 3) {
//        //  Make sure there's a leading open-paren.
//        number = insertCharAtIfNotExists(number,'-', 3);
//    }

//    //  Make sure there's a close-paren following area code.
//    number = insertCharAtIfNotExists(number, '-', 7);

//    number = checkNumberLength(number, 12);

//    element.value = number;
//}

function FormatPhoneNumber(element) {
    number = element.value;
    if (number.length >= 3) {
        //  Make sure there's a leading open-paren.
        number = insertCharAtIfNotExists(number, '(', 0);
    }

    //  Make sure there's a close-paren following area code.
    number = insertCharAtIfNotExists(number, ')', 4);
    //  Make sure there's a space following close-paren
    number = insertCharAtIfNotExists(number, ' ', 5);
    //  Make sure there's a hyphen following the prefix.
    number = insertCharAtIfNotExists(number, '-', 9);

    number = checkNumberLength(number, 14);

    element.value = number;
}
function FormatPinNumber(element) {
    number = element.value;
    if (number.length >= 5) {
        //  Make sure there's a leading open-paren.
        number = insertCharAtIfNotExists(number, '', 0);
    }

    //  Make sure there's a close-paren following area code.
    number = insertCharAtIfNotExists(number, '', 4);
    //  Make sure there's a space following close-paren
    number = insertCharAtIfNotExists(number, '-', 5);
    //  Make sure there's a hyphen following the prefix.
    number = insertCharAtIfNotExists(number, '', 10);

    number = checkNumberLength(number, 11);

    element.value = number;
}

function FormatLodgeno(element) {
    if (element.value.length > 0) {
        number = '0000' + element.value;
        element.value = number.substring(number.length - 5);
    }
}

function FormatSSN(element) {
    number = element.value;
    if (number.length >= 3) {
        number = insertCharAtIfNotExists(number, '-', 3);
    }
    number = insertCharAtIfNotExists(number, '-', 6);

    number = checkNumberLength(number, 11);

    element.value = number;
}

function FormatTime(element, evt) {
    number = element.value;

    var key = evt.keyCode || evt.charCode;

    if (key == 8 || key == 46)
        return false;

    if (number.length == 0) {
        return;
    }
    if (number.length >= 2) {
        number = insertCharAtIfNotExists(number, ':', 2);
    }
    number = insertCharAtIfNotExists(number, ':', 5);

    number = checkNumberLength(number, 5);
    check = checkTime(number);
    if (check == false) {
        element.value = '';
    }
    else {
        element.value = number;
    }
}

function FormatDATE(element, evt) {

    var charCode = (evt.which) ? evt.which : evt.keyCode

    number = element.value
    //var regex = new RegExp('/^[\*|-|\+|=|<|>|!|&|,|_|/]$/');
    //if (regex.source.match(element.value.substring(element.value.length - 1))) {
    //    element.value = element.value.substring(0, element.value.length - 1)
    //    number = element.value
    //}
    if (charCode != 8) {
        //   alert(charCode);
        if (number.length > 2) {
            number = insertCharAtIfNotExists(number, '/', 2);
        }
        number = insertCharAtIfNotExists(number, '/', 5);
        number = checkNumberLength(number, 10);

        element.value = number;
    }
}



function insertCharAt(string, character, at) {
    if (string.length < at)
        return string;
    else if (string.length == at)
        return string + character;
    else
        return string.substring(0, at) + character + string.substring(at);
}

function insertCharAtIfNotExists(string, character, at) {
    if (string.length >= at)
        if (string.charAt(at) != character)
            string = insertCharAt(string, character, at);

    return string;
}

function checkNumberLength(string, maxlength) {
    if (string.length > maxlength)
        return string.substring(0, maxlength);
    else
        return string;
}


function checkTime(time) {
    debugger;
    var hrs = time.substring(0, 2);
    var minutes = time.substring(3, 5);
    if (hrs < 24 && minutes < 60)
        return true;
    else
        return false;
}

function isNumberKeyOrDelete(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode > 31 && (charCode < 46 || charCode > 57 || charCode == 8))
        return false;
    return true;
}

function isNumberKeyOrDot(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode > 31 && (charCode < 46 || charCode > 57 || charCode == 47))
        return false;
    return true;
}



function isNumberKeyOrSpaceandPlus(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode > 31 && (charCode < 46 || charCode > 57 || charCode == 47 || charCode == 32 || charCode == 107 || charCode == 187))
        return false;
    return true;
}

function getObject(id) {
    var obj = document.getElementById(id);
    return obj;
}

function moveItem(inFromBox, inToBox) {
    var inFromBox = getObject(inFromBox);
    var inToBox = getObject(inToBox);
    var selectedValue = "";
    var selectedName = "";
    var countopt = 0;
    for (i = 0; i < inFromBox.length; i++) {

        if (inFromBox[i].selected == true) {
            var TOLength = inToBox.length
            var OptVal = new Option(inFromBox[i].text, inFromBox[i].value);
            OptVal.title = inFromBox[i].title != '' ? inFromBox[i].title : '';
            inToBox[inToBox.length] = OptVal;
            countopt = countopt + 1;
        }
    }
    for (i = inFromBox.options.length - 1; i >= 0; i--) {
        if (inFromBox.options[i].selected)
            inFromBox.remove(i);
    }
    if (countopt == 0) {
        alert("Please select options");
    }

}
function moveall(inFromBox, inToBox) {
    var inFromBox = getObject(inFromBox);
    var inToBox = getObject(inToBox);
    j = inToBox.length;
    for (i = 0; i < inFromBox.length; i++) {
        var OptVal = new Option(inFromBox[i].text, inFromBox[i].value);
        OptVal.title = inFromBox[i].title != '' ? inFromBox[i].title : '';
        inToBox[j] = OptVal;
        j = j + 1;
    }
    inFromBox.length = 0;
}

function GetlistBoxItems(ListName) {
    var str = '';
    var inToBoxd = getObject(ListName);
    for (i = 0; i < inToBoxd.length; i++) {
        if (str == '')
            str = inToBoxd[i].value;
        else
            str = str + ',' + inToBoxd[i].value;
    }

    return str;
}

function GetlistBoxItemsText(ListName) {
    var str = '';
    var inToBoxd = getObject(ListName);
    for (i = 0; i < inToBoxd.length; i++) {
        if (str == '')
            str = inToBoxd[i].text;
        else
            str = str + ',' + inToBoxd[i].text;
    }

    return str;
}

function GetlistBoxItemsPipeSeperated(ListName) {
    debugger;
    var str = '';
    var inToBoxd = getObject(ListName);
    for (i = 0; i < inToBoxd.length; i++) {
        if (str == '')
            str = inToBoxd[i].value;
        else
            str = str + '|' + inToBoxd[i].value;
    }

    return str;
}

function GetValue(id) {
    var obj = getObject(id);
    if (obj != null)
        return obj.value;
    else
        return "";
}

function SetValue(id, value) {
    var obj = getObject(id);
    if (obj != null)
        obj.value = value;
}

function ShowDiv(id) {
    var obj = getObject(id);
    if (obj != null)
        obj.style.display = "";
}

function HideDiv(id) {
    var obj = getObject(id);
    if (obj != null)
        obj.style.display = "none";
}

function CheckEmailExist(typename, id, txtboxid, spanid) {
    var value = JSON.stringify({ typename: typename, value: GetValue(txtboxid), id: GetValue(id) });
    $.ajax({
        type: "POST",
        url: "../Services/GetSettings.aspx/ValidateData", //use absolute link if possible     
        data: value,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d) {
                SetValue(txtboxid, '');
                ShowDiv(spanid);
            }
            else {
                HideDiv(spanid);
            }
        }
    });
}


$(document).ready(function () {
    $(".tabs-menu a").click(function (event) {
        event.preventDefault();
        $(this).parent().addClass("current");
        $(this).parent().siblings().removeClass("current");
        var tab = $(this).attr("href");
        // $(this).parent().parent().parent().find(".tab-content").not(tab).css("display", "none");
        $(this).parent().parent().parent().find(".tab-content").not(tab).css("display", "none");
        $(tab).fadeIn();
    });
})

function validateFloatKeyPress(el, evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57)) {
        return false;
    }

    if (charCode == 46 && el.value.indexOf(".") !== -1) {
        return false;
    }

    return true;
}



var txt = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz,'
var num = '1234567890'
var dec = '.'
var spcarAll = '~!#$%^&*()+'
var SpaceAndPlus = ' +'



function alpha(e, allow) {
    var k;
    k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
    return (allow.indexOf(String.fromCharCode(k)) != -1);

}

function isnumberkeycomma(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 44 || (charCode > 44 && charCode < 48) || charCode > 57))
        return false;
    return true;
}

function isKeyForDate(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode == 8 || charCode == 46)
        return true;
    return false;
}


//$('[id$="txtDate"]').blur(function () {
//    if ($(this).val().search(/^([0-9]|0[1-9]|1[012])\/([0-9]|0[1-9]|[12][0-9]|3[01])\/(19|20|21)\d\d$/) == -1) {
//        $('[id$="txtDate"]').addClass('required-field');
//    }
//    else {
//        $('[id$="txtDate"]').removeClass('required-field');
//    }
//});