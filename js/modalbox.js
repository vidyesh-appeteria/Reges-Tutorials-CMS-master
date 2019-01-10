 $(document).ready(function()
 {
         var DocHeight  = $(window).height();
         var scrollHeight = $("form").height();
         //alert("**" + DocHeight + "__" + scrollHeight);
         if(DocHeight + 2 < scrollHeight )
         {
            $('#footer').css('position','relative');
            
         }
           $('#footer').show();  

       });



/* This script and many more are available free online at
The JavaScript Source!! http://javascript.internet.com
Created by: Steve Chipman | http://slayeroffice.com/ */

// constants to define the title of the alert and button text.
var WINDOW_TITLE = "";
var CONFIRM_BUTTON_NO_TEXT = "No";
var CONFIRM_BUTTON_YES_TEXT = "Yes";
var ALERT_BUTTON_OK_TEXT = "Ok";

// over-ride the confirm method only if this a newer browser.
// Older browser will see standard alerts
var CONFIRM_RESULT = false;
if(document.getElementById) {

 window.confirm = function(txt,btnId) 
 {   
     createCustomConfirm(txt, btnId);
     $(this).parent('div').find('button:contains("No")').focus()
 }

  window.alert = function (txt)
  {
      createCustomAlert(txt, "true");
  }
}

///================================================Confirm============================================///

function createCustomConfirm(txt, btnId) {
   
  // shortcut reference to the document object
  d = document;

  // if the modalContainer object already exists in the DOM, bail out.
  if(d.getElementById("modalContainer"));

  // create the modalContainer div as a child of the BODY element
  mObj = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
  mObj.id = "modalContainer";
   // make sure its as tall as it needs to be to overlay all the content on the page
  mObj.style.height = document.documentElement.scrollHeight + "px";

  // create the DIV that will be the alert 
  alertObj = mObj.appendChild(d.createElement("div"));
  alertObj.id = "confirmBox";
  // MSIE doesnt treat position:fixed correctly, so this compensates for positioning the alert
  if(d.all && !window.opera) alertObj.style.top = document.documentElement.scrollTop + "px";
  // center the alert box
  alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth)/2 + "px";

  // create an H1 element as the title bar
  h1 = alertObj.appendChild(d.createElement("h1"));
  h1.appendChild(d.createTextNode(WINDOW_TITLE));

  // create a paragraph element to contain the txt argument
  msg = alertObj.appendChild(d.createElement("p"));
  msg.innerHTML = txt;
  
  btnObj=alertObj.appendChild(d.createElement("div"));
  btnObj.id="btnBox";
  
  // create an anchor element to use as the     ation button.
  btn = btnObj.appendChild(d.createElement("a"));
  btn.id = "yesBtn";
  btn.appendChild(d.createTextNode(CONFIRM_BUTTON_YES_TEXT));
  btn.href = "#";
// for jquery  eval($('a,input').filter('[id="'+btnId+'"]').attr('href'));
  btn.onclick = function ()
  {
      removeCustomAlert();
      if (btnId != null)
      {
          var radiobtn = btnId;
          while (btnId.indexOf('_') != -1) { btnId = btnId.replace('_', '$'); }
          ShowLoading();


          // alert($.clientID(radiobtn).attr('type'));
          if ($('[id$="radiobtn"]').attr('type') == "radio")
          {
              $('[id$="radiobtn"]').attr('checked', true);
          }
          CONFIRM_RESULT = true;
          __doPostBack(btnId, '');
      }
  }

   
  // create an anchor element to use as the confirmation button.
  btn = btnObj.appendChild(d.createElement("a"));
  btn.id = "noBtn";
  btn.appendChild(d.createTextNode(CONFIRM_BUTTON_NO_TEXT));
  btn.href = "#";
  btn.focus()
  // set up the onclick event to remove the alert when the anchor is clicked
  btn.onclick = function () { removeCustomConfirm(); CONFIRM_RESULT = false; return false; }

}


// removes the custom alert from the DOM
function removeCustomConfirm() {
  document.getElementsByTagName("body")[0].removeChild(document.getElementById("modalContainer"));
}


///================================================Alert============================================///


// over-ride the alert method only if this a newer browser.

function createCustomAlert(txt, mode)
{
 
  // shortcut reference to the document object
  d = document;

  // if the modalContainer object already exists in the DOM, bail out.
  if(d.getElementById("modalContainer"));

  // create the modalContainer div as a child of the BODY element
  mObj = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
  mObj.id = "modalContainer";
   // make sure its as tall as it needs to be to overlay all the content on the page
  mObj.style.height = document.documentElement.scrollHeight + "px";

  // create the DIV that will be the alert 
  alertObj = mObj.appendChild(d.createElement("div"));
  if (mode === "true")
  {
      alertObj.id = "alertBox"
  }
  else
      alertObj.id = "alertBoxError"
 
  // MSIE doesnt treat position:fixed correctly, so this compensates for positioning the alert
  if(d.all && !window.opera) alertObj.style.top = document.documentElement.scrollTop + "px";
  // center the alert box
  alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth)/2 + "px";

  // create an H1 element as the title bar
  h1 = alertObj.appendChild(d.createElement("h1"));
  h1.appendChild(d.createTextNode(WINDOW_TITLE));

  // create a paragraph element to contain the txt argument
  msg = alertObj.appendChild(d.createElement("p"));
  msg.innerHTML = txt;
  
  btnObj=alertObj.appendChild(d.createElement("div"));
  btnObj.id="btnBox";
  
  // create an anchor element to use as the confirmation button.
  btn = btnObj.appendChild(d.createElement("a"));
  btn.id = "okBtn";
  btn.appendChild(d.createTextNode(ALERT_BUTTON_OK_TEXT));
  btn.href = "#";
 
  // set up the onclick event to remove the alert when the anchor is clicked
  btn.onclick = function() { removeCustomAlert();return false; }
  
}

// removes the custom alert from the DOM
function removeCustomAlert() {
  document.getElementsByTagName("body")[0].removeChild(document.getElementById("modalContainer"));
}


//=================================================== Loader =========================================//

function ShowLoading() {
    var h = $(document).height();
    $('.ModalLoad').css('margin-top', (h - 100) / 2 + 'px');
    $('.ModalPopUp').height(h);
    $('.ModalPopUp').show();
    $(this).parent('div').find('noBtn:contains("No")').focus()
    return true;
}

function HideLoading() {
    $('.ModalPopUp').hide();
}






